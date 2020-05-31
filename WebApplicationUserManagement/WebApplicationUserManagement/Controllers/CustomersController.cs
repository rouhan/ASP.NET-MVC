using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class CustomersController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CustomersController));  //Declaring Log4Net  

        // GET: Customers
        public ActionResult Index()
        {
            logger.Info("Calling WebClient for fetching Customer Record");
            //We are calling Restful Webservice for Database Operations
            IEnumerable<Customer> custList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CustomersWebService").Result;
            custList = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;

            return View(custList);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CustomersWebService/" + id.ToString()).Result;

            if (response == null)
            {
                logger.Error("Response Not Found");
                return HttpNotFound();
            }
            return View(response.Content.ReadAsAsync<Customer>().Result);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Department")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CustomersWebService", customer).Result;
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CustomersWebService/" + id.ToString()).Result;

            if (response == null)
            {
                logger.Error("Response Not Found");
                return HttpNotFound();
            }
            return View(response.Content.ReadAsAsync<Customer>().Result);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Department")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("CustomersWebService/" + customer.ID, customer).Result;
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CustomersWebService/" + id.ToString()).Result;

            if (response == null)
            {
                logger.Error("Response Not Found");
                return HttpNotFound();
            }
            return View(response.Content.ReadAsAsync<Customer>().Result);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("CustomersWebService/" + id.ToString()).Result;

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
