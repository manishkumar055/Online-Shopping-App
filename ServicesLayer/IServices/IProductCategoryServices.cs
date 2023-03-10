using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IServices
{
    public interface IProductCategoryServices
    {
        public Task<string> AddProductCategory(string email,string name);
        public Task<string> DeleteCaategory(int id);
        public Task<List<string>> AllCategories();
    }
}
