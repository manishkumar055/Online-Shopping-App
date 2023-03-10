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
    public class OrderServices:IOrderServices
    {
        private readonly IOrderMethods _order;
        private readonly IMapper _mapper;

        public OrderServices(IOrderMethods order,IMapper mapper)
        {
            _order = order;
            _mapper = mapper;   
        }

        public async Task<List<IEnumerable<ProductRequestDTO>>> AllOrders(string email)
        {
            try
            {
                var res=await _order.AllOrders(email);
                var result=_mapper.Map<List<IEnumerable<Products>>,List<IEnumerable<ProductRequestDTO>>>(res);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderTable> PlaceOrder(string userEmail, int[] orders)
        {
            try
            {
                var res=await _order.PlaceOrder(userEmail, orders);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
