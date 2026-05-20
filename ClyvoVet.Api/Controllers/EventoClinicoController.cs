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

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarEventoPorId(Guid id)
    {
        var evento = await _context.EventosClinicos
            .Where(e => e.Id == id)
            .Select(e => new
            {
                e.Id,
                e.Tipo,
                e.Descricao,
                e.DataEvento,
                e.PetId
            })
            .FirstOrDefaultAsync();

        if (evento == null)
            return NotFound("Evento clínico não encontrado.");

        return Ok(evento);
    }

    [HttpPost]
    public async Task<IActionResult> CriarEvento(CreateEventoClinicoDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Tipo) ||
            string.IsNullOrWhiteSpace(dto.Descricao))
        {
            return BadRequest("Tipo e descrição são obrigatórios.");
        }

        var petExiste = await _context.Pets.AnyAsync(p => p.Id == dto.PetId);

        if (!petExiste)
            return NotFound("Pet não encontrado.");

        var evento = new EventoClinico(
            dto.Tipo,
            dto.Descricao,
            dto.DataEvento,
            dto.PetId
        );

        _context.EventosClinicos.Add(evento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarEventoPorId), new { id = evento.Id }, new
        {
            evento.Id,
            evento.Tipo,
            evento.Descricao,
            evento.DataEvento,
            evento.PetId
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarEvento(Guid id, CreateEventoClinicoDto dto)
    {
        var evento = await _context.EventosClinicos.FindAsync(id);

        if (evento == null)
            return NotFound("Evento clínico não encontrado.");

        if (string.IsNullOrWhiteSpace(dto.Tipo) ||
            string.IsNullOrWhiteSpace(dto.Descricao))
        {
            return BadRequest("Tipo e descrição são obrigatórios.");
        }

        var petExiste = await _context.Pets.AnyAsync(p => p.Id == dto.PetId);

        if (!petExiste)
            return NotFound("Pet não encontrado.");

        evento.AtualizarDados(
            dto.Tipo,
            dto.Descricao,
            dto.DataEvento,
            dto.PetId
        );

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarEvento(Guid id)
    {
        var evento = await _context.EventosClinicos.FindAsync(id);

        if (evento == null)
            return NotFound("Evento clínico não encontrado.");

        _context.EventosClinicos.Remove(evento);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}