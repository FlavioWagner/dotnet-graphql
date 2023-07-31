using AutoMapper;
using graphql.api.src.Infraestructure.Data.Contexts;
using graphql.api.src.Infraestructure.Data.Repositories.Abstractions;
using graphql.api.src.Presentation.GraphQL.Interfaces;
using graphql.api.src.Presentation.GraphQL.Mutations;
using graphql.api.src.Presentation.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace graphql.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;
            var database = configuration.GetSection("Database");

            
            builder.Services.AddDbContext<BancoContext>(options =>
            {
                options.UseNpgsql(database["DefaultConnection"]);
            });


            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //add repositories
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(ICustomQuery<>), typeof(CustomQuery<>));

            builder.Services.AddScoped<PessoaMutation>();
            builder.Services.AddScoped<PessoaFisicaMutation>();
            builder.Services.AddScoped<RamoMutation>();
            builder.Services.AddScoped<Mutation>();
             
            builder.Services.AddScoped<PessoaQuery>();
            builder.Services.AddScoped<PessoaFisicaQuery>();
            builder.Services.AddScoped<RamoQuery>();
            builder.Services.AddScoped<Query>();

            builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

            //add cors
            builder.Services.AddCors();

            //add Controllers
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();           
            
            //mapear GraphQL
            app.MapGraphQL();

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


    public static class CorsExtensions
    {
        public static void UseCorsWithDefaultPolicy(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        }
    }
}