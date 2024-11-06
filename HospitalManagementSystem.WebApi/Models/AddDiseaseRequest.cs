using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.WebApi.Models
{
    public class AddDiseaseRequest
    {
        [Required]
        public string DiseaseName { get; set; }
    }
}
