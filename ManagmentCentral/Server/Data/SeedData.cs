using ManagmentCentral.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ManagmentCentral.Server.Data
{
    public class SeedData
    {
        public static ApplicationDbContext db = default!;
        public static UserManager<IdentityUser> userManager = default!;
        public static RoleManager<IdentityRole> roleManager = default!;


        public static async Task InitAsync(ApplicationDbContext context, IServiceProvider services)
        {
            db = context;

            if (db.Roles.Any()) return;

            //userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var roleNames = new[] { "Admin", "User" };
            await AddRolesAsync(roleNames);




            var users = new (string, string, string, string, string?)[] {
                ("admin@gym.se", "%T0lss1t5", "Admin", "Adminson", "Admin"),
                ("user@gym.se","%T0lss1t5", "User", "Userson", "User"),
                ("member1@gym.se","%T0lss1t5", "Member1", "Memberson", null),
                ("member2@gym.se","%T0lss1t5", "Member2", "Membersson", null)
            };

            //await AddUsersAsync(users);

        }

        //#####################################################################################

        private static async Task AddRolesAsync(string[] roleNames)
        {
            foreach (var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }

        //#####################################################################################

        
        private static async Task AddUsersAsync((string, string, string, string, string?)[] users)
        {
            string email, pw, firstName, lastName; string? role;

            foreach (var user in users)
            {
                (email, pw, firstName, lastName, role) = user!;
                if (await userManager.FindByEmailAsync(email) != null) continue;
                var newUser = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    //FirstName = firstName,
                    //LastName = lastName,
                    //TimeOfRegistration = DateTime.Now,
                };
                var result = await userManager.CreateAsync(newUser, pw);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

                if (role != null)
                {
                    await AddUserToRoleAsync(newUser, role);
                }
                
            }

        }

        //#####################################################################################

        private static async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
        {
            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                var result = await userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }
    }
}
