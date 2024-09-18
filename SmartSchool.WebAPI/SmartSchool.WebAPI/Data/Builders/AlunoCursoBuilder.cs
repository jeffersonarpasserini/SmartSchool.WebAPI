using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data.Builders
{
    public class AlunoCursoBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configurando a chave composta AlunoId + CursoId
            modelBuilder.Entity<AlunoCurso>()
                .HasKey(ac => new { ac.AlunoId, ac.CursoId });

            // Relacionamento: AlunoCurso -> Aluno (muitos para um)
            modelBuilder.Entity<AlunoCurso>()
                .HasOne(ac => ac.Aluno)
                .WithMany(a => a.AlunosCursos)
                .HasForeignKey(ac => ac.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: AlunoCurso -> Curso (muitos para um)
            modelBuilder.Entity<AlunoCurso>()
                .HasOne(ac => ac.Curso)
                .WithMany(c => c.AlunosCursos)
                .HasForeignKey(ac => ac.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Propriedades adicionais
            modelBuilder.Entity<AlunoCurso>().Property(ac => ac.DataInicio).IsRequired();
            modelBuilder.Entity<AlunoCurso>().Property(ac => ac.DataFim);

            // Dados iniciais
            modelBuilder.Entity<AlunoCurso>().HasData(
                new AlunoCurso { AlunoId = 1, CursoId = 1, DataInicio = new DateTime(2021, 8, 1) },
                new AlunoCurso { AlunoId = 1, CursoId = 2, DataInicio = new DateTime(2021, 8, 1) },
                new AlunoCurso { AlunoId = 2, CursoId = 1, DataInicio = new DateTime(2021, 8, 1) }
            );
        }
    }
}