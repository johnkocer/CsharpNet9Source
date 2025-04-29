Console.Write("What is your name? ");
string name = Console.ReadLine();
if (string.IsNullOrEmpty(name)) name = "Guest";
Console.WriteLine($"Hello, {name}! Time: {DateTime.Now}");
