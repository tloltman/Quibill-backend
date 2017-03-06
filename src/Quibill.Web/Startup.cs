using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Quibill.Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(Quibill.Web.Startup))]

namespace Quibill.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In startup creating first admin role and creating a default admin user
            if (!roleManager.RoleExists("Admin"))
            {
                //create admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //create an Admin super user who will maintain the website

                var user = new ApplicationUser();
                user.UserName = "Admin1";
                user.Email = "baruch.oltman@gmail.com";
                string userPassword = "password123";

                var checkUser = UserManager.Create(user, userPassword);

                //add default user to Admin role
                if (checkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }

                //TODO create other roles besides Admin.
            }
        }
    }
}
