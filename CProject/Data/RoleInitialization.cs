using CProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace CProject.Data
{
    public class RoleInitialization
    {
        public static void Init(IServiceProvider scopeServiceProvider)
        {
            var userManager = scopeServiceProvider.GetService<UserManager<User>>();

           
            var director = new User
            {
                UserName = "director@m.ru",
                Adress = "Vladimir city, Stalina 11",
                Email = "director@m.ru",
                PhoneNumber = "79101119113",
                UserRole = "Director"
            };

            var result = userManager.CreateAsync(director, "aaaaaaaa").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(director, new Claim(ClaimTypes.Role, "Director")).GetAwaiter().GetResult();
            }
            
            var storekeeper = new User
            {
                UserName = "storekeeper@m.ru",
                Adress = "Vladimir city, Lenina 6",
                Email = "storekeeper@m.ru",
                PhoneNumber = "79101512113",
                UserRole = "Storekeeper"
            };

            var result1 = userManager.CreateAsync(storekeeper, "aaaaaaaa").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(storekeeper, new Claim(ClaimTypes.Role, "Storekeeper")).GetAwaiter().GetResult();
            }
           
            var logistician = new User
            {
                UserName = "logistician@m.ru",
                Adress = "Vladimir city, Belokonskaja 8",
                Email = "logistician@m.ru",
                PhoneNumber = "79151112113",
                UserRole = "Logistician"
            };

            var result2 = userManager.CreateAsync(logistician, "aaaaaaaa").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(logistician, new Claim(ClaimTypes.Role, "Logistician")).GetAwaiter().GetResult();
            }

         
            var wholesaler = new User
            {
                UserName = "wholesaler@m.ru",
                Adress = "Vladimir city, Gorkogo 7",
                Email = "wholesaler@m.ru",
                PhoneNumber = "79101112113",
                UserRole = "Wholesaler"
            };

            var result3 = userManager.CreateAsync(wholesaler, "aaaaaaaa").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(wholesaler, new Claim(ClaimTypes.Role, "Wholesaler")).GetAwaiter().GetResult();
            }
        }
    }
}