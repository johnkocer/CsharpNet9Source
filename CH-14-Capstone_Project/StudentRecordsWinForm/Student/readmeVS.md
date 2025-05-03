# Student Records Management System

## Project Overview
The Student Records Management System is a Windows Forms application built with .NET 9 that allows users to manage student information efficiently. The system enables users to add, update, delete, and search for student records through an intuitive graphical interface.

## Technical Specifications

### Platform & Framework
- **Platform**: Windows
- **Framework**: .NET 9 (net9.0-windows)
- **UI Framework**: Windows Forms
- **Language**: C# 12

### System Architecture
The application follows a layered architecture:

1. **Presentation Layer**: Windows Forms UI
2. **Business Logic Layer**: Student Services
3. **Data Layer**: CSV file-based storage

### Project Structure
- **Models**: Contains the data models
  - `Student.cs`: Defines the Student entity with properties
- **Services**: Contains business logic and data access
  - `IStudentService.cs`: Interface for student operations
  - `StudentService.cs`: Implementation of student operations
- **Forms**: Contains UI components
  - `MainForm.cs`: Main application window
  - `AddStudentForm.cs`: Form for adding/editing students
  - `SearchForm.cs`: Form for searching student records

## Features
- Create, read, update, and delete (CRUD) operations for student records
- Search functionality to find students by name
- Data persistence using CSV file format
- User-friendly interface with data grid for viewing records
- Validation for student data entry

## Data Model
The Student entity includes the following properties:
- Name (string)
- Age (integer)
- Grade (character)
- Email (string)

## Implementation Details

### Data Storage
Student records are stored in a CSV file (`students.csv`) with the following format:
```
Name,Age,Grade,Email
John Doe,18,A,johndoe@example.com
Jane Smith,17,B,jane@example.com
```

### Service Layer
The `StudentService` class implements the `IStudentService` interface and provides methods for:
- Adding new students
- Updating existing student information
- Deleting students
- Retrieving a specific student
- Searching for students
- Getting all student records

### User Interface
- **Main Form**: Displays a list of all students in a data grid and provides buttons for CRUD operations
- **Add/Edit Form**: Allows users to enter or modify student details
- **Search Form**: Enables users to search for specific students

## Getting Started

### Prerequisites
- Windows operating system
- .NET 9 SDK or Runtime
- Visual Studio 2022 or higher (recommended for development)

### Running the Application
1. Clone or download the repository
2. Open the solution file (Student.sln) in Visual Studio
3. Build the solution
4. Run the application (F5 or Ctrl+F5)

### Development
The project can be extended by:
- Adding more fields to the Student model
- Implementing advanced search functionality
- Adding sorting and filtering options
- Migrating to a database for larger data sets
- Implementing user authentication

## License
[Specify your license here]

## Contributors
[List contributors here]