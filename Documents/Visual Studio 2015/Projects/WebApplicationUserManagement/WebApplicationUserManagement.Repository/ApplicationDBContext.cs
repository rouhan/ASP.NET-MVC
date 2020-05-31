using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApplicationUserManagement.Model;

namespace WebApplicationUserManagement.Repository
{
    /// <summary>
    /// DB Context Class for Creating Tables using Entity Framework
    /// </summary>
    /// <author>Muhammad Asad Ashraf </author>
    /// <created>30-May-2020</created>
    /// <revisions>
    ///     <revision>
    ///         <author></author>
    ///         <date></date>
    ///         <remarks></remarks>
    ///     </revision>
    /// </revisions>
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext() :base("DefaultConnection")
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Account> Account { get; set; }

    }
}
