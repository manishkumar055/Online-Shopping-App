using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IDbMethods
{
    public interface IProductsMethods
    {
        public Task<string> AddProduct(string email,Products product,string categpryName);

       
        public Task<string> DeleteProduct(string productCode);

        public Task<string> Update(Products product);

        public Task<List<Products>> GetAllProducts();

        public Products GetByProductCode(string productCode);
    }
}
