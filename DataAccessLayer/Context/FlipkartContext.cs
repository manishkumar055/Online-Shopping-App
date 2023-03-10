using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class FlipkartContext:DbContext
    {
        public FlipkartContext(DbContextOptions<FlipkartContext>options):base(options) { }
        
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        public DbSet<Products> Products { get; set; }   
        public DbSet<OrderTable> OrderTables { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Categories> Categories { get; set; }

    }
}
