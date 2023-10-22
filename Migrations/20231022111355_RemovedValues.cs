using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppB2C2.Migrations
{
    /// <inheritdoc />
    public partial class RemovedValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlHandle",
                table: "MusicItems");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "MusicItems");

            migrationBuilder.AlterColumn<float>(
                name: "ItemValue",
                table: "MusicItems",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ItemValue",
                table: "MusicItems",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "UrlHandle",
                table: "MusicItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "MusicItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
