using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class _1005_BaseClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Yonetmen",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "Film",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeTarihi",
                table: "Film",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GuncelleyenKullanici",
                table: "Film",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKullaniciId",
                table: "Film",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OlusturanKullanici",
                table: "Film",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKullaniciId",
                table: "Film",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturmaTarihi",
                table: "Film",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "Film",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "GuncellemeTarihi",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKullanici",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKullaniciId",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "OlusturanKullanici",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "OlusturanKullaniciId",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "OlusturmaTarihi",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "Film");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Yonetmen",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");
        }
    }
}
