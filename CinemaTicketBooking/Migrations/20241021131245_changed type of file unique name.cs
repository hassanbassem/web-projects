using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTicketBooking.Migrations
{
    public partial class changedtypeoffileuniquename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Movies_Picture_PictureUrl", "Movies");
            migrationBuilder.DropForeignKey("FK_Cinemas_Picture_PictureUrl", "Cinemas");
            migrationBuilder.DropForeignKey("FK_Artists_Picture_PictureUrl", "Artists");

            migrationBuilder.DropPrimaryKey("PK_Picture", "Picture");

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

            migrationBuilder.AlterColumn<string>(
                name: "UniqueName",
                table: "Picture",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                "PK_Picture",
                "Picture",
                "UniqueName"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Picture_PictureUrl",
                table: "Movies",
                column: "PictureUrl",
                principalTable: "Picture",
                onDelete: ReferentialAction.SetNull
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Picture_PictureUrl",
                table: "Cinemas",
                column: "PictureUrl",
                principalTable: "Picture",
                onDelete: ReferentialAction.SetNull
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Picture_PictureUrl",
                table: "Artists",
                column: "PictureUrl",
                principalTable: "Picture",
                onDelete: ReferentialAction.SetNull
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UniqueName",
                table: "Picture",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
        }
    }
}
