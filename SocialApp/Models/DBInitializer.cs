using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SocialApp.Models
{
    public class DBInitializer: CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            // RoleTypes is a class containing constant string values for different roles
            List<IdentityRole> identityRoles = new List<IdentityRole>();
            identityRoles.Add(new IdentityRole() { Name = "Admin" });
            identityRoles.Add(new IdentityRole() { Name = "User" });
            foreach (IdentityRole role in identityRoles)
            {
                roleManager.Create(role);
            }
            // Initialize default user
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = new ApplicationUser();
            user.Email = "admin@admin.com";
            user.UserName = "admin@admin.com";

            manager.Create(user, "admin123");

            manager.AddToRole(user.Id, "Admin");
            // Add code to initialize context tables

            base.Seed(context);
        }
    }
}