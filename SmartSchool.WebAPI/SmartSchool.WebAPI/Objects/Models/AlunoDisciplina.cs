using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SmartSchool.WebAPI.Models;

[Table("alunodisciplina")]
public class AlunoDisciplina
{

    [ForeignKey("alunoid")]
    public int AlunoId { get; set; }
    [JsonIgnore] public Aluno Aluno { get; set; }
    [ForeignKey("disciplinaid")]
    public int DisciplinaId { get; set; }
    [JsonIgnore] public Disciplina Disciplina { get; set; }

    [Column("datainicio")]
    public DateTime DataInicio { get; set; }
    
    [Column("datafim")]
    public DateTime? DataFim { get; set; }
    
    [Column("nota")]
    public int? Nota { get; set; }
    
    public AlunoDisciplina(){ }

    public AlunoDisciplina(int alunoId, int disciplinaId, DateTime dataInicio)
    {
        AlunoId = alunoId;
        DisciplinaId = disciplinaId;
        DataInicio = dataInicio;
        DataFim = null;
    }
}