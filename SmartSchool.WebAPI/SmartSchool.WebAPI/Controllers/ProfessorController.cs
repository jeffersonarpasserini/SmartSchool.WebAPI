using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessorController : Controller
{
    private readonly AppDbContext _context;

    public ProfessorController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Professores);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Professor professor = _context.Professores.FirstOrDefault(a => a.Id == id);

        if (professor == null) return BadRequest("Professor nao encontrado");
        
        return Ok(professor);
    }

    [HttpPost]
    public IActionResult Post(Professor professor)
    {
        try{
            _context.Add(professor);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o Professor.");
        }
        return Ok(professor);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, Professor professor)
    {
        var existingEntity = _context.Professores.Find(id);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).State = EntityState.Detached;
        } else BadRequest("Professor não encontrado");

        try
        {
            // Agora pode fazer a atualização
            _context.Professores.Update(professor);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o Professor.");
        }
        
        return Ok(professor);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Professor professor = _context.Professores.FirstOrDefault(a => a.Id == id);
        if (professor == null) return NotFound("Professor não encontrado");
        try
        {
            _context.Remove(professor);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o Professor.");
        }

        return Ok("Professor apagado com sucesso");
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Professor professor)
    {
        var existingEntity = _context.Professores.Find(id);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).State = EntityState.Detached;
        } else BadRequest("Professor não encontrado");

        try
        {
            // Agora pode fazer a atualização
            _context.Professores.Update(professor);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o Professor.");
        }
        
        return Ok(professor);
    }
}