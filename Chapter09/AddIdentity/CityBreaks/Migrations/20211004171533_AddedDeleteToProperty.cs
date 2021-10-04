using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityBreaks.Migrations
{
    public partial class AddedDeleteToProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Properties",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Properties");
        }
    }
}
