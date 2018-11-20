using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PollApp.Infra.Migrations
{
    public partial class Setup01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poll",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PollOption",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PollID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Votes = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollOption", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PollOption_Poll_PollID",
                        column: x => x.PollID,
                        principalTable: "Poll",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollOption_PollID",
                table: "PollOption",
                column: "PollID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollOption");

            migrationBuilder.DropTable(
                name: "Poll");
        }
    }
}
