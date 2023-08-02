using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class testeRemoveFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_IdUsuarioCadastro",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdUsuarioCadastro",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdUsuarioCadastro",
                table: "Usuario",
                column: "IdUsuarioCadastro");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Usuario_IdUsuarioCadastro",
                table: "Usuario",
                column: "IdUsuarioCadastro",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
