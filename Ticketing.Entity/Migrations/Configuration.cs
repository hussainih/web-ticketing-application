namespace Ticketing.Entity.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ticketing.Identity;
    using Ticketing.TicketModel;

    internal sealed class Configuration : DbMigrationsConfiguration<Ticketing.Identity.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }


        protected override void Seed(ApplicationDbContext context)
        {

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

            context.Roles.AddOrUpdate(
                r => r.Name,
                new ApplicationRole { Name = "Admin" },
                new ApplicationRole { Name = "Student" },
                new ApplicationRole { Name = "Supervisor" },
                new ApplicationRole { Name = "SecondSupervisor" },
                new ApplicationRole { Name = "Professor", Description = "Good description" }
                );

            try
            {
                context.Database.ExecuteSqlCommand(SeedDataForSQL.GetSQLQuery());
            }catch(Exception e)
            {

            }
            context.AllowedDomains.AddOrUpdate(
                a => a.DomainName,
                new AllowedDomains
                {
                    DomainName = "student.com",

                },
                new AllowedDomains
                {
                    DomainName = "supervisor.com"
                }
                );


            if (UserManager.FindByName("Hussaini.Mohd86@gmail.com") == null)
            {
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser { Email = "Hussaini.Mohd86@gmail.com" };
                user.UserName = "Hussaini.Mohd86@gmail.com";
                user.PasswordHash = new PasswordHasher().HashPassword("Dell@123");
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.FirstName = "Admin";
                user.TwoFactorEnabled = false;

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "Admin");


            }

            if (UserManager.FindByName("Hussain@student.com") == null)
            {
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser { Email = "Hussain@student.com" };
                user.UserName = "Hussain@student.com";
                user.PasswordHash = new PasswordHasher().HashPassword("Dell@123");
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.FirstName = "Mohammad";
                user.LastName = "Hussain";
                user.TwoFactorEnabled = false;

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "Student");
            }

            if (UserManager.FindByName("Adnan@student.com") == null)
            {
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser { Email = "Adnan@student.com" };
                user.UserName = "Adnan@student.com";
                user.PasswordHash = new PasswordHasher().HashPassword("Dell@123");
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.FirstName = "Muhammad";
                user.LastName = "Adnan";
                user.TwoFactorEnabled = false;

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "Student");
            }

            if (UserManager.FindByName("Moomal@student.com") == null)
            {
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser { Email = "Moomal@student.com" };
                user.UserName = "Moomal@student.com";
                user.PasswordHash = new PasswordHasher().HashPassword("Dell@123");
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.FirstName = "Moomal";
                user.LastName = "Mahar";
                user.TwoFactorEnabled = false;

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "Student");
            }

            if (UserManager.FindByName("Kriti@student.com") == null)
            {
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser { Email = "Kriti@student.com" };
                user.UserName = "Kriti@student.com";
                user.PasswordHash = new PasswordHasher().HashPassword("Dell@123");
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.FirstName = "Kriti";
                user.LastName = "Agarwaal";
                user.TwoFactorEnabled = false;

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "Student");
            }

            if (UserManager.FindByName("Hans@supervisor.com") == null)
            {
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser { Email = "Hans@supervisor.com" };
                user.UserName = "Hans@supervisor.com";
                user.PasswordHash = new PasswordHasher().HashPassword("Dell@123");
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.FirstName = "Hans";
                user.LastName = "Diestel";
                user.TwoFactorEnabled = false;

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "Supervisor");

                context.SupervisorDegreePrograms.Add(new TicketModel.SupervisorDegreeProgram()
                {
                    Supervisor = UserManager.FindByEmail("Hans@supervisor.com"),
                    Specialization = context.Specializations.Where(x => x.Name.Equals("Information Technology and Systems Development")).FirstOrDefault()
                });
            }
            if (UserManager.FindByName("Robert@supervisor.com") == null)
            {
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser { Email = "Robert@supervisor.com" };
                user.UserName = "Robert@supervisor.com";
                user.PasswordHash = new PasswordHasher().HashPassword("Dell@123");
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.FirstName = "Robert";
                user.LastName = "Manzke";
                user.TwoFactorEnabled = false;

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "Supervisor");
                context.SupervisorDegreePrograms.Add(new TicketModel.SupervisorDegreeProgram()
                {
                    Supervisor = UserManager.FindByEmail("Robert@supervisor.com"),
                    Specialization = context.Specializations.Where(x => x.Name.Equals("Intelligent Systems")).FirstOrDefault()
                });
                context.SupervisorDegreePrograms.Add(new TicketModel.SupervisorDegreeProgram()
                {
                    Supervisor = UserManager.FindByEmail("Robert@supervisor.com"),
                    Specialization = context.Specializations.Where(x => x.Name.Equals("Information Technology and Systems Development")).FirstOrDefault()
                });
            }
            if (UserManager.FindByName("Samberg@supervisor.com") == null)
            {
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser { Email = "Samberg@supervisor.com" };
                user.UserName = "Samberg@supervisor.com";
                user.PasswordHash = new PasswordHasher().HashPassword("Dell@123");
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.FirstName = "Ulrich";
                user.LastName = "Samberg";
                user.TwoFactorEnabled = false;

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "Supervisor");

                context.SupervisorDegreePrograms.Add(new TicketModel.SupervisorDegreeProgram()
                {
                    Supervisor = UserManager.FindByEmail("Samberg@supervisor.com"),
                    Specialization = context.Specializations.Where(x => x.Name.Equals("Business IT-Management")).FirstOrDefault()
                });
                context.SupervisorDegreePrograms.Add(new TicketModel.SupervisorDegreeProgram()
                {
                    Supervisor = UserManager.FindByEmail("Samberg@supervisor.com"),
                    Specialization = context.Specializations.Where(x => x.Name.Equals("Information Technology and Systems Development")).FirstOrDefault()
                });
            }
            if (UserManager.FindByName("Gruschka@supervisor.com") == null)
            {
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser { Email = "Gruschka@supervisor.com" };
                user.UserName = "Gruschka@supervisor.com";
                user.PasswordHash = new PasswordHasher().HashPassword("Dell@123");
                user.EmailConfirmed = true;
                user.IsApproved = true;
                user.FirstName = "Nils";
                user.LastName = "Gruschka";
                user.TwoFactorEnabled = false;

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "Supervisor");
                context.SupervisorDegreePrograms.Add(new TicketModel.SupervisorDegreeProgram()
                {
                    Supervisor = UserManager.FindByEmail("Gruschka@supervisor.com"),
                    Specialization = context.Specializations.Where(x => x.Name.Equals("IT-Security")).FirstOrDefault()
                });
            }
            context.StatusTypes.AddOrUpdate(
               r => r.Status,
              new TicketModel.StatusTypes() { Status = "Proposal Submitted"}
               );

            //ConfigurationManager.AppSettings["mailAccount"], "The Ticketing Robot");
            //var toEmail = new MailAddress(message.Destination);
            //var fromPassword = ConfigurationManager.AppSettings["mailPassword"];

            //var Host1 = ConfigurationManager.AppSettings["SMTPHost"];
            //var Port1 = Int32.Parse(ConfigurationManager.AppSettings["SMTPPort"]);

            using (var db = new ApplicationDbContext())
            {
                db.SystemSettings.Add(new TicketModel.SystemSettings()
                {
                    ConfigurationFor = "Email",
                    Key = "FromEmailAccount",
                    Value = ConfigurationManager.AppSettings["MailAccount"]
                });
                db.SystemSettings.Add(new TicketModel.SystemSettings()
                {
                    ConfigurationFor = "Email",
                    Key = "Password",
                    Value = ConfigurationManager.AppSettings["MailPassword"]
                });
                db.SystemSettings.Add(new TicketModel.SystemSettings()
                {
                    ConfigurationFor = "Email",
                    Key = "SMTPHost",
                    Value = ConfigurationManager.AppSettings["SMTPHost"]
                });
                db.SystemSettings.Add(new TicketModel.SystemSettings()
                {
                    ConfigurationFor = "Email",
                    Key = "SMTPPort",
                    Value = ConfigurationManager.AppSettings["SMTPPort"]
                });
                db.SystemSettings.Add(new TicketModel.SystemSettings()
                {
                    ConfigurationFor = "Email",
                    Key = "EnableSsl",
                    Value = ConfigurationManager.AppSettings["EnableSsl"]
                });
                db.SystemSettings.Add(new TicketModel.SystemSettings()
                {
                    ConfigurationFor = "Email",
                    Key = "DeliveryMethod",
                    Value = ConfigurationManager.AppSettings["DeliveryMethod"]
                });
                db.SystemSettings.Add(new TicketModel.SystemSettings()
                {
                    ConfigurationFor = "Email",
                    Key = "UseDefaultCredentials",
                    Value = ConfigurationManager.AppSettings["UseDefaultCredentials"]
                });
                db.SaveChanges();
            };

        }

    }
}
