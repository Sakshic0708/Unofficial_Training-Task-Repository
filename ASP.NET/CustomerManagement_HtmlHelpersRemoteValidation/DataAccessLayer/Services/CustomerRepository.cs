using CommonLibrary;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;


namespace DataAccessLayer.Services
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
        public void AddCustomer(Customer modal)
        {
            _customers.InsertOne(modal);
        }
        public void UpdateCustomer(Customer customer)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, customer.Id);
            var update = Builders<Customer>.Update
                .Set(c => c.Name, customer.Name)
                .Set(c => c.Email, customer.Email)
                .Set(c => c.Phone, customer.Phone)
                .Set(c => c.Address, customer.Address);
            _customers.UpdateOne(filter, update);
        }

        public Customer GetCustomerById(ObjectId id)
        {
            return _customers.Find(c => c.Id == id).FirstOrDefault();
        }
        public long DeleteCustomer(string id)
        {
            var objectId = new ObjectId(id);
            var result = _customers.DeleteOne(c => c.Id == objectId);
            return result.DeletedCount;
        }
        public List<Customer> GetEmailCustomer(string email)
        {
            var users = _customers.Find(x => x.Email == email).ToList();
            return users;
        }

    }
}
