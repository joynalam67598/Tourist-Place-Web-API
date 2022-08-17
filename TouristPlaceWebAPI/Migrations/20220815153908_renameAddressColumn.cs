using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristPlaceWebAPI.Migrations
{
    public partial class renameAddressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "ToursitPlaces",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ToursitPlaces",
                newName: "Adress");
        }
    }
}
