using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SparesShop2.Data.Migrations
{
    public partial class AddCostSpare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cost",
                table: "Spare",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Spare");
        }
    }
}
