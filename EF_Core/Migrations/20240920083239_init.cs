using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Core.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONGDANs",
                columns: table => new
                {
                    MaCD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONGDANs", x => x.MaCD);
                });

            migrationBuilder.CreateTable(
                name: "LOAIVACXINs",
                columns: table => new
                {
                    MaLoaiVX = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiVX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuocSX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoNgayTiemNhac = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAIVACXINs", x => x.MaLoaiVX);
                });

            migrationBuilder.CreateTable(
                name: "LIEUVACXINs",
                columns: table => new
                {
                    MaLieuVX = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLo = table.Column<int>(type: "int", nullable: false),
                    MaLoaiVX = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgaySanXuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIEUVACXINs", x => x.MaLieuVX);
                    table.ForeignKey(
                        name: "FK_LIEUVACXINs_LOAIVACXINs_MaLoaiVX",
                        column: x => x.MaLoaiVX,
                        principalTable: "LOAIVACXINs",
                        principalColumn: "MaLoaiVX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TIEMCHUNGs",
                columns: table => new
                {
                    MaTC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaCD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLieuVX = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayTiemMui1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTiemMui2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDkTiemMui2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIEMCHUNGs", x => x.MaTC);
                    table.ForeignKey(
                        name: "FK_TIEMCHUNGs_CONGDANs_MaCD",
                        column: x => x.MaCD,
                        principalTable: "CONGDANs",
                        principalColumn: "MaCD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TIEMCHUNGs_LIEUVACXINs_MaLieuVX",
                        column: x => x.MaLieuVX,
                        principalTable: "LIEUVACXINs",
                        principalColumn: "MaLieuVX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CONGDANs",
                columns: new[] { "MaCD", "CMND", "DiaChi", "Email", "HoTen", "NgaySinh", "SoDienThoai" },
                values: new object[] { "CD001", "123456789", "Hà Nội", "", "Nguyễn Văn A", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321" });

            migrationBuilder.InsertData(
                table: "LOAIVACXINs",
                columns: new[] { "MaLoaiVX", "NuocSX", "SoNgayTiemNhac", "TenLoaiVX" },
                values: new object[,]
                {
                    { "VX001", "Anh", 84, "AstraZeneca" },
                    { "VX002", "Mỹ", 21, "Pfizer" },
                    { "VX003", "Nga", 21, "Sputnik V" }
                });

            migrationBuilder.InsertData(
                table: "LIEUVACXINs",
                columns: new[] { "MaLieuVX", "MaLoaiVX", "NgayHetHan", "NgaySanXuat", "SoLo" },
                values: new object[,]
                {
                    { "VX001-001", "VX001", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "VX002-001", "VX002", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "VX003-001", "VX003", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LIEUVACXINs_MaLoaiVX",
                table: "LIEUVACXINs",
                column: "MaLoaiVX");

            migrationBuilder.CreateIndex(
                name: "IX_TIEMCHUNGs_MaCD",
                table: "TIEMCHUNGs",
                column: "MaCD");

            migrationBuilder.CreateIndex(
                name: "IX_TIEMCHUNGs_MaLieuVX",
                table: "TIEMCHUNGs",
                column: "MaLieuVX");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TIEMCHUNGs");

            migrationBuilder.DropTable(
                name: "CONGDANs");

            migrationBuilder.DropTable(
                name: "LIEUVACXINs");

            migrationBuilder.DropTable(
                name: "LOAIVACXINs");
        }
    }
}
