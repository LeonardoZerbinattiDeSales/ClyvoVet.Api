using ClyvoVet.Application.DTOs;
using ClyvoVet.Domain.Entities;
using ClyvoVet.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoVet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoClinicoController : ControllerBase
{
    private readonly ClyvoVetDbContext _context;

    public EventoClinicoController(ClyvoVetDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CriarEvento(CreateEventoClinicoDto dto)
    {
        var petExiste = await _context.Pets.AnyAsync(p => p.Id == dto.PetId);

        if (!petExiste)
        {
            return NotFound("Pet não encontrado.");
        }

        var evento = new EventoClinico(dto.Tipo, dto.Descricao, dto.DataEvento, dto.PetId);

        _context.EventosClinicos.Add(evento);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            evento.Id,
            evento.Tipo,
            evento.Descricao,
            evento.DataEvento,
            evento.PetId
        });
    }

    [HttpGet]
    public async Task<IActionResult> ListarEventos()
    {
        var eventos = await _context.EventosClinicos
            .Select(e => new
            {
                e.Id,
                e.Tipo,
                e.Descricao,
                e.DataEvento,
                e.PetId
            })
            .ToListAsync();

        return Ok(eventos);
    }
}