using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MvcIdentityLab.Models
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var r_administrator = new IdentityRole { Name = "Administrator" };
            var r_employer = new IdentityRole { Name = "Employer" };
            var r_guest = new IdentityRole { Name = "Guest" };

            var admin = new ApplicationUser { Email = "admin@belstu.by", UserName = "admin@belstu.by" };
            var emp = new ApplicationUser { Email = "emp@belstu.by", UserName = "emp@belstu.by" };
            var guest = new ApplicationUser { Email = "guest@belstu.by", UserName = "guest@belstu.by" };
            var super = new ApplicationUser { Email = "super@belstu.by", UserName = "super@belstu.by" };

            var b_administrator = roleManager.Create(r_administrator).Succeeded;
            var b_employer = roleManager.Create(r_employer).Succeeded;
            var b_guest = roleManager.Create(r_guest).Succeeded;

            var b_admin = userManager.Create(admin, "111111").Succeeded;
            var b_emp = userManager.Create(emp, "111111").Succeeded;
            var b_super = userManager.Create(super, "111111").Succeeded;

            if (b_administrator && b_admin)
            {
                userManager.AddToRole(admin.Id, r_administrator.Name);
            }

            if (b_employer && b_employer)
            {
                userManager.AddToRole(emp.Id, r_employer.Name);
            }

            if (b_administrator && b_emp && b_guest && b_super)
            {
                userManager.AddToRoles(super.Id, r_administrator.Name, r_employer.Name, r_guest.Name);
            }

        }
    }
}