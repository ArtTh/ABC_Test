using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly DataContext _context;
        public LocationController(DataContext context)
        {
            _context = context;
        }


    }
}