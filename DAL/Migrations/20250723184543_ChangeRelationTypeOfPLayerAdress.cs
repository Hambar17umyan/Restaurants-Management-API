using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationTypeOfPLayerAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_AlternateAddressId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_OfficeAddressId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PrimaryAddressId",
                table: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AlternateAddressId",
                table: "Players",
                column: "AlternateAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_OfficeAddressId",
                table: "Players",
                column: "OfficeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PrimaryAddressId",
                table: "Players",
                column: "PrimaryAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_AlternateAddressId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_OfficeAddressId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PrimaryAddressId",
                table: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AlternateAddressId",
                table: "Players",
                column: "AlternateAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_OfficeAddressId",
                table: "Players",
                column: "OfficeAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PrimaryAddressId",
                table: "Players",
                column: "PrimaryAddressId",
                unique: true);
        }
    }
}
