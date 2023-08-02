using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class removendoFKSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillUsuario_Usuario_IdUsuario",
                table: "SkillUsuario");

            migrationBuilder.DropIndex(
                name: "IX_SkillUsuario_IdUsuario",
                table: "SkillUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
