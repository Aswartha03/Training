using ApiDemo.Core.Entities;
using ApiDemo.Core.Models.StudentModels;

namespace ApiDemo.Core.Interfaces
{
    public interface IStudentRepo
    {
        public List<StudentEntity> GetAll();

        public StudentEntity? GetStudentById(int id); 

        public Student AddStudent(Student student) ;

        public StudentEntity UpdateStudent(StudentEntity studentExist,Student student) ;

        public bool DeleteStudent(int id) ;

    }
}
