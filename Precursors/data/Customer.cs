using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Precursors.data
{

    public static class Connection
    {
        
        const string ConnectionString = "mongodb://localhost";

        public static MongoClient  Client { get; private set; }

        public static MongoDatabase Database { get; private set; }

         static Connection()
        {
          
           Client = new MongoClient(ConnectionString);
             var server = Client.GetServer();
             Database = server.GetDatabase("test");
            
        }
        public static void TestDb(string customerName)
        {
            var collection = Database.GetCollection<Customer>("customers");
            var customer = new Customer();
            customer.Name = customerName;
            collection.Insert(customer);
            var id = customer.Id;

        }
    }
    public class Customer
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}