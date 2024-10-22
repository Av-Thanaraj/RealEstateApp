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

namespace RealEstate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Log4Net
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly()!);

            // Read Log4Net configuration from appsettings.json
            var log4NetConfig = builder.Configuration.GetSection("Log4Net");

            // Set up the ConsoleAppender
            var consoleAppender = new ConsoleAppender
            {
                Layout = new PatternLayout
                {
                    ConversionPattern = log4NetConfig.GetSection("Appender:ConsoleAppender:Layout:ConversionPattern").Value
                }
            };
            consoleAppender.ActivateOptions();

            // Set the root logger
            var rootLogger = logRepository.GetLogger("Root") as log4net.Repository.Hierarchy.Logger;
            rootLogger.Level = Level.Debug; // Set level based on appsettings
            rootLogger.AddAppender(consoleAppender);



            builder.Services.AddApplication();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
