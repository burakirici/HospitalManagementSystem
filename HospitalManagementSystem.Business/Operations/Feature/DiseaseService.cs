using HospitalManagementSystem.Business.Operations.Feature.Dtos;
using HospitalManagementSystem.Business.Types;
using HospitalManagementSystem.Data.Entities;
using HospitalManagementSystem.Data.Repositories;
using HospitalManagementSystem.Data.UnitOfwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business.Operations.Feature
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<DiseaseEntity> _diseaseRepository;
        public DiseaseService(IUnitOfWork unitOfWork, IRepository<DiseaseEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _diseaseRepository = repository;
        }
        public async Task<ServiceMessage> AddDisease(AddDiseaseDto disease)
        {
            var hasDisease = _diseaseRepository.GetAll(x => x.DiseaseName.ToLower() == disease.DiseaseName.ToLower()).Any();

            if (hasDisease)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "the process failed, this Disease is already present"
                };
            }

            var diseaseEntity = new DiseaseEntity
            {
                DiseaseName = disease.DiseaseName,
            };

            _diseaseRepository.Add(diseaseEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw new Exception("An error occurred while registering a disease");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }
    }
}
