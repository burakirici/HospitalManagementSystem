using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.Entities
{
    public  class PatientDiseaseEntity : BaseEntity
    {
        public int PatientId { get; set; }
        public PatientEntity Patient { get; set; }
        public int DiseaseId { get; set; }
        public DiseaseEntity Disease { get; set; }
        public DateTime DiagnosisDate { get; set; }

        

    }

    public class PatientDiseaseConfiguration : BaseConfiguration<PatientDiseaseEntity>
    {
        public override void Configure(EntityTypeBuilder<PatientDiseaseEntity> builder)
        {
            builder.Property(pd => pd.DiagnosisDate).IsRequired();
            base.Configure(builder);
        }
    }
}
