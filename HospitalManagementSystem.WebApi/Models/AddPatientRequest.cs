using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.WebApi.Models
{
    public class AddPatientRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DiseaseName { get; set; }
        
        public List<int> DiseaseIds { get; set; }
    }
}
