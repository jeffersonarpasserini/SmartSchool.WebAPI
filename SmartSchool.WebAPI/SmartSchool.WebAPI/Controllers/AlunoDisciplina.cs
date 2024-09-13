using System.Text.Json.Serialization;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers;

public class AlunoDisciplina
{
    public int AlunoId { get; set; }
    [JsonIgnore]
    public Aluno aluno { get; set; }
    public int DisciplinaId { get; set; }
    [JsonIgnore]
    public Disciplina disciplina { get; set; }

    public AlunoDisciplina() { }

    public AlunoDisciplina(int alunoId, int disciplinaId)
    {
        AlunoId = alunoId;
        DisciplinaId = disciplinaId;
    }
}