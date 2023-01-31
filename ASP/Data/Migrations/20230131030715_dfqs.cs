using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Data.Migrations
{
    public partial class dfqs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cinema",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Actor",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Actor");
        }
    }
}
