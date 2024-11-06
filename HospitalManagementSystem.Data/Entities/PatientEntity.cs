using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.Entities
{
    public class PatientEntity : BaseEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserEntity User { get; set; }
        public string Disease { get; set; }
        public string Gender { get; set; }
        public ICollection<AppointmentEntity> Appointments { get; set; }
        public ICollection<PatientDiseaseEntity> PatientDiseas { get; set; }
        public ICollection<PatientDoctorEntity> PatientDoctors { get; set; }
    }

    public class PatientConfiguration : BaseConfiguration<PatientEntity>
    {
        public override void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            
            builder.HasIndex(p => p.FirstName);
            base.Configure(builder);
        }
    }
}
