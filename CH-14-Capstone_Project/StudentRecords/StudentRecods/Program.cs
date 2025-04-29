using StudentRecods.Models;
using StudentRecods.Services;

namespace StudentRecods
{
  internal class Program
  {
    private static IStudentService _studentService = new StudentService();

    static void Main()
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine("=== Student Records Management ===");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Update Student");
        Console.WriteLine("3. Find Student");
        Console.WriteLine("4. Delete Student");
        Console.WriteLine("5. Search by Name");
        Console.WriteLine("6. Display All Students");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
          case "1": AddStudent(); break;
          case "2": UpdateStudent(); break;
          case "3": FindStudent(); break;
          case "4": DeleteStudent(); break;
          case "5": SearchByName(); break;
          case "6": DisplayAllStudents(); break;
          case "7": return;
          default: Console.WriteLine("Invalid option!"); break;
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
      }
    }

    // Feature implementations below...
    static void AddStudent()
    {
      Console.Write("Name: ");
      string name = Console.ReadLine();

      Console.Write("Age: ");
      int age = int.Parse(Console.ReadLine());

      Console.Write("Grade (A-F): ");
      char grade = char.Parse(Console.ReadLine());

      Console.Write("Email: ");
      string email = Console.ReadLine();

      _studentService.AddStudent(new Student { Name = name, Age = age, Grade = grade, Email = email });
      Console.WriteLine("Student added successfully!");
    }

    static void UpdateStudent()
    {
      Console.Write("Enter student name to update: ");
      string name = Console.ReadLine();

      var student = _studentService.FindStudent(name);
      if (student == null)
      {
        Console.WriteLine("Student not found!");
        return;
      }

      Console.Write($"New Name ({student.Name}): ");
      string newName = Console.ReadLine();

      Console.Write($"New Age ({student.Age}): ");
      int newAge = int.Parse(Console.ReadLine());

      Console.Write($"New Grade ({student.Grade}): ");
      char newGrade = char.Parse(Console.ReadLine());

      Console.Write($"New Email ({student.Email}): ");
      string newEmail = Console.ReadLine();

      _studentService.UpdateStudent(name, new Student
      {
        Name = string.IsNullOrEmpty(newName) ? student.Name : newName,
        Age = newAge,
        Grade = newGrade,
        Email = string.IsNullOrEmpty(newEmail) ? student.Email : newEmail
      });

      Console.WriteLine("Student updated successfully!");
    }

    static void FindStudent()
    {
      Console.Write("Enter student name: ");
      string name = Console.ReadLine();

      var student = _studentService.FindStudent(name);
      if (student == null)
        Console.WriteLine("Student not found!");
      else
        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}, Email: {student.Email}");
    }

    static void DeleteStudent()
    {
      Console.Write("Enter student name to delete: ");
      string name = Console.ReadLine();

      _studentService.DeleteStudent(name);
      Console.WriteLine("Student deleted successfully!");
    }

    static void SearchByName()
    {
      Console.Write("Enter search keyword: ");
      string keyword = Console.ReadLine();

      var students = _studentService.SearchByName(keyword);
      if (students.Count == 0)
        Console.WriteLine("No matching students found.");
      else
      {
        Console.WriteLine("Matching Students:");
        foreach (var s in students)
          Console.WriteLine($"- {s.Name}, {s.Age}, {s.Grade}, {s.Email}");
      }
    }

    static void DisplayAllStudents()
    {
      var students = _studentService.GetAllStudents();
      if (students.Count == 0)
        Console.WriteLine("No students in database.");
      else
      {
        Console.WriteLine("All Students:");
        Console.WriteLine("Name\tAge\tGrade\tEmail");
        foreach (var s in students)
          Console.WriteLine($"{s.Name}\t{s.Age}\t{s.Grade}\t{s.Email}");
      }
    }
  }
}
