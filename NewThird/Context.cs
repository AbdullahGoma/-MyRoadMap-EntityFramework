using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThird
{
    internal class Context : DbContext
    {
        // AsNoTracking
        public Context()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            // Do No Tracking to all objects come from database
            // because tracking is big on memory 

            // There Some Objects we want to do tracking to it 
            // here we will change "STATE" to this object and will be tracking 

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = ABDULLAH; Initial catalog = ThirdNew;integrated Security = true");
            
            optionsBuilder.LogTo(log => Debug.WriteLine(log));

            optionsBuilder.UseLazyLoadingProxies(true);

            base.OnConfiguring(optionsBuilder);
        }

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Departmen"); // Entit Department Will
                                                                    // map on Table names Department
                                                                    // Data Annotation Faster in this case
            modelBuilder.Entity<Department>().Property(e => e.Name).IsRequired(true);

            modelBuilder.Entity<Attendance>().HasKey(e => new { e.EmployeeID, e.Date });
            modelBuilder.Entity<Attendance>().ToTable("Attendance");

            modelBuilder.Entity<Employee>().HasQueryFilter(e => !e.IsDeleted);

            // Shadow Property
            //modelBuilder.Entity<Department>()
            //    .Property<bool>("IsDeleted").IsRequired(true).HasDefaultValue(false);

            // Shadow Property for all entities
            foreach(var item in modelBuilder.Model.GetRootEntityTypes())
            {
                modelBuilder.Entity(item.Name).Property<bool>("IsDeleted")
                    .IsRequired(true).HasDefaultValue(false);
            }


            base.OnModelCreating(modelBuilder);
        }

    }
}
