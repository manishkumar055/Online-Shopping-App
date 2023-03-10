using DataAccessLayer.Context;
using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using N_Tier_Architecture_FinalProject.ChangeTracking;

namespace DataAccessLayer.DbMehods
{
    public class ProductsMethods : IProductsMethods
    {
        private readonly FlipkartContext _context;
        private readonly ITracking _track;

        public ProductsMethods(FlipkartContext context, ITracking tracking  )
        {
            _context = context;
            _track = tracking;
        }

        public async Task<string> AddProduct(string email, Products product, string categoryName)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();

                var tempProduct = await _context.Products
                    .Where(x => x.ProductCode.Equals(product.ProductCode))
                    .FirstOrDefaultAsync();
                if (tempProduct != null)
                {
                    return $"Product Name: {product.ProductName} of ProductCode: {product.ProductCode} already Added...!";
                }

                var category = await _context.Categories.Where(x => x.CategoryName.Equals(categoryName)).FirstOrDefaultAsync();
                if (category == null)
                {
                    category = new Categories { CategoryName = categoryName, CreatedBy = user.Id };
                    await _context.Categories.AddAsync(category);
                    _track.AllChanges();

                    await _context.SaveChangesAsync();
                }

                product.UserId = user.Id;
                product.CreatedBy = user.Id;
                product.CategotyId = category.Id;
                _context.Products.Add(product);
                _track.AllChanges();
                await _context.SaveChangesAsync();
                return $"Addede {product.ProductName} of ProduductCode {product.ProductCode}";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> DeleteProduct(string productCode)
        {
            try
            {
                var productObj = await _context.Products.Where(x => x.ProductCode.Equals(productCode)).FirstOrDefaultAsync();
                if (productObj != null)
                {
                    _context.Remove(productObj);
                    await _context.SaveChangesAsync();
                    return $"{productObj.ProductName} of ProductCode {productObj.ProductCode} Deleted...";
                }
                return $"Not Found Product For ProductCode{productCode}";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Products>> GetAllProducts()
        {
            try
            {
                var obj = _context.Products.ToListAsync();
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Products GetByProductCode(string productCode)
        {
            try
            {
                var product = _context.Products.Where(x => x.ProductCode.Equals(productCode)).FirstOrDefault();
                if (product == null)
                {
                    throw new Exception("Product Not Found...!");
                }
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Update(Products product)
        {
            try
            {
                var existingProduct = await _context.Products
                                                    .Where(x => x.ProductCode
                                                    .Equals(product.ProductCode))
                                                    .FirstOrDefaultAsync();
                if (existingProduct == null)
                {
                    throw new Exception($"Not Found ProductCode {product.ProductCode}");
                }

                existingProduct.ProductDescription = product.ProductDescription;
                existingProduct.Price = product.Price;
                existingProduct.ProductName = product.ProductName;
                await _context.SaveChangesAsync();
                return $"Data Changed for Product:{product.ProductName} of ProductCode:{product.ProductCode}";

            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
