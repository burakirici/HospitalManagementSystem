using HospitalManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.Context
{
    public class HospitalManagementSystemDbContext : DbContext
    {
        public HospitalManagementSystemDbContext(DbContextOptions<HospitalManagementSystemDbContext> options) : base(options)
        {
            
        }
        // Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientDoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DiseaseConfiguration());
            modelBuilder.ApplyConfiguration(new PatientDiseaseConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<PatientEntity> Patients => Set<PatientEntity>();
        public DbSet<DiseaseEntity> Diseases => Set<DiseaseEntity>();
        public DbSet<PatientDiseaseEntity> PatientDiseases => Set<PatientDiseaseEntity>();
        public DbSet<DoctorEntity> Doctors => Set<DoctorEntity>();
        public DbSet<AppointmentEntity> Appointments => Set<AppointmentEntity>();
        public DbSet<PatientDoctorEntity> PatientDoctors => Set<PatientDoctorEntity>();
        
    }
}
