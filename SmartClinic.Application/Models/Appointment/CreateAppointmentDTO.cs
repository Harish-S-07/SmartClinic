﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Application.Models.Appointment
{
    public class CreateAppointmentDTO
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
