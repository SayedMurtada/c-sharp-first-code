using CodeFirst_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst_1.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly SADBContext db;

        public CustomerRepository(SADBContext db)
        {
            this.db = db;
        }

        public Customer Add(Customer cust)
        {
            db.Customers.Add(cust);
            db.SaveChanges();
            return cust;
        }

        public Customer Delete(Customer cust)
        {
            var customer = db.Customers.Find(cust.Id);
            if (customer!=null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
            return cust;
        }

        public IEnumerable<Customer> GellAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var cust = db.Customers.Find(id);
            return cust;
        }

        public Customer Update(Customer cust)
        {
            var customer = db.Customers.Attach(cust);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return cust;
        }
    }
}
