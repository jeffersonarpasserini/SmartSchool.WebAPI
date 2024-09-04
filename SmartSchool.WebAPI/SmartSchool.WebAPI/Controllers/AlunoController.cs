using Microsoft.AspNetCore.Mvc;
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
        return Ok("Aluno gravado com sucesso");
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, Aluno aluno)
    {
        return Ok("Aluno alterado com sucesso");
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok("Aluno apagado com sucesso");
    }
    
    [HttpPatch]
    public IActionResult Patch(int id)
    {
        return Ok("Aluno alterado com sucesso");
    }
    
    
}