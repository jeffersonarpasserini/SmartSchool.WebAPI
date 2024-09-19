using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.WebAPI.Models;

[Table("professor")]
public class Professor
{
    [Column("id")]
    public int Id { get; set; }
    [Column("nome")]
    public string Nome { get; set; }
    [Column("sobrenome")]
    public string Sobrenome { get; set; }
    [Column("matricula")]
    public int Matricula { get; set; }
    [Column("cpf")]
    public string Cpf { get; set; }
    [Column("datainicio")]
    public DateTime DataInicio { get; set; }
    [Column("datafim")]
    public DateTime? DataFim { get; set; }
    [Column("ativo")]
    public bool Ativo { get; set; } = true;
    public IEnumerable<Disciplina>? Disciplinas { get; set; }

    public Professor() { }

    public Professor(int id, string nome, string sobrenome, int matricula, string cpf)
    {
        Id = id;
        Nome = nome;
        Sobrenome = sobrenome;
        Matricula = matricula;
        Cpf = cpf;
        DataInicio = DateTime.Now;
        DataFim = null;
    }
}