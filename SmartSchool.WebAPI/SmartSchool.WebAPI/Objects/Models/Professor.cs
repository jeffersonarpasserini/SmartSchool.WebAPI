namespace SmartSchool.WebAPI.Models;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public int Matricula { get; set; }
    public string Cpf { get; set; }
    public DateTime DataInicio { get; set; } = DateTime.Now;
    public DateTime? DataFim { get; set; } = null;
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
    }
}