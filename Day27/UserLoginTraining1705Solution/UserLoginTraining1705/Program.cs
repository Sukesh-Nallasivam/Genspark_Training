using Microsoft.EntityFrameworkCore;
using UserLoginTraining1705.Context;
using UserLoginTraining1705.Interfaces;
using UserLoginTraining1705.Models;
using UserLoginTraining1705.Repositories;
using UserLoginTraining1705.Services;

namespace UserLoginTraining1705
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

            #region context
            builder.Services.AddDbContext<UserLoginContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultString")));
            #endregion

            #region services
            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<ISecurity,SecurityService>();
            #endregion

            #region repository
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int,Security>,SecurityRepository>();
            #endregion


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
