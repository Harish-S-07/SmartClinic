using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartApplication.Domain.Entities;

namespace SmartClinic.Infrastructure.Data
{
    public class SmartClinicDbContext : DbContext
    {
        public SmartClinicDbContext(DbContextOptions<SmartClinicDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
