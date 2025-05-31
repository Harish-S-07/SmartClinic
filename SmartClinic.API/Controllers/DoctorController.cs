using Microsoft.AspNetCore.Mvc;
using SmartClinic.Application.Interfaces;
using SmartClinic.Application.Models;

namespace SmartClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("doctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("doctors/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpPost("doctors")]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDTO doctorDTO)
        {
            if (doctorDTO == null)
                return BadRequest("Doctor data is required.");

            var createdDoctor = await _doctorService.CreateDoctorAsync(doctorDTO);
            return CreatedAtAction(nameof(Get), new { id = createdDoctor.Id }, createdDoctor);
        }

        [HttpPut("doctors/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDoctorDTO dto)
        {
            var doctor = await _doctorService.UpdateDoctorAsync(id, dto);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpDelete("doctors/{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var result = await _doctorService.DeleteDoctorAsync(id);
            if (result)
                return NoContent();

            return NotFound($"Doctor with ID {id} not found.");
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> ChangeStatus(Guid id, bool isActive)
        {
            var result = await _doctorService.ChangeDoctorStatusAsync(id, isActive);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}