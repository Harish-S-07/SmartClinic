using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Application.Models
{
    public class DoctorDTO : CreateDoctorDTO
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
