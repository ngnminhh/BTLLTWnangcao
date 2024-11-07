using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTV.Migrations
{
    public partial class UpdateDanhMuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
             name: "sTrangThai",
             table: "tblDanhMuc",
             nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDanhSachMuon");

            migrationBuilder.DropTable(
                name: "tblTaiKhoan");

            migrationBuilder.DropTable(
                name: "tblSach");

            migrationBuilder.DropTable(
                name: "tblNguoiDung");

            migrationBuilder.DropTable(
                name: "tblQuyen");

            migrationBuilder.DropTable(
                name: "tblDanhMuc");

            migrationBuilder.DropTable(
                name: "tblTheMuon");
        }
    }
}
