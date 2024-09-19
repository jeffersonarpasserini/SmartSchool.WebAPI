using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartSchool.WebAPI.Data.Builders;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data;

public class AppDbContext : DbContext
{
    //recebe a conexão do Startup
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Disciplina> Disciplinas { get; set; }
    public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
    public DbSet<AlunoCurso> AlunosCursos { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Chamando Builder para configurar as entidades
        AlunoBuilder.Build(modelBuilder);
        ProfessorBuilder.Build(modelBuilder);
        CursoBuilder.Build(modelBuilder);
        DisciplinaBuilder.Build(modelBuilder);
        AlunoDisciplinaBuilder.Build(modelBuilder);
        AlunoCursoBuilder.Build(modelBuilder);
    }
}