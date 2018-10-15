using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LabOneB.Data.Migrations
{
    public partial class nameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dealership",
                table: "Dealership");

            migrationBuilder.RenameTable(
                name: "Dealership",
                newName: "Dealerships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dealerships",
                table: "Dealerships",
                column: "DealershipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dealerships",
                table: "Dealerships");

            migrationBuilder.RenameTable(
                name: "Dealerships",
                newName: "Dealership");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dealership",
                table: "Dealership",
                column: "DealershipId");
        }
    }
}
