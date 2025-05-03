namespace Student.Services
{
    public interface IStudentService
    {
        void AddStudent(StudentModel.Student student);
        void UpdateStudent(StudentModel.Student student);
        void DeleteStudent(string name);
        StudentModel.Student GetStudent(string name);
        List<StudentModel.Student> SearchStudents(string searchTerm);
        List<StudentModel.Student> GetAllStudents();
    }
} 