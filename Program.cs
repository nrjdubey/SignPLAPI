using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using SignPLAPI.Infrastructure.DbContext;
using SignPLAPI.Infrastructure;
using SignPLAPI.Application;
using Microsoft.OpenApi.Models;

namespace SignPLAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication("MyScheme");
            builder.Services.AddSingleton<DapperContext>();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddPresentation();



            builder.Services.AddSwaggerGen(sw =>
            sw.SwaggerDoc("v1", new OpenApiInfo { Title = "JWTAuthentication", Version = "1.0" }));

            builder.Services.AddSwaggerGen(s =>
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insert JWT Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                }));

            builder.Services.AddSwaggerGen(w =>
                w.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[]{}
                        }
                    }
                    ));

            var app = builder.Build();

            var dapperContext = app.Services.GetRequiredService<DapperContext>();
            bool isConnected = dapperContext.IsConnectionEstablished();
            if (isConnected)
            {
                System.Console.WriteLine("Database connection is established.");
            }
            else
            {
                System.Console.WriteLine("Failed to establish database connection.");
            }
            

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