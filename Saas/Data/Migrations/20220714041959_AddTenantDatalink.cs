using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saas.Data.Migrations
{
    public partial class AddTenantDatalink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenantDatalinks",
                schema: "sas",
                columns: table => new
                {
                    TenantDatalinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    DatalinkId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantDatalinks", x => new { x.TenantId, x.DatalinkId });
                    table.ForeignKey(
                        name: "FK_TenantDatalinks_Datalinks_DatalinkId",
                        column: x => x.DatalinkId,
                        principalSchema: "sas",
                        principalTable: "Datalinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantDatalinks_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "sas",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sas",
                table: "TenantDatalinks",
                columns: new[] { "DatalinkId", "TenantId", "TenantDatalinkID" },
                values: new object[,]
                {
                    { "d9da83f1-19ae-48be-a1ab-e141861ea8e9", "3eeb9e55-2dea-4e60-0f90-08da5ed157b0", 3 },
                    { "ed5b0fe5-ea64-43df-b315-fe4f39734eb1", "e7600b12-0c8a-41f1-0f8f-08da5ed157b0", 2 },
                    { "d976e7ea-58da-4e9c-8d4f-765e9160bd73", "e895cc49-3266-44a0-0f8e-08da5ed157b0", 1 }
                });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3694cda0-b999-4920-0f91-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 14, 19, 59, 337, DateTimeKind.Local).AddTicks(3367), new DateTime(2022, 7, 14, 14, 19, 59, 337, DateTimeKind.Local).AddTicks(3368) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3eeb9e55-2dea-4e60-0f90-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 14, 19, 59, 337, DateTimeKind.Local).AddTicks(3363), new DateTime(2022, 7, 14, 14, 19, 59, 337, DateTimeKind.Local).AddTicks(3365) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e7600b12-0c8a-41f1-0f8f-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 14, 19, 59, 337, DateTimeKind.Local).AddTicks(3360), new DateTime(2022, 7, 14, 14, 19, 59, 337, DateTimeKind.Local).AddTicks(3362) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e895cc49-3266-44a0-0f8e-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 14, 19, 59, 337, DateTimeKind.Local).AddTicks(3328), new DateTime(2022, 7, 14, 14, 19, 59, 337, DateTimeKind.Local).AddTicks(3357) });

            migrationBuilder.CreateIndex(
                name: "IX_TenantDatalinks_DatalinkId",
                schema: "sas",
                table: "TenantDatalinks",
                column: "DatalinkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantDatalinks",
                schema: "sas");

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3694cda0-b999-4920-0f91-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9546), new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9547) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "3eeb9e55-2dea-4e60-0f90-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9543), new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9544) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e7600b12-0c8a-41f1-0f8f-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9540), new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9541) });

            migrationBuilder.UpdateData(
                schema: "sas",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e895cc49-3266-44a0-0f8e-08da5ed157b0",
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9506), new DateTime(2022, 7, 14, 14, 14, 44, 885, DateTimeKind.Local).AddTicks(9537) });
        }
    }
}
