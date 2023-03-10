using System.ComponentModel.DataAnnotations;

namespace Online_Ordering__System.Model
{
    public class Customer
    {
        [Key] public int CustomerID { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get;set; }

        //public virtual ICollection<Deliveries> Deliveries { get;set; }
        

    }
}
