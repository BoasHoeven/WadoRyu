using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class dropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_VideoCategory_VideoCategoryID",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_VideoCategoryID",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "VideoCategoryID",
                table: "Video");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoCategoryID",
                table: "Video",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_VideoCategoryID",
                table: "Video",
                column: "VideoCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_VideoCategory_VideoCategoryID",
                table: "Video",
                column: "VideoCategoryID",
                principalTable: "VideoCategory",
                principalColumn: "VideoCategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
