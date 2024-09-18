using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data;

public class AppDbContext : DbContext
{
    //recebe a conexão do Startup
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Disciplina> Disciplinas { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
    public DbSet<AlunoCurso> AlunosCursos { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Aluno Entitiy
        //AlunoBuilder.Build(modelBuilder);

        modelBuilder.Entity<AlunoDisciplina>().HasKey(AD => new {AD.AlunoId, AD.DisciplinaId});
        modelBuilder.Entity<AlunoCurso>().HasKey(AC => new { AC.AlunoId, AC.CursoId });
    
    
        modelBuilder.Entity<Professor>()
            .HasData(new List<Professor>(){
                new Professor(1, "Lauro", "Martins", 111, "11111111111"),
                new Professor(2, "Roberto", "Martins", 111, "11111111111"),
                new Professor(3, "Ronaldo", "Martins", 111, "11111111111"),
                new Professor(4, "Rodrigo", "Martins", 111, "11111111111"),
                new Professor(5, "Alexandre", "Martins", 111, "11111111111"),
            });
        
        modelBuilder.Entity<Curso>()
            .HasData(new List<Curso>{
                new Curso(1, "Ciencia da Computacao"),
                new Curso(2, "Física"),
                new Curso(3, "Sistemas de Informação"),
                new Curso(4, "Análise e Desenvolvimento de Sistemas")
            });
        
        modelBuilder.Entity<Disciplina>()
            .HasData(new List<Disciplina>{
                new Disciplina(1, "Matemática", 80,1, 1),
                new Disciplina(2, "Física", 80, 2, 2),
                new Disciplina(3, "Português", 80, 3, 3),
                new Disciplina(4, "Inglês", 80, 4, 4),
                new Disciplina(5, "Programação", 160, 4, 5)
            });

        modelBuilder.Entity<Aluno>()
            .HasData(new List<Aluno>()
            {
                new Aluno(1, 11, "11111111111", "Marta", "Kent", "33225555", new DateTime(1985, 5, 1)),
                new Aluno(2, 12, "22222222222", "Paula", "Isabela", "3354288", new DateTime(1985, 5, 1)),
                new Aluno(3, 13, "33333333333", "Laura", "Antonia", "55668899", new DateTime(1985, 5, 1)),
                new Aluno(4, 14, "44444444444", "Luiza", "Maria", "6565659", new DateTime(1985, 5, 1)),
                new Aluno(5, 15, "55555555555", "Lucas", "Machado", "565685415", new DateTime(1985, 5, 1)),
                new Aluno(6, 16, "66666666666", "Pedro", "Alvares", "456454545", new DateTime(1985, 5, 1)),
                new Aluno(7, 17, "77777777777", "Paulo", "José", "9874512", new DateTime(1985, 5, 1))
            });


        modelBuilder.Entity<AlunoDisciplina>()
            .HasData(new List<AlunoDisciplina>() {
                new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
            });
    }
}