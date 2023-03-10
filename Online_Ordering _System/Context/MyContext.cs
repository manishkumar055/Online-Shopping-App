using Microsoft.EntityFrameworkCore;
using Online_Ordering__System.Model;

namespace Online_Ordering__System.Context
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext>options):base(options) { }
        
        public DbSet<Categories> Categories { get; set; }  

        public DbSet<Customer> Customers { get; set; } 

        //dbset<deliveries> deliveries { get; set; }  

        public DbSet<Order> Order { get; set; }    

        public DbSet<Products> Products { get; set; }

        public DbSet<Seller> Sellers { get; set;}


    }
}
