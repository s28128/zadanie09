using Microsoft.AspNetCore.Mvc;
using WebApplication17.Data;
using WebApplication17.Models;
using System.Linq;

namespace WebApplication17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LekarzeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LekarzeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLekarze()
        {
            var lekarze = _context.Lekarze.ToList();
            return Ok(lekarze);
        }

        [HttpGet("{id}")]
        public IActionResult GetLekarz(int id)
        {
            var lekarz = _context.Lekarze.Find(id);
            if (lekarz == null)
            {
                return NotFound();
            }
            return Ok(lekarz);
        }

        [HttpPost]
        public IActionResult PostLekarz([FromBody] Lekarz lekarz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lekarze.Add(lekarz);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetLekarz), new { id = lekarz.Id }, lekarz);
        }

        [HttpPut("{id}")]
        public IActionResult PutLekarz(int id, [FromBody] Lekarz updatedLekarz)
        {
            if (id != updatedLekarz.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lekarz = _context.Lekarze.Find(id);
            if (lekarz == null)
            {
                return NotFound();
            }

            lekarz.Imie = updatedLekarz.Imie;
            lekarz.Nazwisko = updatedLekarz.Nazwisko;
            lekarz.Specjalizacja = updatedLekarz.Specjalizacja;

            _context.Lekarze.Update(lekarz);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLekarz(int id)
        {
            var lekarz = _context.Lekarze.Find(id);
            if (lekarz == null)
            {
                return NotFound();
            }

            _context.Lekarze.Remove(lekarz);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
