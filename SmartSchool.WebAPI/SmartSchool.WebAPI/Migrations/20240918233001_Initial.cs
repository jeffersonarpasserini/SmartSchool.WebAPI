using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    sobrenome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    datanascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    datainicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    datafim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "curso",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professor",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    sobrenome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    datainicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    datafim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "alunocurso",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    datainicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    datafim = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunocurso", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_alunocurso_aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alunocurso_curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "disciplina",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    cargahoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    prerequisitoid = table.Column<int>(type: "INTEGER", nullable: true),
                    cursoid = table.Column<int>(type: "INTEGER", nullable: false),
                    professorid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplina", x => x.id);
                    table.ForeignKey(
                        name: "FK_disciplina_curso_cursoid",
                        column: x => x.cursoid,
                        principalTable: "curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_disciplina_disciplina_prerequisitoid",
                        column: x => x.prerequisitoid,
                        principalTable: "disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_disciplina_professor_professorid",
                        column: x => x.professorid,
                        principalTable: "professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alunodisciplina",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    datainicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    datafim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    nota = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunodisciplina", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_alunodisciplina_aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alunodisciplina_disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "aluno",
                columns: new[] { "id", "ativo", "cpf", "datafim", "datainicio", "datanascimento", "matricula", "nome", "sobrenome", "telefone" },
                values: new object[,]
                {
                    { 1, true, "11111111111", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(6400), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Marta", "Kent", "33225555" },
                    { 2, true, "22222222222", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(6415), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Paula", "Isabela", "3354288" },
                    { 3, true, "33333333333", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(6417), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Laura", "Antonia", "55668899" },
                    { 4, true, "44444444444", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(6418), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Luiza", "Maria", "6565659" },
                    { 5, true, "55555555555", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(6419), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lucas", "Machado", "565685415" },
                    { 6, true, "66666666666", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(6422), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Pedro", "Alvares", "456454545" },
                    { 7, true, "77777777777", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(6423), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "curso",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1, "Ciencia da Computacao" },
                    { 2, "Física" },
                    { 3, "Sistemas de Informação" },
                    { 4, "Análise e Desenvolvimento de Sistemas" }
                });

            migrationBuilder.InsertData(
                table: "professor",
                columns: new[] { "id", "ativo", "cpf", "datafim", "datainicio", "matricula", "nome", "sobrenome" },
                values: new object[,]
                {
                    { 1, true, "11111111111", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(9125), 111, "Lauro", "Martins" },
                    { 2, true, "11111111111", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(9137), 111, "Roberto", "Martins" },
                    { 3, true, "11111111111", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(9138), 111, "Ronaldo", "Martins" },
                    { 4, true, "11111111111", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(9139), 111, "Rodrigo", "Martins" },
                    { 5, true, "11111111111", null, new DateTime(2024, 9, 18, 20, 30, 1, 98, DateTimeKind.Local).AddTicks(9139), 111, "Alexandre", "Martins" }
                });

            migrationBuilder.InsertData(
                table: "alunocurso",
                columns: new[] { "AlunoId", "CursoId", "datafim", "datainicio" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, null, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, null, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "disciplina",
                columns: new[] { "id", "cargahoraria", "cursoid", "nome", "prerequisitoid", "professorid" },
                values: new object[,]
                {
                    { 1, 80, 1, "Matemática", null, 1 },
                    { 2, 80, 2, "Física", null, 2 },
                    { 3, 80, 3, "Português", null, 3 },
                    { 4, 80, 4, "Inglês", null, 4 },
                    { 5, 160, 4, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "alunodisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "datafim", "datainicio", "nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8913), null },
                    { 1, 4, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8920), null },
                    { 1, 5, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8921), null },
                    { 2, 1, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8922), null },
                    { 2, 2, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8923), null },
                    { 2, 5, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8925), null },
                    { 3, 1, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8926), null },
                    { 3, 2, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8927), null },
                    { 3, 3, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8928), null },
                    { 4, 1, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8929), null },
                    { 4, 4, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8930), null },
                    { 4, 5, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8931), null },
                    { 5, 4, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8932), null },
                    { 5, 5, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8933), null },
                    { 6, 1, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8933), null },
                    { 6, 2, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8934), null },
                    { 6, 3, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8935), null },
                    { 6, 4, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8937), null },
                    { 7, 1, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8938), null },
                    { 7, 2, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8938), null },
                    { 7, 3, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8939), null },
                    { 7, 4, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8940), null },
                    { 7, 5, null, new DateTime(2024, 9, 18, 20, 30, 1, 99, DateTimeKind.Local).AddTicks(8941), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_alunocurso_CursoId",
                table: "alunocurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_alunodisciplina_DisciplinaId",
                table: "alunodisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_disciplina_cursoid",
                table: "disciplina",
                column: "cursoid");

            migrationBuilder.CreateIndex(
                name: "IX_disciplina_prerequisitoid",
                table: "disciplina",
                column: "prerequisitoid");

            migrationBuilder.CreateIndex(
                name: "IX_disciplina_professorid",
                table: "disciplina",
                column: "professorid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alunocurso");

            migrationBuilder.DropTable(
                name: "alunodisciplina");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "disciplina");

            migrationBuilder.DropTable(
                name: "curso");

            migrationBuilder.DropTable(
                name: "professor");
        }
    }
}
