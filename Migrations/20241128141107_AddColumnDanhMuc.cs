using Microsoft.EntityFrameworkCore.Migrations;
using QLTV.Models;

#nullable disable

namespace QLTV.Migrations
{
    public partial class AddColumnDanhMuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name:"VerifyKey",
                table:"TblDanhMuc",
                type:"varchar(100)",
                nullable:true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VerifyKey",
                table: "TblDanhMuc",
                type: "varchar(100)",
                nullable: true
                );
        }
    }
}
