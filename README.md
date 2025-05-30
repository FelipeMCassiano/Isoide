# Isoide
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![MongoDB](https://img.shields.io/badge/MongoDB-%234ea94b.svg?style=for-the-badge&logo=mongodb&logoColor=white) ![AWS](https://img.shields.io/badge/AWS-%23FF9900.svg?style=for-the-badge&logo=amazon-aws&logoColor=white)

Isoide is a QR Code generator written in C#, leveraging AWS S3 for storage.

## Features

- Generate QR Codes via a RESTful API.
- Store and retrieve generated QR Codes from AWS S3 buckets.
- Modular architecture with clear separation of concerns.
- Ready for local development with Docker Compose support.

## Project Structure

```
.
├── Dockerfile
├── docker-compose.yml
├── Isoide.sln
├── src
│   ├── Backend
│   │   ├── Isoide.API
│   │   ├── Isoide.Application
│   │   ├── Isoide.Domain
│   │   └── Isoide.Infrastructure
│   └── Shared
└── tests
```

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started) (for containerization)
- AWS account with S3 access

### Configuration

Update your `appsettings.json` with your AWS credentials and S3 bucket name:

```json
"Settings": {
  "Aws": {
    "AccessKey": "{YOUR ACCESS KEY}",
    "SecretKey": "{YOUR SECRET KEY}",
    "BucketName": "{YOUR BUCKET NAME}"
  }
}
```

### Running Locally

1. **Clone the repository:**
   ```bash
   git clone https://github.com/FelipeMCassiano/Isoide.git
   cd Isoide
   ```

2. **Build and run with Docker Compose:**
   ```bash
   docker-compose up --build
   ```

   Or, **run via .NET CLI:**
   ```bash
   dotnet build Isoide.sln
   dotnet run --project src/Backend/Isoide.API
   ```

### Running Tests

Execute all tests with:
```bash
dotnet test
```

## API Usage

After starting the application, the API endpoints are documented and accessible using Swagger UI at:

[http://localhost:8000/swagger/index](http://localhost:8000/swagger/index)

You can use Swagger to explore and test all available endpoints interactively.

## Contributing

Contributions are welcome! To contribute:

- Fork this repository.
- Create a new branch for your feature or fix.
- Commit your changes with clear messages.
- Open a pull request describing your changes.

Please open issues for suggestions, bugs, or feature requests.

## License

This project is licensed under the MIT License.

---

**Author:** Felipe Cassiano  
[GitHub Profile](https://github.com/FelipeMCassiano)

---

Let me know if you’d like further customizations or examples!
