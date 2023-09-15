using Application.Common;
using Application.Common.Interface;
using Infrastructure.CurrentUserService;
using Infrastructure.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
            IConfiguration config) {
            services.AddEntityFrameworkNpgsql().AddDbContext<TCourtContext>(option =>
            {
                option.UseNpgsql(config.GetConnectionString("dbContext"));
            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourtInfoService, CourtInfoService>();
            services.AddScoped<IBookingService, BookingService>();
            
            return services;
        }
    }
}
