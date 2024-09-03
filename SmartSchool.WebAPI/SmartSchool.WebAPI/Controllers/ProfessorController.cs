using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessorController : Controller
{
    public ProfessorController()
    {
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("reposta lista de professor");
    }
}