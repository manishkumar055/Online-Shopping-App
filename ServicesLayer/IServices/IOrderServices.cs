using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using ServicesLayer.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IServices
{
    public interface IOrderServices
    {
        public Task<OrderTable> PlaceOrder(string userEmail, int[] orders);

        public Task<List<IEnumerable<ProductRequestDTO>>> AllOrders(string email);
    }
}
