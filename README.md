🎬 Movie Booking System
A complete and professional ASP.NET Core MVC Movie Ticket Booking System with modern UI, real-time seat selection, and comprehensive admin panel. Perfect for cinema chains and movie theaters.

https://img.shields.io/b/.NET-8.0-512BD4?logo=dotnet
https://img.shields.io/badge/SQLite-07405E?logo=sqlite&logoColor=white
https://img.shields.io/badge/Bootstrap-5.3-7952B3?logo=bootstrap
https://img.shields.io/badge/License-MIT-green

✨ Live Demo
🚀 Coming Soon - Deployment in progress

📸 Screenshots
Homepage	Movie Booking	Admin Dashboard
https://via.placeholder.com/400x250/007bff/ffffff?text=Movies+List	https://via.placeholder.com/400x250/28a745/ffffff?text=Seat+Selection	https://via.placeholder.com/400x250/dc3545/ffffff?text=Dashboard
🌟 Key Features
🎯 Core Functionality
🎟️ Smart Ticket Booking - Real-time seat selection with category-based pricing

📱 Responsive Design - Mobile-first approach works on all devices

🔐 Secure Authentication - Session-based user management

💳 Real-time Pricing - Dynamic price calculation with multiple seat categories

📊 Admin Analytics - Comprehensive dashboard with revenue tracking

👥 User Experience
User Registration & Profile Management

Interactive Movie Catalog with high-quality images

Advanced Seat Selection with visual theater layout

Booking History with cancellation options

Instant Booking Confirmation with unique reference numbers

🎬 Theater Management
Movie Catalog Management with detailed information

Showtime Scheduling across multiple theaters

Seat Availability Tracking in real-time

Theater Layout Management with premium/standard/economy sections

⚡ Admin Power Tools
📈 Dashboard Analytics - Revenue, bookings, user statistics

🎭 Movie CRUD Operations - Full movie lifecycle management

⏰ Showtime Management - Schedule and capacity planning

👥 User Management - Customer database and analytics

💰 Revenue Reports - Financial insights and booking trends

🛠️ Technology Stack
Layer	Technology
Frontend	Bootstrap 5.3, jQuery, Razor Pages, CSS3
Backend	ASP.NET Core 8.0 MVC, C# 12
Database	SQLite with Entity Framework Core 8.0
Authentication	Session-based with role management
Styling	Custom CSS with responsive design
Icons	Font Awesome 6.0
🚀 Quick Start
Prerequisites
.NET 8.0 SDK

Git

Modern Web Browser

Installation & Setup
Clone the repository

bash
git clone https://github.com/kunal37x37/Movie-Booking-System.git
cd Movie-Booking-System
Restore dependencies

bash
dotnet restore
Setup database

bash
dotnet ef database update
Run the application

bash
dotnet run
Access the application
Open your browser and navigate to:

text
https://localhost:7000
or
http://localhost:5000
🔐 Default Accounts
Administrator Access
bash
Email: admin@moviebook.com
Password: admin123
Full system access with admin privileges

Test User Account
bash
Email: user@example.com  
Password: password123
Standard user access for testing bookings

🗄️ Database Architecture
Entity Relationship Diagram
text
Users (1) ─────── (Many) Bookings
   │
   └── IsAdmin (boolean)
   
Movies (1) ────── (Many) Showtimes
   │                  │
   └── TicketPrice    └── Theater
                      └── AvailableSeats

Bookings (Many) ─── (1) Showtimes
   │
   └── SeatCategory
   └── TotalAmount
Key Tables
Users - Customer and admin accounts

Movies - Film catalog with metadata

Showtimes - Screening schedules

Bookings - Transaction records

🎨 Project Structure
text
MovieBookingSystem/
├── 📁 Controllers/          # MVC Controllers
│   ├── HomeController.cs     # Public pages
│   ├── AccountController.cs  # Authentication
│   ├── BookingController.cs  # Booking logic
│   └── AdminController.cs    # Admin operations
├── 📁 Models/               # Data Models
│   ├── User.cs              # User entity
│   ├── Movie.cs             # Movie entity
│   ├── Showtime.cs          # Showtime entity
│   └── Booking.cs           # Booking entity
├── 📁 Views/                # Razor Views
│   ├── Home/                # Public pages
│   ├── Account/             # Auth pages
│   ├── Booking/             # Booking pages
│   └── Admin/               # Admin panels
├── 📁 Data/                 # Data Access
│   └── ApplicationDbContext.cs # Database context
├── 📁 wwwroot/              # Static Assets
│   ├── css/site.css         # Custom styles
│   ├── js/site.js           # Client scripts
│   └── images/              # Movie posters
├── Program.cs               # App entry point
└── MovieBookingSystem.csproj # Project config
💰 Pricing Model
Seat Category	Price Multiplier	Features
🎯 Premium	Base + ₹50	Front rows, recliner seats, best view
⭐ Standard	Base Price	Comfortable seating, great view
💺 Economy	Base - ₹20	Budget-friendly, standard comfort
📱 API Endpoints Overview
Public Endpoints
GET / - Movie catalog homepage

GET /Home/MovieDetails/{id} - Movie details with showtimes

GET /Account/Login - User authentication

GET /Account/Register - New user registration

User Endpoints
GET /Booking/BookShowtime/{id} - Ticket booking interface

GET /Booking/MyBookings - User booking history

POST /Booking/CancelBooking/{id} - Booking cancellation

Admin Endpoints
GET /Admin/AdminDashboard - Analytics dashboard

GET /Admin/Movies - Movie management

GET /Admin/Showtimes - Showtime scheduling

GET /Admin/AllBookings - All bookings view

🎫 User Journey








🔧 Development Guide
Building from Source
bash
# Clean build
dotnet clean
dotnet restore
dotnet build

# Run with specific port
dotnet run --urls="https://localhost:7001"
Database Management
bash
# Create migration
dotnet ef migrations AddMigrationName

# Update database
dotnet ef database update

# Reset database
dotnet ef database drop
dotnet ef database update
Adding New Features
Create model changes (if needed)

Add new migration: dotnet ef migrations AddFeatureName

Update database: dotnet ef database update

Implement controller logic

Create corresponding views

Test thoroughly

🐛 Troubleshooting
Common Issues & Solutions
Issue	Solution
Port already in use	dotnet run --urls="https://localhost:7001"
Database connection failed	dotnet ef database update
Build errors	dotnet clean && dotnet restore
Missing EF tools	dotnet tool install --global dotnet-ef
Authentication issues	Clear browser cookies and cache
Debug Mode
bash
# Run in development mode
dotnet run --environment Development

# Check logs in console for detailed errors
🤝 Contributing
We love contributions! Here's how to help:

Fork the repository

Create a feature branch (git checkout -b feature/AmazingFeature)

Commit your changes (git commit -m 'Add AmazingFeature')

Push to the branch (git push origin feature/AmazingFeature)

Open a Pull Request

Development Standards
Follow C# coding conventions

Use meaningful commit messages

Test all features thoroughly

Update documentation accordingly

📄 License
This project is licensed under the MIT License - see the LICENSE file for details.

👨‍💻 Author
Kunal

GitHub: @kunal37x37

Project: Movie Booking System

🙏 Acknowledgments
Bootstrap Team - For the amazing UI framework

Microsoft .NET Team - For ASP.NET Core

Entity Framework Team - For seamless data access

Font Awesome - For beautiful icons

📞 Support
🐛 Report Bugs: Create Issue

💡 Request Features: Feature Request

❓ Questions: Open a discussion in Issues

🌟 Show Your Support
If you find this project helpful, please give it a ⭐️!

Built with ❤️ using ASP.NET Core
