using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using ApplicationBusiness.Authentication;
using Domain.Identity;
using FluentValidation.Internal;
using Framework.Core.Models;
using Framework.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Controllers.Base;
using WebApi.Infrastructure.Jwt;

namespace WebApi.Controllers
{
    
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;
      
        public AuthenticationController(
            IAuthenticationService authenticationService,
            INotificationHandler<DomainNotification> notificationHandler): base(notificationHandler)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateToken(
            [FromBody] LoginViewModel model,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = await _authenticationService.Login(model.Login, model.Password);
            NotifyError(user);
            model.User = user;
            if (!IsValidOperation())
                return Response(model);
         
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Id.ToString(), "Login"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString())
                }
            );

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate +
                                     TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securityToken);

            model.AccessToken = token;
            return Response(model);
        }

        /*
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // User claim for write customers data
                await _userManager.AddClaimAsync(user, new Claim("Customers", "Write"));

                await _signInManager.SignInAsync(user, false);
                _logger.LogInformation(3, "User created a new account with password.");
                return Response(model);
            }

            AddIdentityErrors(result);
            return Response(model);
        }
        */
    }
    

    public class LoginViewModel:Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        
        public string AccessToken { get; set; }

        public User User { get; set; }
    }
}