using ApiDemo.Core.Entities;
using ApiDemo.Core.Interfaces;
using ApiDemo.Core.Models.StudentModels;
using PetaPoco;
namespace ApiDemo.Infrastructure.Repositaries
{
    public class StudentRepo : IStudentRepo
    {
        private readonly Database db; 
        public StudentRepo(Database database) 
        {
			db = database;
		} 
        public Student AddStudent(Student student) 
        {
			// Using PetaPoco
			db.Insert("Students", "StudentId", true, student);
			return student; // StudentId will be populated here
		}

		public bool DeleteStudent(int id) 
        {
            //need to delete the student into db
            // Using PetaPoco 
            db.Delete("Students", "StudentId", null, id);
            return true;
        }

        public StudentEntity? GetStudentById(int id)
        {
            // retrive the student by id  from db if it contains or null
            StudentEntity? studentEntity = db.FirstOrDefault<StudentEntity>("SELECT * FROM Students WHERE StudentId = @0", id);
			return studentEntity;
        }

        public List<StudentEntity> GetAll()
        {
            // retrive all students
            // using PETAPOCO
            var students = db.Fetch<StudentEntity>("SELECT * FROM Students");
            return students;
        }

        public StudentEntity UpdateStudent(StudentEntity existingStudent,Student student)
        {
            // need to update student in db with given id
            // using petapoco 
            if (student.Name!=null)
            {
                existingStudent.Name = student.Name;
            }
            if (student.Age.HasValue) {
                existingStudent.Age = student.Age.Value;
            } 
            db.Update("Students","StudentId",existingStudent);
            return existingStudent;
		}
	}
}
