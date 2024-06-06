using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication17.Data;
using WebApplication17.Models;
using WebApplication17.DTOs;
using System.Linq;

namespace WebApplication17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReceptyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetRecepta(int id)
        {
            var recepta = _context.Recepty
                .Include(r => r.Pacjent)
                .Include(r => r.Lekarz)
                .Include(r => r.ReceptaLeki)
                .ThenInclude(rl => rl.Lek)
                .SingleOrDefault(r => r.Id == id);

            if (recepta == null)
            {
                return NotFound();
            }

            var receptaDTO = new ReceptaDTO
            {
                Id = recepta.Id,
                Pacjent = new PacjentDTO
                {
                    Id = recepta.Pacjent.Id,
                    Imie = recepta.Pacjent.Imie,
                    Nazwisko = recepta.Pacjent.Nazwisko,
                    Pesel = recepta.Pacjent.Pesel
                },
                Lekarz = new LekarzDTO
                {
                    Id = recepta.Lekarz.Id,
                    Imie = recepta.Lekarz.Imie,
                    Nazwisko = recepta.Lekarz.Nazwisko,
                    Specjalizacja = recepta.Lekarz.Specjalizacja
                },
                Leki = recepta.ReceptaLeki.Select(rl => new LekDTO
                {
                    Id = rl.Lek.Id,
                    Nazwa = rl.Lek.Nazwa,
                    Dawkowanie = rl.Lek.Dawkowanie
                }).ToList()
            };

            return Ok(receptaDTO);
        }
    }
}