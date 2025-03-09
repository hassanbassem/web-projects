using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTicketBooking.Migrations
{
    public partial class createdpicturemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PictureUrl",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PictureUrl",
                table: "Cinemas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PictureUrl",
                table: "Artists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    UniqueName = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilenameAtClient = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.UniqueName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PictureUrl",
                table: "Movies",
                column: "PictureUrl",
                unique: true,
                filter: "[PictureUrl] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_PictureUrl",
                table: "Cinemas",
                column: "PictureUrl",
                unique: true,
                filter: "[PictureUrl] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_PictureUrl",
                table: "Artists",
                column: "PictureUrl",
                unique: true,
                filter: "[PictureUrl] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Picture_PictureUrl",
                table: "Artists",
                column: "PictureUrl",
                principalTable: "Picture",
                principalColumn: "UniqueName",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Picture_PictureUrl",
                table: "Cinemas",
                column: "PictureUrl",
                principalTable: "Picture",
                principalColumn: "UniqueName",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Picture_PictureUrl",
                table: "Movies",
                column: "PictureUrl",
                principalTable: "Picture",
                principalColumn: "UniqueName",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Picture_PictureUrl",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Picture_PictureUrl",
                table: "Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Picture_PictureUrl",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Movies_PictureUrl",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_PictureUrl",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Artists_PictureUrl",
                table: "Artists");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Movies",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Cinemas",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Artists",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
