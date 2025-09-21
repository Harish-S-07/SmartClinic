using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SmartClinic.Domain.Entities;
using SmartClinic.Application.Models.Appointment;
using SmartClinic.Application.Models.Doctor;
using SmartClinic.Application.Models.Patient;

namespace SmartClinic.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<CreatePatientRequest, Patient>();
            CreateMap<UpdatePatientRequest, Patient>();
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<CreateDoctorDTO, Doctor>();
            CreateMap<UpdateDoctorDTO, Doctor>();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<CreateAppointmentDTO, Appointment>();
            CreateMap<UpdateAppointmentDTO, Appointment>();
        }
    }
}
