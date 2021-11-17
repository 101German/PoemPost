using Microsoft.EntityFrameworkCore.Migrations;

namespace PoemPost.Host.Migrations
{
    public partial class update_subscription_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Subscriptions");
        }
    }
}
