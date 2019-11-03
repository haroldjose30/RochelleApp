using System;
using Domain.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace WebApi.Infrastructure.Jwt
{
    public static class JsonWebTokenExtensions
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

        }
    }
}

/*
Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyIyMDE5MTEwMyAwMDoxNTozNkFkbWluQWRtaW4iLCIyMDE5MTEwMyAwMDoxNTozNkFkbWluQWRtaW4iXSwianRpIjoiMDkzY2RmM2E1NjYzNGEyZjk0MzVkMTI2ZmY2OTViMGQiLCJuYmYiOjE1NzI3NjY3NTYsImV4cCI6MTU3Mjc2Njg3NiwiaWF0IjoxNTcyNzY2NzU2LCJpc3MiOiJIYXJvbGQgSm9zZSIsImF1ZCI6IkFwcCBXZWIgQWRtaW4gVXNlcnMifQ.BYpf2sblrQGH5-ID-i4zJrEsjYnPxn1aHPuuQH7o9Zz96W1V423PqiputLF5ImCI-WDeYYLPPyVavCuWuFjZtLm8if61fXgMXNXmGnn5Y5wR-m35ujtsRGMr9M1CtSg8ShJGZZR_Q62AEC36aAJ0EWy_2SN0dfyr-jOtZxcJwY4YRwPZZepdxKN5JzlJFp4veWOBpkEBhKxA_9nAjFkgDTqYMHbDV959aNPIkQnPXoGKBLPCqngPP4TmwcYl0MntzUXJN64PalWOO4obhZQE8DIBwOvejyJ_NBJfEnqw4ji2UC17jdJz_7HWfIM96M_hg04pUZxoOxIpszOccTyKmw
*/