using HospitalManagementSystem.Business.Operations.Patient.Dto;
using HospitalManagementSystem.Business.Types;
using HospitalManagementSystem.Data.Entities;
using HospitalManagementSystem.Data.Repositories;
using HospitalManagementSystem.Data.UnitOfwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business.Operations.Patient
{
    public class PatientManager : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PatientEntity> _patientRepository;
        private readonly IRepository<PatientDiseaseEntity> _patientDiseaseRepository;
        public PatientManager(IUnitOfWork unitOfWork, IRepository<PatientEntity> patientRepository, IRepository<PatientDiseaseEntity> patientDiseaseRepository)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
            _patientDiseaseRepository = patientDiseaseRepository;
        }

        public async Task<ServiceMessage> AddPatient(AddPatientDto patient)
        {
            var hasPatient = _patientRepository.GetAll(x => x.FirstName.ToLower() == patient.FirstName.ToLower()).Any();

            if(hasPatient)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu otel zaten sistemde mevcut."
                };
            }

            await _unitOfWork.BeginTransaction();

            var patientEntity = new PatientEntity
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Disease = patient.DiseaseName,
              

            };

            _patientRepository.Add(patientEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw new Exception("We encountered a problem during patient registration!");
            }

            foreach(var diseaseId in patient.DiseaseIds)
            {
                var patientDisease = new PatientDiseaseEntity
                {
                    PatientId = patientEntity.Id,
                    DiseaseId = diseaseId

                };

                _patientDiseaseRepository.Add(patientDisease);
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("An error was encountered while adding the patient's diseases, and the process restarted.");
            }
            return new ServiceMessage
            {
                IsSucceed = true
            };
        }
    }
}
