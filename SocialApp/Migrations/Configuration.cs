namespace SocialApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SocialApp.Models.ApplicationDbContext";
        }

        protected override void Seed(SocialApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            // Initialize default user
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            var adminUser = manager.FindByEmail("admin@admin.com");

            if (adminUser == null)
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

                ApplicationUser user = new ApplicationUser();
                user.Email = "admin@admin.com";
                user.UserName = "admin@admin.com";
                manager.Create(user, "admin123");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
