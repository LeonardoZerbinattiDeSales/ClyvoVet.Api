using ClyvoVet.Domain.Commons;

namespace ClyvoVet.Domain.Entities;

public class EventoClinico : BaseEntity
{
    public string Tipo { get; private set; }

    public string Descricao { get; private set; }

    public DateTime DataEvento { get; private set; }

    public Guid PetId { get; private set; }

    public Pet Pet { get; private set; }

    public EventoClinico(string tipo, string descricao, DateTime dataEvento, Guid petId)
    {
        Tipo = tipo;
        Descricao = descricao;
        DataEvento = dataEvento;
        PetId = petId;
    }

    public void AtualizarDados(string tipo, string descricao, DateTime dataEvento, Guid petId)
    {
        Tipo = tipo;
        Descricao = descricao;
        DataEvento = dataEvento;
        PetId = petId;
    }
}