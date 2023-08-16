# Pschool Application

Pschool is a Single Page Application (SPA) built using ASP.NET Blazor WebAssembly and ASP.NET Core Web API. The project demonstrates basic CRUD (Create, Read, Update, Delete) operations in a simple parent/student management system.

## Description

The Pschool application showcases how to implement a basic parent/student management system using ASP.NET technologies:

- **Backend**: ASP.NET Core Web API handles the data management, providing API endpoints for CRUD operations on parent and student records.
- **Frontend**: Blazor WebAssembly creates the user interface for easy interaction with the application. Users can view, add, edit, and delete parent and student data.

## Features

- View a list of parents and students.
- Add, edit, and delete parent and student records.
- Filter students based on parent selection.
- Responsive user interface for easy access from different devices.

## Technologies Used

- **Backend**: ASP.NET Core Web API with Entity Framework Core for database interactions.
- **Frontend**: Blazor WebAssembly for building the user interface.
- **Database**: Entity Framework Core with SQL Server (or your chosen database provider).

## Getting Started

Follow these steps to set up and run the Pschool application locally:

1. **Clone the repository**:

   ```sh
   git clone https://github.com/your-username/pschool.git
   cd pschool
### Backend Setup:

1. Open the `Pschool.API` solution in Visual Studio or your preferred IDE.
2. Configure your database connection in the `appsettings.json` file.
3. Build and run the API project.

### Frontend Setup:

1. Open the `Pschool.Blazor` project in Visual Studio or your preferred IDE.
2. Ensure the API base URL is correctly set in the `Program.cs` file.
3. Build and run the Blazor WebAssembly project.

### Access the Application:

Open your web browser and navigate to `http://localhost:5000` to access the Pschool application.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- Thanks to the [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) and [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) communities for their valuable resources.

---
