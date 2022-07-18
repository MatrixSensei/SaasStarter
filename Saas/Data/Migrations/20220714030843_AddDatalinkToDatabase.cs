using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saas.Data.Migrations
{
    public partial class AddDatalinkToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sas");

            migrationBuilder.CreateTable(
                name: "Datalinks",
                schema: "sas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ConnectionString = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datalinks", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "sas",
                table: "Datalinks",
                columns: new[] { "Id", "Active", "ConnectionString", "Name", "Provider" },
                values: new object[,]
                {
                    { "d976e7ea-58da-4e9c-8d4f-765e9160bd73", true, "Data Source=(localdb)\\mssqllocaldb;Database=saasTenantAlpha;Integrated Security=True;MultipleActiveResultSets=True", "alphaDatalink", "mssql" },
                    { "d9da83f1-19ae-48be-a1ab-e141861ea8e9", true, "", "charlieDatalink", "mssql" },
                    { "ed5b0fe5-ea64-43df-b315-fe4f39734eb1", true, "Data Source=(localdb)\\mssqllocaldb;Database=saasTenantBeta;Integrated Security=True;MultipleActiveResultSets=True", "betaDatalink", "mssql" },
                    { "f63f4ca8-2c92-41bf-8918-ee18e80580af", true, "Data Source=(localdb)\\mssqllocaldb;Database=saasTenantsShared;Integrated Security=True;MultipleActiveResultSets=True", "defaultSharedDatalink", "mssql" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datalinks_Name",
                schema: "sas",
                table: "Datalinks",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datalinks",
                schema: "sas");
        }
    }
}
