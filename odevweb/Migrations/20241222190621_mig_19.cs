using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RandevuPersonel",
                table: "RandevuPersonel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RandevuIslems",
                table: "RandevuIslems");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Islems");

            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "Personels",
                newName: "PersonelSoyad");

            migrationBuilder.AddColumn<int>(
                name: "RandevuPersonelId",
                table: "RandevuPersonel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RandevuIslemId",
                table: "RandevuIslems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "PersonelAd",
                table: "Personels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IslemAd",
                table: "Islems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandevuPersonel",
                table: "RandevuPersonel",
                column: "RandevuPersonelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandevuIslems",
                table: "RandevuIslems",
                column: "RandevuIslemId");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuPersonel_RandevuId",
                table: "RandevuPersonel",
                column: "RandevuId");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuIslems_RandevuId",
                table: "RandevuIslems",
                column: "RandevuId");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_RandevuPersonel",
                table: "RandevuPersonel");

            migrationBuilder.DropIndex(
                name: "IX_RandevuPersonel_RandevuId",
                table: "RandevuPersonel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RandevuIslems",
                table: "RandevuIslems");

            migrationBuilder.DropIndex(
                name: "IX_RandevuIslems_RandevuId",
                table: "RandevuIslems");

            migrationBuilder.DropColumn(
                name: "RandevuPersonelId",
                table: "RandevuPersonel");

            migrationBuilder.DropColumn(
                name: "RandevuIslemId",
                table: "RandevuIslems");

            migrationBuilder.DropColumn(
                name: "PersonelAd",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "IslemAd",
                table: "Islems");

            migrationBuilder.RenameColumn(
                name: "PersonelSoyad",
                table: "Personels",
                newName: "Soyad");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Islems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandevuPersonel",
                table: "RandevuPersonel",
                columns: new[] { "RandevuId", "PersonelId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandevuIslems",
                table: "RandevuIslems",
                columns: new[] { "RandevuId", "IslemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels",
                column: "IslemId",
                principalTable: "Islems",
                principalColumn: "IslemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
