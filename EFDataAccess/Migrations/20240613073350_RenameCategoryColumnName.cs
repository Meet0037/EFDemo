using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoryColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CatagoryId",
                table: "Categories",
                newName: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CatagoryId");
        }
    }
}
