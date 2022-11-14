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
        public DbSet<CelestialObject> CelestialObjects { get; set; }   

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

      

    }
}
