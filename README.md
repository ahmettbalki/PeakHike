# PeakHike
# My ASP.NET MVC Web Application

This project is a web application build using ASP.NET MVC, following the Onion Architecture. The application also utilizes the Mediator pattern and MSSQL for the database management.

## Project Overview

### Technologies Used

- **ASP.NET MVC**: The primary framework for building the web application.
- **Onion Architecture**: To maintain a clean separation of concerns and promote a highly testable and maintainable codebase.
- **Mediator Pattern**: Used to handle application logic and business rules, reducing the coupling between components.
- **MSSQL**: Used for database management and storage.

### Architecture

The application follows the Onion Architecture, which is a layered architecture style that emphasizes the separation of concerns. The core of the architecture is the domain layer, which contains business logic and domain entities. Surrounding the core are various layers that handle infrastructure, application services, and presentation.

#### Layers

1. **Domain Layer**: Contains the domain entities, interfaces, and domain services.
2. **Application Layer**: Implements application logic and services using the Mediator pattern. This layer is responsible for handling commands and queries.
3. **Infrastructure Layer**: Contains implementations for data access, external services, and repositories.
4. **Presentation Layer**: The ASP.NET MVC web api that interacts with users and sends requests to the application layer.

### Features

- **User Authentication and Authorization**: Secure login and role-based access control.
- **CRUD Operations**: Create, read, update, and delete operations for managing entities.
- **Responsive Design**: User-friendly interface compatible with various devices.

### Mediator Pattern

The Mediator pattern is used to handle requests and responses within the application layer. It helps in decoupling the components and promotes a clean and maintainable code structure.

- **Commands**: Represent actions or operations to be performed (e.g., creating a user).
- **Queries**: Represent requests for data (e.g., fetching user details).

### Database Management

The application uses MSSQL for data storage and management. Entity Framework is used as the ORM (Object-Relational Mapper) to interact with the database.
