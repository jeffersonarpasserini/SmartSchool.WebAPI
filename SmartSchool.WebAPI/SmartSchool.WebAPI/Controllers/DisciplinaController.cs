using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisciplinaController : Controller
{

    
    public DisciplinaController(){}


    [HttpGet]
    public IActionResult Get()
    {
        return Ok("reposta lista de disciplina");
    }
}