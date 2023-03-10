using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Products:Audit
    {
        [Key] 
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string ProductCode { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        [ForeignKey("Category")]
        public int CategotyId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Categories Category { get; set; }
        public Users? User { get; set; }
        public ICollection<OrderDetails> Details { get; set; }


    }
}
