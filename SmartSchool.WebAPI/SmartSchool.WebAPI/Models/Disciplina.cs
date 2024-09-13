using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace SmartSchool.WebAPI.Models;

public class Disciplina
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int CargaHoraria { get; set; }

    public int? PrerequisitoId { get; set; }
    [JsonIgnore] public Disciplina Prerequisito { get; set; } = null;
    
    public int CursoId { get; set; }
    [JsonIgnore] public Curso Curso { get; set; }
    
    public int ProfessorId { get; set; }
    [JsonIgnore] public Professor Professor { get; set; }

    public IEnumerable<AlunoDisciplina>? AlunosDisciplinas { get; set; }
    
    public Disciplina() { }

    public Disciplina(int id, string nome, int cargaHoraria, int cursoId, int professorId)
    {
        Id = id;
        Nome = nome;
        CargaHoraria = cargaHoraria;
        CursoId = cursoId;
        ProfessorId = professorId;
    }
}