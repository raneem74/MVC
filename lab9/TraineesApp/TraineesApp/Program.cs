using Microsoft.EntityFrameworkCore;
using TraineesApp.DBServices_Repo_;
using TraineesApp.Models;
using Microsoft.AspNetCore.Identity;
using TraineesApp.Data;



namespace TraineesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load configuration from appsettings.json file
            builder.Configuration.AddJsonFile("appsettings.json", optional: true);
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MainContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ITIConnStr"))
            );
            builder.Services.AddDbContext<TraineesAppContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("TraineesAppContextConnection"))
            );


            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<TraineesAppContext>();
            
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IDBRepo<Trainee>, TraineeReop>();
            builder.Services.AddScoped<IDBRepo<Course>, CourseRepo>();
            builder.Services.AddScoped<IDBRepo<Track>, TrackRepo>();
            builder.Services.AddScoped<IDBManyRepo<Enrollment>, EnrollmentRepo>();

            //IServiceCollection.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}