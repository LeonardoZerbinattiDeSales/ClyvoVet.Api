using ClyvoVet.Application.DTOs;
using ClyvoVet.Domain.Entities;
using ClyvoVet.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClyvoVet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly ClyvoVetDbContext _context;

    public PetController(ClyvoVetDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ListarPets()
    {
        var pets = await _context.Pets
            .Select(p => new
            {
                p.Id,
                p.Nome,
                p.Especie,
                p.Raca,
                p.DataNascimento,
                Tutor = new
                {
                    p.Tutor.Id,
                    p.Tutor.Nome,
                    p.Tutor.Email
                }
            })
            .ToListAsync();

        return Ok(pets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPetPorId(Guid id)
    {
        var pet = await _context.Pets
            .Where(p => p.Id == id)
            .Select(p => new
            {
                p.Id,
                p.Nome,
                p.Especie,
                p.Raca,
                p.DataNascimento,
                Tutor = new
                {
                    p.Tutor.Id,
                    p.Tutor.Nome,
                    p.Tutor.Email
                }
            })
            .FirstOrDefaultAsync();

        if (pet == null)
            return NotFound("Pet não encontrado.");

        return Ok(pet);
    }

    [HttpPost]
    public async Task<IActionResult> CriarPet(CreatePetDto dto)
    {
        var tutor = await _context.Tutores.FindAsync(dto.TutorId);

        if (tutor == null)
            return BadRequest("Tutor não encontrado.");

        var pet = new Pet(
            dto.Nome,
            dto.Especie,
            dto.Raca,
            dto.DataNascimento,
            dto.TutorId
        );

        _context.Pets.Add(pet);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPetPorId), new { id = pet.Id }, pet);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPet(Guid id, CreatePetDto dto)
    {
        var pet = await _context.Pets.FindAsync(id);

        if (pet == null)
            return NotFound("Pet não encontrado.");

        pet.AtualizarDados(
            dto.Nome,
            dto.Especie,
            dto.Raca,
            dto.DataNascimento
        );

        await _context.SaveChangesAsync();

        return Ok(pet);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarPet(Guid id)
    {
        var pet = await _context.Pets.FindAsync(id);

        if (pet == null)
            return NotFound("Pet não encontrado.");

        _context.Pets.Remove(pet);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}