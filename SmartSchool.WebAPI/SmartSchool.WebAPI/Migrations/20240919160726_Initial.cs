using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    matricula = table.Column<int>(type: "integer", nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sobrenome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    datanascimento = table.Column<DateTime>(type: "date", nullable: false),
                    datainicio = table.Column<DateTime>(type: "date", nullable: false),
                    datafim = table.Column<DateTime>(type: "date", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "curso",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sobrenome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    matricula = table.Column<int>(type: "integer", nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    datainicio = table.Column<DateTime>(type: "date", nullable: false),
                    datafim = table.Column<DateTime>(type: "date", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "alunocurso",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "integer", nullable: false),
                    CursoId = table.Column<int>(type: "integer", nullable: false),
                    datainicio = table.Column<DateTime>(type: "date", nullable: false),
                    datafim = table.Column<DateTime>(type: "date", nullable: true)
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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cargahoraria = table.Column<int>(type: "integer", nullable: false),
                    prerequisitoid = table.Column<int>(type: "integer", nullable: true),
                    cursoid = table.Column<int>(type: "integer", nullable: false),
                    professorid = table.Column<int>(type: "integer", nullable: false)
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
                    AlunoId = table.Column<int>(type: "integer", nullable: false),
                    DisciplinaId = table.Column<int>(type: "integer", nullable: false),
                    datainicio = table.Column<DateTime>(type: "date", nullable: false),
                    datafim = table.Column<DateTime>(type: "date", nullable: true),
                    nota = table.Column<int>(type: "integer", nullable: true)
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
                    { 1, true, "11111111111", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(4298), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Marta", "Kent", "33225555" },
                    { 2, true, "22222222222", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(4310), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Paula", "Isabela", "3354288" },
                    { 3, true, "33333333333", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(4311), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Laura", "Antonia", "55668899" },
                    { 4, true, "44444444444", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(4312), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Luiza", "Maria", "6565659" },
                    { 5, true, "55555555555", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(4313), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lucas", "Machado", "565685415" },
                    { 6, true, "66666666666", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(4315), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Pedro", "Alvares", "456454545" },
                    { 7, true, "77777777777", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(4316), new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Paulo", "José", "9874512" }
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
                    { 1, true, "11111111111", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(5969), 111, "Lauro", "Martins" },
                    { 2, true, "11111111111", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(5973), 111, "Roberto", "Martins" },
                    { 3, true, "11111111111", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(5974), 111, "Ronaldo", "Martins" },
                    { 4, true, "11111111111", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(5975), 111, "Rodrigo", "Martins" },
                    { 5, true, "11111111111", null, new DateTime(2024, 9, 19, 13, 7, 25, 787, DateTimeKind.Local).AddTicks(5976), 111, "Alexandre", "Martins" }
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
                    { 3, 80, 3, "Português", null, 3 },
                    { 4, 80, 4, "Inglês", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "alunodisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "datafim", "datainicio", "nota" },
                values: new object[,]
                {
                    { 1, 4, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3746), null },
                    { 2, 1, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3748), null },
                    { 3, 1, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3752), null },
                    { 3, 3, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3754), null },
                    { 4, 1, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3755), null },
                    { 4, 4, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3756), null },
                    { 5, 4, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3758), null },
                    { 6, 1, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3759), null },
                    { 6, 3, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3761), null },
                    { 6, 4, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3762), null },
                    { 7, 1, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3763), null },
                    { 7, 3, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3764), null },
                    { 7, 4, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3765), null }
                });

            migrationBuilder.InsertData(
                table: "disciplina",
                columns: new[] { "id", "cargahoraria", "cursoid", "nome", "prerequisitoid", "professorid" },
                values: new object[,]
                {
                    { 2, 80, 2, "Física", 1, 2 },
                    { 5, 160, 4, "Programação", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "alunodisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "datafim", "datainicio", "nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3741), null },
                    { 1, 5, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3747), null },
                    { 2, 2, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3749), null },
                    { 2, 5, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3752), null },
                    { 3, 2, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3753), null },
                    { 4, 5, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3757), null },
                    { 5, 5, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3758), null },
                    { 6, 2, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3760), null },
                    { 7, 2, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3764), null },
                    { 7, 5, null, new DateTime(2024, 9, 19, 13, 7, 25, 788, DateTimeKind.Local).AddTicks(3766), null }
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
