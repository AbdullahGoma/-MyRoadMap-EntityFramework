using System;
using System.Linq;
using System.Reflection.Metadata;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NewThird
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // By Convention vs Data Annotations vs Fluent API
            
            Context context = new Context();
            //var query =
            //    from d in context.Departments
            //    where d.ID > 4
            //    select d;

            //foreach (var dept in query)
            //{
            //    Console.WriteLine(dept.Name);
            //    foreach (var emp in dept.Employees) // Lazy Loading is banned in EntityFrameworkCore
            //                                        // because Performance(it bined all collections by Default)
            //                                        // To implement it => Eager Loading, Explicit Loading,
            //                                        // Select Loading and Lazy Loading
            //    {
            //        Console.WriteLine(emp.Name);
            //    }
            //}


            #region Eager Loading
            // Eager Loading: Include employee with you
            //var query = context.Departments
            //    .Include(d => d.Projects) // from Departments
            //    .Include(d => d.Employees) // from Departments
            //    .ThenInclude(e => e.Attendances) /* from Departments */; // This is not good
            //                                                             // because many results returns

            //var query = context.Departments.AsSplitQuery() /* Every Include to one query */
            //    .Include(d => d.Projects) // from Departments
            //    .Include(d => d.Employees) // from Departments
            //    .ThenInclude(e => e.Attendances) /* from Departments */;

            //foreach (var dept in query)
            //{
            //    Console.WriteLine(dept.Name);
            //    foreach (var emp in dept.Employees) // Lazy Loading is banned in EntityFrameworkCore
            //                                        // because Performance(it bined all collections by Default)
            //                                        // To implement it => Eager Loading, Explicit Loading,
            //                                        // Select Loading and Lazy Loading
            //    {
            //        Console.WriteLine(emp.Name);
            //    }
            //}
            #endregion


            #region Explicit Loading
            // Explicit Loading
            //var query = context.Departments.ToList();

            //foreach (var dept in query)
            //{
            //    Console.WriteLine(dept.Name);
            //    context.Entry(dept).Collection(d => d.Employees).Load(); // Explicit Loading
            //    // By Load Employees every iterate
            //    context.Entry(dept).Reference(d => d.Branch).Load(); // Explicit Loading

            //    foreach (var emp in dept.Employees) 
            //    {
            //        Console.WriteLine(emp.Name);
            //    }
            //}

            //foreach (var dept in query)
            //{
            //    Console.WriteLine(dept.Name);
            //    var employees = context.Entry(dept).Collection(d => d.Employees)
            //        .Query().Where(e => e.ID < 10); // Explicit Loading
            //    // By Load Employees every iterate
            //    context.Entry(dept).Reference(d => d.Branch).Load(); // Explicit Loading

            //    foreach (var emp in employees)
            //    {
            //        Console.WriteLine(emp.Name);
            //    }
            //} 
            #endregion


            #region Select Loading
            // Select Loading
            //var query = context.Departments.Select(d => new
            //{
            //    Departments = d,
            //    Employees = d.Employees
            //}).ToList();


            //foreach (var dept in query)
            //{
            //    Console.WriteLine(dept.Departments.Name);
            //    foreach (var emp in dept.Employees)
            //    {
            //        Console.WriteLine(emp.Name);
            //    }
            //} 
            #endregion


            #region Lazy Loading
            // Lazy Loading: Every Navigation Property must be virtual

            // Here was a problem
            // Fix: Put the next code to CSPROJ File
            //< ItemGroup >
            //  < InternalsVisibleTo Include = "DynamicProxyGenAssembly2" />
            //</ ItemGroup >

            //var query = context.Departments.ToList();

            //foreach (var dept in query)
            //{
            //    Console.WriteLine(dept.Name);
            //    foreach (var emp in dept.Employees)
            //    {
            //        Console.WriteLine(emp.Name);
            //    }
            //} 
            #endregion



            #region Client vs. Server Evaluation
            // We assume that will run at Client Side

            // Exception Here because we did where ..
            //var query = (from d in context.Departments
            //            where string.Join(':', "Dept", d.Name) == d.Name
            //            select d).ToList();

            // Here No Exception
            //var query = (from d in context.Departments
            //             select string.Join(':', "Dept", d.Name) == d.Name).ToList(); 
            #endregion


            #region EF Functions
            //var query = (from d in context.Departments
            //            where d.Name.Contains("d")
            //            select d).ToList();

            //var query = (from d in context.Departments
            //             where EF.Functions.Like(d.Name, "%d")
            //             select d).ToList(); 
            #endregion


            #region NoTracking
            // AsNoTracking
            //var query = context.Employees.AsNoTracking().Include(d => d.Department);

            // AsNoTrackingWithIdentityResolution: To do only one object and all Employees
            // are reference to it (Before every object was reference to object)
            // Now all objects references to the same object
            // Saving Time but on performance it slower
            //var query = context.Employees.AsNoTrackingWithIdentityResolution()
            //    .Include(d => d.Department); 
            #endregion

            #region HasQueryFilter

            // Global Query Filter 

            //var query = from e in context.Employees
            //            where e.ID < 10 && !e.IsDeleted
            //            select e;

            //var query = from e in context.Employees
            //            where e.ID < 10 
            //            select e; 
            #endregion


            // Shadow Property: Property not in medel as a main but will be in Database Side
            // we will add Shadow Properties in OnModelCreating 
            // we did'nt put it in classes because in bussiness logic is not related to class

            //var dept = context.Departments.First();

            //context.Entry(dept).Property("IsDeleted").CurrentValue = true;

            //context.SaveChanges();

            //var query = from d in context.Departments
            //            where EF.Property <bool>(d, "IsDeleted") == false
            //            select d;
            //foreach (var d in query)
            //{
            //    Console.WriteLine(d.Name);
            //}






        }
    }
}