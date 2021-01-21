using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IEnablers.Models
{
    public class AppointmentItemsForTB
    {
        [Key]
        public int Appointment_ID
        {
            get;
            set;
        }

        public string Provider_ID
        {
            get;
            set;

        }

        public string Patient_ID
        {
            get;
            set;
        }

        public DateTime Appointment_Date
        {

            get;
            set;
        }
       
        public string Appointment_Time
        {

            get;
            set;
        }

        public string Visit_Reason
        {
            get;
            set;
        }

        
        public string Appointment_Status
        {
            get;
            set;
        }
       
    }
}
