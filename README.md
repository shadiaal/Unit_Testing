# Advanced Unit Testing for the Data Access Layer

## Overview

This project demonstrates advanced unit testing for a Data Access Layer (DAL) of an application that manages user data and orders.  
It focuses on building models, repositories, and comprehensive unit tests using **NUnit** with **Entity Framework Core**.

## Features

- ✅ User and Order Data Models
- ✅ Entity Framework Core Database Context (AppDbContext)
- ✅ Repository Pattern for User and Order entities
- ✅ Full CRUD operations
- ✅ Unit Testing for CRUD operations
- ✅ Mocking external dependencies
- ✅ Edge case handling and exception testing

## Technologies Used

- C#
- .NET Core
- Entity Framework Core
- NUnit
- Moq (for mocking)


## Getting Started

### Prerequisites
- .NET Core SDK installed
- Visual Studio or VSCode


## Setup

### 1. Clone the repository
```bash
git clone https://github.com/your-repo/AdvancedUnitTesting.git
cd AdvancedUnitTesting
```

### 2. Restore dependencies
```bash
dotnet restore
```

### 3. Update database provider if needed (InMemory or real database)

### 4. Apply EF Core Migrations 
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Build the project
```bash
dotnet build
```

### 6. Run the tests
```bash
dotnet test
```

## Usage

- Use the repository classes to perform CRUD operations for Users and Orders.
- Run unit tests to ensure everything works as expected.
- Check test coverage and validate edge case handling.

## Testing

This project uses **NUnit**  to run unit tests.  
Tests cover:

- ✅ Create: Adding new users and orders.
- ✅ Read: Fetching users and orders by ID.
- ✅ Update: Updating existing users and orders.
- ✅ Delete: Removing users and orders.
- ✅ Edge Cases: Handling null values, empty fields, and non-existent IDs.
- ✅ Exception Handling: Graceful failure and validation.


