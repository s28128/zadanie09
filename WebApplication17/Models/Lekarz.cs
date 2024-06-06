namespace WebApplication17.Models;

public class Lekarz
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Specjalizacja { get; set; }
    public ICollection<Recepta> Recepty { get; set; }
}