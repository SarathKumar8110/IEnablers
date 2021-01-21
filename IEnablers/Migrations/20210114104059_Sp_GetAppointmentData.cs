using Microsoft.EntityFrameworkCore.Migrations;

namespace IEnablers.Migrations
{
    public partial class Sp_GetAppointmentData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create proc Sp_appointmentBYid 
                                     as
                                     begin
                                     Select ap.Provider_ID,ap.Appointment_ID,ap.Patient_ID,	
									 CONVERT(DATETIME, CONVERT(CHAR(8), ap.Appointment_Date, 112) 
                                     + ' ' + CONVERT(CHAR(8), ap.Appointment_Time, 108)) as Appointment_Date_Time,							      
                                     ap.Appointment_Status,ap.Visit_Reason,pt.EMAIL_ID as PatientMail_ID,pt.PATIENT_RELATIONSHIP,
                                     provider.EMAIL_ID as ProviderMail_ID,provider.NPI  from APPOINTMENT_TB ap join PATIENT_TB pt
                                     on ap.Patient_ID=pt.PATIENT_ID join PROVIDER_TB provider on ap.Provider_ID=provider.PROVIDER_ID
                                     end";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop proc Sp_appointmentBYid 
                                    ";
            migrationBuilder.Sql(procedure);

        }
    }
}
