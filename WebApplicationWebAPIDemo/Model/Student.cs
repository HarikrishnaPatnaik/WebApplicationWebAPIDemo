using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationWebAPIDemo.Model
{
    [Table("tblStudents")]
    public class Student
    {
        [Key]
        public int StdId { get; set; }

        [Required(ErrorMessage = "Student Name is a required field.")]
        [MaxLength(30,ErrorMessage = "Student name should not be more than 30 characters.")]
        [MinLength(3, ErrorMessage = "Student name should not be less than 3 characters.")]
        public string StdName { get; set; }

        [Required]
        public int StdAge { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")]
        public string StdEmail { get; set; }
    }
}
