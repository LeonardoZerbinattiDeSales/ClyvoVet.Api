using ClyvoVet.Application.DTOs;
using ClyvoVet.Domain.Entities;
using ClyvoVet.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoVet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TutorController : ControllerBase
{
    private readonly ClyvoVetDbContext _context;

    public TutorController(ClyvoVetDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTutores()
    {
        var tutores = await _context.Tutores
            .Select(t => new
            {
                t.Id,
                t.Nome,
                t.Email,
                t.Telefone,
                t.CriadoEm,
                t.Ativo,
                Pets = t.Pets.Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Especie,
                    p.Raca,
                    p.DataNascimento
                })
            })
            .ToListAsync();

        return Ok(tutores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarTutorPorId(Guid id)
    {
        var tutor = await _context.Tutores
            .Where(t => t.Id == id)
            .Select(t => new
            {
                t.Id,
                t.Nome,
                t.Email,
                t.Telefone,
                t.CriadoEm,
                t.Ativo,
                Pets = t.Pets.Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Especie,
                    p.Raca,
                    p.DataNascimento
                })
            })
            .FirstOrDefaultAsync();

        if (tutor == null)
        {
            return NotFound("Tutor não encontrado.");
        }

        return Ok(tutor);
    }

    [HttpPost]
    public async Task<IActionResult> CriarTutor(CreateTutorDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome) ||
            string.IsNullOrWhiteSpace(dto.Email) ||
            string.IsNullOrWhiteSpace(dto.Telefone))
        {
            return BadRequest("Nome, email e telefone são obrigatórios.");
        }

        var tutor = new Tutor(dto.Nome, dto.Email, dto.Telefone);

        _context.Tutores.Add(tutor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarTutorPorId), new { id = tutor.Id }, new
        {
            tutor.Id,
            tutor.Nome,
            tutor.Email,
            tutor.Telefone,
            tutor.CriadoEm,
            tutor.Ativo
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTutor(Guid id, CreateTutorDto dto)
    {
        var tutor = await _context.Tutores.FindAsync(id);

        if (tutor == null)
        {
            return NotFound("Tutor não encontrado.");
        }

        tutor.AtualizarDados(dto.Nome, dto.Email, dto.Telefone);

        await _context.SaveChangesAsync();

        return Ok(new
        {
            tutor.Id,
            tutor.Nome,
            tutor.Email,
            tutor.Telefone,
            tutor.CriadoEm,
            tutor.Ativo
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarTutor(Guid id)
    {
        var tutor = await _context.Tutores.FindAsync(id);

        if (tutor == null)
        {
            return NotFound("Tutor não encontrado.");
        }

        _context.Tutores.Remove(tutor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}