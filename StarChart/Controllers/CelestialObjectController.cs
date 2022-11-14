using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int", Name = "GetById")]
        public IActionResult GetById(int id) {
            var celeestialObj = _context.CelestialObject 
            if(id == null)
            {
                return NotFound();
            }

        }

    }
}
