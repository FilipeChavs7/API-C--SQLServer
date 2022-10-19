using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiProdutos.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    departamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    maximoFuncionarios = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.departamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    funcionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    departamento_id = table.Column<int>(type: "int", nullable: false),
                    data_entrada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.funcionarioId);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "departamentoId", "maximoFuncionarios", "nome" },
                values: new object[,]
                {
                    { 1, 10, "TI" },
                    { 2, 10, "Suporte" }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "funcionarioId", "data_entrada", "departamento_id", "nome" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 19, 17, 48, 28, 436, DateTimeKind.Local).AddTicks(7909), 1, "Filipe" },
                    { 2, new DateTime(2022, 10, 19, 17, 48, 28, 437, DateTimeKind.Local).AddTicks(4188), 2, "Fernando" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
