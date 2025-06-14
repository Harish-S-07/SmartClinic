using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartApplication.Domain.Entities;
using SmartClinic.Application.Interfaces;
using SmartClinic.Application.Models.Patient;
using SmartClinic.Infrastructure.Data;

namespace SmartClinic.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly SmartClinicDbContext _context;
        private readonly IMapper _mapper;
        public PatientService(SmartClinicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PatientDTO> CreatePatientAsync(CreatePatientRequest patientCreateRequest)
        {
            var patient = _mapper.Map<Patient>(patientCreateRequest);
            patient.Id = Guid.NewGuid();
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return _mapper.Map<PatientDTO>(patient);
        }

        public async Task<bool> DeletePatientAsync(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
                return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<PatientDTO>> GetAllPatientsAsync()
        {
            return await _context.Patients
               .Select(p => new PatientDTO
               {
                   Id = p.Id,
                   FullName = p.FullName,
                   Gender = p.Gender,
                   DateOfBirth = p.DateOfBirth,
                   PhoneNumber = p.PhoneNumber,
                   Address = p.Address
               })
               .ToListAsync();
        }

        public async Task<PatientDTO> GetPatientByIdAsync(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
                return null;

            return new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Gender = patient.Gender,
                DateOfBirth = patient.DateOfBirth,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address
            };
        }

        public async Task<PatientDTO> UpdatePatientAsync(Guid id, UpdatePatientRequest patientUpdateRequest)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null)
                return null;

            _mapper.Map(patientUpdateRequest, existingPatient);

            await _context.SaveChangesAsync();
            return _mapper.Map<PatientDTO>(existingPatient);
        }
    }
}
