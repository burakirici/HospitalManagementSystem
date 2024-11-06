using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.Entities
{
    public class DoctorEntity : BaseEntity
    {

        public string Name { get; set; }
        public string? Specialization { get; set; }
        public ICollection<AppointmentEntity> Appointments { get; set; }
        public ICollection<PatientDoctorEntity> PatientDoctors { get; set; } = new List<PatientDoctorEntity>();
    }


    public class DoctorConfiguration : BaseConfiguration<DoctorEntity>
    {
        public override void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Specialization).HasMaxLength(100);
            builder.HasMany(d => d.PatientDoctors)
                   .WithOne(dp => dp.Doctor)
                   .HasForeignKey(dp => dp.DoctorId);
            base.Configure(builder);
        }
    }
}
