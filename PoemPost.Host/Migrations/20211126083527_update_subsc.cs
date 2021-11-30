using Microsoft.EntityFrameworkCore.Migrations;

namespace PoemPost.Host.Migrations
{
    public partial class update_subsc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Subscriptions");
        }
    }
}
