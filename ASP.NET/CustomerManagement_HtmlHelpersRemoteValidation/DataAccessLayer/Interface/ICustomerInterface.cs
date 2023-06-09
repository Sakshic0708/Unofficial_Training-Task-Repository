﻿using DataAccessLayer.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        List<Customer> GetEmailCustomer(string email);
        CustomerListContainer SearchCustomer(string search, string sortby = "Name", string orderby = "asc", int page = 1, int pageSize = 15);
     
    }
}
