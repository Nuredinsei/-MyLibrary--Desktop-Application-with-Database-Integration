
# MyLibrary - Desktop Application

**Course**: Event-Driven Programming with C#  
**Assignment Type**: Individual  
**Student**: [Ynuredin seid 1501419]  
**Date**: June 2, 2025  

## Overview

MyLibrary is a C# Windows Forms Application designed to manage a small library's books and borrowing records. It demonstrates key event-driven programming techniques and integrates with a local database using ADO.NET.

## Features

### Login Form
- Simple authentication using a Users table.
- On success: opens the main dashboard.
- On failure: displays an error message.

### Main Dashboard (Tabbed Interface)
#### Books Management
- View all books in a DataGridView
- Add/Edit/Delete book records
- Validates input fields (non-empty, numeric ranges)

#### Borrowers Management
- View borrowers in a DataGridView
- Add/Edit/Delete borrower records
- Input validation included

#### Issue Book
- Select borrower and book
- Decrease available copies
- Record issued details in `IssuedBooks` table

#### Return Book
- Select record to return
- Increase available copies
- Mark record as returned or delete it

### Bonus Features
- Filter books by author or year range
- Generate report of overdue books

## Technologies Used

- Language: C# (.NET Framework)
- UI: Windows Forms (WinForms)
- Database: SQL Server (LocalDB) or SQLite
- Data Access: ADO.NET with parameterized queries

## How to Run

1. Clone or download this repo.
2. Open the solution in Visual Studio.
3. Ensure database is created using provided SQL script.
4. Update connection string in `App.config` if needed.
5. Build and run the application.

## Screenshots

Screenshots can be found in `/docs/screenshots/` folder.  
Includes: Login screen, Book & Borrower management, Issue/Return workflow.

## Default Credentials

- **Username**: admin  
- **Password**: 1234  

## Deliverables Included

- C# WinForms project code
- README.md file
- SQL script to create and seed tables
- UI screenshots

## License

This project is submitted for educational purposes.
