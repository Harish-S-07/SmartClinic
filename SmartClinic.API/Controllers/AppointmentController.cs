using Microsoft.AspNetCore.Mvc;
using SmartClinic.Application.Interfaces;
using SmartClinic.Application.Models.Appointment;

namespace SmartClinic.API.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("appointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        [HttpGet("appointments/{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        [HttpPost("appointments")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDTO appointmentDTO)
        {
            if (appointmentDTO == null)
            {
                return BadRequest("Appointment data is required.");
            }
            var createdAppointment = await _appointmentService.CreateAppointmentAsync(appointmentDTO);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = createdAppointment.Id }, createdAppointment);
        }

        [HttpPut("appointments/{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] UpdateAppointmentDTO appointmentDTO)
        {
            if (appointmentDTO == null)
            {
                return BadRequest("Appointment data is required.");
            }
            var updatedAppointment = await _appointmentService.UpdateAppointmentAsync(id, appointmentDTO);
            if (updatedAppointment == null) return NotFound();
            return Ok(updatedAppointment);
        }

        [HttpDelete("appointments/{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            var result = await _appointmentService.DeleteAppointmentAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound($"Appointment with ID {id} not found.");
        }

        [HttpPut("appointments/status")]
        public async Task<IActionResult> UpdateAppointmentStatus([FromBody] UpdateAppointmentStatusDTO updateStatus)
        {
            if (updateStatus == null)
            {
                return BadRequest("Update status data is required.");
            }
            var result = await _appointmentService.UpdateAppointmentStatusAsync(updateStatus);
            if (result)
            {
                return NoContent();
            }
            return NotFound($"Appointment with ID {updateStatus.AppointmentId} not found.");
        }

    }
}
