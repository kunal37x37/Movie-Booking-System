Movie Booking System - README
---------------------------------------------------------------------------------
🎬 Project Overview
A complete Movie Ticket Booking System built with ASP.NET Core MVC, Entity Framework Core, and SQLite. This system allows users to browse movies, book tickets, and manage bookings, while admins can manage movies, showtimes, and view reports.

---------------------------------------------------------------------------------
📁 Project Structure

MovieBookingSystem/
├── 📄 MovieBookingSystem.csproj
├── 📄 Program.cs
├── 📄 appsettings.json
├── 📂 Properties/
│   └── 📄 launchSettings.json
├── 📂 wwwroot/
│   ├── 📂 css/
│   │   └── 📄 site.css
│   └── 📂 images/
│       ├── 📂 movies/ (uploaded images)
│       └── 📄 default-movie.jpg
├── 📂 Data/
│   └── 📄 ApplicationDbContext.cs
├── 📂 Models/
│   ├── 📄 User.cs
│   ├── 📄 Movie.cs
│   ├── 📄 Showtime.cs
│   └── 📄 Booking.cs
├── 📂 Controllers/
│   ├── 📄 HomeController.cs
│   ├── 📄 AccountController.cs
│   ├── 📄 BookingController.cs
│   └── 📄 AdminController.cs
├── 📂 Views/
│   ├── 📂 Shared/
│   │   ├── 📄 _Layout.cshtml
│   │   ├── 📄 _ValidationScriptsPartial.cshtml
│   │   └── 📄 Error.cshtml
│   ├── 📂 Home/
│   │   ├── 📄 Index.cshtml
│   │   ├── 📄 MovieDetails.cshtml
│   │   ├── 📄 About.cshtml
│   │   ├── 📄 Contact.cshtml
│   │   └── 📄 Privacy.cshtml
│   ├── 📂 Account/
│   │   ├── 📄 Login.cshtml
│   │   ├── 📄 Register.cshtml
│   │   └── 📄 Profile.cshtml
│   ├── 📂 Booking/
│   │   ├── 📄 BookShowtime.cshtml
│   │   ├── 📄 BookingConfirmation.cshtml
│   │   └── 📄 MyBookings.cshtml
│   └── 📂 Admin/
│       ├── 📄 AdminDashboard.cshtml
│       ├── 📄 Movies.cshtml
│       ├── 📄 AddMovie.cshtml
│       ├── 📄 EditMovie.cshtml
│       ├── 📄 Showtimes.cshtml
│       ├── 📄 BookingMessages.cshtml
│       ├── 📄 DeleteMovie.cshtml
│       ├── 📄 AddShowtime.cshtml
│       ├── 📄 AllBookings.cshtml
│       └── 📄 Users.cshtml
└── 📂 Migrations/
    └── 📄 (Entity Framework migration files)


---------------------------------------------------------------------------------
🚀 Features

👥 User Features
•	✅ User Registration & Login
•	✅ Browse Movies with Details
•	✅ View Available Showtimes
•	✅ Book Tickets with different categories(1-10 tickets per booking)
•	✅ Automatic Seat Allocation
•	✅ Booking Confirmation with Reference Number
•	✅ View/Cancel Bookings
•	✅ Download/Print Movie Tickets
•	✅ User Profile Management

🎯 Admin Features
•	✅ Admin Dashboard with Statistics
•	✅ Manage Movies (Add, Edit, Delete, Activate/Deactivate)
•	✅ Image Upload for Movie Posters
•	✅ Manage Showtimes
•	✅ View All Bookings
•	✅ User Management
•	✅ Revenue Reports

🛠️ Technical Features
•	✅ SQLite Database (Easy setup, no server required)
•	✅ Entity Framework Core with Code-First Approach
•	✅ Session-based Authentication
•	✅ Responsive Bootstrap UI
•	✅ Form Validation & Error Handling
•	✅ Image Upload with Validation
•	✅ Real-time Seat Availability

---------------------------------------------------------------------------------
🗄️ Database Schema
Tables:
1.	Users - User accounts and authentication
2.	Movies - Movie catalog with image support
3.	Showtimes - Movie screening schedules
4.	Bookings - Ticket booking records

Relationships:
•	Users (1) → (Many) Bookings
•	Movies (1) → (Many) Showtimes
•	Showtimes (1) → (Many) Bookings

---------------------------------------------------------------------------------
🛠️ Installation & Setup

Prerequisites
•	.NET 8.0 SDK
•	Visual Studio 2022 or VS Code

Step-by-Step Setup

1.	Clone/Download the Project
--------------------------------------
cd MovieBookingSystem
--------------------------------------

2.	Restore Packages
--------------------------------------
dotnet restore
--------------------------------------

3.	Create Database
--------------------------------------
dotnet ef migrations add InitialCreate
dotnet ef database update
--------------------------------------
4.	Run Application
--------------------------------------
dotnet run
--------------------------------------

5.	Access Application
o	Open: https://localhost:7000
o	Admin Login: admin@moviebook.com / admin123
o	User Register: Create new account


---------------------------------------------------------------------------------
🔑 Default Accounts

Admin Account
•	Email: rajhans@gmail.com
•	Password: abc123

Sample User Accounts
•	Email: abc123@gmail.com
•	Password: abc123

📱 Usage Guide
For Users:
1.	Register/Login - Create account or login
2.	Browse Movies - View available movies on homepage
3.	Select Movie - Click on movie for details and showtimes
4.	Book Tickets - Choose showtime, select tickets, confirm booking
5.	Manage Bookings - View/Cancel bookings from "My Bookings"

For Admins:
1.	Admin Login - Use admin credentials
2.	Dashboard - View system statistics
3.	Manage Movies - Add/edit movies with image upload
4.	Manage Showtimes - Add screening schedules
5.	View Reports - Check bookings and revenue

---------------------------------------------------------------------------------
🖼️ Image Upload Feature

Supported Features:
•	✅ Upload movie posters (JPG, PNG, JPEG)
•	✅ Max file size: 5MB
•	✅ Automatic image validation
•	✅ Unique filename generation
•	✅ Default image fallback
•	✅ Image preview before upload

Image Storage:
•	Path: wwwroot/images/movies/
•	Default: wwwroot/images/default-movie.jpg

🔧 Configuration
Database Connection (appsettings.json)
json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=MovieBookingSystem.db"
  }
}

---------------------------------------------------------------------------------
Packages Used (MovieBookingSystem.csproj)
xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />

---------------------------------------------------------------------------------
🐛 Troubleshooting
Common Issues & Solutions:
1.	Database Connection Error
-------------------------------------
dotnet ef database drop --force
dotnet ef database update
-------------------------------------

2.	Migration Errors
-------------------------------------
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
-------------------------------------

3.	Image Upload Not Working
-------------------------------------
o	Ensure wwwroot/images/movies/ folder exists
o	Check file permissions
o	Verify image file format and size
-------------------------------------

4.	Build Errors
-------------------------------------
dotnet clean
dotnet build
-------------------------------------


---------------------------------------------------------------------------------
📊 Sample Data
The system comes with pre-loaded sample data:
•	6+ Movies (Marvel, Bollywood, Anime)
•	Multiple showtimes
•	Sample bookings
•	Admin and test user accounts


---------------------------------------------------------------------------------
🎨 UI/UX Features
•	Responsive Design - Works on desktop, tablet, mobile
•	Bootstrap 5 - Modern UI components
•	Font Awesome Icons - Enhanced visual appeal
•	Interactive Forms - Real-time validation
•	Image Previews - Before upload confirmation
•	Alert Messages - Success/error notifications


---------------------------------------------------------------------------------
🔒 Security Features
•	Session-based Authentication
•	Anti-Forgery Tokens
•	Input Validation
•	SQL Injection Prevention
•	Role-based Access Control (Admin/User)


---------------------------------------------------------------------------------
📈 Future Enhancements
•	Payment Gateway Integration
•	Email Notifications
•	Seat Selection Interface
•	Movie Ratings & Reviews
•	Advanced Search & Filters
•	Mobile App Version


---------------------------------------------------------------------------------
🤝 Contributing
1.	Fork the project
2.	Create feature branch
3.	Commit changes
4.	Push to branch
5.	Create Pull Request

---------------------------------------------------------------------------------
📄 License
This project is for educational purposes. Feel free to modify and use.
👨‍💻 Developer
Built using ASP.NET Core MVC
🆘 Support
For issues and questions:
1.	Check troubleshooting section
2.	Verify database connection
3.	Ensure all packages are restored
4.	Check application logs for errors
________________________________________
