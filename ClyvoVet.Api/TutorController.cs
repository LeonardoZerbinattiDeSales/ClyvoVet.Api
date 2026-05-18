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
    
    [HttpPost]
    public async Task<IActionResult> CriarTutor(CreateTutorDto dto)
    {
        var tutor = new Tutor(dto.Nome, dto.Email, dto.Telefone);

        _context.Tutores.Add(tutor);

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
}