using log4net.Config;
using log4net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.Controllers;
using RealEstate.Application;
using RealEstate.Application.Repositories;
using RealEstate.Application.UseCases.Property.Queries.GetAll;
using RealEstate.Infrastructure.BaseDbContext;
using RealEstate.Infrastructure.Repositories;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using RealEstate.API.Middleware;

namespace RealEstate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddLog4Net("log4net.config");
            });

            builder.Services.AddApplication();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register the DbContext with the services
            builder.Services.AddDbContext<RealEstateDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("RealEstateDb")));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
