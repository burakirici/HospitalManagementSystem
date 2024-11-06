using HospitalManagementSystem.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public UserType Role { get; set; }

        public ICollection<AppointmentEntity> Appointments { get; set; }
    }

    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Password)
                .IsRequired();
            builder.Property(u => u.Role)
                .IsRequired();
            base.Configure(builder);
        }
    }
}
