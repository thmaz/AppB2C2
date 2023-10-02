using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppB2C2.Migrations
{
    /// <inheritdoc />
    public partial class AppDbInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedCollections = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornCollectionId = table.Column<int>(type: "int", nullable: false),
                    CollectionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollectionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedItems = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionId);
                    table.ForeignKey(
                        name: "FK_Collections_Users_FornCollectionId",
                        column: x => x.FornCollectionId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CollectionItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<int>(type: "int", nullable: false),
                    EstimatedPrice = table.Column<float>(type: "real", nullable: false),
                    FornItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_CollectionItems_Collections_FornItemId",
                        column: x => x.FornItemId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_FornItemId",
                table: "CollectionItems",
                column: "FornItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_FornCollectionId",
                table: "Collections",
                column: "FornCollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionItems");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
