using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabLabDevice.Api.Migrations
{
    /// <inheritdoc />
    public partial class changeAddressConfiguretooneMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Equipments_LocationId",
                table: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "LocationId",
                table: "Equipments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_LocationId",
                table: "Equipments",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Locations_LocationId",
                table: "Equipments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Locations_LocationId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_LocationId",
                table: "Equipments");

            migrationBuilder.AlterColumn<string>(
                name: "LocationId",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Equipments_LocationId",
                table: "Locations",
                column: "LocationId",
                principalTable: "Equipments",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
