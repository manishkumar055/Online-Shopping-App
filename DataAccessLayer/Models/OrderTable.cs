using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class OrderTable:Audit
    {
        [Key] public int Id { get; set; }
        public string ShippingDetails { get; set; }

        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public double TotalPrice { get; set; }

        public ICollection<OrderDetails> Details { get; set; }
        public Users Users { get; set; }

    }
}
