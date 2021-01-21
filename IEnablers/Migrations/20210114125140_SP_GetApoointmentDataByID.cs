using Microsoft.EntityFrameworkCore.Migrations;

namespace IEnablers.Migrations
{
    public partial class SP_GetApoointmentDataByID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create proc SP_GetApoointmentDataByID
                                 @Appointment_id varchar(30)
                                    as
                                      begin
                                     Select ap.Provider_ID,ap.Appointment_ID,ap.Patient_ID,	
									 CONVERT(DATETIME, CONVERT(CHAR(8), ap.Appointment_Date, 112) 
                                     + ' ' + CONVERT(CHAR(8), ap.Appointment_Time, 108)) as Appointment_Date_Time,							      
                                     ap.Appointment_Status,ap.Visit_Reason,pt.EMAIL_ID as PatientMail_ID,pt.PATIENT_RELATIONSHIP,
                                     provider.EMAIL_ID as ProviderMail_ID,provider.NPI  from APPOINTMENT_TB ap join PATIENT_TB pt
                                     on ap.Patient_ID=pt.PATIENT_ID join PROVIDER_TB provider on ap.Provider_ID=provider.PROVIDER_ID where ap.Appointment_ID=@Appointment_id
                                     end";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop proc SP_GetApoointmentDataByID 
                                    ";
            migrationBuilder.Sql(procedure);
        }
    }
}
