using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IEnablers.DBContexts;
using IEnablers.Models;

/// <summary>
/// Repository works as a micro component of microservice that encapsulates the data access layer and helps in data persistence and testability as well.
/// below  methods in the interface that performs CRUD operations for Appointment microservice.
/// </summary>

namespace IEnablers.Repository
{
    public class AppointmentRepository :IAppointment
    {
        private readonly AppointmentContext dbContext;

        public AppointmentRepository(AppointmentContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteAppointment(int Appointment_ID)
        {
            var appointment = dbContext.APPOINTMENT_TB.Find(Appointment_ID);
            if (appointment!=null)
            {
                dbContext.APPOINTMENT_TB.Remove(appointment);
                Save();
                
            }
           
        }
        public Appointment GetApponitmentbyID(int Appointment_ID)
        {
            return dbContext.appointments.FromSqlRaw<Appointment>("SP_GetApoointmentDataByID {0}",Appointment_ID).ToList().FirstOrDefault();
        }
        public IEnumerable<Appointment> GetApponitment()
        {
            return dbContext.appointments.FromSqlRaw<Appointment>("Sp_appointmentBYid").ToList();
        }
        public void InsertAppointment(AppointmentItemsForTB APPOINTMENT_TB)
        {
            dbContext.APPOINTMENT_TB.Add(APPOINTMENT_TB);
            dbContext.SaveChanges();
            
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public void UpdateAppointment(AppointmentItemsForTB appointment)
        {
            dbContext.Entry(appointment).State = EntityState.Modified;
            Save();
        }
    }
}
