using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data.Builders
{
    public class AlunoCursoBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configura chave primária composta
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

            // Mapeamento de DataInicio como timestamp with time zone
            modelBuilder.Entity<AlunoCurso>()
                .Property(ac => ac.DataInicio)
                .HasColumnType("date")
                .IsRequired();

            // Mapeamento de DataFim como timestamp with time zone
            modelBuilder.Entity<AlunoCurso>()
                .Property(ac => ac.DataFim)
                .HasColumnType("date").IsRequired(false);

            // Dados iniciais
            modelBuilder.Entity<AlunoCurso>().HasData(
                new AlunoCurso { AlunoId = 1, CursoId = 1, DataInicio = new DateTime(2021, 8, 1) },
                new AlunoCurso { AlunoId = 1, CursoId = 2, DataInicio = new DateTime(2021, 8, 1) },
                new AlunoCurso { AlunoId = 2, CursoId = 1, DataInicio = new DateTime(2021, 8, 1) }
            );
        }
    }
}