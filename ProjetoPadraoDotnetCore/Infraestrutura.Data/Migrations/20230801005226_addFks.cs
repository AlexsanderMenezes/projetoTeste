using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class addFks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdUsuarioCadastro",
                table: "Usuario",
                column: "IdUsuarioCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUsuario_IdUsuario",
                table: "SkillUsuario",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUsuario_Usuario_IdUsuario",
                table: "SkillUsuario",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Usuario_IdUsuarioCadastro",
                table: "Usuario",
                column: "IdUsuarioCadastro",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillUsuario_Usuario_IdUsuario",
                table: "SkillUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_IdUsuarioCadastro",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdUsuarioCadastro",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_SkillUsuario_IdUsuario",
                table: "SkillUsuario");
        }
    }
}
