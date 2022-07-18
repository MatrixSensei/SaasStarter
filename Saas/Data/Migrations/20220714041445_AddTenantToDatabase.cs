using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saas.Data.Migrations
{
    public partial class AddTenantToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "sas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "sas",
                table: "Tenants",
                columns: new[] { "Id", "Comment", "Created", "Description", "Name", "Updated" },
                values: new object[,]
                {
                    { "3694cda0-b999-4920-0f91-08da5ed157b0", "This Tenant is for testing purposes only and is not a guenuine company.", new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9546), "Test Tenant called Delta", "Delta", new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9547) },
                    { "3eeb9e55-2dea-4e60-0f90-08da5ed157b0", "This Tenant is for testing purposes only and is not a guenuine company.", new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9543), "Test Tenant called Charlie", "Charlie", new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9544) },
                    { "e7600b12-0c8a-41f1-0f8f-08da5ed157b0", "This Tenant is for testing purposes only and is not a guenuine company.", new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9540), "Test Tenant called Beta", "Beta", new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9541) },
                    { "e895cc49-3266-44a0-0f8e-08da5ed157b0", "This Tenant is for testing purposes only and is not a guenuine company.", new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9506), "Test Tenant called Alpha", "Alpha", new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9537) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Name",
                schema: "sas",
                table: "Tenants",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "sas");
        }
    }
}
