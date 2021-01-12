using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Torito.Data.Migrations
{
    public partial class AddressText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 4, 14, 0, 4, 762, DateTimeKind.Local).AddTicks(8021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 15, 3, 13, 44, 389, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedAt",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 4, 14, 0, 4, 768, DateTimeKind.Local).AddTicks(5821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 15, 3, 13, 44, 396, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.AddColumn<string>(
                name: "AddressText",
                table: "Tweets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressText",
                table: "Tweets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 15, 3, 13, 44, 389, DateTimeKind.Local).AddTicks(9219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 4, 14, 0, 4, 762, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedAt",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 15, 3, 13, 44, 396, DateTimeKind.Local).AddTicks(9686),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 4, 14, 0, 4, 768, DateTimeKind.Local).AddTicks(5821));
        }
    }
}
