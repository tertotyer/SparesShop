using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SparesShop2.Data.Migrations
{
    public partial class AddCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Spare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Spare",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spare_CharacterId",
                table: "Spare",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spare_Character_CharacterId",
                table: "Spare",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spare_Character_CharacterId",
                table: "Spare");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Spare_CharacterId",
                table: "Spare");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Spare");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Spare");
        }
    }
}
