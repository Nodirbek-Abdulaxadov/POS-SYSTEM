using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_System.Data.Migrations
{
    public partial class clientHasLoanColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasLoan",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasLoan",
                table: "Clients");
        }
    }
}
