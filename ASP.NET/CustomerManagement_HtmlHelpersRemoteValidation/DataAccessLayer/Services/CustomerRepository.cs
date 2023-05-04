using CommonLibrary;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection;
using System;


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
                .Set(c => c.Address, customer.Address)
                .Set(c => c.FilePath, customer.FilePath);

            _customers.UpdateOne(filter, update);
        }
        //Note that I removed the line that called the File method, and also added a missing closing brace for the Edit action method.


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

      
        public CustomerListContainer SearchCustomer(string searchText, string sortby = "Name", string orderby = "asc", int page = 1, int pageSize = 15)
        {
            var filter = Builders<Customer>.Filter.Empty;

            if (!string.IsNullOrEmpty(searchText))
            {
                filter &= Builders<Customer>.Filter.Regex(field: "Email", regex: new BsonRegularExpression(pattern: searchText, options: "i")) |
                          Builders<Customer>.Filter.Regex(field: "Name", regex: new BsonRegularExpression(pattern: searchText, options: "i")) |
                          Builders<Customer>.Filter.Regex(field: "Phone", regex: new BsonRegularExpression(pattern: searchText, options: "i"));
            }

            var objCustomers = _customers.Find(filter);
            var totalRecordCount = objCustomers.Count();
            var sort = orderby == "asc" ? Builders<Customer>.Sort.Ascending(sortby) : Builders<Customer>.Sort.Descending(sortby);

            var totalPages = System.Convert.ToInt32(System.Math.Ceiling(totalRecordCount / System.Convert.ToDouble(pageSize)));
            var records = objCustomers.Sort(sort).Skip((page - 1) * pageSize).Limit(pageSize).ToList();

            var ObjResponse = new CustomerListContainer()
            {
                CustomerPageList = new CustomerPaging()
                {
                    Page = page,
                    PageSize = pageSize,
                    TotalPage = totalPages,
                    TotalRecord = totalRecordCount,
                    Records = records
                }
            };

            return ObjResponse;
        }



    }
}
