# StudentRecordsWinForm

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [User Interface](#user-interface)
- [Contributing](#contributing)
- [License](#license)
- [Author](#author)

## Overview
StudentRecordsWinForm is a Windows Forms application built in C# (.NET 9) to manage student records. It allows administrators to create, read, update, and delete student profiles and courses.

## Features
- Add, edit, and remove student records
- Course enrollment management
- Data validation and error handling
- Search and filter students by name, ID, or course
- Export records to CSV

## Architecture
The application follows a layered architecture:
1. **Presentation Layer** (WinForms UI)
2. **Business Logic Layer** (services for CRUD operations and validation)
3. **Data Access Layer** (Entity Framework Core for SQLite)

## Tech Stack
- Language: C# 11
- Framework: .NET 9
- UI: Windows Forms
- ORM: Entity Framework Core 8
- Database: SQLite

## Getting Started

### Prerequisites
- Windows 10 or later
- .NET 9 SDK (https://dotnet.microsoft.com/download)
- Visual Studio 2022 or later with WinForms workload

### Installation
1. Clone the repo:
   ```powershell
   git clone https://github.com/johnkocer/CsharpNet9Source.git
   cd CsharpNet9Source/CH-14-Capstone_Project/StudentRecordsWinForm/Student
   ```
2. Restore NuGet packages:
   ```powershell
   dotnet restore
   ```

### Running the Application
1. Open `StudentRecordsWinForm.sln` in Visual Studio.
2. Build the solution (Ctrl+Shift+B).
3. Run the project (F5).

## Project Structure
```
/Student                       - WinForms project directory
├─ /Properties
├─ /Models                     - EF Core POCO entities
├─ /Data                       - DbContext and migrations
├─ /Services                   - Business logic classes
├─ /Views                      - Forms and user controls
└─ Program.cs                  - Application entry point
```

## Database Schema
- **Students**: Id (PK), FirstName, LastName, DateOfBirth, Email
- **Courses**: Id (PK), Title, Credits
- **Enrollments**: StudentId (FK), CourseId (FK), EnrollmentDate

## User Interface
![Main Form](docs/screenshots/main_form.png)
- **Student List**: DataGridView with pagination
- **Detail Pane**: Form fields to edit selected student
- **Toolbar**: Buttons for Add, Edit, Delete, Export

## Contributing
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m "Add feature"`)
4. Push to branch (`git push origin feature/YourFeature`)
5. Open a Pull Request

## License
This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Author
John Kocer (<john.kocer@example.com>)