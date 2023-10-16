using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppB2C2.Migrations.DjDb
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTagMusicItem",
                columns: table => new
                {
                    ItemTagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTagMusicItem", x => new { x.ItemTagsId, x.MusicItemsId });
                    table.ForeignKey(
                        name: "FK_ItemTagMusicItem_ItemTags_ItemTagsId",
                        column: x => x.ItemTagsId,
                        principalTable: "ItemTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTagMusicItem_MusicItems_MusicItemsId",
                        column: x => x.MusicItemsId,
                        principalTable: "MusicItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTagMusicItem_MusicItemsId",
                table: "ItemTagMusicItem",
                column: "MusicItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTagMusicItem");

            migrationBuilder.DropTable(
                name: "ItemTags");

            migrationBuilder.DropTable(
                name: "MusicItems");
        }
    }
}
