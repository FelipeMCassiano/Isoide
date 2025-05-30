# Isoide

Isoide is a QrCode Generator made With c# and AWS S3

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

### Update appsettings.json
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

3. **Or run via .NET CLI:**
   ```bash
   dotnet build Isoide.sln
   dotnet run --project src/Backend/Isoide.API
   ```

### Testing

Run tests with:
```bash
dotnet test
```

## Contributing

Contributions are welcome! Please open issues or pull requests for improvements, bug fixes, or new features.

## License

This project is licensed under the MIT License.

---

> **Author:** Felipe Cassiano  
> [GitHub Profile](https://github.com/FelipeMCassiano)
