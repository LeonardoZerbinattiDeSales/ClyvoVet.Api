namespace ClyvoVet.Application.DTOs;

public class CreateEventoClinicoDto
{
    public string Tipo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataEvento { get; set; }
    public Guid PetId { get; set; }
}