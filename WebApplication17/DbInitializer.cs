using WebApplication17.Data;
using WebApplication17.Models;
using System.Linq;

namespace WebApplication16
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            
            if (context.Lekarze.Any())
            {
                return;  
            }

            var lekarze = new Lekarz[]
            {
                new Lekarz{ Imie="Jan", Nazwisko="Kowalski", Specjalizacja="Kardiolog" },
                new Lekarz{ Imie="Anna", Nazwisko="Nowak", Specjalizacja="Dermatolog" }
            };

            foreach (var l in lekarze)
            {
                context.Lekarze.Add(l);
            }
            context.SaveChanges();

            var pacjenci = new Pacjent[]
            {
                new Pacjent{ Imie="Piotr", Nazwisko="Zieliński", Pesel="12345678901" },
                new Pacjent{ Imie="Maria", Nazwisko="Kowal", Pesel="10987654321" }
            };

            foreach (var p in pacjenci)
            {
                context.Pacjenci.Add(p);
            }
            context.SaveChanges();

            var leki = new Lek[]
            {
                new Lek{ Nazwa="Aspiryna", Dawkowanie="1 tabletka dziennie" },
                new Lek{ Nazwa="Paracetamol", Dawkowanie="2 tabletki dziennie" }
            };

            foreach (var l in leki)
            {
                context.Leki.Add(l);
            }
            context.SaveChanges();

            
            var recepty = new Recepta[]
            {
                new Recepta{ PacjentId = pacjenci.First().Id, LekarzId = lekarze.First().Id },
                new Recepta{ PacjentId = pacjenci.Last().Id, LekarzId = lekarze.Last().Id }
            };

            foreach (var r in recepty)
            {
                context.Recepty.Add(r);
            }
            context.SaveChanges();

            
            var receptaLeki = new ReceptaLek[]
            {
                new ReceptaLek{ ReceptaId = recepty[0].Id, LekId = leki[0].Id },
                new ReceptaLek{ ReceptaId = recepty[0].Id, LekId = leki[1].Id },
                new ReceptaLek{ ReceptaId = recepty[1].Id, LekId = leki[1].Id }
            };

            foreach (var rl in receptaLeki)
            {
                context.ReceptaLeki.Add(rl);
            }
            context.SaveChanges();
        }
    }
}
