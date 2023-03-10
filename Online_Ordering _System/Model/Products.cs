using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Ordering__System.Model
{
    public class Products
    {
        [Key] public int ProductId { get; set; }
        public string ProductName { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        [ForeignKey("SellerId")]
        public int SellerId { get; set; }


        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public virtual  Categories Categories { get; set; }

        public virtual Order Order { get; set; }
        public virtual Seller Seller { get; set; }

        //public virtual ICollection<Deliveries> Deliveries { get; set; }


          

    }
}
