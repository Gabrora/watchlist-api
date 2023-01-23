using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace watchlist_api.Migrations
{
    public partial class fixed_movie_column_to_content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchList_Content_MovieId",
                table: "WatchList");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "WatchList",
                newName: "ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_WatchList_MovieId",
                table: "WatchList",
                newName: "IX_WatchList_ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchList_Content_ContentId",
                table: "WatchList",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchList_Content_ContentId",
                table: "WatchList");

            migrationBuilder.RenameColumn(
                name: "ContentId",
                table: "WatchList",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_WatchList_ContentId",
                table: "WatchList",
                newName: "IX_WatchList_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchList_Content_MovieId",
                table: "WatchList",
                column: "MovieId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
