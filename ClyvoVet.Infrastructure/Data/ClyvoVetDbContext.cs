using ClyvoVet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClyvoVet.Infrastructure.Data;

public class ClyvoVetDbContext : DbContext
{
    public ClyvoVetDbContext(DbContextOptions<ClyvoVetDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tutor> Tutores { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<EventoClinico> EventosClinicos { get; set; }

    public DbSet<Lembrete> Lembretes { get; set; }
}