using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IDbMethods
{
    public interface IOrderMethods
    {
        public Task<OrderTable> PlaceOrder(string userEmail,int[]orders);

        public Task<List<IEnumerable<Products>>> AllOrders(string email);
    }
}
