using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class OrderDetails:Audit
    {
        [Key] public int Id { get; set; }

        [ForeignKey("OrderTableId")]
        public int OrderTableId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductsId { get; set; }
        public Products Products { get; set; }
        public OrderTable OrderTable { get; set; }



    }
}
