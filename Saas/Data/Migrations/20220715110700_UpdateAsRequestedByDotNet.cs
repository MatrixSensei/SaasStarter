using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saas.Data.Migrations
{
    public partial class UpdateAsRequestedByDotNet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b44ce1a0-06a9-4123-ad57-7cd458485ddc");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b44ce1a0-06a9-4123-ad57-7cd458485ddc", 0, "a550385f-27f5-47d6-9715-97c754ab240e", "IdentityUser", "admin@saas.com", false, false, null, "ADMIN@SAAS.COM", "ADMIN@SAAS.COM", "AQAAAAEAACcQAAAAECdHbFmJUrpwqvXXXPouK/taz+boBdhWheMz7e5nF5urd46DicUx4rWZ5Nuglwo+jA==", null, true, "UWFNILQ466TSZJV2LLK3K4TXLIFX7ZNS", false, "admin@saas.com" });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3694cda0-b999-4920-0f91-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 15, 21, 6, 59, 805, DateTimeKind.Local).AddTicks(1490), new DateTime(2022, 7, 15, 21, 6, 59, 805, DateTimeKind.Local).AddTicks(1492) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3eeb9e55-2dea-4e60-0f90-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 15, 21, 6, 59, 805, DateTimeKind.Local).AddTicks(1480), new DateTime(2022, 7, 15, 21, 6, 59, 805, DateTimeKind.Local).AddTicks(1481) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e7600b12-0c8a-41f1-0f8f-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 15, 21, 6, 59, 805, DateTimeKind.Local).AddTicks(1476), new DateTime(2022, 7, 15, 21, 6, 59, 805, DateTimeKind.Local).AddTicks(1478) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e895cc49-3266-44a0-0f8e-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 15, 21, 6, 59, 805, DateTimeKind.Local).AddTicks(1436), new DateTime(2022, 7, 15, 21, 6, 59, 805, DateTimeKind.Local).AddTicks(1473) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3694cda0-b999-4920-0f91-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 20, 51, 6, 993, DateTimeKind.Local).AddTicks(3396), new DateTime(2022, 7, 14, 20, 51, 6, 993, DateTimeKind.Local).AddTicks(3398) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3eeb9e55-2dea-4e60-0f90-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 20, 51, 6, 993, DateTimeKind.Local).AddTicks(3385), new DateTime(2022, 7, 14, 20, 51, 6, 993, DateTimeKind.Local).AddTicks(3387) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e7600b12-0c8a-41f1-0f8f-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 20, 51, 6, 993, DateTimeKind.Local).AddTicks(3381), new DateTime(2022, 7, 14, 20, 51, 6, 993, DateTimeKind.Local).AddTicks(3383) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e895cc49-3266-44a0-0f8e-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 20, 51, 6, 993, DateTimeKind.Local).AddTicks(3343), new DateTime(2022, 7, 14, 20, 51, 6, 993, DateTimeKind.Local).AddTicks(3377) });
        }
    }
}
