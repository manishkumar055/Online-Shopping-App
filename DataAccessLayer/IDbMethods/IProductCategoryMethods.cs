using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IDbMethods
{
    public interface IProductCategoryMethods
    {
         public Task<string> AddProductCategory(string email,string name);
        public Task<string > DeleteCaategory(int id);
        public Task<List<Categories>> AllCategories();
        
    }
}
