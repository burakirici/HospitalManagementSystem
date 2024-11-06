using HospitalManagementSystem.Business.Operations.Feature;
using HospitalManagementSystem.Business.Operations.Feature.Dtos;
using HospitalManagementSystem.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;
        public DiseasesController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddDisease(AddDiseaseRequest request)
        {
            var addDiseaseDto = new AddDiseaseDto
            {
                DiseaseName = request.DiseaseName,
            };

            var result = await _diseaseService.AddDisease(addDiseaseDto);

            if(result.IsSucceed)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
