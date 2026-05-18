namespace ClyvoVet.Application.DTOs;

public class CreatePetDto
{
    public string Nome { get; set; }
    public string Especie { get; set; }
    public string Raca { get; set; }
    public DateTime DataNascimento { get; set; }
    public Guid TutorId { get; set; }
}