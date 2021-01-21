using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEnablers.Models;

/// <summary>
/// Repository works as a micro component of microservice that encapsulates the data access layer and helps in data persistence and testability as well.
/// below  methods in the interface that performs CRUD operations for Appointment microservice.
/// </summary>

namespace IEnablers.Repository
{
   public interface IAppointment 
    {
        IEnumerable<Appointment> GetApponitment();

        Appointment GetApponitmentbyID(int Appointment_ID);
        void InsertAppointment(AppointmentItemsForTB appointment);

        void DeleteAppointment(int Appointment_ID);

        void UpdateAppointment(AppointmentItemsForTB appointment);

        void Save();
    }
}
