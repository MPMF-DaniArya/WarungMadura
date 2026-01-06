using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarungMadura.Migrations
{
    /// <inheritdoc />
    public partial class TambahKolomStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Produks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Produks");
        }
    }
}
