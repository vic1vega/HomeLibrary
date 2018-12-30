using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibrary.Migrations
{
    public partial class AddingIsRenFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRent",
                table: "Items",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRent",
                table: "Items");
        }
    }
}
