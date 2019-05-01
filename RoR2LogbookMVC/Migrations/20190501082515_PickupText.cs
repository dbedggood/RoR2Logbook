using Microsoft.EntityFrameworkCore.Migrations;

namespace RoR2LogbookMVC.Migrations
{
    public partial class PickupText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PickupText",
                table: "Item",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PickupText",
                table: "Item",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
