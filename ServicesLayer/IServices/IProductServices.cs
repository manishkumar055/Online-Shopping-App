using DataAccessLayer.Models;
using ServicesLayer.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IServices
{
    public interface IProductServices
    {
        
        public Task<string> AddProduc(string email,ProductRequestDTO product);


        public Task<string> DeleteProduct(string productCode);

        public Task<string> Update(ProductRequestDTO product);

        public Task<List<ProductRequestDTO>> GetAllProducts();

        public Task<ProductRequestDTO> GetByProductCode(string productCode);
    }
}
