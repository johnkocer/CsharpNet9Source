using System;
using System.Collections.Generic;

class Todo
{
  public int Id { get; set; }
  public string Name { get; set; }
}

class Program
{
  static List<Todo> todos = new List<Todo>();

  static void Main(string[] args)
  {
    while (true)
    {
      Console.WriteLine("Enter a command:");
      Console.WriteLine("1. Add a new todo");
      Console.WriteLine("2. Update a todo");
      Console.WriteLine("3. Delete a todo");
      Console.WriteLine("4. Display all todos");
      Console.WriteLine("5. Exit");

      string input = Console.ReadLine();

      switch (input)
      {
        case "1":
          AddTodo();
          break;
        case "2":
          UpdateTodo();
          break;
        case "3":
          DeleteTodo();
          break;
        case "4":
          DisplayAll();
          break;
        case "5":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Invalid command.");
          break;
      }
    }
  }

  static void AddTodo()
  {
    Console.WriteLine("Enter the name of the todo:");
    string name = Console.ReadLine();

    int id = todos.Count + 1;

    Todo todo = new Todo { Id = id, Name = name };
    todos.Add(todo);

    Console.WriteLine($"Added todo with id {id}.");
  }

  static void UpdateTodo()
  {
    Console.WriteLine("Enter the id of the todo to update:");
    int id = int.Parse(Console.ReadLine());

    Todo todo = todos.Find(t => t.Id == id);

    if (todo == null)
    {
      Console.WriteLine($"Todo with id {id} not found.");
      return;
    }

    Console.WriteLine($"Current name: {todo.Name}");
    Console.WriteLine("Enter the new name:");
    string name = Console.ReadLine();

    todo.Name = name;

    Console.WriteLine($"Updated todo with id {id}.");
  }

  static void DeleteTodo()
  {
    Console.WriteLine("Enter the id of the todo to delete:");
    int id = int.Parse(Console.ReadLine());

    Todo todo = todos.Find(t => t.Id == id);

    if (todo == null)
    {
      Console.WriteLine($"Todo with id {id} not found.");
      return;
    }

    todos.Remove(todo);

    Console.WriteLine($"Deleted todo with id {id}.");
  }

  static void DisplayAll()
  {
    foreach (var todo in todos)
    {
      Console.WriteLine($"Id: {todo.Id}, Name: {todo.Name}");
    }
  }
}
