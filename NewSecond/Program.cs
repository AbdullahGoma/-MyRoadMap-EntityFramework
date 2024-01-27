using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSecond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // By Default
            // Value Type => Not allow Null in DB, Like int, double, ...
            // Reference Type => Allow Null in DB, Like: String
            // Property ID => PK 

            Context context = new Context();

            //context.Departments.Add(new Department
            //{
            //    Name = "SD"
            //});

            //context.SaveChanges();

            foreach(var item in context.Departments)
            {
                Console.WriteLine(item.Name);
            }

            // When we Add Migration it will compare between snapshoot in DB and Classes

            // Undo the last applied migration.
            // https://stackoverflow.com/questions/11904571/ef-migrations-rollback-last-applied-migration

            // When We remove migration and do update database it will give error
            // to handle that => Remove All things from function up in last migration
            // and Update database 


            // Tables Creat in Database in two cases:
            // 1- Class in DbSet
            // 2- Class in another Class have relation with DbContext
            // ex: public virtual ICollection<Project> Projects { get; set; } in Department
            // and we did not do DbSet to Projct, but it will created in database 





        }
    }
}
