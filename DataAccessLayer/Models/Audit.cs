using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Audit
    {

        public bool IsActive { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; }=DateTimeOffset.Now;
        public int CreatedBy { set; get; }
                       
        
    }
}
