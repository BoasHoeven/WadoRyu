using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class Chk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoCategory",
                table: "VideoCategory");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "VideoCategory");

            migrationBuilder.AddColumn<int>(
                name: "VideoCategoryID",
                table: "VideoCategory",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Video",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoCategory",
                table: "VideoCategory",
                column: "VideoCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoCategory",
                table: "VideoCategory");

            migrationBuilder.DropColumn(
                name: "VideoCategoryID",
                table: "VideoCategory");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Video");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "VideoCategory",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoCategory",
                table: "VideoCategory",
                column: "ID");
        }
    }
}
