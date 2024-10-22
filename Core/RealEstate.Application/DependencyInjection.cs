using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Mapper;
using RealEstate.Application.UseCases.Property.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllQueryHandler).Assembly));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }
    }
}
