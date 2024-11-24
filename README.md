# Wallet API  
Wallet API is a backend application developed using ASP.NET Core, .NET 7, and EF Core 7. It enables users to manage wallet transactions and includes a system for calculating daily bonus points.  

## Features  
- **Daily Bonus Points**: Automatic calculation of bonus points based on predefined rules.  
- **Transaction Management**: Create, retrieve, and manage wallet transactions.  
- **Database Integration**: Robust support with PostgreSQL 17 using Entity Framework Core.  

## Prerequisites  
Ensure you have the following installed:  
- [.NET 7 SDK](https://dotnet.microsoft.com/download)  
- PostgreSQL 17  

## Installation  
1. **Clone the Repository**  
   ```bash  
   git clone <repository-url>  
   cd wallet-api  
   ```
2. **Install Dependencies**
   ```bash
   dotnet restore
   ```
3. **Configure Database**
   Update the PostgreSQL connection string in `appsettings.json`
   ```json
   "ConnectionStrings": {  
      "DefaultConnection": "Server=yourHost;Port=5432;Database=YourDBName;User Id=yourUserId;Password=YourPassword;"  
    }  
   ```
4. **Apply Database Migrations**
   Run migrations to set up the database schema:
   ```bash
   dotnet ef database update
   ```
5. **Run the Application**
   Start the API server:
   ```bash
   dotnet run  
   ```
   
## API Documentation
The API is documented with Swagger. After running the application, you can access the Swagger UI at:
```bash
http://localhost:<port>/swagger
```
It provides detailed information about the endpoints, request/response models, and example usage.

## Technologies Used
- **ASP.NET Core**: For building the API.
- **EF Core 7**: ORM for database interactions.
- **PostgreSQL 17**: Database for storing transactions and bonus point data.
- **Swagger**: For interactive API documentation.
