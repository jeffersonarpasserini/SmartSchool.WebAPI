using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data;

public class AppDBContext : DbContext
{
    //recebe a conexão do Startup
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){}
    
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Disciplina> Disciplinas { get; set; }
    public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Aluno Entitiy
        //AlunoBuilder.Build(modelBuilder);

        modelBuilder.Entity<AlunoDisciplina>().HasKey(AD => new {AD.AlunoId, AD.DisciplinaId});

    }
    
}