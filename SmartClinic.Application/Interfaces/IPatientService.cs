using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartClinic.Application.Models;

namespace SmartClinic.Application.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientDTO>> GetAllPatientsAsync();   
        Task<PatientDTO> GetPatientByIdAsync(Guid id);
        Task<PatientDTO> CreatePatientAsync(CreatePatientRequest patient);
        Task<PatientDTO> UpdatePatientAsync(Guid id, UpdatePatientRequest patient);
        Task<bool> DeletePatientAsync(Guid id);
    }
}
