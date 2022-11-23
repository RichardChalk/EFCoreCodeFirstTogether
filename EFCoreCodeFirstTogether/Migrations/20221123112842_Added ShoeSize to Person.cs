using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCodeFirstTogether.Migrations
{
    public partial class AddedShoeSizetoPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoeSize",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoeSize",
                table: "Person");
        }
    }
}
