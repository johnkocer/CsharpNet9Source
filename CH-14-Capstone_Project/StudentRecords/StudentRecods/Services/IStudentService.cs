using StudentRecods.Models;

namespace StudentRecods.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        void UpdateStudent(string name, Student updatedStudent);
        Student? FindStudent(string name);
        void DeleteStudent(string name);
        List<Student> SearchByName(string keyword);
        List<Student> GetAllStudents();
    }
}
