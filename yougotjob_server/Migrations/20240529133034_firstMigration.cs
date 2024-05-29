using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yougotjob_server.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentAgenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDay = table.Column<int>(type: "int", nullable: false),
                    AppointmentMonth = table.Column<int>(type: "int", nullable: false),
                    AppointmentYear = table.Column<int>(type: "int", nullable: false),
                    AppointmentTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAppointmentComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthPractitionersTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileRecovery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailRecovery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthPractitionersTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientUsersTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailRecovery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileRecovery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    BMI = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientUsersTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuingOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertificationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificationAttachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HealthPractitionersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifications_HealthPractitionersTable_HealthPractitionersId",
                        column: x => x.HealthPractitionersId,
                        principalTable: "HealthPractitionersTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientUsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_PatientUsersTable_PatientUsersId",
                        column: x => x.PatientUsersId,
                        principalTable: "PatientUsersTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_HealthPractitionersId",
                table: "Certifications",
                column: "HealthPractitionersId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_PatientUsersId",
                table: "EmergencyContact",
                column: "PatientUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentsTable");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "HealthPractitionersTable");

            migrationBuilder.DropTable(
                name: "PatientUsersTable");
        }
    }
}
