using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_10baglantiveislemekleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels",
                column: "IslemId",
                principalTable: "Islems",
                principalColumn: "IslemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels",
                column: "IslemId",
                principalTable: "Islems",
                principalColumn: "IslemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
