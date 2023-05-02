using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface ICustomerInterface
    {
        List<Customer> GetCustomers();

        List<Customer> GetNameCustomers(string name);

        int PostCustomers(Customer customer);

        long PutCustomers(string name, Customer customer);

        List<Customer> DeleteCustomers(string name);
    }
}
