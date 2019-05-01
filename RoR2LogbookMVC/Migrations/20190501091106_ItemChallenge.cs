using Microsoft.EntityFrameworkCore.Migrations;

namespace RoR2LogbookMVC.Migrations
{
    public partial class ItemChallenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Challenge",
                table: "Item",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Challenge",
                table: "Item");
        }
    }
}
