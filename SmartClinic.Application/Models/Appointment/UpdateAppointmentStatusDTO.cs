using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartApplication.Domain.Enums;

namespace SmartClinic.Application.Models.Appointment
{
    public class UpdateAppointmentStatusDTO
    {
        public Guid AppointmentId { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
