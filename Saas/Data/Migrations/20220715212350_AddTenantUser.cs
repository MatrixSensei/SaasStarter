using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saas.Data.Migrations
{
    public partial class AddTenantUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b44ce1a0-06a9-4123-ad57-7cd458485ddc");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TenantUsers",
                schema: "sas",
                columns: table => new
                {
                    TenantUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantUsers", x => x.TenantUserID);
                    table.ForeignKey(
                        name: "FK_TenantUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantUsers_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "sas",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b44ce1a0-06a9-4123-ad57-7cd458485ddc", 0, "a550385f-27f5-47d6-9715-97c754ab240e", "IdentityUser", "admin@saas.com", false, false, null, "ADMIN@SAAS.COM", "ADMIN@SAAS.COM", "AQAAAAEAACcQAAAAECdHbFmJUrpwqvXXXPouK/taz+boBdhWheMz7e5nF5urd46DicUx4rWZ5Nuglwo+jA==", null, true, "UWFNILQ466TSZJV2LLK3K4TXLIFX7ZNS", false, "admin@saas.com" });

            migrationBuilder.InsertData(
                schema: "sas",
                table: "TenantUsers",
                columns: new[] { "TenantUserID", "TenantId", "UserId" },
                values: new object[,]
                {
                    { 1, "e895cc49-3266-44a0-0f8e-08da5ed157b0", "b44ce1a0-06a9-4123-ad57-7cd458485ddc" },
                    { 2, "e7600b12-0c8a-41f1-0f8f-08da5ed157b0", "b44ce1a0-06a9-4123-ad57-7cd458485ddc" },
                    { 3, "3eeb9e55-2dea-4e60-0f90-08da5ed157b0", "b44ce1a0-06a9-4123-ad57-7cd458485ddc" },
                    { 4, "3694cda0-b999-4920-0f91-08da5ed157b0", "b44ce1a0-06a9-4123-ad57-7cd458485ddc" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TenantUsers_UserId",
                schema: "sas",
                table: "TenantUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantUsers",
                schema: "sas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3694cda0-b999-4920-0f91-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 0, 26, 325, DateTimeKind.Local).AddTicks(4465), new DateTime(2022, 7, 16, 7, 0, 26, 325, DateTimeKind.Local).AddTicks(4467) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3eeb9e55-2dea-4e60-0f90-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 0, 26, 325, DateTimeKind.Local).AddTicks(4456), new DateTime(2022, 7, 16, 7, 0, 26, 325, DateTimeKind.Local).AddTicks(4458) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e7600b12-0c8a-41f1-0f8f-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 0, 26, 325, DateTimeKind.Local).AddTicks(4452), new DateTime(2022, 7, 16, 7, 0, 26, 325, DateTimeKind.Local).AddTicks(4454) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e895cc49-3266-44a0-0f8e-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 16, 7, 0, 26, 325, DateTimeKind.Local).AddTicks(4405), new DateTime(2022, 7, 16, 7, 0, 26, 325, DateTimeKind.Local).AddTicks(4449) });
        }
    }
}
