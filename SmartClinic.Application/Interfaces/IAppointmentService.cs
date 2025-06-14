using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartClinic.Application.Models.Appointment;

namespace SmartClinic.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDTO>> GetAllAppointmentsAsync();
        Task<AppointmentDTO?> GetAppointmentByIdAsync(Guid id);
        Task<AppointmentDTO> CreateAppointmentAsync(CreateAppointmentDTO appointment);
        Task<AppointmentDTO?> UpdateAppointmentAsync(Guid id, UpdateAppointmentDTO appointment);
        Task<bool> DeleteAppointmentAsync(Guid id);
        Task<bool> UpdateAppointmentStatusAsync(UpdateAppointmentStatusDTO updateStatus);
    }
}
