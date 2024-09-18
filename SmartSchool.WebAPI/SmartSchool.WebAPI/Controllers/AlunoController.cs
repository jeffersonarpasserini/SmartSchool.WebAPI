using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Services.Interfaces;

namespace SmartSchool.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : Controller
{
    private readonly IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
        this._alunoService = alunoService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var alunos = await _alunoService.GetAll();
        return Ok(alunos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var aluno = await _alunoService.GetById(id);
        if (aluno == null) return NotFound("Aluno não encontrado!");
        return Ok(aluno);
    }
    
    [HttpGet("/api/GetAlunoById/{id}")]
    public async Task<IActionResult> GetAlunoById(int id)
    {
        var aluno = await _alunoService.GetAlunoById(id, true);
        if (aluno == null) return NotFound("Aluno não encontrado!");
        return Ok(aluno);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Aluno aluno)
    {
        try{
            await _alunoService.Create(aluno);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar inserir um novo aluno.");
        }
        return Ok(aluno);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Aluno aluno)
    {
        try
        {
            await _alunoService.Update(aluno, id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar atualizar o aluno.");
        }
        
        return Ok(aluno);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _alunoService.Remove(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o aluno.");
        }

        return Ok("Aluno apagado com sucesso");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, Aluno aluno)
    {
        try
        {
            await _alunoService.Update(aluno, id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao tentar remover o aluno.");
        }
        
        return Ok(aluno);
    }
}