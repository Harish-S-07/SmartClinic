using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SmartClinic.Domain.Entities;
using SmartClinic.Domain.Enums;
using SmartClinic.Application.Interfaces;
using SmartClinic.Application.Models.Appointment;
using SmartClinic.Infrastructure.Data;

namespace SmartClinic.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly SmartClinicDbContext _context;
        private readonly IMapper _mapper;
        public AppointmentService(SmartClinicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<AppointmentDTO> IAppointmentService.CreateAppointmentAsync(CreateAppointmentDTO appointment)
        {
            var newAppointment = _mapper.Map<Appointment>(appointment);
            newAppointment.Id = Guid.NewGuid();
            newAppointment.Status = AppointmentStatus.Scheduled;
            _context.Appointments.Add(newAppointment);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentDTO>(newAppointment);
        }

        async Task<bool> IAppointmentService.DeleteAppointmentAsync(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return false;
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<List<AppointmentDTO>> IAppointmentService.GetAllAppointmentsAsync()
        {
            var appointments = await _context.Appointments
                .Select(a => new AppointmentDTO
                {
                    Id = a.Id,
                    PatientName = a.Patient!.FullName,
                    DoctorName = a.Doctor!.Name,
                    AppointmentDate = a.AppointmentDate,
                    Status = a.Status,
                    Reason = a.Reason
                })
                .ToListAsync();

            return _mapper.Map<List<AppointmentDTO>>(appointments);
        }

        async Task<AppointmentDTO?> IAppointmentService.GetAppointmentByIdAsync(Guid id)
        {
            var appointment = await _context.Appointments
                .Where(a => a.Id == id)
                .Select(a => new AppointmentDTO
                {
                    Id = a.Id,
                    PatientName = a.Patient!.FullName,
                    DoctorName = a.Doctor!.Name,
                    AppointmentDate = a.AppointmentDate,
                    Status = a.Status,
                    Reason = a.Reason   
                })
                .FirstOrDefaultAsync();

            if (appointment == null)
                return null;

            return appointment;
        }

        async Task<AppointmentDTO?> IAppointmentService.UpdateAppointmentAsync(Guid id, UpdateAppointmentDTO appointment)
        {
            var existingAppointment = await _context.Appointments.FindAsync(id);
            if (existingAppointment == null)
                return null;
            _mapper.Map(appointment, existingAppointment);
            _context.Appointments.Update(existingAppointment);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentDTO>(existingAppointment);
        }

        async Task<bool> IAppointmentService.UpdateAppointmentStatusAsync(UpdateAppointmentStatusDTO updateStatus)
        {  
            var existingAppintment = await _context.Appointments.FindAsync(updateStatus.AppointmentId);
            if (existingAppintment == null)
                return false;
            existingAppintment.Status = updateStatus.Status;
            _context.Appointments.Update(existingAppintment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
