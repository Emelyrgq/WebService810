using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService810.Data;
using WebService810.Models;

namespace WebService810.Controllers
{
    [Route("webservices/[controller]")]
    [ApiController]
    public class WebServiceUsageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WebServiceUsageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebServiceUsage>>> GetWebServiceUsage()
        {
            return await _context.WebServiceUsage.ToListAsync();
        }

    }
}
