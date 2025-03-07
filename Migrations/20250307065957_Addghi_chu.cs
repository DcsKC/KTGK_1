using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KTGK_1.Migrations
{
    /// <inheritdoc />
    public partial class Addghi_chu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ghi_chu",
                table: "Goods",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ghi_chu",
                table: "Goods");
        }
    }
}
