using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PartAssessment.Application;
//using MediatR;

namespace PartAssessment.Api
{
    public static class DependancyResolver
    {
        public static IServiceCollection AddApiDependecies(this IServiceCollection services)
        {
            //add dependencies
            services.AddMediatR(typeof(EntryPoint));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters();
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole",
                     policy => policy.RequireRole("Admin"));
            });

            return services;
        }
    }
}