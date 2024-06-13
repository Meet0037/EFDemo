using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Category 1')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Category 2')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Category 3')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
