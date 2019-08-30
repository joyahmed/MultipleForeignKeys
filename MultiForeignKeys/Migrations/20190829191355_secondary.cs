using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiForeignKeys.Migrations
{
    public partial class secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DesignationName",
                table: "Designations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignationName",
                table: "Designations");
        }
    }
}
