using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.WebAPI.Models;

[Table("curso")]
public class Curso
{
    [Column("id")]
    public int Id { get; set; }
    [Column("nome")]
    public string Nome { get; set; }
    public IEnumerable<Disciplina> Disciplinas { get; set; }
    public IEnumerable<AlunoCurso>? AlunosCursos { get; set; }

    public Curso() { }
    
    public Curso(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}