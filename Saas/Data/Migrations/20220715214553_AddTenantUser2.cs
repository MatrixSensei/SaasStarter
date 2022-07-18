using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saas.Data.Migrations
{
    public partial class AddTenantUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantUsers",
                schema: "sas",
                table: "TenantUsers");

            migrationBuilder.DropIndex(
                name: "IX_TenantUsers_TenantId",
                schema: "sas",
                table: "TenantUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "sas",
                table: "TenantUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450)
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "TenantId",
                schema: "sas",
                table: "TenantUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450)
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantUsers",
                schema: "sas",
                table: "TenantUsers",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3694cda0-b999-4920-0f91-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 45, 53, 390, DateTimeKind.Local).AddTicks(2871), new DateTime(2022, 7, 16, 7, 45, 53, 390, DateTimeKind.Local).AddTicks(2873) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3eeb9e55-2dea-4e60-0f90-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 45, 53, 390, DateTimeKind.Local).AddTicks(2864), new DateTime(2022, 7, 16, 7, 45, 53, 390, DateTimeKind.Local).AddTicks(2865) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e7600b12-0c8a-41f1-0f8f-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 45, 53, 390, DateTimeKind.Local).AddTicks(2860), new DateTime(2022, 7, 16, 7, 45, 53, 390, DateTimeKind.Local).AddTicks(2862) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e895cc49-3266-44a0-0f8e-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 45, 53, 390, DateTimeKind.Local).AddTicks(2811), new DateTime(2022, 7, 16, 7, 45, 53, 390, DateTimeKind.Local).AddTicks(2855) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantUsers",
                schema: "sas",
                table: "TenantUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b44ce1a0-06a9-4123-ad57-7cd458485ddc");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "sas",
                table: "TenantUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450)
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "TenantId",
                schema: "sas",
                table: "TenantUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450)
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantUsers",
                schema: "sas",
                table: "TenantUsers",
                column: "TenantUserID");

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
                values: new object[] { new DateTime(2022, 7, 16, 7, 23, 50, 524, DateTimeKind.Local).AddTicks(6995), new DateTime(2022, 7, 16, 7, 23, 50, 524, DateTimeKind.Local).AddTicks(6996) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3eeb9e55-2dea-4e60-0f90-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 23, 50, 524, DateTimeKind.Local).AddTicks(6987), new DateTime(2022, 7, 16, 7, 23, 50, 524, DateTimeKind.Local).AddTicks(6988) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e7600b12-0c8a-41f1-0f8f-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 23, 50, 524, DateTimeKind.Local).AddTicks(6984), new DateTime(2022, 7, 16, 7, 23, 50, 524, DateTimeKind.Local).AddTicks(6985) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e895cc49-3266-44a0-0f8e-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 23, 50, 524, DateTimeKind.Local).AddTicks(6942), new DateTime(2022, 7, 16, 7, 23, 50, 524, DateTimeKind.Local).AddTicks(6981) });

            migrationBuilder.CreateIndex(
                name: "IX_TenantUsers_TenantId",
                schema: "sas",
                table: "TenantUsers",
                column: "TenantId");
        }
    }
}
