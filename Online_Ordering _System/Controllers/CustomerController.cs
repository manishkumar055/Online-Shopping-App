using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Ordering__System.Context;
using Online_Ordering__System.Model;

namespace Online_Ordering__System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MyContext _myContext;
        private IConfiguration _configuration;

        public CustomerController(MyContext myContext, IConfiguration configuration)
        {
            _myContext = myContext;
            _configuration = configuration; 
        }

        [HttpPost("Register")]

        public async Task<ActionResult<string>> Register(RegisterRequest request)
        {
            var obj = _myContext.Customers.Any(obj => obj.Name.ToLower().Equals(request.Name));
            if (!obj)
            {
                _myContext.Customers.Add(
                    new Customer
                    {
                        Name = request.Name,
                        Address = request.Address,
                        ContactNumber = request.ContactNumber,
                    });
                await _myContext.SaveChangesAsync();
                return Ok($"{request.Name} Added...!");
            }
            return BadRequest("Please Login...!"); 
        }

        [HttpGet("Login")]




    }
}
