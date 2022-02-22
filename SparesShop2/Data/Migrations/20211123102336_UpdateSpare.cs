using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SparesShop2.Data.Migrations
{
    public partial class UpdateSpare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spare_Character_CharacterId",
                table: "Spare");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Spare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Spare_Character_CharacterId",
                table: "Spare",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spare_Character_CharacterId",
                table: "Spare");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Spare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Spare_Character_CharacterId",
                table: "Spare",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id");
        }
    }
}
