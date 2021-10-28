using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nexos.Models;

namespace nexos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILogger<LibroController> _logger;

        private readonly nexosContext _context;

        public LibroController(ILogger<LibroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = "10"
                })
                .ToArray();
        }

        // GET: api/Libro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            return await _context.Libros.ToListAsync();
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null) {
                return NotFound();
            }

            return libro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.idLibro) {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!LibroExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.idLibro }, libro);
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.idLibro == id);
        }
    }
}
