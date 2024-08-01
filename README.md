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
- SQL Server
- Bootstrap 5
- C#, HTML, CSS

## Installation and Setup

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Steps
1. Clone the repository: `git clone https://github.com/username/repo.git`
2. Navigate to the project directory: `cd repo`
3. Restore dependencies: `dotnet restore`
4. Build the project: `dotnet build`
5. Run the project: `dotnet run`

### Configuration
Update the `appsettings.json` file with your database connection string.

## Usage
- Navigate to `/posts` to view all blog posts.
- Use `/posts/create` to add a new post.
- Use `/posts/edit/{id}` to edit a post.

## Screenshots
![Homepage Screenshot](screenshots/homepage.png)



## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Credits
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
- [Bootstrap](https://getbootstrap.com/)

