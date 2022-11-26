using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartAssessment.Application.Interfaces;
using PartAssessment.Domain.Repositories;
using PartAssessment.Infrastructure.Persistence;
using PartAssessment.Infrastructure.Persistence.Repositories;

namespace PartAssessment.Infrastructure
{
    public static class DependancyResolver
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services,
            IConfiguration configuration,
            string secret,
            string issuer,
            string audience)
        {
            //add dependencies
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PartConnectionString"));
            });
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<ITokenGenerator>(x => ActivatorUtilities.CreateInstance<JwtTokenGenerator>(x, secret, issuer, audience));

            return services;
        }
    }
}