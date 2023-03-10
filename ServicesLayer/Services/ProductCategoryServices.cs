using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using ServicesLayer.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{

    public class ProductCategoryServices:IProductCategoryServices
    {
        private readonly IProductCategoryMethods _prod;

        public ProductCategoryServices(IProductCategoryMethods prod)
        {
            _prod = prod;
        }

        public Task<string> AddProductCategory(string email,string name)
        {
            try
            {
                var res = _prod.AddProductCategory(email,name);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> DeleteCaategory(int id)
        {
            try
            {
                var res = _prod.DeleteCaategory(id);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<string>> AllCategories()
        {
            try
            {
                var res = await _prod.AllCategories();

                List<string> lists= new List<string>();
                foreach (var item in res)
                {
                    lists.Add(item.CategoryName);
                }
                return lists;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
