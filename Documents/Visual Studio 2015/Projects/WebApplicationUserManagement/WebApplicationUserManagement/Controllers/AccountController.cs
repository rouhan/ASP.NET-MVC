using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationUserManagement.Repository;

namespace WebApplicationUserManagement.Controllers
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
    public class AccountController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AccountController));  //Declaring Log4Net  

        UserService.AccountWebServiceClient ser = new UserService.AccountWebServiceClient();
        // GET: Account
        public ActionResult Index(string searching)
        {
            logger.Info("Calling WebService for Account List");
            return View(ser.GetData(searching));
        }
       
    }
}