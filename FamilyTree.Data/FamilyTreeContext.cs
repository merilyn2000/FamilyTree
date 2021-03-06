using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sitline.Training.FamilyTree;
using Sitline.Training.FamilyTree.Vehicles;
using System;

namespace FamilyTree.Data
{
    public class FamilyTreeContext : DbContext
    {
        public FamilyTreeContext()
        {
        }

        public FamilyTreeContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                

                optionsBuilder.UseSqlServer("Server =DESKTOP-94QO6UM; Database = FamilyTreeData; Trusted_Connection = True;")
                    ///*"Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=FamilyTreeData"*/)
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                        LogLevel.Information)
                    .EnableSensitiveDataLogging();
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>();
            modelBuilder.Entity<Motorcycle>();
            modelBuilder.Entity<Scooter>();
            modelBuilder.Entity<Train>();

            modelBuilder.Entity<Person>()
                .HasMany(s => s.Friends)
                .WithMany(b => b.Persons)
                .UsingEntity<FriendPerson>
                    (bs => bs.HasOne<Friend>().WithMany(),
                    bs => bs.HasOne<Person>().WithMany())
                .Property(bs => bs.DateJoined)
                .HasDefaultValueSql("getdate()");
        }
    }
}
