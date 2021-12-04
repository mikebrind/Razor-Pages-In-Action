using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityBreaks.Migrations
{
    public partial class AddedCreatorToProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Properties",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CreatorId",
                table: "Properties",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_CreatorId",
                table: "Properties",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_CreatorId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_CreatorId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Properties");
        }
    }
}
