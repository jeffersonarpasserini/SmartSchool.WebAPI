using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data.Builders
{
    public class ProfessorBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configura a chave primária
            modelBuilder.Entity<Professor>().HasKey(p => p.Id);

            // Configura as propriedades
            modelBuilder.Entity<Professor>().Property(p => p.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Professor>().Property(p => p.Sobrenome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Professor>().Property(p => p.Matricula).IsRequired();
            modelBuilder.Entity<Professor>().Property(p => p.Cpf).HasMaxLength(11).IsRequired();

            // Mapeamento de DataInicio e DataFim
            modelBuilder.Entity<Professor>()
                .Property(p => p.DataInicio)
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.DataFim)
                .HasColumnType("date")
                .IsRequired(false);

            // Relacionamento: Professor -> Disciplina (um para muitos)
            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Disciplinas)
                .WithOne(d => d.Professor)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Adicionar dados iniciais
            modelBuilder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, "Lauro", "Martins", 111, "11111111111"),
                    new Professor(2, "Roberto", "Martins", 111, "11111111111"),
                    new Professor(3, "Ronaldo", "Martins", 111, "11111111111"),
                    new Professor(4, "Rodrigo", "Martins", 111, "11111111111"),
                    new Professor(5, "Alexandre", "Martins", 111, "11111111111"),
                });
        }
    }
}