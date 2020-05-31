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
    /// SOAP Web Service Interface for User Account 
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountWebService" in both code and config file together.
    [ServiceContract]
    public interface IAccountWebService
    {
        /// <summary>
        /// Get Account data from database
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Account> GetData(string searching);
    }
}
