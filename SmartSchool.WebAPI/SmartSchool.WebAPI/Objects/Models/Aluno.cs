using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components.Web;

namespace SmartSchool.WebAPI.Models;

[Table("aluno")]
public class Aluno
{
    [Column("id")]
    public int Id { get; set; }
    [Column("matricula")]
    public int Matricula { get; set; }
    [Column("cpf")]
    public string Cpf { get; set; }
    [Column("nome")]
    public string Nome { get; set; }
    [Column("sobrenome")]
    public string Sobrenome { get; set; }
    [Column("telefone")]
    public string Telefone { get; set; }
    [Column("datanascimento")]
    public DateTime DataNascimento { get; set; }
    [Column("datainicio")]
    public DateTime DataInicio { get; set; }
    [Column("datafim")]
    public DateTime? DataFim { get; set; }
    [Column("ativo")]
    public bool Ativo { get; set; } = true;
    public IEnumerable<AlunoDisciplina>? AlunosDisciplinas { get; set; }
    public IEnumerable<AlunoCurso>? AlunosCursos { get; set; }

    public Aluno()
    {
        
    }

    public Aluno(int id, int matricula, string cpf, string nome, string sobrenome, string telefone, DateTime dataNascimento)
    {
        Id = id;
        Matricula = matricula;
        Cpf = cpf;
        Nome = nome;
        Sobrenome = sobrenome;
        Telefone = telefone;
        DataNascimento = dataNascimento;
        DataInicio = DateTime.Now;
        DataFim = null;
    }
    
}