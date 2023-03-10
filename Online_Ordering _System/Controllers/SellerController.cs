using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Ordering__System.Context;

namespace Online_Ordering__System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private IConfiguration _configuration;
        private MyContext _context;
        public SellerController(IConfiguration configuration, MyContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public ActionResult Index()
        {

        }
    }
}
