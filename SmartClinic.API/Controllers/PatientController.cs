using Microsoft.AspNetCore.Mvc;
using SmartClinic.Application.Interfaces;
using SmartClinic.Application.Models;

namespace SmartClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("patients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpPost("patients")]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientRequest patientDTO)
        {
            if (patientDTO == null)
            {
                return BadRequest("Patient data is required.");
            }

            var createdPatient = await _patientService.CreatePatientAsync(patientDTO);
            return CreatedAtAction(nameof(Get), new { id = createdPatient.Id }, createdPatient);
        }

        [HttpDelete("patients/{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound($"Patient with ID {id} not found.");
        }

        [HttpGet("patients/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPut("patients/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePatientRequest dto)
        {

            var patient = await _patientService.UpdatePatientAsync(id, dto);
            if (patient == null) return NotFound();
            return Ok();
        }
    }
}
