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

    [HttpPost]
    public async Task<IActionResult> CriarPet(CreatePetDto dto)
    {
        var tutorExiste = await _context.Tutores.AnyAsync(t => t.Id == dto.TutorId);

        if (!tutorExiste)
        {
            return NotFound("Tutor não encontrado.");
        }

        var pet = new Pet(dto.Nome, dto.Especie, dto.Raca, dto.DataNascimento, dto.TutorId);

        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            pet.Id,
            pet.Nome,
            pet.Especie,
            pet.Raca,
            pet.DataNascimento,
            pet.TutorId
        });
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
                p.TutorId
            })
            .ToListAsync();

        return Ok(pets);
    }
}