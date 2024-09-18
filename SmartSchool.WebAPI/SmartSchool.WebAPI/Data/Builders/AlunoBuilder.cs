using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data.Builders
{
    public class AlunoBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configura a chave primária
            modelBuilder.Entity<Aluno>().HasKey(a => a.Id);

            // Configura as propriedades com restrições adicionais
            modelBuilder.Entity<Aluno>().Property(a => a.Matricula).IsRequired();
            modelBuilder.Entity<Aluno>().Property(a => a.Cpf).HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Aluno>().Property(a => a.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Aluno>().Property(a => a.Sobrenome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Aluno>().Property(a => a.Telefone).HasMaxLength(15);
            modelBuilder.Entity<Aluno>().Property(a => a.DataNascimento).IsRequired();
            modelBuilder.Entity<Aluno>().Property(a => a.Ativo).IsRequired();

            // Relacionamento: Aluno -> AlunoDisciplina (um para muitos)
            modelBuilder.Entity<Aluno>()
                .HasMany(a => a.AlunosDisciplinas)
                .WithOne(ad => ad.Aluno)
                .HasForeignKey(ad => ad.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Aqui você poderia adicionar inserções iniciais se necessário
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
        }
    }
}