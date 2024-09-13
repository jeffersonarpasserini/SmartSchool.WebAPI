using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : Controller
{
    private readonly IAlunoRepository _repo;

    public AlunoController(IAlunoRepository repo)
    {
        this._repo = repo;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repo.Get<Aluno>());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Aluno aluno = _repo.GetById<Aluno>(id);

        if (aluno == null) return NotFound("Aluno nao encontrado");
        
        return Ok(aluno);
    }
    
    [HttpGet("/api/GetAlunoById/{id}")]
    public IActionResult GetAlunoById(int id)
    {
        Aluno aluno = _repo.GetAlunoById(id, true);

        if (aluno == null) return NotFound("Aluno nao encontrado");
        
        return Ok(aluno);
    }

    [HttpPost]
    public IActionResult Post(Aluno aluno)
    {
        try{
            _repo.Add(aluno);
            _repo.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar inserir um novo aluno.");
        }
        return Ok(aluno);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, Aluno aluno)
    {
        if(_repo.GetById<Aluno>(id) == null) return NotFound("Aluno não encontrado");
        try
        {
            _repo.Update(aluno);
            _repo.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar atualizar o aluno.");
        }
        
        return Ok(aluno);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Aluno aluno = _repo.GetById<Aluno>(id);
        if(aluno == null) return NotFound("Aluno não encontrado");
        try
        {
            _repo.Remove(aluno);
            _repo.SaveChanges();
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
        if(_repo.GetById<Aluno>(id) == null) return NotFound("Aluno não encontrado");
        try
        {
            // Agora pode fazer a atualização
            _repo.Update(aluno);
            _repo.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o aluno.");
        }
        
        return Ok(aluno);
    }
}