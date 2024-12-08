using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Islems",
                columns: table => new
                {
                    IslemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sure = table.Column<int>(type: "int", nullable: false),
                    Ucret = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islems", x => x.IslemId);
                });

            migrationBuilder.CreateTable(
                name: "Musteris",
                columns: table => new
                {
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteris", x => x.MusteriId);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uzmanlik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelId);
                });

            migrationBuilder.CreateTable(
                name: "Randevus",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saat = table.Column<TimeSpan>(type: "time", nullable: false),
                    ToplamUcret = table.Column<double>(type: "float", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevus", x => x.RandevuId);
                    table.ForeignKey(
                        name: "FK_Randevus_Musteris_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteris",
                        principalColumn: "MusteriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelMusaitliks",
                columns: table => new
                {
                    PersonelMusaitlikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaslangicSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelMusaitliks", x => x.PersonelMusaitlikId);
                    table.ForeignKey(
                        name: "FK_PersonelMusaitliks_Personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personels",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RandevuIslems",
                columns: table => new
                {
                    RandevuIslemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    RandevuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuIslems", x => x.RandevuIslemId);
                    table.ForeignKey(
                        name: "FK_RandevuIslems_Islems_IslemId",
                        column: x => x.IslemId,
                        principalTable: "Islems",
                        principalColumn: "IslemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RandevuIslems_Personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personels",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RandevuIslems_Randevus_RandevuId",
                        column: x => x.RandevuId,
                        principalTable: "Randevus",
                        principalColumn: "RandevuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMusaitliks_PersonelId",
                table: "PersonelMusaitliks",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuIslems_IslemId",
                table: "RandevuIslems",
                column: "IslemId");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuIslems_PersonelId",
                table: "RandevuIslems",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuIslems_RandevuId",
                table: "RandevuIslems",
                column: "RandevuId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevus_MusteriId",
                table: "Randevus",
                column: "MusteriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelMusaitliks");

            migrationBuilder.DropTable(
                name: "RandevuIslems");

            migrationBuilder.DropTable(
                name: "Islems");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Randevus");

            migrationBuilder.DropTable(
                name: "Musteris");
        }
    }
}
