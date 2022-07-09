using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamWorkMVC.Web.Migrations
{
    public partial class LazyLoadingBugFixed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Tasks");
        }
    }
}
