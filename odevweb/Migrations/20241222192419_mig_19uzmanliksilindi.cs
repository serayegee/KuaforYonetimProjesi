using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_19uzmanliksilindi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uzmanlik",
                table: "Personels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uzmanlik",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
