using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace odevweb.Migrations
{
    public partial class mig_21islemlerpersonellertablosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_Islem_IslemId",
                table: "Personel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personel_Islemlerr_IslemlerId",
                table: "Personel");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelMusaitliks_Personel_PersonelId",
                table: "PersonelMusaitliks");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelMusaitliks_Personellerr_PersonellerId",
                table: "PersonelMusaitliks");

            migrationBuilder.DropForeignKey(
                name: "FK_RandevuIslems_Islem_IslemId",
                table: "RandevuIslems");

            migrationBuilder.DropForeignKey(
                name: "FK_RandevuIslems_Islemlerr_IslemlerId",
                table: "RandevuIslems");

            migrationBuilder.DropForeignKey(
                name: "FK_RandevuPersonel_Personel_PersonelId",
                table: "RandevuPersonel");

            migrationBuilder.DropForeignKey(
                name: "FK_RandevuPersonel_Personellerr_PersonellerId",
                table: "RandevuPersonel");

            migrationBuilder.DropTable(
                name: "Islemlerr");

            migrationBuilder.DropTable(
                name: "Personellerr");

            migrationBuilder.DropIndex(
                name: "IX_RandevuPersonel_PersonellerId",
                table: "RandevuPersonel");

            migrationBuilder.DropIndex(
                name: "IX_RandevuIslems_IslemlerId",
                table: "RandevuIslems");

            migrationBuilder.DropIndex(
                name: "IX_PersonelMusaitliks_PersonellerId",
                table: "PersonelMusaitliks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personel",
                table: "Personel");

            migrationBuilder.DropIndex(
                name: "IX_Personel_IslemlerId",
                table: "Personel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Islem",
                table: "Islem");

            migrationBuilder.DropColumn(
                name: "PersonellerId",
                table: "RandevuPersonel");

            migrationBuilder.DropColumn(
                name: "IslemlerId",
                table: "RandevuIslems");

            migrationBuilder.DropColumn(
                name: "PersonellerId",
                table: "PersonelMusaitliks");

            migrationBuilder.DropColumn(
                name: "IslemlerId",
                table: "Personel");

            migrationBuilder.RenameTable(
                name: "Personel",
                newName: "Personels");

            migrationBuilder.RenameTable(
                name: "Islem",
                newName: "Islems");

            migrationBuilder.RenameIndex(
                name: "IX_Personel_IslemId",
                table: "Personels",
                newName: "IX_Personels_IslemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personels",
                table: "Personels",
                column: "PersonelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Islems",
                table: "Islems",
                column: "IslemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelMusaitliks_Personels_PersonelId",
                table: "PersonelMusaitliks",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels",
                column: "IslemId",
                principalTable: "Islems",
                principalColumn: "IslemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuIslems_Islems_IslemId",
                table: "RandevuIslems",
                column: "IslemId",
                principalTable: "Islems",
                principalColumn: "IslemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuPersonel_Personels_PersonelId",
                table: "RandevuPersonel",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelMusaitliks_Personels_PersonelId",
                table: "PersonelMusaitliks");

            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Islems_IslemId",
                table: "Personels");

            migrationBuilder.DropForeignKey(
                name: "FK_RandevuIslems_Islems_IslemId",
                table: "RandevuIslems");

            migrationBuilder.DropForeignKey(
                name: "FK_RandevuPersonel_Personels_PersonelId",
                table: "RandevuPersonel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personels",
                table: "Personels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Islems",
                table: "Islems");

            migrationBuilder.RenameTable(
                name: "Personels",
                newName: "Personel");

            migrationBuilder.RenameTable(
                name: "Islems",
                newName: "Islem");

            migrationBuilder.RenameIndex(
                name: "IX_Personels_IslemId",
                table: "Personel",
                newName: "IX_Personel_IslemId");

            migrationBuilder.AddColumn<int>(
                name: "PersonellerId",
                table: "RandevuPersonel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IslemlerId",
                table: "RandevuIslems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonellerId",
                table: "PersonelMusaitliks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IslemlerId",
                table: "Personel",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personel",
                table: "Personel",
                column: "PersonelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Islem",
                table: "Islem",
                column: "IslemId");

            migrationBuilder.CreateTable(
                name: "Islemlerr",
                columns: table => new
                {
                    IslemlerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sure = table.Column<int>(type: "int", nullable: false),
                    Ucret = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islemlerr", x => x.IslemlerId);
                });

            migrationBuilder.CreateTable(
                name: "Personellerr",
                columns: table => new
                {
                    PersonellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemlerId = table.Column<int>(type: "int", nullable: false),
                    PersonelAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personellerr", x => x.PersonellerId);
                    table.ForeignKey(
                        name: "FK_Personellerr_Islem_IslemlerId",
                        column: x => x.IslemlerId,
                        principalTable: "Islem",
                        principalColumn: "IslemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RandevuPersonel_PersonellerId",
                table: "RandevuPersonel",
                column: "PersonellerId");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuIslems_IslemlerId",
                table: "RandevuIslems",
                column: "IslemlerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMusaitliks_PersonellerId",
                table: "PersonelMusaitliks",
                column: "PersonellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_IslemlerId",
                table: "Personel",
                column: "IslemlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Personellerr_IslemlerId",
                table: "Personellerr",
                column: "IslemlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_Islem_IslemId",
                table: "Personel",
                column: "IslemId",
                principalTable: "Islem",
                principalColumn: "IslemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_Islemlerr_IslemlerId",
                table: "Personel",
                column: "IslemlerId",
                principalTable: "Islemlerr",
                principalColumn: "IslemlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelMusaitliks_Personel_PersonelId",
                table: "PersonelMusaitliks",
                column: "PersonelId",
                principalTable: "Personel",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelMusaitliks_Personellerr_PersonellerId",
                table: "PersonelMusaitliks",
                column: "PersonellerId",
                principalTable: "Personellerr",
                principalColumn: "PersonellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuIslems_Islem_IslemId",
                table: "RandevuIslems",
                column: "IslemId",
                principalTable: "Islem",
                principalColumn: "IslemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuIslems_Islemlerr_IslemlerId",
                table: "RandevuIslems",
                column: "IslemlerId",
                principalTable: "Islemlerr",
                principalColumn: "IslemlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuPersonel_Personel_PersonelId",
                table: "RandevuPersonel",
                column: "PersonelId",
                principalTable: "Personel",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuPersonel_Personellerr_PersonellerId",
                table: "RandevuPersonel",
                column: "PersonellerId",
                principalTable: "Personellerr",
                principalColumn: "PersonellerId");
        }
    }
}
