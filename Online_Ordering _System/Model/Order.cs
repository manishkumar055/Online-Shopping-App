using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Ordering__System.Model
{
    public class Order
    {
       
        [Key]
        public int OrderId { get; set; }


        public DateTime OrderDate { get; set; }

          [ForeignKey("CostomerId")]  

        public int CostomerId { get; set; }

        
        
        public virtual ICollection<Products> Products { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
