using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUserManagement.Model;
using WebApplicationUserManagement.Repository;

namespace WebApplicationUserManagement
{
    /// <summary>
    /// Account Manager Class is used to fetch User information from Database
    /// </summary>
    /// <author> Muhammad Asad Ashraf</author>
    /// <created>30-5-2020</created>
    /// <revisions>
    ///     <revision>
    ///         <author></author>
    ///         <date></date>
    ///         <remarks></remarks>
    ///     </revision>
    /// </revisions>
    public class AccountManager
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AccountManager));  //Declaring Log4Net  

        private ApplicationDBContext dbContext;
        public AccountManager()
        {
            dbContext = new ApplicationDBContext();
        }
        /// <summary>
        /// Get User information from Account table 
        /// </summary>
        /// <returns>List of Account Object</returns>
        public List<Account> GetAccounts(string searching)
        {
            logger.Info("Account Manager Getting Account from Account Table");
            List<Account> account;
            if (string.IsNullOrEmpty(searching))
                 account = dbContext.Account.ToList();
            else
                account= dbContext.Account.Where(x => x.Name.Contains(searching)).ToList();
            return account;
        }
        /// <summary>
        /// Fetch Account details from Account Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Account Object</returns>
        public Account GetAccountbyName(string name)
        {
            logger.Info("Account Manager Getting Account from Name"+name);

            Account account = dbContext.Account.Find(name);
            return account;
        }


    }
}