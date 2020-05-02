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
        //todo: harold - change to mediator
        
        private readonly IUserGenericRepositoryEntity genericRepositoryEntity;
        private readonly IMediatorHandler _bus;
        private readonly IMediator mediator;
        private readonly IServiceProvider _serviceProvider;

        public AuthenticationService(IUserGenericRepositoryEntity genericRepositoryEntity, 
                              IMediatorHandler bus,
                              IMediator mediator,
                              IServiceProvider serviceProvider)
        {
            this.genericRepositoryEntity = genericRepositoryEntity;
            _bus = bus;
            this.mediator = mediator;
            this._serviceProvider = serviceProvider;
        }
        
        public async Task<User> Login(string login, string password)
        {
            //todo: passar para mediator
            var user = await genericRepositoryEntity.GetByLogin(login);

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
