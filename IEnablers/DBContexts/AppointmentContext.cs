using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEnablers.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.SqlServer;


// AppointmentContext  is needed so that the models could interact with the database

namespace IEnablers.DBContexts 
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
        }
        #region Configuration 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Data Source=COL011023908\SQLEXPRESS;Initial Catalog=IEnablers;User ID=sa;Password=Vallika143@@;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        #endregion   

        //AppointmentContext which includes the DbSet properties for appointments and APPOINTMENT_TB. 
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<AppointmentItemsForTB> APPOINTMENT_TB { get; set; }


    }
}
