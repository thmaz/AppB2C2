using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppB2C2.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionItemRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteItems",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "CollectionItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "CollectionItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "CollectionItems",
                columns: new[] { "ItemId", "CollectionId", "CreatedOn", "EstimatedPrice", "ItemDescription", "ItemName", "ReleaseDate" },
                values: new object[] { 1, 0, new DateTime(2023, 9, 25, 7, 50, 31, 928, DateTimeKind.Local).AddTicks(1223), 0, null, "Item Test", 0 });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionId", "AddedItems", "CollectionDescription", "CollectionName", "CreatedOn" },
                values: new object[] { 1, null, null, "Collection Test", new DateTime(2023, 9, 25, 7, 50, 31, 928, DateTimeKind.Local).AddTicks(1431) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedCollections", "MailAdress", "UserName", "UserPassword" },
                values: new object[] { 1, 0, "test@home.nl", "Test Name", "test_pass" });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_CollectionId",
                table: "CollectionItems",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_Collections_CollectionId",
                table: "CollectionItems",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_Collections_CollectionId",
                table: "CollectionItems");

            migrationBuilder.DropIndex(
                name: "IX_CollectionItems_CollectionId",
                table: "CollectionItems");

            migrationBuilder.DeleteData(
                table: "CollectionItems",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CollectionItems");

            migrationBuilder.AddColumn<string>(
                name: "FavoriteItems",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "CollectionItems",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
