using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureAPI.Migrations
{
    public partial class ChangingPasswordLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "Furniture",
                table: "Users",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDateSubmission",
                schema: "Furniture",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 5, 18, 45, 11, 974, DateTimeKind.Utc).AddTicks(9812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 4, 23, 27, 57, 963, DateTimeKind.Utc).AddTicks(1305));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "Furniture",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDateSubmission",
                schema: "Furniture",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 4, 23, 27, 57, 963, DateTimeKind.Utc).AddTicks(1305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 5, 18, 45, 11, 974, DateTimeKind.Utc).AddTicks(9812));
        }
    }
}
