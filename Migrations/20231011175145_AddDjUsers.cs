using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppB2C2.Migrations
{
    /// <inheritdoc />
    public partial class AddDjUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Users_CollectionId",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "DjUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DjUsers",
                table: "DjUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_DjUsers_CollectionId",
                table: "Collections",
                column: "CollectionId",
                principalTable: "DjUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_DjUsers_CollectionId",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DjUsers",
                table: "DjUsers");

            migrationBuilder.RenameTable(
                name: "DjUsers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Users_CollectionId",
                table: "Collections",
                column: "CollectionId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
