﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool.WebAPI.Data;

#nullable disable

namespace SmartSchool.WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Cpf = "11111111111",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7252),
                            DataNascimento = new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 11,
                            Nome = "Marta",
                            Sobrenome = "Kent",
                            Telefone = "33225555"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Cpf = "22222222222",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7258),
                            DataNascimento = new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 12,
                            Nome = "Paula",
                            Sobrenome = "Isabela",
                            Telefone = "3354288"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Cpf = "33333333333",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7260),
                            DataNascimento = new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 13,
                            Nome = "Laura",
                            Sobrenome = "Antonia",
                            Telefone = "55668899"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Cpf = "44444444444",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7261),
                            DataNascimento = new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 14,
                            Nome = "Luiza",
                            Sobrenome = "Maria",
                            Telefone = "6565659"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            Cpf = "55555555555",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7262),
                            DataNascimento = new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 15,
                            Nome = "Lucas",
                            Sobrenome = "Machado",
                            Telefone = "565685415"
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            Cpf = "66666666666",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7264),
                            DataNascimento = new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 16,
                            Nome = "Pedro",
                            Sobrenome = "Alvares",
                            Telefone = "456454545"
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            Cpf = "77777777777",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7265),
                            DataNascimento = new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 17,
                            Nome = "Paulo",
                            Sobrenome = "José",
                            Telefone = "9874512"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunosCursos");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Nota")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7293)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7296)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7297)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7298)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7299)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7300)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7301)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7302)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7303)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7304)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7305)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7306)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7307)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7307)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7308)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7309)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7310)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7311)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7312)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7313)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7314)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7314)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7315)
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Ciencia da Computacao"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Física"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Sistemas de Informação"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Análise e Desenvolvimento de Sistemas"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PrerequisitoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("PrerequisitoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaHoraria = 80,
                            CursoId = 1,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            CargaHoraria = 80,
                            CursoId = 2,
                            Nome = "Física",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 3,
                            CargaHoraria = 80,
                            CursoId = 3,
                            Nome = "Português",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 4,
                            CargaHoraria = 80,
                            CursoId = 4,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 5,
                            CargaHoraria = 160,
                            CursoId = 4,
                            Nome = "Programação",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            Cpf = "11111111111",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7097),
                            Matricula = 111,
                            Nome = "Lauro",
                            Sobrenome = "Martins"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            Cpf = "11111111111",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7113),
                            Matricula = 111,
                            Nome = "Roberto",
                            Sobrenome = "Martins"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            Cpf = "11111111111",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7114),
                            Matricula = 111,
                            Nome = "Ronaldo",
                            Sobrenome = "Martins"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            Cpf = "11111111111",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7115),
                            Matricula = 111,
                            Nome = "Rodrigo",
                            Sobrenome = "Martins"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            Cpf = "11111111111",
                            DataInicio = new DateTime(2024, 9, 13, 14, 51, 34, 726, DateTimeKind.Local).AddTicks(7116),
                            Matricula = 111,
                            Nome = "Alexandre",
                            Sobrenome = "Martins"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoCurso", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Disciplina", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Disciplina", "Prerequisito")
                        .WithMany()
                        .HasForeignKey("PrerequisitoId");

                    b.HasOne("SmartSchool.WebAPI.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Prerequisito");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Aluno", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Curso", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Disciplina", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Professor", b =>
                {
                    b.Navigation("Disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
