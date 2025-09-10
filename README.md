# File Hosting Application

## About the project
This project aims to be a file hosting application in the vein of dropbox, Google Drive etc. The application primarily aims to deepen my knowledge about ASP.NET, but I've also 
decided to make a frontend using Svelte, to learn about that framework as well. 

### Built with
* [![Svelte][Svelte.dev]][Svelte-url]
* [![.NET][.NET-badge]][.NET-url]
* [![ASP.NET][ASP.NET-badge]][ASP.NET-url]
* [![PostgreSQL][PostgreSQL.org]][PostgreSQL-url]

## Getting Started
1. To get started with the project, start by cloning it or download and unzip the contents of the project to your local machine. 
2. Now install any prerequisites needed.
3. Create a PostgreSQL database for the app to connect to (see database setup below)
4. Inside the fileapp directory, run the command ```npm run dev```
5. Inside the backend directory, run the command ```dotnet run```

Enjoy!

### Prerequisites

* Install npm
  ```sh
  npm install npm@latest -g
  ```
* Install [PostgreSQL](https://www.postgresql.org/download/)
* Install [.NET](https://learn.microsoft.com/en-us/dotnet/core/install/)

### Database Setup

To connect to your database, you can either:
- Create a database using the default credentials found in `Backend/data/configuration.cs`
- If connecting to an existing database with different credentials, enter these credentials as environment variables (also referenced in `Backend/data/configuration.cs`)

*Note: You can simply change the connection string variable to match your database information if preferred.*


<!-- Markdown links found below-->
[Svelte.dev]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte&logoColor=FF3E00
[Svelte-url]: https://svelte.dev/
[.NET-badge]: https://img.shields.io/badge/.net-9.0-blue
[.NET-url]: https://dotnet.microsoft.com/en-us/
[ASP.NET-badge]: https://img.shields.io/badge/-ASP.NET--Core-999?style=flat&logo=Microsoft&logoColor=0078D7
[ASP.NET-url]: https://dotnet.microsoft.com/en-us/apps/aspnet
[PostgreSQL.org]: https://img.shields.io/badge/postgresql-4169e1?style=for-the-badge&logo=postgresql&logoColor=white
[PostgreSQL-url]: https://www.postgresql.org/

## Roadmap

- [ ] Fix cookies not refreshing
- [ ] Fix ability to edit resources on the frontend
- [ ] Add frontend upload
- [ ] Add frontend download


See the [open issues](https://github.com/DefinitelyUnlikely/FileHostingApp/issues) for a full list of proposed features (and known issues).
