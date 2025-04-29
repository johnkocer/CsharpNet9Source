// Models/Student.cs
namespace StudentRecods.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public char Grade { get; set; }
        public string Email { get; set; }

        public Student()
        {
            Name = string.Empty;
            Email = string.Empty;
        }
    }
}
