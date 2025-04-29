using StudentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Student.Services
{
    public class StudentService : IStudentService
    {
        private readonly string _filePath = "students.csv";

        public StudentService()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "Name,Age,Grade,Email");
            }
        }

        public void AddStudent(StudentModel.Student student)
        {
            var students = GetAllStudents();
            students.Add(student);
            SaveStudents(students);
        }

        public void UpdateStudent(StudentModel.Student student)
        {
            var students = GetAllStudents();
            var existingStudent = students.FirstOrDefault(s => s.Name.Equals(student.Name, StringComparison.OrdinalIgnoreCase));
            
            if (existingStudent != null)
            {
                existingStudent.Age = student.Age;
                existingStudent.Grade = student.Grade;
                existingStudent.Email = student.Email;
                SaveStudents(students);
            }
        }

        public void DeleteStudent(string name)
        {
            var students = GetAllStudents();
            students.RemoveAll(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            SaveStudents(students);
        }

        public StudentModel.Student GetStudent(string name)
        {
            return GetAllStudents()
                .FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<StudentModel.Student> SearchStudents(string searchTerm)
        {
            return GetAllStudents()
                .Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<StudentModel.Student> GetAllStudents()
        {
            var students = new List<StudentModel.Student>();
            var lines = File.ReadAllLines(_filePath).Skip(1);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    students.Add(new StudentModel.Student
                    {
                        Name = parts[0],
                        Age = int.Parse(parts[1]),
                        Grade = char.Parse(parts[2]),
                        Email = parts[3]
                    });
                }
            }

            return students;
        }

        private void SaveStudents(List<StudentModel.Student> students)
        {
            var lines = new List<string> { "Name,Age,Grade,Email" };
            lines.AddRange(students.Select(s => $"{s.Name},{s.Age},{s.Grade},{s.Email}"));
            File.WriteAllLines(_filePath, lines);
        }
    }
} 