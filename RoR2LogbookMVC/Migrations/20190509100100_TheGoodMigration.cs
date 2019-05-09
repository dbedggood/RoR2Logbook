using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoR2LogbookMVC.Migrations
{
    public partial class TheGoodMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Icon = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    OrderNo = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: false),
                    PickupText = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Challenge = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Survivor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    OrderNo = table.Column<int>(nullable: true),
                    Icon = table.Column<string>(nullable: false),
                    BaseMaxHealth = table.Column<float>(nullable: false),
                    MaxHealthIncrease = table.Column<float>(nullable: false),
                    BaseDamage = table.Column<float>(nullable: false),
                    DamageIncrease = table.Column<float>(nullable: false),
                    Speed = table.Column<float>(nullable: false),
                    Challenge = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survivor", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Survivor");
        }
    }
}
