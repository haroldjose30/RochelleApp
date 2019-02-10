namespace WebApi.Controllers
{
    /*
    [Route("api/[controller]")]
    public class LoginController: ControllerBase
    {
        IServiceGeneric<User> service;
        public LoginController(IServiceGeneric<User> _service)
        {
            service = _service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<Object> Post(
           [FromBody]User user,
           [FromServices]SigningConfigurations signingConfigurations,
           [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool CredencialsValid = false;
            if (user != null && !String.IsNullOrWhiteSpace(user.Id))
            {
                var usuarioBase = await service.GetByIdAsync(user.Id);
                CredencialsValid = (usuarioBase != null &&
                    user.Id == usuarioBase.Id &&
                    user.Password == usuarioBase.Password);
            }

            if (CredencialsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Id, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Id)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
    */
}