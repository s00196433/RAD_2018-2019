namespace WebApplication2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication2.Models;
    using ClassLibrary1;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var manager =
               new UserManager<ApplicationUser>(
                   new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Branch Manager" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Data Clerk" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Customer" }
                );

            PasswordHasher ps = new PasswordHasher();

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "Bank Manager",
                    Email = "bank.manager@bob.com",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("TheBoss$1")
                });


            ApplicationUser Librarian = manager.FindByEmail("bank.manager@bob.com");
            if (Librarian != null)
            {
                manager.AddToRoles(Librarian.Id, new string[] { "Branch Manager" });
            }
            context.SaveChanges();

            SeedCustomers(manager, context);
        }

            private void SeedCustomers(UserManager<ApplicationUser> manager, ApplicationDbContext context)
            {


                PasswordHasher ps = new PasswordHasher();
                using (BankContext bankDb = new BankContext())
                {

                    foreach (var customer in bankDb.Customers)
                    {
                        ApplicationUser user = manager.FindByName(customer.Name);
                        if (user == null)
                        {
                            context.Users.AddOrUpdate(u => u.UserName,
                                new ApplicationUser
                                {
                                    Id = customer.ID.ToString(),
                                    UserName = customer.Name,
                                    SecurityStamp = Guid.NewGuid().ToString(),
                                   // PasswordHash = ps.HashPassword("Customer$1")
                                });
                        }
                    }
                    context.SaveChanges();


                    foreach (var customer in bankDb.Customers)
                    {
                        ApplicationUser ChosenCustomers = manager.FindByName(customer.Name);
                        if (ChosenCustomers != null)
                        {
                            manager.AddToRoles(ChosenCustomers.Id, new string[] { "Customer" });
                        }

                    }
                }
                context.SaveChanges();

            }
    }
    
}
