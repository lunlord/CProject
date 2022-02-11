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
            
            //директор
            var director = new User
            {
                UserName = "director@m.ru",
                Adress = "Selo Zar",
                Email = "director@m.ru",
                PhoneNumber = "79000220000"
            };

            var result = userManager.CreateAsync(director, "aaaaaaaa").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(director, new Claim(ClaimTypes.Role, "Director")).GetAwaiter().GetResult();
            }
            //кладовщик
            var storekeeper = new User
            {
                UserName = "storekeeper@m.ru",
                Adress = "Selo Zar",
                Email = "storekeeper@m.ru",
                PhoneNumber = "79000220000"
            };
           
            var result1 = userManager.CreateAsync(storekeeper, "aaaaaaaa").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(storekeeper, new Claim(ClaimTypes.Role, "Storekeeper")).GetAwaiter().GetResult();
            }
            //логист
            var logistician = new User
            {
                UserName = "logistician@m.ru",
                Adress = "Selo Zar",
                Email = "logistician@m.ru",
                PhoneNumber = "7900033000"
            };
            
            var result2 = userManager.CreateAsync(logistician, "aaaaaaaa").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(logistician, new Claim(ClaimTypes.Role, "Logistician")).GetAwaiter().GetResult();
            }

            //оптовик
            var wholesaler = new User
            {
                UserName = "wholesaler@m.ru",
                Adress = "Selo Zar",
                Email = "wholesaler@m.ru",
                PhoneNumber = "7900000000"
            };
      
            var result3 = userManager.CreateAsync(wholesaler, "aaaaaaaa").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(wholesaler, new Claim(ClaimTypes.Role, "Wholesaler")).GetAwaiter().GetResult();
            }
        }
    }
}
