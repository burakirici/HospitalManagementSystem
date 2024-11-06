using HospitalManagementSystem.Business.Operations.Patient.Dto;
using HospitalManagementSystem.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business.Operations.Patient
{
    public interface IPatientService
    {
        Task<ServiceMessage> AddPatient(AddPatientDto patient);
    }
}
