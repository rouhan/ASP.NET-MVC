using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebApplicationUserManagement.Model;

namespace WebApplicationUserManagement
{
    /// <summary>
    /// 
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountWebService.svc or AccountWebService.svc.cs at the Solution Explorer and start debugging.
    public class AccountWebService : IAccountWebService
    {
        public List<Account> GetData(string searching)
        {
            AccountManager _manager = new AccountManager();

            return _manager.GetAccounts(searching);
        }
    }
}
