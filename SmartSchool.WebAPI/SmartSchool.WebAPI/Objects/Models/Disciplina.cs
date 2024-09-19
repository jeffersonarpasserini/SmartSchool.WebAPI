using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace SmartSchool.WebAPI.Models;

[Table("disciplina")]
public class Disciplina
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("nome")]
    public string Nome { get; set; }
    
    [Column("cargahoraria")]
    public int CargaHoraria { get; set; }
    
    
    [Column("prerequisitoid")]
    public int? PrerequisitoId { get; set; }
    
    [JsonIgnore][ForeignKey("PrerequisitoId")]
    public Disciplina? Prerequisito { get; set; }
    
    [Column("cursoid")]
    public int CursoId { get; set; }
    
    [JsonIgnore][ForeignKey("CursoId")] 
    public Curso Curso { get; set; }
    
     
    [Column("professorid")]
    public int ProfessorId { get; set; }
    
    [JsonIgnore][ForeignKey("ProfessorId")] 
    public Professor Professor { get; set; }

    public IEnumerable<AlunoDisciplina>? AlunosDisciplinas { get; set; }
    
    public Disciplina() { }

    public Disciplina(int id, string nome, int cargaHoraria, int cursoId, int professorId, int? preRequisito)
    {
        Id = id;
        Nome = nome;
        CargaHoraria = cargaHoraria;
        CursoId = cursoId;
        ProfessorId = professorId;
        PrerequisitoId = preRequisito;
    }
}