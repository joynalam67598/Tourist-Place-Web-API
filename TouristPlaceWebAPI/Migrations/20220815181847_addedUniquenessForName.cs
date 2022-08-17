using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristPlaceWebAPI.Migrations
{
    public partial class addedUniquenessForName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToursitPlaces",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ToursitPlaces_Name",
                table: "ToursitPlaces",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToursitPlaces_Name",
                table: "ToursitPlaces");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToursitPlaces",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
