using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace R4ClothesAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Makhachhang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenkhachhang = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gioitinh = table.Column<int>(type: "int", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Sodienthoai = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false),
                    Matkhau = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Makhachhang);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    Maloai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenloai = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.Maloai);
                });

            migrationBuilder.CreateTable(
                name: "QuanTris",
                columns: table => new
                {
                    Maquantri = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taikhoan = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Matkhau = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanTris", x => x.Maquantri);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Mahoadon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maquantri = table.Column<int>(type: "int", nullable: false),
                    Makhachhang = table.Column<int>(type: "int", nullable: false),
                    Tongtien = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Ngaydat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangthaiHD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Mahoadon);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_Makhachhang",
                        column: x => x.Makhachhang,
                        principalTable: "KhachHangs",
                        principalColumn: "Makhachhang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDons_QuanTris_Maquantri",
                        column: x => x.Maquantri,
                        principalTable: "QuanTris",
                        principalColumn: "Maquantri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Masanpham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tensanpham = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Maquantri = table.Column<int>(type: "int", nullable: false),
                    Maloai = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Soluotxem = table.Column<int>(type: "int", nullable: false),
                    Dacbiet = table.Column<int>(type: "int", nullable: false),
                    Ngaynhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Giamgia = table.Column<double>(type: "float", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TrangthaiSP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Masanpham);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_Maloai",
                        column: x => x.Maloai,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "Maloai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_QuanTris_Maquantri",
                        column: x => x.Maquantri,
                        principalTable: "QuanTris",
                        principalColumn: "Maquantri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    MaChiTietHoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mahoadon = table.Column<int>(type: "int", nullable: false),
                    Masanpham = table.Column<int>(type: "int", nullable: false),
                    Tensanpham = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.MaChiTietHoaDon);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_Mahoadon",
                        column: x => x.Mahoadon,
                        principalTable: "HoaDons",
                        principalColumn: "Mahoadon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_Masanpham",
                        column: x => x.Masanpham,
                        principalTable: "SanPhams",
                        principalColumn: "Masanpham",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DanhGiaSanPhams",
                columns: table => new
                {
                    MaDanhGiaSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Makhachhang = table.Column<int>(type: "int", nullable: false),
                    Masanpham = table.Column<int>(type: "int", nullable: false),
                    Thoigian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chitiet = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaSanPhams", x => x.MaDanhGiaSP);
                    table.ForeignKey(
                        name: "FK_DanhGiaSanPhams_KhachHangs_Makhachhang",
                        column: x => x.Makhachhang,
                        principalTable: "KhachHangs",
                        principalColumn: "Makhachhang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhGiaSanPhams_SanPhams_Masanpham",
                        column: x => x.Masanpham,
                        principalTable: "SanPhams",
                        principalColumn: "Masanpham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    Mashare = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Makhachhang = table.Column<int>(type: "int", nullable: false),
                    Masanpham = table.Column<int>(type: "int", nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Thoigian = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.Mashare);
                    table.ForeignKey(
                        name: "FK_Shares_KhachHangs_Makhachhang",
                        column: x => x.Makhachhang,
                        principalTable: "KhachHangs",
                        principalColumn: "Makhachhang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shares_SanPhams_Masanpham",
                        column: x => x.Masanpham,
                        principalTable: "SanPhams",
                        principalColumn: "Masanpham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_Mahoadon",
                table: "ChiTietHoaDons",
                column: "Mahoadon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_Masanpham",
                table: "ChiTietHoaDons",
                column: "Masanpham");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaSanPhams_Makhachhang",
                table: "DanhGiaSanPhams",
                column: "Makhachhang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaSanPhams_Masanpham",
                table: "DanhGiaSanPhams",
                column: "Masanpham");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_Makhachhang",
                table: "HoaDons",
                column: "Makhachhang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_Maquantri",
                table: "HoaDons",
                column: "Maquantri");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Maloai",
                table: "SanPhams",
                column: "Maloai");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Maquantri",
                table: "SanPhams",
                column: "Maquantri");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_Makhachhang",
                table: "Shares",
                column: "Makhachhang");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_Masanpham",
                table: "Shares",
                column: "Masanpham");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "DanhGiaSanPhams");

            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");

            migrationBuilder.DropTable(
                name: "QuanTris");
        }
    }
}
