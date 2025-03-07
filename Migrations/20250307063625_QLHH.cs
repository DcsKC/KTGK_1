using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KTGK_1.Migrations
{
    /// <inheritdoc />
    public partial class QLHH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    ma_hanghoa = table.Column<string>(type: "nchar(9)", fixedLength: true, maxLength: 9, nullable: false),
                    ten_hanghoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    so_luong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.ma_hanghoa);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");
        }
    }
}
