using System;
using System.Collections.Generic;

class Car
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Year { get; set; }
  public string Model { get; set; }
}

class Program
{
  static List<Car> cars = new List<Car>();

  static void Main(string[] args)
  {
    while (true)
    {
      Console.WriteLine("Enter a command:");
      Console.WriteLine("1. Add a new car");
      Console.WriteLine("2. Update a car");
      Console.WriteLine("3. Delete a car");
      Console.WriteLine("4. Display all cars");
      Console.WriteLine("5. Find car by id");
      Console.WriteLine("6. Find car by name");
      Console.WriteLine("7. Exit");

      string input = Console.ReadLine();

      switch (input)
      {
        case "1":
          AddCar();
          break;
        case "2":
          UpdateCar();
          break;
        case "3":
          DeleteCar();
          break;
        case "4":
          DisplayAll();
          break;
        case "5":
          FindById();
          break;
        case "6":
          FindByName();
          break;
        case "7":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Invalid command.");
          break;
      }
    }
  }

  static void AddCar()
  {
    Console.WriteLine("Enter the name of the car:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter the year of the car:");
    int year = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the model of the car:");
    string model = Console.ReadLine();

    int id = cars.Count + 1;

    Car car = new Car { Id = id, Name = name, Year = year, Model = model };
    cars.Add(car);

    Console.WriteLine($"Added car with id {id}.");
  }

  static void UpdateCar()
  {
    Console.WriteLine("Enter the id of the car to update:");
    int id = int.Parse(Console.ReadLine());

    Car car = cars.Find(c => c.Id == id);

    if (car == null)
    {
      Console.WriteLine($"Car with id {id} not found.");
      return;
    }

    Console.WriteLine($"Current name: {car.Name}");
    Console.WriteLine("Enter the new name:");
    string name = Console.ReadLine();

    Console.WriteLine($"Current year: {car.Year}");
    Console.WriteLine("Enter the new year:");
    int year = int.Parse(Console.ReadLine());

    Console.WriteLine($"Current model: {car.Model}");
    Console.WriteLine("Enter the new model:");
    string model = Console.ReadLine();

    car.Name = name;
    car.Year = year;
    car.Model = model;

    Console.WriteLine($"Updated car with id {id}.");
  }

  static void DeleteCar()
  {
    Console.WriteLine("Enter the id of the car to delete:");
    int id = int.Parse(Console.ReadLine());

    Car car = cars.Find(c => c.Id == id);

    if (car == null)
    {
      Console.WriteLine($"Car with id {id} not found.");
      return;
    }

    cars.Remove(car);

    Console.WriteLine($"Deleted car with id {id}.");
  }

  static void DisplayAll()
  {
    foreach (var car in cars)
    {
      Console.WriteLine($"Id: {car.Id}, Name: {car.Name}, Year: {car.Year}, Model: {car.Model}");
    }
  }

  static void FindById()
  {
    Console.WriteLine("Enter the id of the car to find:");
    int id = int.Parse(Console.ReadLine());

    Car car = cars.Find(c => c.Id == id);

    if (car == null)
    {
      Console.WriteLine($"Car with id {id} not found.");
      return;
    }

    Console.WriteLine($"Id: {car.Id}, Name: {car.Name}, Year: {car.Year}, Model: {car.Model}");
  }

  static void FindByName()
  {
    Console.WriteLine("Enter the name of the car to find:");
    string name = Console.ReadLine();

    List<Car> matchingCars = cars.FindAll(c => c.Name.ToLower().Contains(name.ToLower()));

    if (matchingCars.Count == 0)
    {
      Console.WriteLine($"No cars found with name '{name}'.");
      return;
    }

  }
}

