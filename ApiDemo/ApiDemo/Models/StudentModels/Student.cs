using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ApiDemo.Models.StudentModels
{
    public class Student
    {
        [Required(ErrorMessage ="Name is Requred.")] 
        public string? Name { get; set; }
		public int studentId { get; set; }

        [Required]
		public int? Age { get; set; }
    }
}
