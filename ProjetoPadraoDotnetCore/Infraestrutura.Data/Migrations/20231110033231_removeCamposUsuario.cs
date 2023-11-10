using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class removeCamposUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoRecuperarSenha",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataRecuperacaoSenha",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "NomeMae",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "NomePai",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TentativasRecuperarSenha",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoRecuperarSenha",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRecuperacaoSenha",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeMae",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomePai",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TentativasRecuperarSenha",
                table: "Usuario",
                type: "int",
                nullable: true);
        }
    }
}
