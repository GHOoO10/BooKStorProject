using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhamdanAlYamaniProject.Migrations
{
    public partial class @finally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "B_Img",
                table: "Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "B_Img",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
