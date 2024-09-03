using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : Controller
{
    public List<Aluno> Alunos = new List<Aluno>()
    {
        new Aluno()
        {
            Id = 1,
            Nome = "Marcos",
            Sobrenome = "Jose",
            Telefone = "1111111"
        },
        new Aluno()
        {
            Id = 2,
            Nome = "Joao",
            Sobrenome = "Jose",
            Telefone = "2222222"
        },
        new Aluno()
        {
            Id = 3,
            Nome = "Mauro",
            Sobrenome = "Jose",
            Telefone = "3333333"
        }
    };
        
    public AlunoController()
    {
        
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Alunos);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Aluno aluno = Alunos.FirstOrDefault(a => a.Id == id);

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