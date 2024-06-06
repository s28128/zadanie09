namespace WebApplication17.Models;

public class ReceptaLek
{
    public int ReceptaId { get; set; }
    public Recepta Recepta { get; set; }
    public int LekId { get; set; }
    public Lek Lek { get; set; }
}