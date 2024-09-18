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
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "INTEGER", nullable: true),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Nota = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, "11111111111", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9389), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Marta", "Kent", "33225555" },
                    { 2, true, "22222222222", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9393), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Paula", "Isabela", "3354288" },
                    { 3, true, "33333333333", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9394), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Laura", "Antonia", "55668899" },
                    { 4, true, "44444444444", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9395), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Luiza", "Maria", "6565659" },
                    { 5, true, "55555555555", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9396), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lucas", "Machado", "565685415" },
                    { 6, true, "66666666666", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9397), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Pedro", "Alvares", "456454545" },
                    { 7, true, "77777777777", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9398), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Ciencia da Computacao" },
                    { 2, "Física" },
                    { 3, "Sistemas de Informação" },
                    { 4, "Análise e Desenvolvimento de Sistemas" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "Cpf", "DataFim", "DataInicio", "Matricula", "Nome", "Sobrenome" },
                values: new object[,]
                {
                    { 1, true, "11111111111", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9269), 111, "Lauro", "Martins" },
                    { 2, true, "11111111111", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9287), 111, "Roberto", "Martins" },
                    { 3, true, "11111111111", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9288), 111, "Ronaldo", "Martins" },
                    { 4, true, "11111111111", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9289), 111, "Rodrigo", "Martins" },
                    { 5, true, "11111111111", null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9290), 111, "Alexandre", "Martins" }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
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
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9422), null },
                    { 1, 4, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9424), null },
                    { 1, 5, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9425), null },
                    { 2, 1, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9425), null },
                    { 2, 2, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9426), null },
                    { 2, 5, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9427), null },
                    { 3, 1, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9428), null },
                    { 3, 2, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9429), null },
                    { 3, 3, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9429), null },
                    { 4, 1, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9430), null },
                    { 4, 4, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9431), null },
                    { 4, 5, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9432), null },
                    { 5, 4, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9432), null },
                    { 5, 5, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9433), null },
                    { 6, 1, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9434), null },
                    { 6, 2, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9434), null },
                    { 6, 3, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9435), null },
                    { 6, 4, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9436), null },
                    { 7, 1, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9437), null },
                    { 7, 2, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9437), null },
                    { 7, 3, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9438), null },
                    { 7, 4, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9438), null },
                    { 7, 5, null, new DateTime(2024, 9, 18, 12, 43, 5, 393, DateTimeKind.Local).AddTicks(9439), null }
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
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
