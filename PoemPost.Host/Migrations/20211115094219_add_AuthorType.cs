using Microsoft.EntityFrameworkCore.Migrations;

namespace PoemPost.Host.Migrations
{
    public partial class add_AuthorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorType",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorType",
                table: "Authors");
        }
    }
}
