namespace WebApplication17.Models;

public class Pacjent
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pesel { get; set; }
    public ICollection<Recepta> Recepty { get; set; }    
}