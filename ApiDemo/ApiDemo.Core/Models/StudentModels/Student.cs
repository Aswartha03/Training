using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ApiDemo.Core.Models.StudentModels
{
    public class Student
    {
        //[Required(ErrorMessage ="Name is Requred.")] 
        public string? Name { get; set; }
		public int StudentId { get; set; }

        //[Required] 
		public int? Age { get; set; } 
    }
}
