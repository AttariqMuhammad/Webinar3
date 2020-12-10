using Microsoft.EntityFrameworkCore.Migrations;

namespace Webinar.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PendaftaranModels_PenggunaModels_PenggunaModelPenggunaID",
                table: "PendaftaranModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PendaftaranModels_WebinarModels_WebinarModelID1",
                table: "PendaftaranModels");

            migrationBuilder.DropIndex(
                name: "IX_PendaftaranModels_PenggunaModelPenggunaID",
                table: "PendaftaranModels");

            migrationBuilder.DropIndex(
                name: "IX_PendaftaranModels_WebinarModelID1",
                table: "PendaftaranModels");

            migrationBuilder.DropColumn(
                name: "PenggunaModelPenggunaID",
                table: "PendaftaranModels");

            migrationBuilder.DropColumn(
                name: "WebinarModelID1",
                table: "PendaftaranModels");

            migrationBuilder.AlterColumn<string>(
                name: "JudulWebinar",
                table: "WebinarModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WebinarModelID",
                table: "PendaftaranModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PenggunaModelID",
                table: "PendaftaranModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PendaftaranModels_PenggunaModelID",
                table: "PendaftaranModels",
                column: "PenggunaModelID");

            migrationBuilder.CreateIndex(
                name: "IX_PendaftaranModels_WebinarModelID",
                table: "PendaftaranModels",
                column: "WebinarModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_PendaftaranModels_PenggunaModels_PenggunaModelID",
                table: "PendaftaranModels",
                column: "PenggunaModelID",
                principalTable: "PenggunaModels",
                principalColumn: "PenggunaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PendaftaranModels_WebinarModels_WebinarModelID",
                table: "PendaftaranModels",
                column: "WebinarModelID",
                principalTable: "WebinarModels",
                principalColumn: "WebinarModelID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PendaftaranModels_PenggunaModels_PenggunaModelID",
                table: "PendaftaranModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PendaftaranModels_WebinarModels_WebinarModelID",
                table: "PendaftaranModels");

            migrationBuilder.DropIndex(
                name: "IX_PendaftaranModels_PenggunaModelID",
                table: "PendaftaranModels");

            migrationBuilder.DropIndex(
                name: "IX_PendaftaranModels_WebinarModelID",
                table: "PendaftaranModels");

            migrationBuilder.AlterColumn<string>(
                name: "JudulWebinar",
                table: "WebinarModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WebinarModelID",
                table: "PendaftaranModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PenggunaModelID",
                table: "PendaftaranModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PenggunaModelPenggunaID",
                table: "PendaftaranModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WebinarModelID1",
                table: "PendaftaranModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PendaftaranModels_PenggunaModelPenggunaID",
                table: "PendaftaranModels",
                column: "PenggunaModelPenggunaID");

            migrationBuilder.CreateIndex(
                name: "IX_PendaftaranModels_WebinarModelID1",
                table: "PendaftaranModels",
                column: "WebinarModelID1");

            migrationBuilder.AddForeignKey(
                name: "FK_PendaftaranModels_PenggunaModels_PenggunaModelPenggunaID",
                table: "PendaftaranModels",
                column: "PenggunaModelPenggunaID",
                principalTable: "PenggunaModels",
                principalColumn: "PenggunaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PendaftaranModels_WebinarModels_WebinarModelID1",
                table: "PendaftaranModels",
                column: "WebinarModelID1",
                principalTable: "WebinarModels",
                principalColumn: "WebinarModelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
