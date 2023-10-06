using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppB2C2.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_Collections_FornItemId",
                table: "CollectionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Users_FornCollectionId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_FornCollectionId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_CollectionItems_FornItemId",
                table: "CollectionItems");

            migrationBuilder.DropColumn(
                name: "FornCollectionId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "FornItemId",
                table: "CollectionItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MailAdress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CollectionId",
                table: "Collections",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CollectionItemItemId",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "CollectionItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CollectionItemItemId",
                table: "Collections",
                column: "CollectionItemItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_Collections_ItemId",
                table: "CollectionItems",
                column: "ItemId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionItems_CollectionItemItemId",
                table: "Collections",
                column: "CollectionItemItemId",
                principalTable: "CollectionItems",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Users_CollectionId",
                table: "Collections",
                column: "CollectionId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_Collections_ItemId",
                table: "CollectionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionItems_CollectionItemItemId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Users_CollectionId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CollectionItemItemId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CollectionItemItemId",
                table: "Collections");

            migrationBuilder.AlterColumn<string>(
                name: "UserPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MailAdress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollectionId",
                table: "Collections",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FornCollectionId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "CollectionItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FornItemId",
                table: "CollectionItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_FornCollectionId",
                table: "Collections",
                column: "FornCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_FornItemId",
                table: "CollectionItems",
                column: "FornItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_Collections_FornItemId",
                table: "CollectionItems",
                column: "FornItemId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Users_FornCollectionId",
                table: "Collections",
                column: "FornCollectionId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
