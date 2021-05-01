using Microsoft.EntityFrameworkCore.Migrations;

namespace real_estate_market.Migrations
{
    public partial class ApplyConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Cladding_CladdingId",
                table: "RealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cladding",
                table: "Cladding");

            migrationBuilder.RenameTable(
                name: "Cladding",
                newName: "Claddings");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claddings",
                table: "Claddings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Claddings_CladdingId",
                table: "RealEstates",
                column: "CladdingId",
                principalTable: "Claddings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Claddings_CladdingId",
                table: "RealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Claddings",
                table: "Claddings");

            migrationBuilder.RenameTable(
                name: "Claddings",
                newName: "Cladding");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "RealEstates",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cladding",
                table: "Cladding",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Cladding_CladdingId",
                table: "RealEstates",
                column: "CladdingId",
                principalTable: "Cladding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
