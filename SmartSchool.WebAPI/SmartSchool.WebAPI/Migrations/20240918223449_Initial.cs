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
                name: "Cursos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
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
                    table.PrimaryKey("PK_Professores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    datainicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    datafim = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    cargahoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "INTEGER", nullable: true),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
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
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1, "Ciencia da Computacao" },
                    { 2, "Física" },
                    { 3, "Sistemas de Informação" },
                    { 4, "Análise e Desenvolvimento de Sistemas" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "id", "ativo", "cpf", "datafim", "datainicio", "matricula", "nome", "sobrenome" },
                values: new object[,]
                {
                    { 1, true, "11111111111", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(4599), 111, "Lauro", "Martins" },
                    { 2, true, "11111111111", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(4606), 111, "Roberto", "Martins" },
                    { 3, true, "11111111111", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(4607), 111, "Ronaldo", "Martins" },
                    { 4, true, "11111111111", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(4608), 111, "Rodrigo", "Martins" },
                    { 5, true, "11111111111", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(4609), 111, "Alexandre", "Martins" }
                });

            migrationBuilder.InsertData(
                table: "aluno",
                columns: new[] { "id", "ativo", "cpf", "datafim", "datainicio", "datanascimento", "matricula", "nome", "sobrenome", "telefone" },
                values: new object[,]
                {
                    { 1, true, "11111111111", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(2781), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Marta", "Kent", "33225555" },
                    { 2, true, "22222222222", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(2797), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Paula", "Isabela", "3354288" },
                    { 3, true, "33333333333", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(2798), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Laura", "Antonia", "55668899" },
                    { 4, true, "44444444444", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(2799), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Luiza", "Maria", "6565659" },
                    { 5, true, "55555555555", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(2799), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lucas", "Machado", "565685415" },
                    { 6, true, "66666666666", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(2801), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Pedro", "Alvares", "456454545" },
                    { 7, true, "77777777777", null, new DateTime(2024, 9, 18, 19, 34, 49, 251, DateTimeKind.Local).AddTicks(2802), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "AlunosCursos",
                columns: new[] { "AlunoId", "CursoId", "datafim", "datainicio" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, null, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, null, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "id", "cargahoraria", "CursoId", "nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 80, 1, "Matemática", null, 1 },
                    { 2, 80, 2, "Física", null, 2 },
                    { 3, 80, 3, "Português", null, 3 },
                    { 4, 80, 4, "Inglês", null, 4 },
                    { 5, 160, 4, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "datafim", "datainicio", "nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1091), null },
                    { 1, 4, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1098), null },
                    { 1, 5, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1099), null },
                    { 2, 1, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1100), null },
                    { 2, 2, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1100), null },
                    { 2, 5, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1102), null },
                    { 3, 1, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1102), null },
                    { 3, 2, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1103), null },
                    { 3, 3, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1104), null },
                    { 4, 1, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1105), null },
                    { 4, 4, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1105), null },
                    { 4, 5, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1130), null },
                    { 5, 4, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1131), null },
                    { 5, 5, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1132), null },
                    { 6, 1, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1132), null },
                    { 6, 2, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1133), null },
                    { 6, 3, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1134), null },
                    { 6, 4, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1135), null },
                    { 7, 1, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1136), null },
                    { 7, 2, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1136), null },
                    { 7, 3, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1137), null },
                    { 7, 4, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1138), null },
                    { 7, 5, null, new DateTime(2024, 9, 18, 19, 34, 49, 252, DateTimeKind.Local).AddTicks(1139), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
