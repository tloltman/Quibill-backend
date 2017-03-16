using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Quibill.Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Configuration;

[assembly: OwinStartup(typeof(Quibill.Web.Startup))]

namespace Quibill.Web
{
    public partial class Startup
    {
        #region Admin Role Credentials
        public string AdminUserName
        {
            get
            {
                return WebConfigurationManager.AppSettings["defaultAdminUserName"];
            }
        }

        public string AdminEmail
        {
            get
            {
                return WebConfigurationManager.AppSettings["defaultAdminEmail"];
            }
        }

        public string AdminPassword
        {
            get
            {
                return WebConfigurationManager.AppSettings["defaultAdminPassword"];
            }
        }

        public string AdminRole
        {
            get
            {
                return WebConfigurationManager.AppSettings["defaultAdminRole"];
            }
        }
        #endregion //Properties to get admin credentials from web.config

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
            if (!roleManager.RoleExists(AdminRole))
            {
                //create admin role
                var role = new IdentityRole();
                role.Name = AdminRole;
                roleManager.Create(role);

                //create an Admin super user who will maintain the website

                var user = new ApplicationUser();
                user.UserName = AdminUserName;
                user.Email = AdminEmail;
                string userPassword = AdminPassword;

                var checkUser = UserManager.Create(user, userPassword);

                //add default user to Admin role
                if (checkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, AdminRole);
                }

                //TODO create other roles besides Admin.
            }
        }
    }
}
