using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class Tests : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "VideoID",
                table: "VideoCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategory_VideoID",
                table: "VideoCategory",
                column: "VideoID");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCategory_Video_VideoID",
                table: "VideoCategory",
                column: "VideoID",
                principalTable: "Video",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoCategory_Video_VideoID",
                table: "VideoCategory");

            migrationBuilder.DropIndex(
                name: "IX_VideoCategory_VideoID",
                table: "VideoCategory");

            migrationBuilder.DropColumn(
                name: "VideoID",
                table: "VideoCategory");

            migrationBuilder.AddColumn<int>(
                name: "VideoCategoryID",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Video_VideoCategoryID",
                table: "Video",
                column: "VideoCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_VideoCategory_VideoCategoryID",
                table: "Video",
                column: "VideoCategoryID",
                principalTable: "VideoCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
