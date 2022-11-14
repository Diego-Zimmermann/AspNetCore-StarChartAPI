using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarChart.Data;
using StarChart.Models;

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

        [HttpGet ("{id:int}" , Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects.FirstOrDefault(c => c.Id == id);
            if (celestialObject == null) return NotFound();

            celestialObject.Satellites = _context.CelestialObjects.Where(e => e.Id == id).ToList();
            return Ok(celestialObject);

        }

        [HttpGet("{name: string}")]
        public IActionResult GetByName(string name)
        {
            var celestialObjects = _context.CelestialObjects.Where(c => c.Name == name);
            if (!celestialObjects.Any()) return NotFound();

            foreach(var celestialObject in celestialObjects )
                celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == celestialObject.OrbitedObjectId).ToList();
            return Ok(celestialObjects.ToList());

        }

        public IActionResult GetAll()
        {
            var celestialObjects = _context.CelestialObjects.ToList();
            foreach (var celestialObject in celestialObjects)
            {
                celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == celestialObject.OrbitedObjectId).ToList();
            }
            return Ok(celestialObjects);
        }

    }
}
