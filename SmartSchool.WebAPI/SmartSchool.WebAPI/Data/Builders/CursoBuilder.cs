using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data.Builders
{
    public class CursoBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configura a chave primária
            modelBuilder.Entity<Curso>().HasKey(c => c.Id);

            // Configura as propriedades com restrições adicionais
            modelBuilder.Entity<Curso>().Property(c => c.Nome).HasMaxLength(100).IsRequired();

            // Relacionamento: Curso -> Disciplinas (um para muitos)
            modelBuilder.Entity<Curso>()
                .HasMany(c => c.Disciplinas)
                .WithOne(d => d.Curso)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Adicionar dados iniciais
            modelBuilder.Entity<Curso>()
                .HasData(new List<Curso>{
                    new Curso(1, "Ciencia da Computacao"),
                    new Curso(2, "Física"),
                    new Curso(3, "Sistemas de Informação"),
                    new Curso(4, "Análise e Desenvolvimento de Sistemas")
                });
        }
    }
}