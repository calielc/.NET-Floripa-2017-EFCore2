using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCore.Data.Migrations
{
    public partial class Add_photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Height = table.Column<int>(type: "int", nullable: false),
                    PhotographerId = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Geolocation_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geolocation_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geolocation_Lat = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Geolocation_Long = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Peoples_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotographerId",
                table: "Photos",
                column: "PhotographerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
