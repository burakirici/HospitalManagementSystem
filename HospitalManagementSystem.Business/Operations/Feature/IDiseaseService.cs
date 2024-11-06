using HospitalManagementSystem.Business.Operations.Feature.Dtos;
using HospitalManagementSystem.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business.Operations.Feature
{
    public interface IDiseaseService
    {
        Task<ServiceMessage> AddDisease(AddDiseaseDto disease);
    }
}
