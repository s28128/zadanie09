namespace WebApplication17.DTOs;

public class ReceptaDTO
{
    public int Id { get; set; }
    public PacjentDTO Pacjent { get; set; }
    public LekarzDTO Lekarz { get; set; }
    public List<LekDTO> Leki { get; set; }
}