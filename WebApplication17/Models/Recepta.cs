namespace WebApplication17.Models;

public class Recepta
{
    public int Id { get; set; }
    public int PacjentId { get; set; }
    public Pacjent Pacjent { get; set; }
    public int LekarzId { get; set; }
    public Lekarz Lekarz { get; set; }
    public ICollection<ReceptaLek> ReceptaLeki { get; set; }
}