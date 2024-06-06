namespace WebApplication17.Models;

public class Lek
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Dawkowanie { get; set; }
    public ICollection<ReceptaLek> ReceptaLeki { get; set; }
}