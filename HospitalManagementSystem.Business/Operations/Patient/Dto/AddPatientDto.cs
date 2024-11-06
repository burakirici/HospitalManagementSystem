using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business.Operations.Patient.Dto
{
    public class AddPatientDto
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string DiseaseName { get; set; }

        public List<int> DiseaseIds { get; set; }
    }
}
