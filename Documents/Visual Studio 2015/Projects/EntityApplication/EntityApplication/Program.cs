using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApplication
{
    class Program 
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var stud = new Student() { StudentName = "asad" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }

        }
      
    }
}
