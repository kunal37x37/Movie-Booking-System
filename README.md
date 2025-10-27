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
