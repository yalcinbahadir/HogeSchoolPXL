using HogeSchoolPXL.Domein;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhotoUrl { get; set; }

        public static Student MapStudent(StudentModel model)
        {
            var student = new Student
            {
                Name=model.Name, 
                LastName=model.LastName, 
                Email=model.Email,
                PhotoUrl=model.PhotoUrl
               
            };

            return student;
        }
    }
}
