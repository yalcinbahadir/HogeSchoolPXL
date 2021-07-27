using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Models
{
    public class RegistrationModel
    {
        public string RegistrationId { get; set; }
        [Required(ErrorMessage = " Student is required.")]
        public string StudentId { get; set; }
        [Required(ErrorMessage = " Course is required.")]
        public string CourseId { get; set; }
    }
}
