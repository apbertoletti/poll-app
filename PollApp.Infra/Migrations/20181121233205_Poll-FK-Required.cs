using Microsoft.EntityFrameworkCore.Migrations;

namespace PollApp.Infra.Migrations
{
    public partial class PollFKRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PollID",
                table: "PollOption",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PollID",
                table: "PollOption",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
