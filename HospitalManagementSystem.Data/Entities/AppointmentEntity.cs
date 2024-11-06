using HospitalManagementSystem.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.Entities
{
    public class AppointmentEntity : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public DoctorEntity Doctor { get; set; }
        public PatientEntity Patient { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; } // For Pending, Cancelled or Confirmed.

        

    }

    public class AppointmentConfiguration : BaseConfiguration<AppointmentEntity>
    {
        public override void Configure(EntityTypeBuilder<AppointmentEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
