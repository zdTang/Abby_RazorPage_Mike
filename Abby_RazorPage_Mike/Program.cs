using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Abby.Utility;

namespace Abby_RazorPage_Mike
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<AbbyDbContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
    ));

            //builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AbbyDbContext>();

            builder.Services
                .AddIdentity<IdentityUser, IdentityRole>()        // if we need use RoleManager, we need add IdentityRole
                .AddEntityFrameworkStores<AbbyDbContext>()        // Be aware the correct DbContext name
                .AddDefaultTokenProviders();                      // used to generate Tokens for changing password or reset Email....

            builder.Services.AddSingleton<IEmailSender, EmailSender>();

            // The following are for DI registeration
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            //https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-7.0
            app.MapControllers();  // This is called to map Attribute routed controllers

            app.Run();
        }
    }
}