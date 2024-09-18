using System.Text.Json.Serialization;

namespace SmartSchool.WebAPI.Models;

public class AlunoCurso
{
    
    public int AlunoId { get; set; }
    [JsonIgnore] public Aluno Aluno { get; set; }
    public int CursoId { get; set; }
    [JsonIgnore] public Curso Curso { get; set; }

    public DateTime DataInicio { get; set; } = DateTime.Now;
    public DateTime? DataFim { get; set; }
    
    public AlunoCurso(){ }

    public AlunoCurso(int alunoId, int cursoId)
    {
        AlunoId = alunoId;
        CursoId = cursoId;
    }
}