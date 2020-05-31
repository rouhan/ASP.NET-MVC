using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationUserManagement.Model;
using WebApplicationUserManagement.Repository;

namespace WebApplicationUserManagement.Repository
{
    /// <summary>
    /// Initializing Data
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
    class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            base.Seed(context);

            var users = new List<Account>
            {
                new Account {Name="Asad",Email="rouhan_1993@hotmail.com",Password="123",RetryCount=0,Active=true,LastLoginDate=DateTime.Now,LastFailedLoginDate=DateTime.Now },
                new Account {Name="Mark",Email="rouhan1_1993@hotmail.com",Password="123",RetryCount=0,Active=true,LastLoginDate=DateTime.Now,LastFailedLoginDate=DateTime.Now },
                new Account {Name="Wasim",Email="rouhan2_1993@hotmail.com",Password="123",RetryCount=0,Active=true,LastLoginDate=DateTime.Now,LastFailedLoginDate=DateTime.Now },
                new Account {Name="John",Email="rouhan3_1993@hotmail.com",Password="123",RetryCount=0,Active=true,LastLoginDate=DateTime.Now,LastFailedLoginDate=DateTime.Now },
            };
            users.ForEach(s => context.Account.Add(s));
            context.SaveChanges();

            var customer = new List<Customer>
            {
                new Customer {Name="Asad",Department="Retail" },
                new Customer {Name="John",Department="Sales" },
                new Customer {Name="Mark",Department="CustomerService" },

            };
            customer.ForEach(s => context.Customer.Add(s));
            context.SaveChanges();

        }
    }
}
