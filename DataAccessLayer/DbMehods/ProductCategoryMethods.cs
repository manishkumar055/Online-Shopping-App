using DataAccessLayer.Context;
using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbMehods
{
    public class ProductCategoryMethods:IProductCategoryMethods
    {
        private readonly FlipkartContext _context;
        public ProductCategoryMethods(FlipkartContext context)
        {
            _context = context;
        }

        public async Task<string> AddProductCategory(string email,string name)
        {
            var userobj = await _context.Users.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();

            try
            {
                var obj=await _context.Categories.Where(x=>x.CategoryName.Equals(name)).FirstOrDefaultAsync();
                if (obj != null)
                {
                    return $"Product Name is Already Added {name}";
                }
                var newCategory = new Categories()
                {
                     CategoryName = name,
                     CreatedBy=userobj.Id
                    
                };
                _context.Categories.Add(newCategory);
                await _context.SaveChangesAsync();
                return $"Saved ProductCategory {name}";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Categories>> AllCategories()
        {
            try
            {
                var categories =await _context.Categories.ToListAsync();
                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> DeleteCaategory(int id)
        {
            try
            {
                var category=await _context.Categories.Where(x=>x.Id.Equals(id)).FirstOrDefaultAsync();
                if (category != null)
                {
                     _context.Categories.Remove(category);
                    _context.SaveChangesAsync();
                    return $"Deleted Category {category.CategoryName}";
                }
                return "Not Found...!";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
