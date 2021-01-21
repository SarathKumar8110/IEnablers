using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IEnablers.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Appointment_ID = table.Column<int>(type: "int", nullable: false),
                    Provider_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patient_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appointment_Date_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visit_Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PATIENT_RELATIONSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appointment_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientMail_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderMail_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPI = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Appointment_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");
        }
    }
}
