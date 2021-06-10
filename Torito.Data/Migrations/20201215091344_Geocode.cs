using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Torito.Data.Migrations
{
    public partial class Geocode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 15, 3, 13, 44, 389, DateTimeKind.Local).AddTicks(9219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 8, 4, 11, 21, 553, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedAt",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 15, 3, 13, 44, 396, DateTimeKind.Local).AddTicks(9686),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 8, 4, 11, 21, 561, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.CreateTable(
                name: "GeocodeDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TweetForeignKey = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeocodeDbo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeocodeDbo_Tweets_TweetForeignKey",
                        column: x => x.TweetForeignKey,
                        principalTable: "Tweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDbo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlusCodeDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompoundCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlobalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusCodeDbo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViewportDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NortheastId = table.Column<int>(type: "int", nullable: true),
                    SouthwestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewportDbo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewportDbo_LocationDbo_NortheastId",
                        column: x => x.NortheastId,
                        principalTable: "LocationDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViewportDbo_LocationDbo_SouthwestId",
                        column: x => x.SouthwestId,
                        principalTable: "LocationDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeometryDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    LocationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeometryDbo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeometryDbo_LocationDbo_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeometryDbo_ViewportDbo_ViewportId",
                        column: x => x.ViewportId,
                        principalTable: "ViewportDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResultDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormattedAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeometryId = table.Column<int>(type: "int", nullable: true),
                    PlaceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlusCodeId = table.Column<int>(type: "int", nullable: true),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeocodeDboId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultDbo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultDbo_GeocodeDbo_GeocodeDboId",
                        column: x => x.GeocodeDboId,
                        principalTable: "GeocodeDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultDbo_GeometryDbo_GeometryId",
                        column: x => x.GeometryId,
                        principalTable: "GeometryDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultDbo_PlusCodeDbo_PlusCodeId",
                        column: x => x.PlusCodeId,
                        principalTable: "PlusCodeDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressComponentDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LongName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeocodeDboId = table.Column<int>(type: "int", nullable: true),
                    ResultDboId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressComponentDbo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressComponentDbo_GeocodeDbo_GeocodeDboId",
                        column: x => x.GeocodeDboId,
                        principalTable: "GeocodeDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressComponentDbo_ResultDbo_ResultDboId",
                        column: x => x.ResultDboId,
                        principalTable: "ResultDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressComponentDbo_GeocodeDboId",
                table: "AddressComponentDbo",
                column: "GeocodeDboId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressComponentDbo_ResultDboId",
                table: "AddressComponentDbo",
                column: "ResultDboId");

            migrationBuilder.CreateIndex(
                name: "IX_GeocodeDbo_TweetForeignKey",
                table: "GeocodeDbo",
                column: "TweetForeignKey",
                unique: true,
                filter: "[TweetForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GeometryDbo_LocationId",
                table: "GeometryDbo",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GeometryDbo_ViewportId",
                table: "GeometryDbo",
                column: "ViewportId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultDbo_GeocodeDboId",
                table: "ResultDbo",
                column: "GeocodeDboId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultDbo_GeometryId",
                table: "ResultDbo",
                column: "GeometryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultDbo_PlusCodeId",
                table: "ResultDbo",
                column: "PlusCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewportDbo_NortheastId",
                table: "ViewportDbo",
                column: "NortheastId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewportDbo_SouthwestId",
                table: "ViewportDbo",
                column: "SouthwestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressComponentDbo");

            migrationBuilder.DropTable(
                name: "ResultDbo");

            migrationBuilder.DropTable(
                name: "GeocodeDbo");

            migrationBuilder.DropTable(
                name: "GeometryDbo");

            migrationBuilder.DropTable(
                name: "PlusCodeDbo");

            migrationBuilder.DropTable(
                name: "ViewportDbo");

            migrationBuilder.DropTable(
                name: "LocationDbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 8, 4, 11, 21, 553, DateTimeKind.Local).AddTicks(1157),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 15, 3, 13, 44, 389, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedAt",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 8, 4, 11, 21, 561, DateTimeKind.Local).AddTicks(47),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 15, 3, 13, 44, 396, DateTimeKind.Local).AddTicks(9686));
        }
    }
}
