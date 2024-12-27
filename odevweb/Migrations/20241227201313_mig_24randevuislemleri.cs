using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_24randevuislemleri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RandevuPersonel_Personels_PersonelId",
                table: "RandevuPersonel");

            migrationBuilder.DropForeignKey(
                name: "FK_RandevuPersonel_Randevus_RandevuId",
                table: "RandevuPersonel");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevus_Musteris_MusteriId",
                table: "Randevus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RandevuPersonel",
                table: "RandevuPersonel");

            migrationBuilder.RenameTable(
                name: "RandevuPersonel",
                newName: "RandevuPersonels");

            migrationBuilder.RenameIndex(
                name: "IX_RandevuPersonel_RandevuId",
                table: "RandevuPersonels",
                newName: "IX_RandevuPersonels_RandevuId");

            migrationBuilder.RenameIndex(
                name: "IX_RandevuPersonel_PersonelId",
                table: "RandevuPersonels",
                newName: "IX_RandevuPersonels_PersonelId");

            migrationBuilder.AlterColumn<int>(
                name: "MusteriId",
                table: "Randevus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Randevus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "Kullanicis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Kullanicis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandevuPersonels",
                table: "RandevuPersonels",
                column: "RandevuPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevus_KullaniciId",
                table: "Randevus",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuPersonels_Personels_PersonelId",
                table: "RandevuPersonels",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuPersonels_Randevus_RandevuId",
                table: "RandevuPersonels",
                column: "RandevuId",
                principalTable: "Randevus",
                principalColumn: "RandevuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevus_Kullanicis_KullaniciId",
                table: "Randevus",
                column: "KullaniciId",
                principalTable: "Kullanicis",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevus_Musteris_MusteriId",
                table: "Randevus",
                column: "MusteriId",
                principalTable: "Musteris",
                principalColumn: "MusteriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RandevuPersonels_Personels_PersonelId",
                table: "RandevuPersonels");

            migrationBuilder.DropForeignKey(
                name: "FK_RandevuPersonels_Randevus_RandevuId",
                table: "RandevuPersonels");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevus_Kullanicis_KullaniciId",
                table: "Randevus");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevus_Musteris_MusteriId",
                table: "Randevus");

            migrationBuilder.DropIndex(
                name: "IX_Randevus_KullaniciId",
                table: "Randevus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RandevuPersonels",
                table: "RandevuPersonels");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Randevus");

            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "Kullanicis");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Kullanicis");

            migrationBuilder.RenameTable(
                name: "RandevuPersonels",
                newName: "RandevuPersonel");

            migrationBuilder.RenameIndex(
                name: "IX_RandevuPersonels_RandevuId",
                table: "RandevuPersonel",
                newName: "IX_RandevuPersonel_RandevuId");

            migrationBuilder.RenameIndex(
                name: "IX_RandevuPersonels_PersonelId",
                table: "RandevuPersonel",
                newName: "IX_RandevuPersonel_PersonelId");

            migrationBuilder.AlterColumn<int>(
                name: "MusteriId",
                table: "Randevus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandevuPersonel",
                table: "RandevuPersonel",
                column: "RandevuPersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuPersonel_Personels_PersonelId",
                table: "RandevuPersonel",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuPersonel_Randevus_RandevuId",
                table: "RandevuPersonel",
                column: "RandevuId",
                principalTable: "Randevus",
                principalColumn: "RandevuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevus_Musteris_MusteriId",
                table: "Randevus",
                column: "MusteriId",
                principalTable: "Musteris",
                principalColumn: "MusteriId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
