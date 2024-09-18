using Microsoft.AspNetCore.Components.Web;

namespace SmartSchool.WebAPI.Models;

public class Aluno
{
    public int Id { get; set; }
    public int Matricula { get; set; }
    public string Cpf { get; set; }
    
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public DateTime DataInicio { get; set; } = DateTime.Now;
    public DateTime? DataFim { get; set; } = null;
    public bool Ativo { get; set; } = true;
    public IEnumerable<AlunoDisciplina>? AlunosDisciplinas { get; set; }

    public Aluno() { }

    public Aluno(int id, int matricula, string cpf, string nome, string sobrenome, string telefone, DateTime dataNascimento)
    {
        Id = id;
        Matricula = matricula;
        Cpf = cpf;
        Nome = nome;
        Sobrenome = sobrenome;
        Telefone = telefone;
        DataNascimento = dataNascimento;
    }
    
}