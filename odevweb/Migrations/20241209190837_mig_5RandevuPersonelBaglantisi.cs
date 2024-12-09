using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_5RandevuPersonelBaglantisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandevuPersonel",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuPersonel", x => new { x.RandevuId, x.PersonelId });
                    table.ForeignKey(
                        name: "FK_RandevuPersonel_Personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personels",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RandevuPersonel_Randevus_RandevuId",
                        column: x => x.RandevuId,
                        principalTable: "Randevus",
                        principalColumn: "RandevuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RandevuPersonel_PersonelId",
                table: "RandevuPersonel",
                column: "PersonelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandevuPersonel");
        }
    }
}
