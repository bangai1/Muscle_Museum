using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Museum_Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVisitorFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Visitors");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Visitors",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Visitors",
                newName: "ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Visitors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
