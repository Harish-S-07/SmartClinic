using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SmartApplication.Domain.Entities;
using SmartClinic.Application.Models;

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
        }
    }
}
