using Microsoft.EntityFrameworkCore.Migrations;

namespace RoR2Logbook.Migrations
{
    public partial class Icon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Item",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Item");
        }
    }
}
