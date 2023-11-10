using Microsoft.EntityFrameworkCore;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;

namespace CRM.API.Data
{
    public class DataContext : IdentityDbContext<Users> /*Obligatoriamente se hereda para poder usar entity framework*/
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Oportunity> Oportunities { get; set; }

        public DbSet<Activity> Activities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
