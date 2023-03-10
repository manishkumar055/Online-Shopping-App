using System.ComponentModel.DataAnnotations;

namespace Online_Ordering__System.Model
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public string CategoryType { get; set; }

        public virtual ICollection<Products> Products { get; set; }

        

    }
}
