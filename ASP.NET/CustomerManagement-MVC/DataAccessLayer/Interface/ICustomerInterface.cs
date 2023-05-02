using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using MongoDB.Bson;

namespace DataAccessLayer.Interface
{
    public interface ICustomerInterface
    {
        List<Customer> GetCustomers();

        List<Customer> GetNameCustomers(string name);
        void AddCustomer(Customer modal);
                
        void UpdateCustomer(Customer customer);

        long DeleteCustomer(string id);
        Customer GetCustomerById(ObjectId id);
    }
}
