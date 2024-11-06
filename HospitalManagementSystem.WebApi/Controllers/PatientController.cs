using HospitalManagementSystem.Business.Operations.Patient;
using HospitalManagementSystem.Business.Operations.Patient.Dto;
using HospitalManagementSystem.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        [Authorize(Roles ="Doctor")]
        public async Task<IActionResult> AddPatient(AddPatientRequest request)
        {
            var addPatientDto = new AddPatientDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DiseaseIds = request.DiseaseIds,
                DiseaseName = request.DiseaseName
            };

            var result = await _patientService.AddPatient(addPatientDto);

            if(!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok();
            }
        }
    }
}
