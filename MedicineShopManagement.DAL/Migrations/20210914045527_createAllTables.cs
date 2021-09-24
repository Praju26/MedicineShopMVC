using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineShopManagement.DAL.Migrations
{
    public partial class createAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(nullable: true),
                    TotalBill = table.Column<decimal>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineDetailInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Cost_Price = table.Column<decimal>(nullable: false),
                   MedicineCode_Code = table.Column<string>(nullable: true),
                    IsFinanceable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDetailInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicine_Name = table.Column<string>(maxLength: 100, nullable: false),
                    Medicine_Type = table.Column<string>(nullable: false),
                    Medicine_Quantity = table.Column<int>(nullable: false),
                    Mediicine_Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisplayMedicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Cost_Price = table.Column<decimal>(nullable: false),
                    MedicineCode_Code = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisplayMedicines_MedicineType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MedicineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisplayMedicines_TypeId",
                table: "DisplayMedicines",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisplayMedicine");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "MedicineDetailInfos");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "MedicineType");
        }
    }
}
