using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlasherPastaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1tomanyrelationshipbetweenaplicationUserandartigos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Artigos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Artigos_ApplicationUserId",
                table: "Artigos",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artigos_AspNetUsers_ApplicationUserId",
                table: "Artigos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artigos_AspNetUsers_ApplicationUserId",
                table: "Artigos");

            migrationBuilder.DropIndex(
                name: "IX_Artigos_ApplicationUserId",
                table: "Artigos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Artigos");
        }
    }
}
