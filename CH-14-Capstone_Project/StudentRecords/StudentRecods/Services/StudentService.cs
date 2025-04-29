using StudentRecods.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentRecods.Services
{
    public class StudentService : IStudentService
    {
        private readonly string _filePath = "students.csv";

        // Add a new student
        public void AddStudent(Student student)
        {
            var students = GetAllStudents();
            students.Add(student);
            SaveStudents(students);
        }

        // Update a student
        public void UpdateStudent(string name, Student updatedStudent)
        {
            var students = GetAllStudents();
            var student = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.Grade = updatedStudent.Grade;
                student.Email = updatedStudent.Email;
                SaveStudents(students);
            }
        }

        // Find a student by name
        public Student? FindStudent(string name)
        {
            return GetAllStudents()
                .FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Delete a student
        public void DeleteStudent(string name)
        {
            var students = GetAllStudents();
            students.RemoveAll(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            SaveStudents(students);
        }

        // Search students by name keyword
        public List<Student> SearchByName(string keyword)
        {
            return GetAllStudents()
                .Where(s => s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Get all students
        public List<Student> GetAllStudents()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            var lines = File.ReadAllLines(_filePath);
            return lines.Select(line =>
            {
                var data = line.Split(',');
                return new Student
                {
                    Name = data[0],
                    Age = int.Parse(data[1]),
                    Grade = char.Parse(data[2]),
                    Email = data[3]
                };
            }).ToList();
        }

        // Save students to CSV
        private void SaveStudents(List<Student> students)
        {
            var lines = students.Select(s => $"{s.Name},{s.Age},{s.Grade},{s.Email}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}
