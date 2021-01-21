using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using IEnablers.Models;
using IEnablers.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Appointment controller  methods implement  by calling the repository methods

namespace IEnablers.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment _appointmentRepository;

        public AppointmentController(IAppointment appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        public IActionResult GetApponitments()
        {
            var appoint = _appointmentRepository.GetApponitment();
            return new OkObjectResult(appoint);
        }

        [HttpGet("{Appointment_ID}")]
        public IActionResult Get(int Appointment_ID)
        {
            var appoint = _appointmentRepository.GetApponitmentbyID(Appointment_ID);
            if (appoint == null)
            {
                return NotFound("The Appointment data  couldn't be found.");
            }
            return new OkObjectResult(appoint);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AppointmentItemsForTB appointment)
        {
            using (var scope = new TransactionScope())
            {
                _appointmentRepository.InsertAppointment(appointment);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = appointment.Appointment_ID }, appointment);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AppointmentItemsForTB appointment)
        {
            if (appointment != null)
            {
                using (var scope = new TransactionScope())
                {
                    _appointmentRepository.UpdateAppointment(appointment);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{Appointment_ID}")]
        public IActionResult Delete(int? Appointment_ID)
        {
            _appointmentRepository.DeleteAppointment(Appointment_ID.Value);
            if (Appointment_ID == null)
            {
                return BadRequest("data  not found");
            }
            else
            {
                return new OkResult();
                
            }
            
            
            
        }
    }
}
