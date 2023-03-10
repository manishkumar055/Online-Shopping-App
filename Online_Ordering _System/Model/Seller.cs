using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Ordering__System.Model
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public string Address { get; set; }

        

        public ICollection<Products> Products { get; set; }    

    }
}
