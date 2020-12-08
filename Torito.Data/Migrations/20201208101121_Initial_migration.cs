using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Torito.Data.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Annotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<int>(type: "int", nullable: true),
                    End = table.Column<int>(type: "int", nullable: true),
                    Probability = table.Column<double>(type: "float", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityDboId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annotations_Entities_EntityDboId",
                        column: x => x.EntityDboId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hastags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<int>(type: "int", nullable: true),
                    End = table.Column<int>(type: "int", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityDboId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hastags_Entities_EntityDboId",
                        column: x => x.EntityDboId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntitiesId = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2020, 12, 8, 4, 11, 21, 553, DateTimeKind.Local).AddTicks(1157)),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2020, 12, 8, 4, 11, 21, 561, DateTimeKind.Local).AddTicks(47))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweets_Entities_EntitiesId",
                        column: x => x.EntitiesId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_EntityDboId",
                table: "Annotations",
                column: "EntityDboId");

            migrationBuilder.CreateIndex(
                name: "IX_Hastags_EntityDboId",
                table: "Hastags",
                column: "EntityDboId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_EntitiesId",
                table: "Tweets",
                column: "EntitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "Hastags");

            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
