using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Torito.Data.Migrations
{
    public partial class UpdateTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 4, 14, 0, 4, 762, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedAt",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 4, 14, 0, 4, 768, DateTimeKind.Local).AddTicks(5821));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 4, 14, 0, 4, 762, DateTimeKind.Local).AddTicks(8021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedAt",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 4, 14, 0, 4, 768, DateTimeKind.Local).AddTicks(5821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}
