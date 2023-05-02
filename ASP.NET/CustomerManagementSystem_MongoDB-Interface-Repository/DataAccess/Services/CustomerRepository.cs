using MongoDB.Driver;
using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using DataAccess.Interface;

namespace DataAccess.Services
{
    public class CustomerRepository : ICustomerInterface
    {
        private readonly IMongoCollection<Customer> _customers;
        public CustomerRepository()
        {
            var client = new MongoClient(AppConfiguration.ConnectionString);
            var database = client.GetDatabase(AppConfiguration.DatabaseName);
            _customers = database.GetCollection<Customer>("Customers");
        }
        public List<Customer> GetCustomers()
        {
            return _customers.Find(x => true).ToList();
        }
        public List<Customer> GetNameCustomers(string name)
        {
            var filter = Builders<Customer>.Filter.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            return _customers.Find(filter).ToList();
        }
        public int PostCustomers(Customer customer)
        {
            _customers.InsertOne(customer);
            return 1;
        }
        public long PutCustomers(string name, Customer customer)
        {
            var filter = Builders<Customer>.Filter.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            var update = Builders<Customer>.Update
                .Set(c => c.Name, customer.Name)
                .Set(c => c.Email, customer.Email)
                .Set(c => c.Address, customer.Address)
                .Set(c => c.Phone, customer.Phone);

            var result = _customers.UpdateMany(filter, update);

            return result.ModifiedCount;
        }

        public List<Customer> DeleteCustomers(string name)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Name, name);
            _customers.DeleteOne(filter);

            // return a list of customers after deletion
            return _customers.Find(Builders<Customer>.Filter.Empty).ToList();
        }
    }
}
