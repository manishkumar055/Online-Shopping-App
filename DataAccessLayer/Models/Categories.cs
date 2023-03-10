using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Categories:Audit
    {
        [Key] public int Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Products> Products { get; set; }


    }
}
