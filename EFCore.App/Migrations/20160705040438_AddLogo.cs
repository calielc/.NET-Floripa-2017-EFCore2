using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.App.Migrations
{
    public partial class AddLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Crafts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Beers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Crafts",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beers",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Crafts");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Beers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Crafts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Beers",
                nullable: true);
        }
    }
}
