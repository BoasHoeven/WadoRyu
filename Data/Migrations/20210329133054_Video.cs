using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp.Data.Migrations
{
    public partial class Video : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Video");

            migrationBuilder.AddColumn<int>(
                name: "VideoCategoryID",
                table: "Video",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Video",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
