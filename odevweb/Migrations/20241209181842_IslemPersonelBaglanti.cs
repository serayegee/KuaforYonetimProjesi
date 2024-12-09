using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class IslemPersonelBaglanti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "Islems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Islems_PersonelId",
                table: "Islems",
                column: "PersonelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Islems_Personels_PersonelId",
                table: "Islems",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Islems_Personels_PersonelId",
                table: "Islems");

            migrationBuilder.DropIndex(
                name: "IX_Islems_PersonelId",
                table: "Islems");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Islems");
        }
    }
}
