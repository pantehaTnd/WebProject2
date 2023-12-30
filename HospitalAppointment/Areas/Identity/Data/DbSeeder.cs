
using HospitalAppointment.Constants;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace HospitalAppointment.Areas.Identity.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync (IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<ApplicationUser>> ();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            //creating Admin
            var user = new ApplicationUser
            {
                UserName = "B161210551@sakarya.edu.tr",
                Email = "B161210551@sakarya.edu.tr",
                FirstName = "Admin",
                LastName ="Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                //change password later
                await userManager.CreateAsync(user, "Abcd!123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());

            }
        
    }

}
}
