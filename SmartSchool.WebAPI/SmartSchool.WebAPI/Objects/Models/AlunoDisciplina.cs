using System.Text.Json.Serialization;

namespace SmartSchool.WebAPI.Models;

public class AlunoDisciplina
{

    public int AlunoId { get; set; }
    [JsonIgnore] public Aluno Aluno { get; set; }
    public int DisciplinaId { get; set; }
    [JsonIgnore] public Disciplina Disciplina { get; set; }

    public DateTime DataInicio { get; set; } = DateTime.Now;
    public DateTime? DataFim { get; set; }
    public int? Nota { get; set; }
    
    public AlunoDisciplina(){ }

    public AlunoDisciplina(int alunoId, int disciplinaId)
    {
        AlunoId = alunoId;
        DisciplinaId = disciplinaId;
    }
}