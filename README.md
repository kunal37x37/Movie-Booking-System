# 🎬 Movie Booking System
---------------------------------------------------------------------------------
A complete ASP.NET Core MVC Movie Ticket Booking System with modern UI, real-time seat selection, and comprehensive admin panel.

![ASP.NET Core](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![SQLite](https://img.shields.io/badge/SQLite-07405E?logo=sqlite&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?logo=bootstrap)
![License](https://img.shields.io/badge/License-MIT-green)
---------------------------------------------------------------------------------
## ✨ Features

### 🎯 Core Functionality
- **User Registration & Authentication**
- **Movie Catalog & Showtimes**
- **Seat Selection & Booking**
- **Booking Management**
- **Admin Dashboard**
- **Real-time Price Calculation**

### 👥 User Features
- ✅ User Registration & Login
- ✅ Browse Movies & Showtimes
- ✅ Seat Category Selection (Premium/Standard/Economy)
- ✅ Ticket Booking with Real-time Pricing
- ✅ Booking History & Cancellation
- ✅ User Profile Management

### 🎬 Movie Management
- ✅ Movie Catalog with Images
- ✅ Showtime Scheduling
- ✅ Theater Management
- ✅ Seat Availability Tracking
- ✅ Price Management

### ⚡ Admin Features
- ✅ Admin Dashboard with Analytics
- ✅ Movie CRUD Operations
- ✅ Showtime Management
- ✅ User Management
- ✅ Booking Analytics & Reports
- ✅ Revenue Tracking
---------------------------------------------------------------------------------
## 🛠️ Technology Stack

- **Backend:** ASP.NET Core 8.0 MVC
- **Database:** SQLite with Entity Framework Core
- **Frontend:** Bootstrap 5, jQuery, Razor Pages
- **Authentication:** Session-based
- **Styling:** CSS3 with Responsive Design
---------------------------------------------------------------------------------
## 🚀 Quick Start

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Git](https://git-scm.com/)
---------------------------------------------------------------------------------
### Installation & Setup

1. **Clone the Repository**
   -----------------------------------------------
   git clone https://github.com/kunal37x37/Movie-Booking-System.git
   cd Movie-Booking-System
   -----------------------------------------------
  [ must required .NET 8.0 SDK or upper]

2.Restore Dependencies
-----------------------------------------------
dotnet restore
-----------------------------------------------

3.Setup Database
-----------------------------------------------
dotnet ef database update
-----------------------------------------------

4.Run Application
-----------------------------------------------
dotnet run
-----------------------------------------------

5.Access Application
Open your browser and navigate to:
-----------------------------------------------
https://localhost:7000
or
http://localhost:5000
-----------------------------------------------
---------------------------------------------------------------------------------
🔐 Default Accounts
Admin Account
Email: rajhans@gmail.com
Password: abc123

User Account
Register new account or use:

Email: apple@gmail.com
Password: abc123
---------------------------------------------------------------------------------
🗄️ Database Schema
Tables
Users - User accounts and authentication
Movies - Movie catalog and details
Showtimes - Movie schedules and theater info
Bookings - Ticket bookings and transactions
---------------------------------------------------------------------------------

🎨 Project Structure
MovieBookingSystem/
├── Controllers/          # MVC Controllers
│   ├── HomeController.cs
│   ├── AccountController.cs
│   ├── BookingController.cs
│   └── AdminController.cs
├── Models/              # Data Models
│   ├── User.cs
│   ├── Movie.cs
│   ├── Showtime.cs
│   └── Booking.cs
├── Views/               # Razor Views
│   ├── Home/
│   ├── Account/
│   ├── Booking/
│   └── Admin/
├── Data/                # Database Context
│   └── ApplicationDbContext.cs
├── wwwroot/             # Static Files
│   ├── css/
│   ├── js/
│   └── images/
└── Program.cs           # Application Entry Point
---------------------------------------------------------------------------------
💰 Pricing Structure
Premium Class: Base Price + ₹50 (Best view)
Standard Class: Base Price (Comfortable)
Economy Class: Base Price - ₹20 (Budget-friendly)
---------------------------------------------------------------------------------
📱 API Endpoints
Public Routes
GET / - Homepage with movies
GET /Home/MovieDetails/{id} - Movie details
GET /Account/Login - User login
GET /Account/Register - User registration

Protected Routes
GET /Booking/BookShowtime/{id} - Book tickets
GET /Booking/MyBookings - User bookings
POST /Booking/CancelBooking/{id} - Cancel booking

Admin Routes
GET /Admin/AdminDashboard - Admin dashboard
GET /Admin/Movies - Manage movies
GET /Admin/Showtimes - Manage showtimes
GET /Admin/AllBookings - View all bookings
---------------------------------------------------------------------------------
🎫 Booking Flow
Browse Movies → View available movies
Select Movie → Check showtimes and theaters
Choose Showtime → Select date and time
Select Seats → Choose category and tickets
Confirm Booking → Review and pay
Get Confirmation → Booking reference and details
---------------------------------------------------------------------------------
🐛 Troubleshooting

Common Issues

1.Database Connection Error
------------------------------------------
dotnet ef database update
------------------------------------------

2.Build Failures
------------------------------------------
dotnet clean
dotnet restore
dotnet build
------------------------------------------

3.Port Already in Use
------------------------------------------
dotnet run --urls="https://localhost:7001"
------------------------------------------

4.Missing EF Tools
------------------------------------------
dotnet tool install --global dotnet-ef
------------------------------------------

---------------------------------------------------------------------------------
🤝 Contributing
Fork the repository
Create feature branch (git checkout -b feature/AmazingFeature)
Commit changes (git commit -m 'Add AmazingFeature')
Push to branch (git push origin feature/AmazingFeature)
Open Pull Request

---------------------------------------------------------------------------------
📄 License
This project is licensed under the MIT License - see the LICENSE file for details.
---------------------------------------------------------------------------------
👨‍💻 Developer
Kunal - GitHub
---------------------------------------------------------------------------------
🙏 Acknowledgments
Bootstrap for UI components
Entity Framework Core for data access
ASP.NET Core team for the amazing framework
---------------------------------------------------------------------------------
⭐ Star this repo if you find it helpful!
🔗 Links
Issue Tracker
Releases
---------------------------------------------------------------------------------

