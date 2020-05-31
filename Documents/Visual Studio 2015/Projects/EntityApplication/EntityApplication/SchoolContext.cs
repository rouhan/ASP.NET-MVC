using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApplication
{
    class SchoolContext: DbContext
    {
        public SchoolContext():base()
        {
            //Disable initializer
            Database.SetInitializer<SchoolContext>(null);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }


}
