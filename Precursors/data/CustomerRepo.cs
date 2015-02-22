using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Precursors.data
{
    public class CustomerRepo
    {
        private MongoDatabase _db;
        private MongoCollection<Customer> _customers; 

        public CustomerRepo()
        {
            _db = Connection.Database;
            _customers = _db.GetCollection<Customer>("customers");
        }
        public ObjectId AddCustomer(Customer customer)
        {
            if (customer == null) return new ObjectId();
            _customers.Insert(customer);
            return customer.Id;

        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers.FindAll();
        }

        public Customer UpdateCustomer( Customer customer)
        {
            
            var query = Query<Customer>.EQ(e => e.Id, customer.Id);
            var update = Update<Customer>.Set(e => e.Name, customer.Name); // update modifiers
            _customers.Update(query, update);
            return customer;
        }

        public void DeleteCustomer(ObjectId objectId)
        {
            var query = Query<Customer>.EQ(e => e.Id, objectId);
            _customers.Remove(query);
        }
    }
}