using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data.Builders
{
    public class AlunoDisciplinaBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configura chave primária composta
            modelBuilder.Entity<AlunoDisciplina>()
                .HasKey(ad => new { ad.AlunoId, ad.DisciplinaId });

            // Relacionamento: AlunoDisciplina -> Aluno (muitos para um)
            modelBuilder.Entity<AlunoDisciplina>()
                .HasOne(ad => ad.Aluno)
                .WithMany(a => a.AlunosDisciplinas)
                .HasForeignKey(ad => ad.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: AlunoDisciplina -> Disciplina (muitos para um)
            modelBuilder.Entity<AlunoDisciplina>()
                .HasOne(ad => ad.Disciplina)
                .WithMany(d => d.AlunosDisciplinas)
                .HasForeignKey(ad => ad.DisciplinaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Mapeamento de DataInicio como timestamp with time zone
            modelBuilder.Entity<AlunoDisciplina>()
                .Property(ad => ad.DataInicio)
                .HasColumnType("date")
                .IsRequired();

            // Mapeamento de DataFim como timestamp with time zone
            modelBuilder.Entity<AlunoDisciplina>()
                .Property(ad => ad.DataFim)
                .HasColumnType("date").IsRequired(false);

            // Nota opcional
            modelBuilder.Entity<AlunoDisciplina>()
                .Property(ad => ad.Nota)
                .IsRequired(false);

            // Dados iniciais
            modelBuilder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2, DataInicio = DateTime.Now},
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5, DataInicio = DateTime.Now},
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4, DataInicio = DateTime.Now },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5, DataInicio = DateTime.Now }
                });
        }
    }
}