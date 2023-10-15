using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CodeFirst_1.Models
{
    public class SADBContext:DbContext
    {
        public SADBContext(DbContextOptions<SADBContext>options):base(options)
        {

        }


        //6-
        public DbSet<Customer> Customers { get; set; }
    }
}
