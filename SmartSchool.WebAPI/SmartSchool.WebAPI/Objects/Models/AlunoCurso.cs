using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SmartSchool.WebAPI.Models;

public class AlunoCurso
{
    [ForeignKey("alunoid")]
    public int AlunoId { get; set; }
    [JsonIgnore] public Aluno Aluno { get; set; }
    
    [ForeignKey("cursoid")]
    public int CursoId { get; set; }
    [JsonIgnore] public Curso Curso { get; set; }

    [Column("datainicio")]
    public DateTime DataInicio { get; set; } = DateTime.Now;
    [Column("datafim")]
    public DateTime? DataFim { get; set; }
    
    public AlunoCurso(){ }

    public AlunoCurso(int alunoId, int cursoId)
    {
        AlunoId = alunoId;
        CursoId = cursoId;
    }
}