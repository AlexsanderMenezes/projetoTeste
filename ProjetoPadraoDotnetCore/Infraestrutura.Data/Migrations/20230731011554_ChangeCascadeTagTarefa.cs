using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class ChangeCascadeTagTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    CPF = table.Column<string>(maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: false),
                    PerfilAdministrador = table.Column<bool>(nullable: false),
                    Cep = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Cidade1 = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: true),
                    NomeMae = table.Column<string>(nullable: true),
                    NomePai = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    IdUsuarioCadastro = table.Column<int>(nullable: true),
                    CodigoRecuperarSenha = table.Column<int>(nullable: true),
                    TentativasRecuperarSenha = table.Column<int>(nullable: true),
                    DataRecuperacaoSenha = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Usuario_IdUsuarioCadastro",
                        column: x => x.IdUsuarioCadastro,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillUsuario",
                columns: table => new
                {
                    IdSkill = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillUsuario", x => x.IdSkill);
                    table.ForeignKey(
                        name: "FK_SkillUsuario_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillUsuario_IdUsuario",
                table: "SkillUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdUsuarioCadastro",
                table: "Usuario",
                column: "IdUsuarioCadastro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillUsuario");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
