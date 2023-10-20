using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabLabDevice.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    EquipmentTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.EquipmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectName);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierName);
                });

            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    BorrowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Borrower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnSite = table.Column<bool>(type: "bit", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => x.BorrowId);
                    table.ForeignKey(
                        name: "FK_Borrows_Projects_ProjectName",
                        column: x => x.ProjectName,
                        principalTable: "Projects",
                        principalColumn: "ProjectName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfSupply = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeOfManage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EquipmentTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "EquipmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_Suppliers_SupplierName",
                        column: x => x.SupplierName,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowsEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowsEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowsEquipments_Borrows_BorrowId",
                        column: x => x.BorrowId,
                        principalTable: "Borrows",
                        principalColumn: "BorrowId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowsEquipments_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Equipments_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_ProjectName",
                table: "Borrows",
                column: "ProjectName");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowsEquipments_BorrowId",
                table: "BorrowsEquipments",
                column: "BorrowId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowsEquipments_EquipmentId",
                table: "BorrowsEquipments",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentTypeId",
                table: "Equipments",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_SupplierName",
                table: "Equipments",
                column: "SupplierName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowsEquipments");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
