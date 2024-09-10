using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AverageRating_Value = table.Column<double>(type: "double", nullable: false),
                    AverageRating_NumRatings = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HostId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuDinnerIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DinnerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MenuId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuDinnerIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuDinnerIds_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuReviewIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ReviewId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MenuId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuReviewIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuReviewIds_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuSections",
                columns: table => new
                {
                    MenuSectionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MenuId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSections", x => new { x.MenuSectionId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_MenuSections_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MenuSectionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MenuId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => new { x.MenuItemId, x.MenuSectionId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuSections_MenuSectionId_MenuId",
                        columns: x => new { x.MenuSectionId, x.MenuId },
                        principalTable: "MenuSections",
                        principalColumns: new[] { "MenuSectionId", "MenuId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MenuDinnerIds_MenuId",
                table: "MenuDinnerIds",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuSectionId_MenuId",
                table: "MenuItems",
                columns: new[] { "MenuSectionId", "MenuId" });

            migrationBuilder.CreateIndex(
                name: "IX_MenuReviewIds_MenuId",
                table: "MenuReviewIds",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSections_MenuId",
                table: "MenuSections",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuDinnerIds");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuReviewIds");

            migrationBuilder.DropTable(
                name: "MenuSections");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
