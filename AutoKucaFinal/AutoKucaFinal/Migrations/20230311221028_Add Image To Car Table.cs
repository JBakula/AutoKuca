using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoKucaFinal.Migrations
{
    public partial class AddImageToCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Cars");
        }
    }
}
