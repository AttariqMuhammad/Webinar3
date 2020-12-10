using Microsoft.EntityFrameworkCore.Migrations;

namespace Webinar.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PembicaraModelID",
                table: "WebinarModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PembicaraModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaDepan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaBelakang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kontak = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PembicaraModels", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebinarModels_PembicaraModelID",
                table: "WebinarModels",
                column: "PembicaraModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebinarModels_PembicaraModels_PembicaraModelID",
                table: "WebinarModels",
                column: "PembicaraModelID",
                principalTable: "PembicaraModels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebinarModels_PembicaraModels_PembicaraModelID",
                table: "WebinarModels");

            migrationBuilder.DropTable(
                name: "PembicaraModels");

            migrationBuilder.DropIndex(
                name: "IX_WebinarModels_PembicaraModelID",
                table: "WebinarModels");

            migrationBuilder.DropColumn(
                name: "PembicaraModelID",
                table: "WebinarModels");
        }
    }
}
