using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : Controller
{
    private readonly AppDbContext _context;

    public AlunoController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Alunos);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Aluno aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

        if (aluno == null) return BadRequest("Aluno nao encontrado");
        
        return Ok(aluno);
    }

    [HttpPost]
    public IActionResult Post(Aluno aluno)
    {
        try{
            _context.Add(aluno);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o aluno.");
        }
        return Ok(aluno);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, Aluno aluno)
    {
        var existingEntity = _context.Alunos.Find(id);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).State = EntityState.Detached;
        } else BadRequest("Aluno não encontrado");

        try
        {
            // Agora pode fazer a atualização
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o aluno.");
        }
        
        return Ok(aluno);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Aluno aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
        if (aluno == null) return NotFound("Aluno não encontrado");
        try
        {
            _context.Remove(aluno);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o aluno.");
        }

        return Ok("Aluno apagado com sucesso");
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Aluno aluno)
    {
        var existingEntity = _context.Alunos.Find(id);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).State = EntityState.Detached;
        } else BadRequest("Aluno não encontrado");

        try
        {
            // Agora pode fazer a atualização
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o aluno.");
        }
        
        return Ok(aluno);
    }
}