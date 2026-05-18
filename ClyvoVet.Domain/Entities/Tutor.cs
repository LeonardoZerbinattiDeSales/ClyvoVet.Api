using ClyvoVet.Domain.Commons;

namespace ClyvoVet.Domain.Entities;

public class Tutor : BaseEntity
{
    public string Nome { get; private set; }
    
    public string Email { get; private set; }
    
    public string Telefone { get; private set; }

    public ICollection<Pet> Pets { get; private set; } = new List<Pet>();

    public Tutor(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }
}