using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartApplication.Domain.Entities;
using SmartClinic.Application.Interfaces;
using SmartClinic.Application.Models;
using SmartClinic.Infrastructure.Data;

namespace SmartClinic.Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly SmartClinicDbContext _context;
        private readonly IMapper _mapper;
        public DoctorService(SmartClinicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<DoctorDTO> IDoctorService.CreateDoctorAsync(CreateDoctorDTO dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            doctor.Id = Guid.NewGuid();
            doctor.IsActive = true;
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return _mapper.Map<DoctorDTO>(doctor);
        }

        async Task<bool> IDoctorService.DeleteDoctorAsync(Guid id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<IEnumerable<DoctorDTO>> IDoctorService.GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors.Where(x => x.IsActive).ToListAsync();
            return _mapper.Map<List<DoctorDTO>>(doctors);
        }

        async Task<DoctorDTO?> IDoctorService.GetDoctorByIdAsync(Guid id)
        {
           var doctorEntity = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (doctorEntity == null)
                return null;
            return _mapper.Map<DoctorDTO>(doctorEntity);
        }

        async Task<DoctorDTO?> IDoctorService.UpdateDoctorAsync(Guid id, UpdateDoctorDTO dto)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (doctor == null)
                return null;

            _mapper.Map(dto, doctor);
            await _context.SaveChangesAsync();
            return _mapper.Map<DoctorDTO>(doctor);
        }

        async Task<bool> IDoctorService.ChangeDoctorStatusAsync(Guid id, bool isActive)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return false;
            doctor.IsActive = isActive;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
