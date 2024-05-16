using Microsoft.EntityFrameworkCore;
using PizzaStore.Contexts;
using PizzaStore.Interfaces;
using PizzaStore.Repositories;
using PizzaStore.Models;
using System.Numerics;
using PizzaStore.Services;

namespace PizzaStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //
            #region Context
            builder.Services.AddDbContext<PizzaStoreDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
            #endregion

            #region Method
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            builder.Services.AddScoped < IRepository<int, Customer>, CustomerRepository>();
            #endregion

            #region Service
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            #endregion
            //
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
