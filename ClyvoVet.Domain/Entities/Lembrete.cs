using ClyvoVet.Domain.Commons;

namespace ClyvoVet.Domain.Entities;

public class Lembrete : BaseEntity
{
    public string Titulo { get; private set; }

    public string Descricao { get; private set; }

    public DateTime DataLembrete { get; private set; }

    public bool Concluido { get; private set; }

    public Guid PetId { get; private set; }

    public Pet Pet { get; private set; }

    public Lembrete(string titulo, string descricao, DateTime dataLembrete, Guid petId)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataLembrete = dataLembrete;
        PetId = petId;
        Concluido = false;
    }

    public void MarcarComoConcluido()
    {
        Concluido = true;
    }
}