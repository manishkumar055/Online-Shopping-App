using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.RequestDTO
{
    public  class ProductRequestDTO
    {
        public string ProductName { get; set; }

        public string ProductCode { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryName { get; set; }
    }
}
