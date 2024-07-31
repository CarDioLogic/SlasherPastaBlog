using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlasherPastaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class revert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artigos_AspNetUsers_ApplicationUserId1",
                table: "Artigos");

            migrationBuilder.DropIndex(
                name: "IX_Artigos_ApplicationUserId1",
                table: "Artigos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Artigos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Artigos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artigos_ApplicationUserId1",
                table: "Artigos",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Artigos_AspNetUsers_ApplicationUserId1",
                table: "Artigos",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
