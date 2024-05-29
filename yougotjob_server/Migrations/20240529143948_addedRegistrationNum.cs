using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yougotjob_server.Migrations
{
    public partial class addedRegistrationNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "HealthPractitionersTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "HealthPractitionersTable");
        }
    }
}
