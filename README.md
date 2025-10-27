# 🎬 Movie Booking System

![Movie Booking System Banner](assets/banner.png)

> A complete **Movie Ticket Booking System** built with **ASP.NET Core MVC**, **Entity Framework Core**, and **SQLite**.  
> Users can browse movies, view showtimes, and book tickets, while admins can manage movies, schedules, and reports — all in one seamless platform.

---

## 🌐 Demo

🎥 **Live Demo / Video Walkthrough**  
[▶ Watch on YouTube](https://youtu.be/demo)

📸 **Screenshots**  
| Home Page | Movie Details | Admin Dashboard |
|------------|----------------|----------------|
| ![Home Page](assets/home.png) | ![Movie Details](assets/movie-details.png) | ![Admin Dashboard](assets/admin-dashboard.png) |

---

## 🧠 Table of Contents

- [Overview](#-project-overview)
- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Database Schema](#️-database-schema)
- [Installation & Setup](#-installation--setup)
- [Default Accounts](#-default-accounts)
- [Usage Guide](#-usage-guide)
- [Image Upload Feature](#️-image-upload-feature)
- [Troubleshooting](#-troubleshooting)
- [UI/UX Features](#-uiux-features)
- [Security Features](#-security-features)
- [Future Enhancements](#-future-enhancements)
- [Contributing](#-contributing)
- [License](#-license)
- [Developer & Support](#-developer--support)

---

## 🧩 Project Overview

A powerful, responsive movie booking platform designed to simplify ticket booking for users and management for admins.

**Core Technologies:**  
- ASP.NET Core MVC  
- Entity Framework Core (Code First)  
- SQLite Database  
- Bootstrap 5 Frontend  

**Purpose:**  
To create a modern, feature-rich movie booking experience with easy deployment, secure login, and admin management features.

---

## 🚀 Features

### 👥 User Features
| Feature | Description |
|----------|--------------|
| 🧾 Registration & Login | Secure account creation with validation |
| 🎞 Browse Movies | View all available movies with details |
| 🕒 Showtimes | Check available timings |
| 🎟 Book Tickets | Choose seat category & book 1–10 tickets |
| 🔢 Auto Seat Allocation | Automatic smart seat assignment |
| ✅ Booking Confirmation | Reference number & confirmation page |
| 🧾 Manage Bookings | View or cancel previous bookings |
| 🖨 Ticket Download | Download or print movie tickets |
| 👤 Profile Management | Update and manage your user details |

### 🎯 Admin Features
| Feature | Description |
|----------|--------------|
| 📊 Dashboard | Quick stats for movies, bookings, and users |
| 🎬 Manage Movies | Add, edit, delete, activate/deactivate |
| 🕒 Manage Showtimes | Create & manage schedules |
| 🖼 Image Upload | Upload movie posters with validation |
| 📅 View All Bookings | Track all user bookings |
| 👥 User Management | View or delete registered users |
| 💰 Revenue Reports | Monitor income & performance metrics |

---

## ⚙️ Tech Stack

| Layer | Technology |
|--------|-------------|
| Frontend | Bootstrap 5, Razor Views |
| Backend | ASP.NET Core MVC |
| ORM | Entity Framework Core |
| Database | SQLite |
| Authentication | Session-based, Role-based Access |
| Tools | Visual Studio 2022 / VS Code |

**NuGet Packages Used:**
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />

```

## 🗄️ Database Schema

### **Tables**
| Table | Description |
|--------|--------------|
| 🧑‍💻 Users | User accounts and authentication |
| 🎬 Movies | Movie catalog with image support |
| 🕒 Showtimes | Movie screening schedules |
| 🎟 Bookings | Ticket booking records |

### **Relationships**
- Users (1) ────▶ (Many) Bookings
- Movies (1) ────▶ (Many) Showtimes
- Showtimes (1) ────▶ (Many) Bookings
---

## 🛠 Installation & Setup

### **Prerequisites**
- ✅ .NET 8.0 SDK  
- ✅ Visual Studio 2022 or Visual Studio Code  

### **Steps**

```bash
# 1️⃣ Clone the repository
git clone https://github.com/yourusername/MovieBookingSystem.git
cd MovieBookingSystem

# 2️⃣ Restore dependencies
dotnet restore

# 3️⃣ Apply migrations & create database
dotnet ef migrations add InitialCreate
dotnet ef database update

# 4️⃣ Run the project
dotnet run
```
### **Open in browser:**
```bash
https://localhost:7000
```

## 🔑 Default Accounts
| Role | Email | Password |
|--------|--------------|--------|
| 👑 Admin | rajhans@gmail.com | abc123 |
| 👤 User | apple@gmail.com | abc123 |

## 📱 Usage Guide
### **For Users**
- Register or log in
- Browse available movies
- Select a movie → Choose showtime
- Book tickets → Confirm → Download ticket
- Manage all bookings from My Bookings

### **For Admins**
- Log in as admin
- Access Admin Dashboard
- Manage movies, showtimes, and users
- View booking reports and revenue stats

### **Image Upload Feature**
- Supported file types: .jpg, .jpeg, .png
- Max file size: 5 MB
- Automatic filename generation
- Default image fallback
- Live preview before upload

### **Configuration (appsettings.json):**
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=MovieBookingSystem.db"
  }
}
```
## 🔒 Security Features
- 🔐 Session-based authentication
- 👥 Role-based authorization (Admin/User)
- 🛡 Anti-forgery token protection
- 🚫 SQL Injection prevention
- 🧾 Input validation on all forms

## 📈 Future Enhancements
- 💳 Payment Gateway Integration
- 📧 Email Notification System
- 💺 Interactive Seat Selectio
- ⭐ Movie Ratings & Reviews
- 🔍 Advanced Search & Filters
- 📱 Android/iOS App version

## 🤝 Contributing
- Fork this repository
- Create a new branch (feature/YourFeature)
- Commit your changes
- Push to your branch
- Create a Pull Request

## 📄 Licens
- This project is for educational purposes only.

## 👨‍💻 Developer & Support
# Developer: Patel Kunal 
# Built with ❤️ using ASP.NET Core MVC
# Github:kunal37x37
# Project Link :

