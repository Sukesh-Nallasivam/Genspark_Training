using Microsoft.EntityFrameworkCore;
using PizzaStore.Contexts;
using PizzaStore.Interfaces;
using PizzaStore.Repositories;
using PizzaStore.Models;
using System.Numerics;
using PizzaStore.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
            builder.Services.AddScoped<IRepository<int,Admin>,AdminRepository>();
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            builder.Services.AddScoped<PizzaRepository>();
            builder.Services.AddScoped < IRepository<int, Customer>, CustomerRepository>();
            builder.Services.AddScoped<IRepository<int,UserAccount>,UserRepository>();
            #endregion

            #region Service
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IUserService, LoginService>();
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
