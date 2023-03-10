using AutoMapper;
using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using ServicesLayer.IServices;
using ServicesLayer.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class ProductServices:IProductServices
    {
        private readonly IProductsMethods _prodMeth;
        private readonly IMapper _mapper;

        public ProductServices(IProductsMethods meth,IMapper mapper)
        {
            _prodMeth= meth;
            _mapper= mapper;
        }

        public Task<string> AddProduc(string email, ProductRequestDTO product)
        {
            try
            {
                var tempProduct = _mapper.Map<ProductRequestDTO, Products>(product);
                var res = _prodMeth.AddProduct(email, tempProduct, product.CategoryName);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

         

        public Task<string> DeleteProduct(string productCode)
        {
            try
            {
                var res = _prodMeth.DeleteProduct(productCode);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ProductRequestDTO>> GetAllProducts()
        {
            try
            {
                var res=await _prodMeth.GetAllProducts();
                
                var result = _mapper.Map<List<Products>, List<ProductRequestDTO>>(res);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async  Task<ProductRequestDTO> GetByProductCode(string productCode)
        {
            try
            {
                var res = _prodMeth.GetByProductCode(productCode);
                var result = _mapper.Map<Products, ProductRequestDTO>(res);
                return result;
            }
            catch (Exception)
            {

                throw;
            } 
        }

        public Task<string> Update(ProductRequestDTO product)
        {
            try
            {
                var productObj = _mapper.Map<ProductRequestDTO, Products>(product);
                var res = _prodMeth.Update(productObj);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
