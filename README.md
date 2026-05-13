# 🎓 Student Tuition Management System

> A desktop-based tuition management software developed using C# and SQL Server for managing students, classes, tuition payments, and educational statistics.

![C#](https://img.shields.io/badge/C%23-.NET-68217A)
![Visual Studio](https://img.shields.io/badge/IDE-Visual%20Studio-5C2D91)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927)
![Windows](https://img.shields.io/badge/Platform-Windows-0078D6)
![License](https://img.shields.io/badge/license-MIT-green)

---

# 📌 Introduction

Student Tuition Management System is a desktop application designed to simplify and automate the management process in educational institutions.

The system supports:
- Student management
- Class organization
- Automatic student ID generation
- Tuition fee calculation
- Tuition payment tracking
- Revenue statistics
- Administrative management

The project was developed using C# with SQL Server database integration, following a structured software engineering approach.

---

# 🚀 Main Features

## 👨‍🎓 Student Management
- Add / Edit / Delete student information
- Automatic student ID generation
- Search students by ID or name
- Student profile management

## 🏫 Class Management
- Create and manage classes
- Assign students to classes
- Manage academic years

## 💰 Tuition Management
- Calculate tuition automatically
- Tuition payment tracking
- Outstanding tuition management
- Payment history

## 📊 Statistics & Reporting
- Revenue statistics
- Tuition payment reports
- Student statistics by class
- Monthly / yearly reports

## 🔐 Authentication & Authorization
- Login system
- Admin authorization
- Role management

---

# 🏗️ System Architecture

```bash id="k2m9fr"
Application Type : Desktop Application
Language         : C#
Framework        : .NET
IDE              : Visual Studio
Database         : SQL Server
Architecture     : 3-Layer Architecture
🛠️ Technologies Used
Technology	Purpose
C#	Main programming language
.NET Framework	Application framework
Windows Forms	User Interface
SQL Server	Database management
ADO.NET	Database connectivity
Visual Studio	Development environment
📂 Project Structure
StudentTuitionManagement/
│
├── GUI/                    # User Interface Layer
├── BUS/                    # Business Logic Layer
├── DAL/                    # Data Access Layer
├── DTO/                    # Data Transfer Objects
├── Database/               # SQL Scripts
│
├── App.config
├── Program.cs
└── README.md
🗄️ Database Design
Main Tables
STUDENTS
StudentID
FullName
DateOfBirth
Gender
PhoneNumber
Address
ClassID
CLASSES
ClassID
ClassName
Department
AcademicYear
TUITION
TuitionID
StudentID
Semester
TuitionAmount
PaymentStatus
CreatedDate
USERS
UserID
Username
Password
Role
⚙️ Installation Guide
1️⃣ Requirements
Visual Studio 2019+
SQL Server
.NET Framework
Windows OS
2️⃣ Clone Repository
git clone https://github.com/your-username/student-tuition-management-csharp.git
3️⃣ Setup Database
Create Database
CREATE DATABASE TuitionManagement;
GO
Import SQL File
TuitionManagement.sql
4️⃣ Configure Connection String

Update App.config:

<connectionStrings>
    <add name="DBConnection"
         connectionString="Data Source=.;Initial Catalog=TuitionManagement;Integrated Security=True"/>
</connectionStrings>
5️⃣ Run Project

Open solution in Visual Studio and run:

Ctrl + F5
🔢 Automatic Student ID Generation

Example:

SV001
SV002
SV003

The system automatically generates unique student IDs when adding new students.

💵 Tuition Calculation Logic
Tuition Fee = Number of Subjects × Fee Per Subject

Additional support:

Semester tuition
Outstanding balance checking
Payment status tracking
📈 Reporting Features
Tuition revenue reports
Unpaid tuition statistics
Student quantity by class
Financial summaries
🖥️ Main Application Modules
Module	Description
Dashboard	System overview
Student Management	Student CRUD operations
Class Management	Manage classes
Tuition Management	Tuition calculation
Statistics	Reports & analytics
Authentication	Login & authorization
🔒 Security Features
User authentication
Role-based access control
SQL injection prevention
Data validation
📷 Screenshots

Add your project screenshots here

/images/login-form.png
/images/dashboard.png
/images/student-management.png
/images/tuition-management.png
/images/statistics.png
🧪 Testing

System testing includes:

Login functionality
Student CRUD testing
Tuition calculation testing
SQL Server connection testing
Reporting functionality
🔮 Future Improvements
Online payment gateway
Export Excel/PDF reports
Email notifications
Cloud database deployment
Multi-user support
Mobile application integration
👨‍💻 Developer Information
Role	Information
Developer	Your Name
Project Type	Desktop Management System
Language	C#
Database	SQL Server
📚 Educational Purpose

This project was developed for:

Learning C# Desktop Development
SQL Server Database Design
3-Layer Architecture
ADO.NET Connectivity
Software Engineering Practices
📄 License

MIT License © 2026

⭐ Project Highlights
Built with C# and SQL Server
Automatic student ID generation
Tuition fee management system
3-Layer architecture implementation
Windows Forms desktop application
Real-world educational workflow
Secure database integration
