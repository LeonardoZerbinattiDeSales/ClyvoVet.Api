using ClyvoVet.Domain.Commons;

namespace ClyvoVet.Domain.Entities;

public class Pet : BaseEntity
{
    public string Nome { get; private set; }

    public string Especie { get; private set; }

    public string Raca { get; private set; }

    public DateTime DataNascimento { get; private set; }

    public Guid TutorId { get; private set; }

    public Tutor Tutor { get; private set; }
    
    public ICollection<EventoClinico> EventosClinicos { get; private set; } = new List<EventoClinico>();

    public ICollection<Lembrete> Lembretes { get; private set; } = new List<Lembrete>();

    public Pet(string nome, string especie, string raca, DateTime dataNascimento, Guid tutorId)
    {
        Nome = nome;
        Especie = especie;
        Raca = raca;
        DataNascimento = dataNascimento;
        TutorId = tutorId;
    }
}