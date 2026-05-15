# Finki Bets 🎯

Finki Bets is a web application developed as a university project for the Faculty of Computer Science and Engineering (FINKI).  
The application is built following the **Onion Architecture** principles and includes full CRUD functionality, integration with an external API, and domain-based data transformation.

---

## 📌 Project Requirements

This project successfully implements all required functionalities from the project specification:

- ✅ Implementation using **Onion Architecture**
- ✅ Minimum of **4 domain models**
- ✅ Full **CRUD operations**
- ✅ Additional custom action functionality
- ✅ Integration with an **external API**
- ✅ Transformation and display of external API data inside the application domain

---

## 🏗️ Architecture

The application follows the **Onion Architecture** pattern, separating responsibilities into layers:

- **Domain Layer**
  - Entities
  - Business rules
  - Interfaces

- **Application Layer**
  - Services
  - DTOs
  - Business logic

- **Infrastructure Layer**
  - Database access
  - Repository implementations
  - External API integration

- **Presentation Layer**
  - ASP.NET MVC / Web interface
  - User interaction

This architecture improves:
- Maintainability
- Scalability
- Testability
- Separation of concerns

---

## 📦 Main Features

### CRUD Operations
The application supports complete CRUD functionality for the main entities:

- Create
- Read
- Update
- Delete

### Additional Actions
Besides standard CRUD operations, the application includes additional domain-specific functionality related to betting management and processing.

### External API Integration
The project integrates with an external API that provides sports/betting-related data.  
The received data is transformed and adapted to fit the application's domain model instead of being displayed directly.

---

## 🧩 Models

The application contains at least 4 core models/entities, including:

- User
- Bet
- Match
- Ticket

*(Adjust these based on your actual models if different.)*

---

## 🛠️ Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Onion Architecture
- REST API Integration
- Bootstrap

---

## 🚀 Running the Project

### 1. Clone the repository

```bash
git clone https://github.com/your-username/finki-bets.git
