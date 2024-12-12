using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_8kullanicitablosuguncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Kullanicis",
                newName: "KullaniciId");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Kullanicis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Kullanicis");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "Kullanicis",
                newName: "Id");
        }
    }
}
