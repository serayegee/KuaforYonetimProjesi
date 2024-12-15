using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_9baglantiguncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "IslemId",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_IslemId",
                table: "Personels",
                column: "IslemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels",
                column: "IslemId",
                principalTable: "Islems",
                principalColumn: "IslemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_IslemId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "IslemId",
                table: "Personels");

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
    }
}
