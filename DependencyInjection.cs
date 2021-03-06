// using IdentityModel;
// using IdentityServer4.Models;
// using IdentityServer4.Test;
// using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System.Collections.Generic;
//using System.Security.Claims;

using FamilyBudget.Application.Interface;
using FamilyBudget.Infrastructure.DataContext;
using FamilyBudget.Infrastructure.Repositories;

namespace FamilyBudget.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) //, IWebHostEnvironment environment)
        {
            // services.AddDbContext<BudgetDbContext>(options =>
            //     options.UseSqlite(
            //         configuration.GetConnectionString("DefaultConnection"), 
            //         b => b.MigrationsAssembly(typeof(BudgetDbContext).Assembly.FullName)));

           services.AddDbContext<BudgetDbContext>(options =>
             options.UseSqlite(configuration.GetConnectionString("BudgetConnection")));



      //      services.AddScoped<IApplicationDbContext>(provider => provider.GetService<BudgetDbContext>());
           services.AddScoped<ICategoryXrefRepo, CategoryXrefRepo>();
           services.AddScoped<ICategoryRepo, CategoryRepo>();
           services.AddScoped<IProductRepo, ProductRepo>();
           services.AddScoped<IPurchaseRepo, PurchaseRepo>();
  
            // services.AddDefaultIdentity<ApplicationUser>()
            //     .AddEntityFrameworkStores<ApplicationDbContext>();

            // if (environment.IsEnvironment("Test"))
            // {
            //     services.AddIdentityServer()
            //         .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
            //         {
            //             options.Clients.Add(new Client
            //             {
            //                 ClientId = "CleanArchitecture.IntegrationTests",
            //                 AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
            //                 ClientSecrets = { new Secret("secret".Sha256()) },
            //                 AllowedScopes = { "CleanArchitecture.WebUIAPI", "openid", "profile" }
            //             });
            //         }).AddTestUsers(new List<TestUser>
            //         {
            //             new TestUser
            //             {
            //                 SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
            //                 Username = "jason@clean-architecture",
            //                 Password = "CleanArchitecture!",
            //                 Claims = new List<Claim>
            //                 {
            //                     new Claim(JwtClaimTypes.Email, "jason@clean-architecture")
            //                 }
            //             }
            //         });
            // }
            // else
            // {
            //     services.AddIdentityServer()
            //         .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            //     services.AddTransient<IDateTime, DateTimeService>();
            //     services.AddTransient<IIdentityService, IdentityService>();
            //     services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            // }

            // services.AddAuthentication()
            //     .AddIdentityServerJwt();

            return services;
        }
    }
}
