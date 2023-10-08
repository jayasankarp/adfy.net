# Adfy.net

Adfy.net is a simple advertisement platform designed to showcase various software development concepts and practices such as Clean Architecture, Domain-Driven Design (DDD), Command Query Responsibility Segregation (CQRS), Cross-cutting Concerns, and the new Identity API endpoints in .NET 8. This project serves as a learning resource and example for developers looking to understand and implement these concepts in a .NET environment.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)

- [License](#license)

## Introduction

Adfy.net is a practical demonstration of how to build a modern web application with a focus on architectural patterns and best practices. Whether you are a beginner looking to learn more about software architecture or an experienced developer aiming to sharpen your skills, this project has something to offer. It's built with .NET 8, making use of the latest features and improvements available in the framework.

## Features

- **Clean Architecture:** Adfy.net is structured using the Clean Architecture pattern, which promotes separation of concerns, maintainability, and testability.
- **Domain-Driven Design (DDD):** The project implements DDD principles to model the application's domain, ensuring that the business logic remains isolated and cohesive.
- **CQRS (Command Query Responsibility Segregation):** Adfy.net demonstrates how to implement CQRS for improved performance and separation of commands and queries.
- **Cross-cutting Concerns:** The project includes examples of handling cross-cutting concerns such as logging, authorization, and validation.
- **Identity API Endpoints:** It incorporates the new Identity API endpoints introduced in .NET 8, showcasing the latest authentication and authorization capabilities.

## Getting Started

Follow these instructions to get the Adfy.net project up and running on your local machine.

### Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (optional but recommended)

### Installation

1. Clone the repository:

   ```shell
   git clone https://github.com/jayasankarp/Adfy.net.git
   ```

2. Navigate to the project directory:

   ```shell
   cd Adfy.net
   ```

3. Restore dependencies:

   ```shell
   dotnet restore
   ```

4. Configure the database connection in the `appsettings.json` file.

5. Apply the database migrations:

   ```shell
   dotnet ef database update
   ```

6. Start the application:

   ```shell
   dotnet run
   ```

The application should now be running locally.

## Project Structure

The project structure follows the Clean Architecture principles and is organized into different layers:

- **Adfy.Application:** Contains application-specific logic and use cases.
- **Adfy.Domain:** Defines the domain models and entities.
- **Adfy.Infrastructure:** Contains infrastructure concerns like data access, external services, and Identity-related configurations.
- **Adfy.Api:** The web application layer responsible for handling requests, controllers.

## Technologies Used

Adfy.net is built using the following technologies and libraries:

- .NET 8
- ASP.NET Core
- Entity Framework Core
- Dapper
- MediatR (for CQRS)
- FluentValidation
- Serilog (for logging)
- Identity API (new in .NET 8)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

---

**Note:** This README serves as a starting point for your project. Be sure to customize it to provide more specific details about your project's architecture, features, and implementation. Additionally, you may want to include sections on testing, deployment, and usage instructions as your project evolves.