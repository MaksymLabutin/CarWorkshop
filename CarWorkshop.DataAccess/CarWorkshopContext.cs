using System;
using CarWorkshop.Core;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.DataAccess
{
    public class CarWorkshopContext : DbContext
    {
        public CarWorkshopContext(DbContextOptions<CarWorkshopContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(_ => _.Id);
            modelBuilder.Entity<User>()
                .HasOne(_ => _.City).WithMany();
            modelBuilder.Entity<User>()
                .Property(_ => _.Name).IsRequired();
            modelBuilder.Entity<User>()
                .Property(_ => _.Email).IsRequired();
            modelBuilder.Entity<User>().HasAlternateKey(_ => new { _.Email, _.Name });

            modelBuilder.Entity<Country>()
                .HasKey(_ => _.Id);
            modelBuilder.Entity<Country>()
                .Property(_ => _.Name).IsRequired();


            modelBuilder.Entity<City>()
                .HasKey(_ => _.Id);
            modelBuilder.Entity<City>()
                .Property(_ => _.Name).IsRequired();
            modelBuilder.Entity<City>()
                .HasOne(_ => _.Country).WithMany(_ => _.Cities);

            modelBuilder.Entity<Company>()
                .HasKey(_ => _.Id);
            modelBuilder.Entity<Company>()
                .Property(_ => _.Name).IsRequired();
            modelBuilder.Entity<Company>().HasAlternateKey(_ => new { _.Name });
            modelBuilder.Entity<Company>()
                .HasOne(_ => _.City).WithMany();

            modelBuilder.Entity<Appointment>()
                .HasKey(_ => _.Id);
            modelBuilder.Entity<Appointment>()
                .Property(_ => _.Date).IsRequired(); 
            modelBuilder.Entity<Appointment>()
                .HasOne(_ => _.User).WithMany();
            modelBuilder.Entity<Appointment>()
                .HasOne(_ => _.Company).WithMany();


            base.OnModelCreating(modelBuilder);
        }

        public object Entry(object appointments)
        {
            throw new NotImplementedException();
        }
    }
}
