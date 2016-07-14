using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebDeveloper.Models;

[assembly: OwinStartupAttribute(typeof(WebDeveloper.Startup))]
namespace WebDeveloper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            CreateUserAndRole();
            ConfigureAuth(app);            
            ConfigInjector();
        }

        internal void CreateUserAndRole()
        {
            using (var context = new WebDeveloperDbContext())
            {

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<WebDeveloperUser>(new UserStore<WebDeveloperUser>(context));

                // In Startup iam creating first Admin Role and creating a default Admin User    
                if (!roleManager.RoleExists("Admin"))
                {

                    // first we create Admin rool   
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website                  

                    var user = new WebDeveloperUser
                    {
                        UserName = "juvega@gmail.com",
                        Email = "juvega@gmail.com"
                    };

                    string userPassword = "Passw0rd2016";

                    var userCreation = userManager.Create(user, userPassword);

                    //Add default User to Role Admin   
                    if (userCreation.Succeeded)
                        userManager.AddToRole(user.Id, "Admin");


                }

                // creating Creating Manager role    
                if (!roleManager.RoleExists("Manager"))
                {
                    var role = new IdentityRole
                    {
                        Name = "Manager"
                    };
                    roleManager.Create(role);

                }

                // creating Creating Employee role    
                if (!roleManager.RoleExists("Employee"))
                {
                    var role = new IdentityRole
                    {
                        Name = "Employee"
                    };
                    roleManager.Create(role);

                }
            }
        }
    }
}
