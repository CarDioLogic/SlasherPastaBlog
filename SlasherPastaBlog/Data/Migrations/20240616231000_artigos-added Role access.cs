using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlasherPastaBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class artigosaddedRoleaccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Artigos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Artigos");
        }
    }
}
