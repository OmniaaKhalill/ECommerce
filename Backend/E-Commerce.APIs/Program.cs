
using E_Commerce.APIs.Controllers;
using E_Commerce.APIs.Helpers;
using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Talabat.APIs.Extensions;

namespace E_Commerce.APIs
{
    public class Program
    {
        public  static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerServices();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProjectContext>(op => 
            op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericReposity<>));
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddIdentity<AppUser, IdentityRole>
            (options =>
            {

            } ).AddEntityFrameworkStores<ProjectContext>();


            builder.Services.AddApplicationServices();

            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerfactory = services.GetRequiredService<ILoggerFactory>();

                var dbContext = services.GetRequiredService<ProjectContext>();
                var _manager = services.GetRequiredService<UserManager<AppUser>>();

                try
                {
                    await dbContext.Database.MigrateAsync();//update-database

                    var _userManager = services.GetRequiredService<UserManager<AppUser>>();
                    await AppIdentityDbContextDataSeed.SeedUserAsync(_userManager);
                    //await ProjectContextSeed.SeedAsync(dbContext);

                }
                catch (Exception ex)
                {

                    var logger = loggerfactory.CreateLogger<Program>();
                    logger.LogError(ex, "an error occured while apply migration");
                }
                finally
                {
                    scope.Dispose();

                }
            }

            app.UseMiddleware<ExceptionMiddleware>();
          


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }


        public static async Task AddUser(UserManager<AppUser> userManager)
        {
            

           

        }
    }
}
