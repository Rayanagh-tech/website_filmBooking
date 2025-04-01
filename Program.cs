using MovieBooking.BL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieBooking.DAL; // Namespace for your DbContext
using Microsoft.Extensions.DependencyInjection;
using identityuser.Services;
using Microsoft.DotNet.Scaffolding.Shared;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure DbContext
        builder.Services.AddDbContext<MovieBookingContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.MigrationsAssembly("identityuser"))); // Migrations will be stored in identityuser


        // Add Identity with IdentityUser (ApplicationUser class is used here)
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<MovieBookingContext>()
            .AddDefaultTokenProviders();

        // Register EmailSender
        builder.Services.AddSingleton<Microsoft.AspNetCore.Identity.UI.Services.IEmailSender, EmailSender>();

        // Register controllers with views
        builder.Services.AddControllersWithViews();

        // Optional: Register Razor Pages if applicable
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Error handling
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Seed roles during application startup
        using (var scope = app.Services.CreateScope())
        {
            

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRolesAsync(roleManager);
        }

        // Enable middleware
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles();


        // Map controllers and define default route
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Optional: Map Razor Pages if you're using them
        app.MapRazorPages();

        app.Run();

        static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Define roles to seed
            string[] roles = ["User", "Admin"];

            foreach (var role in roles)
            {
                if (await roleManager.RoleExistsAsync(role))
                {
                    continue;
                }
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            var adminUser = new ApplicationUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    Console.WriteLine("Admin user created successfully.");
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    Console.WriteLine("Failed to create admin user. Errors:");
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
            else
            {
                Console.WriteLine("Admin user already exists.");
            }
        }
    }
}