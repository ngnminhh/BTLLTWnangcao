using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTV.Migrations
{
    public partial class XoaCotTrangThaiDM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sTrangThai",
                table: "tblDanhMuc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sTrangThai",
                table: "tblDanhMuc",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
