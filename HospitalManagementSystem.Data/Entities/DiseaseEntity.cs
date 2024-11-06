using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.Entities
{
    public class DiseaseEntity : BaseEntity
    {
        public string DiseaseName { get; set; }
        public ICollection<PatientDiseaseEntity> PatientDiseases { get; set; }
    }
    public class DiseaseConfiguration : BaseConfiguration<DiseaseEntity>
    {
        public override void Configure(EntityTypeBuilder<DiseaseEntity> builder)
        {
            builder.Property(d => d.DiseaseName).IsRequired().HasMaxLength(100);
            base.Configure(builder);
        }
    }
}
