# File Hosting Application

A file hosting application similar to Dropbox and Google Drive, built with modern web technologies.

## About the Project

This project aims to create a comprehensive file hosting solution similar to Dropbox, Google Drive, and other cloud storage services. The application primarily focuses on deepening knowledge of ASP.NET while also exploring frontend development with Svelte.

### Built With

* [![Svelte][Svelte.dev]][Svelte-url]
* [![.NET][.NET-badge]][.NET-url]
* [![ASP.NET][ASP.NET-badge]][ASP.NET-url]
* [![PostgreSQL][PostgreSQL.org]][PostgreSQL-url]

## Getting Started

Follow these steps to set up and run the project locally.

### Prerequisites

Before running the project, ensure you have the following installed:

* **Node.js and npm**
  ```sh
  npm install npm@latest -g
  ```
* **PostgreSQL** - [Download here](https://www.postgresql.org/download/)
* **.NET 8.0+** - [Download here](https://learn.microsoft.com/en-us/dotnet/core/install/)

### Installation

1. **Clone the repository**
   ```sh
   git clone [repository-url]
   cd file-hosting-app
   ```

2. **Set up the database**
   - Create a PostgreSQL database (see Database Setup section below)

3. **Start the frontend**
   ```sh
   cd fileapp
   npm install
   npm run dev
   ```

4. **Start the backend**
   ```sh
   cd backend
   dotnet restore
   dotnet run
   ```

5. **Access the application**
   - Frontend: Usually available at `http://localhost:5173`
   - Backend API: Usually available at `https://localhost:7000`

### Database Setup

To connect to your database, you can either:
- Create a database using the default credentials found in `Backend/data/configuration.cs`
- If connecting to an existing database with different credentials, enter these credentials as environment variables (also referenced in `Backend/data/configuration.cs`)

*Note: You can modify the connection string variable directly in the configuration file to match your database information.*

## Roadmap

### Current Development Tasks
- [ ] Fix cookies not refreshing properly
- [ ] Fix ability to edit resources on the frontend
- [ ] Add frontend file upload functionality
- [ ] Add frontend file download functionality


See the [open issues](https://github.com/DefinitelyUnlikely/FileHostingApp/issues) for a full list of proposed features and known issues.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For questions or support, please open an issue on the GitHub repository.

<!-- Markdown links -->
[Svelte.dev]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte&logoColor=FF3E00
[Svelte-url]: https://svelte.dev/
[.NET-badge]: https://img.shields.io/badge/.net-9.0-blue
[.NET-url]: https://dotnet.microsoft.com/en-us/
[ASP.NET-badge]: https://img.shields.io/badge/-ASP.NET--Core-999?style=flat&logo=Microsoft&logoColor=0078D7
[ASP.NET-url]: https://dotnet.microsoft.com/en-us/apps/aspnet
[PostgreSQL.org]: https://img.shields.io/badge/postgresql-4169e1?style=for-the-badge&logo=postgresql&logoColor=white
[PostgreSQL-url]: https://www.postgresql.org/
