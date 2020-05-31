using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplicationUserManagement.Model;
using WebApplicationUserManagement.Repository;

namespace WebApplicationUserManagement.Controllers
{
    /// <summary>
    /// Rest WebService Controller for controlling database operation in customer table 
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
    public class CustomersWebServiceController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CustomersWebServiceController));  //Declaring Log4Net  

        // GET: api/CustomersWebService
        public IQueryable<Customer> GetCustomer()
        {
            Log.Info("Fetching Customer from CustomersWebServiceController");
            return db.Customer;
        }

        // GET: api/CustomersWebService/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Log.Info("Get Customer with"+id.ToString());

            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                Log.Info("Customer Not Found");
                return NotFound();
            }
            Log.Info("Returning Customer List");

            return Ok(customer);
        }

        // PUT: api/CustomersWebService/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            Log.Info("Updating Customer Information");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.ID)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    Log.Info("Customer Not Found");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomersWebService
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customer.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        }

        // DELETE: api/CustomersWebService/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Log.Info("Deleting Customer with "+ id.ToString());

            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customer.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customer.Count(e => e.ID == id) > 0;
        }
    }
}