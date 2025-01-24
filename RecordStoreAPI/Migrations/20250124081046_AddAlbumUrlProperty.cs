using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAlbumUrlProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlbumArtUrl",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumArtUrl",
                table: "Albums");
        }
    }
}
