using DataAccessLayer.Context;
using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DbMehods
{
    public class OrderMethods : IOrderMethods
    {
        private readonly FlipkartContext _context;
        public OrderMethods(FlipkartContext context)
        {
            _context = context;
        }

        public async Task<List<IEnumerable<Products>>> AllOrders(string email)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
                var allOrders = await _context.OrderTables.Where(x => x.UsersId == user.Id).Select(x => x.Details.Select(x => x.Products)).ToListAsync();
                return allOrders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderTable> PlaceOrder(string userEmail, int[] products)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Email == userEmail).FirstOrDefaultAsync();
                double totalPrice = 0;

                List<OrderDetails> orderDetails = new List<OrderDetails>();

                var productEntities = await _context.Products.Where(x => products.Contains(x.Id)).ToListAsync();
                foreach (var prodId in products)
                {
                    var product = productEntities.FirstOrDefault(x => x.Id == prodId);
                    
                    if (product is null) { throw new Exception("Unable to retrieve Product for specified identifier"); }
                    
                    var order = new OrderDetails
                    {
                        ProductsId = prodId,
                        CreatedBy = user?.Id ?? 0
                    };

                    totalPrice += product.Price;

                    orderDetails.Add(order);
                }

                var ordTable = new OrderTable()
                {
                    CreatedBy = user.Id,
                    UsersId = user.Id,
                    TotalPrice = totalPrice,
                    Details = orderDetails,
                    ShippingDetails = "shipped",

                };
                await _context.OrderTables.AddAsync(ordTable);
                await _context.SaveChangesAsync();

                return ordTable;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Task<List<orderDetails>> IOrderMethods.PlaceOrder(string userEmail, int[] orders)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
