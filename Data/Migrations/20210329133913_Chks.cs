using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class Chks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Video");

            migrationBuilder.AddColumn<int>(
                name: "VideoCategoryID",
                table: "Video",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoCategoryID",
                table: "Video");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
