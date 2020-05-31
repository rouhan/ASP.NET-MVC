using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationUserManagement.Model;
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
    public class HomeController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));  //Declaring Log4Net  

        private ApplicationDBContext db = new ApplicationDBContext();
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            Log.Info("Login-page started...");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account objUser)
        {
            Log.Info("Request for Login Email" + objUser.Email);

            // if (ModelState.IsValid)
            {
                //Check the Email is present
                var obj = db.Account.Where(a => a.Email.Equals(objUser.Email)).FirstOrDefault();
                if (obj != null)
                {
                    //Check for Active Account
                    if (obj.Active)
                    {
                        if (obj.Password != objUser.Password)
                        {
                            Log.Info("Incorrect Password");
                            obj.LastFailedLoginDate = DateTime.Now;//Updating Last Failed Login Date
                            obj.RetryCount++;
                            Log.Info("Incresing RetryCount" + obj.RetryCount);

                            if (obj.RetryCount >= 3)//Mark the Status of Account as inActive if Retries Exhauseted
                                obj.Active = false;
                        }
                        else 
                        {
                            Log.Info("User Login Successful");
                            Log.Info("Resetting Retry Counter");

                            obj.RetryCount = 0;//If login was successful reset Retry Counter
                            obj.LastLoginDate = DateTime.Now;//Updating Last Login Date

                            db.Entry(obj).State = EntityState.Modified;
                            try
                            {
                                db.SaveChanges();
                            }
                            catch (DbUpdateConcurrencyException e)
                            {
                                Log.Error(e.Message);
                            }

                            Session["LastLogin"] = obj.LastLoginDate.ToString();
                            Session["LastFailLogin"] = obj.LastFailedLoginDate.ToString();
                            Session["UserName"] = obj.Name.ToString();

                            return RedirectToAction("Index");
                        }
                        db.Entry(obj).State = EntityState.Modified;
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException e)
                        {
                            Log.Error(e.Message);
                        }

                    }
                    else
                        Log.Info("Account Inactive");
                }
                else
                    Log.Info("Email not registered");
            }
            return View(objUser);
        }
    }
}