using HospitalManagementSystem.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.Entities
{
    public class PatientDoctorEntity : BaseEntity
    {
        //A table created to show which patient has an appointment with which doctor.
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DoctorEntity Doctor { get; set; }
        public PatientEntity Patient { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
    public class PatientDoctorConfiguration : BaseConfiguration<PatientDoctorEntity>
    {
        public override void Configure(EntityTypeBuilder<PatientDoctorEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
