using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ticketing.Entity.TicketModel;
using Ticketing.TicketModel;

namespace Ticketing.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TicketingConnection")
        {
        }
        //Temp

        public DbSet<Ticket> Ticket { get; set; }
        
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<ToUserEmailContents> ToUserEmailContents { get; set; }
        public DbSet<AllowedDomains> AllowedDomains { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }

        public DbSet<Proposal> Proposal { get; set; }
        public DbSet<ProposalType> ProposalTypes { get; set; }
        public DbSet<DegreeType> DegreeTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DegreeProgram> DegreePrograms { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<SupervisorDegreeProgram> SupervisorDegreePrograms { get; set; }
        
        public DbSet<SystemSettings> SystemSettings { get; set; }
        public DbSet<StatusTypes> StatusTypes { get; set; }
        public DbSet<Notification> Notification { get; set; }
        
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Files> Files { get; set; }
      
       

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllowedDomains>()
                        .HasMany<ApplicationRole>(a => a.Roles)
                        .WithMany(i => i.AllowedDomains)
                        .Map(DomainRoles =>
                       {
                           DomainRoles.MapLeftKey("AllowedDomainsID");
                           DomainRoles.MapRightKey("RolesID");
                           DomainRoles.ToTable("DomainRoles");
                       });
            //modelBuilder.Entity<Degrees>()
            //    .HasMany<Faculties>( d => d.Faculties)

            base.OnModelCreating(modelBuilder);
        }

      
    }
}