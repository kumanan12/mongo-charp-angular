using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using Precursors.data;

namespace Precursors.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer

        private CustomerRepo _repo=new CustomerRepo();
       
        public IEnumerable<Customer> Get()
        {

            return _repo.GetCustomers();
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public HttpResponseMessage Post(Customer customer)
        {
           var id= _repo.AddCustomer(customer);
            return Request.CreateResponse(HttpStatusCode.Created,customer);
            

        }

        // PUT: api/Customer/5
        public void Put(string Id, Customer customer)
        {
            var objectId = new ObjectId(Id);
            customer.Id = objectId;
            Customer _customer = _repo.UpdateCustomer(customer);

        }

        // DELETE: api/Customer/5
        public HttpResponseMessage Delete(string Id)
        {
            var objectId = new ObjectId(Id);
            _repo.DeleteCustomer(objectId);
           return Request.CreateResponse(HttpStatusCode.Moved);

        }
    }
}
