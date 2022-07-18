using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multitenant.Data.Migrations
{
    public partial class InitialMagration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Getting this far will already create the database.
            // Not sure where it happens.  Maybe in the MigrationBuilder migrationBuilder argument
            //                             Maybe in the Microsoft.EntityFrameworkCore.Migrations Up() before the override comes into effect;

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(455)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
