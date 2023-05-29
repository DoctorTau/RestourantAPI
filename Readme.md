# Order Microservices

## Даниил Шатравка

## Description 

User and Order are two microservices built using C# ASP.NET. They are designed to work together and are connected to the same database. The User service handles user registration and authentication, while the Order service provides functionality for working with dishes and orders. The microservices are designed to be scalable and fault-tolerant, ensuring that the system can handle high volumes of traffic without downtime.

## Usage

1. Create a PostgreSQL database.
2. Update the connection strings in [OrderService/appsettings.json](./OrderService/appsettings.json) and [UserService/appsettings.json](./UserService/appsettings.json) to point to your database.
3. Apply the migrations by running the command `dotnet ef database` update in the root directory of each service.
4. Navigate to the UserService directory and run the command `dotnet run` to start the User service.
5. Navigate to the OrderService directory and run the command `dotnet run` to start the Order service.
6. Open Swagger to interact with the APIs.