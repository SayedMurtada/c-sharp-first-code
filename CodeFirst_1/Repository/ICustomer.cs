using CodeFirst_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst_1.Repository
{
   public interface ICustomer
    {
        IEnumerable<Customer> GellAllCustomers();
        Customer GetCustomer(int id);
        Customer Add(Customer cust);
        Customer Update(Customer cust);
        Customer Delete(Customer cust);
    }
}
