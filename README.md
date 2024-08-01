# SlasherPastaBlog

## Description
A simple blog application built with ASP.NET Core that allows users to create, manage, and rate on horror stories.

## Features
- User authentication
- Read stories
- Create and rate horror stories (for registered users)
- Rating system
- Age restriction system (certain users can´t read some stories based on restrictions)
- Delete and edit stories (Admin)
- Create and Delete roles (Admin)
- Manage user roles - banning included (Admin)
  
## Technologies Used
- ASP.NET Core
- Entity Framework Core
- Microsoft SQL Server
- Bootstrap 5
- C#, HTML, CSS

## Installation and Setup

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Steps
1. Clone the repository: `git clone https://github.com/CarDioLogic/SlasherPastaBlog.git`
2. Navigate to the project directory: `cd repo`
3. Restore dependencies: `dotnet restore`
4. Build the project: `dotnet build`
5. Run the project: `dotnet run`

### Configuration
Update the `appsettings.json` file with your database connection string.
Make sure you have a database in MSSQL server macthing the connection string

## Usage
- Read pre-seeded stories as a unregistered user.
- Register a user to create and rate other stories.
- Login as Admin to manage stories and users.

## Screenshots
![Homepage Screenshot](screenshots/homepage.png)
![Stories Screenshot](screenshots/stories.png)

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Credits
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
- [Bootstrap](https://getbootstrap.com/)

