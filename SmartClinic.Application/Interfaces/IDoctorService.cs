using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartClinic.Application.Models.Doctor;

namespace SmartClinic.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<DoctorDTO> CreateDoctorAsync(CreateDoctorDTO dto);
        Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();
        Task<DoctorDTO?> GetDoctorByIdAsync(Guid id);
        Task<bool> DeleteDoctorAsync(Guid id);
        Task<DoctorDTO?> UpdateDoctorAsync(Guid id, UpdateDoctorDTO dto);
        Task<bool> ChangeDoctorStatusAsync(Guid id, bool isActive);
    }
}
