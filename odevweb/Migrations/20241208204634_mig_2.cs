using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RandevuIslems_Personels_PersonelId",
                table: "RandevuIslems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RandevuIslems",
                table: "RandevuIslems");

            migrationBuilder.DropIndex(
                name: "IX_RandevuIslems_PersonelId",
                table: "RandevuIslems");

            migrationBuilder.DropIndex(
                name: "IX_RandevuIslems_RandevuId",
                table: "RandevuIslems");

            migrationBuilder.DropColumn(
                name: "RandevuIslemId",
                table: "RandevuIslems");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "RandevuIslems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandevuIslems",
                table: "RandevuIslems",
                columns: new[] { "RandevuId", "IslemId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RandevuIslems",
                table: "RandevuIslems");

            migrationBuilder.AddColumn<int>(
                name: "RandevuIslemId",
                table: "RandevuIslems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "RandevuIslems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandevuIslems",
                table: "RandevuIslems",
                column: "RandevuIslemId");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuIslems_PersonelId",
                table: "RandevuIslems",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuIslems_RandevuId",
                table: "RandevuIslems",
                column: "RandevuId");

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuIslems_Personels_PersonelId",
                table: "RandevuIslems",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
