using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adfy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVersionFromAds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "advertisements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "Version",
                table: "advertisements",
                type: "INTEGER",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);
        }
    }
}
