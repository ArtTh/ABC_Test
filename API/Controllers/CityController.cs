using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext _context;
        public CityController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Get()
        {
            var cities = await _context.Cities.ToListAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Get(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            return Ok(city);
        }
    }
}