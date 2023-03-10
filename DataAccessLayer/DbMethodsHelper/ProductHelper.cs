using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbMethodsHelper
{
    internal class ProductHelper
    {
        private  readonly FlipkartContext _context;

       
        //public ProductHelper(FlipkartContext context)
        //{
        //    _context = context;
        //}

        //public async Task< Products >byProductCode(string productCode)
        //{
        //    var product = await _context.Products.Where(x => x.ProductCode == productCode).FirstOrDefaultAsync();
        //    return product;
        //}
    }
}
