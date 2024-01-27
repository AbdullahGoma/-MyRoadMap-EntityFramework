using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SecondEntities context = new SecondEntities(); // Open Connection with Database

            context.Database.Log = log => Debug.WriteLine(log);


            #region EF in Action
            //// Connected Mode (Deffered Execution)
            //foreach (var dept in context.Departments) // Here will select * from Department
            //    // and data will be in SQL Provider
            //{
            //    Console.WriteLine(dept.Dname);
            //}
            //// DisConnected Mode (Eager Execution)
            //foreach (var dept in context.Departments.ToList()) // Here will select * from Department
            //                                          // and data will be in SQL Provider
            //{
            //    Console.WriteLine(dept.Dname);
            //}

            //context.Departments.Where(d => d.Dnumber > 10).ToList().ForEach(d => { Console.WriteLine(d.Dname); });


            // Deffered Execution "Connected Mode"
            //var query = context.Departments.Where(d => d.Dnumber > 10); // Server Side
            // Where not where of IEnumerable but come from IQueryable and IQueryable
            // implement IEnumerable
            // IQueryable inside it Expression Tree: Collection of lambda expression
            // Object that have Collection of lambda expressions inside it functions 
            // that transform Lambda expressions to SQL queries
            // d => d.Dnumber > 10 will put in object of expression and will transform to
            // SQL queries

            //var query = from Dept in context.Departments
            //            where Dept.Dnumber > 10 
            //            select Dept;

            //foreach ( var entity in query)
            //{
            //    Console.WriteLine(entity.Dnumber);
            //}

            // This query not IQuerable but IEnumerable 
            //var query = context.Departments.ToList().Where(d => d.Dnumber > 10); // Client Side


            //var query = from Dept in context.Departments
            //            where Dept.Dnumber > int.Parse("10") // Exception here because Entity framework
            //                                                 // not support that 
            //            select Dept;

            //foreach (var entity in query)
            //{
            //    Console.WriteLine(entity.Dnumber);
            //}


            //var id = int.Parse("10");
            //var query = from Dept in context.Departments
            //            where Dept.Dnumber > id // Correct
            //            select Dept;

            //foreach (var entity in query)
            //{
            //    Console.WriteLine(entity.Dnumber);
            //}

            // Eager Execution
            //var query = from Dept in context.Departments.ToList() //
            //            where Dept.Dnumber > int.Parse("10") // Will not return Exception
            //            // because it work with IEnumerable and that not good because
            //            // data will come to memory and will not good if data is big
            //            select Dept;

            //foreach (var entity in query)
            //{
            //    Console.WriteLine(entity.Dnumber);
            //}

            //var query = context.Departments.Select(d => d.Dname);

            //var query = from emp in context.Employees
            //            where emp.Department.Dname == "DP1"
            //            select emp;

            //foreach (var entity in query)
            //{
            //    Console.WriteLine(entity.SSN);
            //}

            //var query = from emp in context.Employees
            //            where emp.Department.Dnumber == emp.Dno
            //            select new { EmpName = emp.Fname, DeptName = emp.Department.Dname};

            //foreach (var entity in query)
            //{
            //    Console.WriteLine($"{entity.EmpName} /t {entity.DeptName}");
            //}



            //var query = (from Dept in context.Departments
            //                 //where Dept.Dnumber == Dept.Employee.Dno
            //             select new { EmpNum = Dept.Employees.Count(), Dept.Dname  });

            //foreach (var entity in query)
            //{
            //    Console.WriteLine(entity);
            //}


            //var dept = context.Departments.First(); // Collection of Employees will return
            //// empty 
            //foreach (var entity in dept.Employees) // Collection of Employees will generated
            //    // when we iterate on it 
            //    // Thats called Lazy Loading
            //{
            //    Console.WriteLine(entity.Fname);
            //}

            //var dept = context.Departments.Find(10); // find department that have PK = 3

            #endregion

            //Here
            #region Tracking Changes
            //var dept = context.Departments.First();

            //dept.Dname = "Dept1"; // Chane not on database but on memory
            //context.Entry(dept).State = System.Data.Entity.EntityState.Modified;
            //context.SaveChanges(); // Save updates in database

            // Change Tracker: track changes on object that come from database
            // context have also reference and track changes
            // (context have specefic class to this subject) this class name is Entry
            // Performance: Every record come from database will creat object from Entry
            // Every Object come from database => Entry have property names 'State'
            // State is Enum have group of values (Modified)
            // when we change thing Entry will change to Modified, when we call
            // SaveChanges() function SaveChanges do detect changes and iterate on All Entries
            // and see Entries Modified 

            // We will say to context don't do track
            //context.Entry(dept).State = System.Data.Entity.EntityState.Detached;
            // If we want to return it
            //context.Departments.Attach(dept); // State will be UnModified

            // How to say to context this query for read only(don't do tracking)
            //var query = (from d in context.Departments
            //            where d.Dnumber > 10
            //            select d).AsNoTracking(); 
            #endregion


            #region Update
            //var dept = context.Departments.First();
            //dept.Dname = "Dept1";
            //context.SaveChanges(); 
            #endregion


            #region Difference between Find and Single
            // Difference between Find and Single:
            // Find search in context(in memory) and if object in it will come 
            // Single came data from database

            // Context do Cashing to data 
            //var dept = context.Departments.Find(3);
            //var dept = context.Departments.Single(d => d.Dnumber == 3); // Single like where
            // Where return all men that match that condition, Single will do Exception if 
            // return data more than one 
            #endregion


            #region Insert Parent/Child
            //var dept = new Department { Dnumber = 50, Dname = "Dp5", MGRSSN = 112233 };
            //context.Departments.Add(dept); // Departments ICollection then have function named add
            //context.SaveChanges();

            //var dept = from d in context.Departments
            //           select d;
            //foreach (var d in dept)
            //{
            //    Console.WriteLine(d.Dname);
            //}


            //context.Departments.AddRange(dept); // to insert more than object 



            //var dept = new Department { Dnumber = 60, Dname = "Dp6", MGRSSN = 112233 };
            //dept.Employees = new List<Employee>()
            //{
            //    new Employee { SSN = 112233, BDATE = DateTime.Now },
            //    new Employee { SSN = 334455, BDATE = DateTime.Now },
            //    new Employee { SSN = 444444, BDATE = DateTime.Now },
            //};
            //context.Departments.Add(dept); // dept.Employees will insert to Employee
            //context.SaveChanges();



            //var dept = new Department { Dnumber = 60, Dname = "Dp6", MGRSSN = 112233 };
            //var emp = new Employee { SSN = 112233, BDATE = DateTime.Now, Department = dept };
            //context.Employees.Add(emp); // dept will insert to database
            //context.SaveChanges(); 
            #endregion


            #region Delete
            //var dept = context.Departments.Find(5);
            //context.Departments.Remove(dept);
            //context.SaveChanges(); 
            #endregion


            #region Stored Procedure
            //context.procGetDepartments(); 
            #endregion


            SecondEntities context2 = new SecondEntities();

            // Salary = 150000
            //var emp = context.Employees.First();
            //var emp1 = context2.Employees.First();
            //emp.Salary -= 1000;
            //context.SaveChanges(); // here Salary will be 149000 in database
            //emp1.Salary -= 2000;
            //context2.SaveChanges(); // here Salary will be 148000 in database


            // if another one work also on the same database and minus 2000 from salary
            // and we update the database, here error 
            // We will use concurrency check to solve this problem (By Watching Salary)
            // Change Concurrency Mode to (Fixed) means watch salary
            // and when another one update database it will throw exception
            // and we will catch it 

            var emp1 = context.Employees.First();
            var emp2 = context2.Employees.First();
            emp1.Salary -= 1000;
            context.SaveChanges();


            emp2.Salary -= 2000; 

            // Solve to this to do it in loop untill proccess success
            try
            {
                context2.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                var emp = e.Entries.First().Entity as Employee;
                context2.Entry(emp).Reload();
                emp2.Salary -= 2000; // here Salary will be 147000
                // if another one change it here? Solve to this to do it in loop untill proccess success
                context2.SaveChanges();
            }













        }
    }
}
