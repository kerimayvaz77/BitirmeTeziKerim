using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeTeziKerim.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminTablos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciIsmi = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Sifre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTablos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duyurues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuyuruLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KoyulacakLink = table.Column<string>(type: "TEXT", nullable: true),
                    KoyulacakLink2 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuyuruLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonelTablos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AkademikPersonel = table.Column<string>(type: "TEXT", nullable: true),
                    Unvan = table.Column<string>(type: "TEXT", nullable: true),
                    Sayi = table.Column<int>(type: "INTEGER", nullable: false),
                    IdariPersonel = table.Column<string>(type: "TEXT", nullable: true),
                    Sinif = table.Column<string>(type: "TEXT", nullable: true),
                    Sayi1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelTablos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sayilars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SayiTablo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sayilars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SayilarTablos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OgrenimDuzeyi = table.Column<string>(type: "TEXT", nullable: true),
                    AkademikBirim = table.Column<string>(type: "TEXT", nullable: true),
                    Kadin = table.Column<int>(type: "INTEGER", nullable: false),
                    Erkek = table.Column<int>(type: "INTEGER", nullable: false),
                    Toplam = table.Column<int>(type: "INTEGER", nullable: false),
                    SayilarId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SayilarTablos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SayilarTablos_Sayilars_SayilarId",
                        column: x => x.SayilarId,
                        principalTable: "Sayilars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SayilarTablos_SayilarId",
                table: "SayilarTablos",
                column: "SayilarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTablos");

            migrationBuilder.DropTable(
                name: "Duyurues");

            migrationBuilder.DropTable(
                name: "DuyuruLinks");

            migrationBuilder.DropTable(
                name: "PersonelTablos");

            migrationBuilder.DropTable(
                name: "SayilarTablos");

            migrationBuilder.DropTable(
                name: "Sayilars");
        }
    }
}
