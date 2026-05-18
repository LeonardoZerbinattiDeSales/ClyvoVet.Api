namespace ClyvoVet.Domain.Commons;

public abstract class BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public DateTime CriadoEm { get; private set; } = DateTime.Now;

    public bool Ativo { get; private set; } = true;
}