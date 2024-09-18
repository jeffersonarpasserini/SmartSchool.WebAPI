using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data.Builders
{
    public class AlunoDisciplinaBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configurando a chave composta AlunoId + DisciplinaId
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

            // Propriedades adicionais
            modelBuilder.Entity<AlunoDisciplina>().Property(ad => ad.DataInicio).IsRequired();
            modelBuilder.Entity<AlunoDisciplina>().Property(ad => ad.Nota);

            // Dados iniciais
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
}