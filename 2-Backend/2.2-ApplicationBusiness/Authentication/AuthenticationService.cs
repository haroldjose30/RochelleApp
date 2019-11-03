using System;
using System.Threading.Tasks;
using Domain.Identity;
using FluentValidation.Results;
using Framework.Core.Interfaces;
using Infra.Data.Repositories;
using MediatR;

namespace ApplicationBusiness.Authentication
{
    public class AuthenticationService: IAuthenticationService
    {

        private readonly IUserRepository _repository;
        private readonly IMediatorHandler _bus;
        private readonly IMediator mediator;
        private readonly IServiceProvider _serviceProvider;

        public AuthenticationService(IUserRepository repository, 
                              IMediatorHandler bus,
                              IMediator mediator,
                              IServiceProvider serviceProvider)
        {
            _repository = repository;
            _bus = bus;
            this.mediator = mediator;
            this._serviceProvider = serviceProvider;
        }
        
        public async Task<User> Login(string login, string password)
        {
            //todo: passar para mediator
            var user = await _repository.GetByLogin(login);

            if (user == null)
            {
                user = new User();
                user.GetValidationResult().Errors.Add(new ValidationFailure("login","Usuário ou senha inválido!"));
                return user;
            }
            
            if (!user.Login.Equals(login) && user.Password.Equals(password))
                user.GetValidationResult().Errors.Add(new ValidationFailure("login","Usuário ou senha inválido!"));

            //change password to protect user
            user.ProtectPassword();
            
            return user;
        }
       
    }




}
