using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data.Builders
{
    public class DisciplinaBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configura a chave primária
            modelBuilder.Entity<Disciplina>().HasKey(d => d.Id);

            // Configura as propriedades
            modelBuilder.Entity<Disciplina>().Property(d => d.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Disciplina>().Property(d => d.CargaHoraria).IsRequired();

            // Relacionamento: Disciplina -> Curso (muitos para um)
            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Curso)
                .WithMany(c => c.Disciplinas)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: Disciplina -> Professor (muitos para um)
            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Professor)
                .WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: Disciplina -> Prerequisito (auto-relacionamento)
            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Prerequisito)
                .WithMany()
                .HasForeignKey(d => d.PrerequisitoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento: Disciplina -> AlunoDisciplina (um para muitos)
            modelBuilder.Entity<Disciplina>()
                .HasMany(d => d.AlunosDisciplinas)
                .WithOne(ad => ad.Disciplina)
                .HasForeignKey(ad => ad.DisciplinaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Adicionar dados iniciais (opcional)
            modelBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 80,1, 1, null),
                    new Disciplina(2, "Física", 80, 2, 2, 1),
                    new Disciplina(3, "Português", 80, 3, 3, null),
                    new Disciplina(4, "Inglês", 80, 4, 4, null),
                    new Disciplina(5, "Programação", 160, 4, 5, 1)
                });
        }
    }
}
