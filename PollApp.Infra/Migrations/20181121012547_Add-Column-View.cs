using Microsoft.EntityFrameworkCore.Migrations;

namespace PollApp.Infra.Migrations
{
    public partial class AddColumnView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Poll",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Poll");
        }
    }
}
