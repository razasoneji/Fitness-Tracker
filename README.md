# Fitness Tracker

Fitness Tracker is a simple web application built using **ASP.NET Framework WebForms** that focuses on managing CRUD operations through web forms. This project allows users to track their fitness data by interacting with a SQL Server database, but it currently lacks authentication.

## Features

- **User Management**: Create, read, update, and delete user information.
- **Workout Tracking**: Add, view, modify, and remove workout sessions.
- **Nutrition Management**: Record and view daily nutrition data.
- **Progress Monitoring**: Track weight, BMI, and other progress metrics over time.
  
All these functionalities are implemented with a focus on **database transactions** using SQL Server and ADO.NET.

## Technologies Used

- **ASP.NET Framework WebForms**
- **C#**
- **ADO.NET (System.Data.SqlClient)**
- **SQL Server**
- **HTML/CSS for basic web forms**

## Database Configuration

The application uses a connection string from the `web.config` file to connect to a SQL Server database.

Example connection string:
```xml
<connectionStrings>
  <add name="FitnessTrackerDB" connectionString="Data Source=YourServer;Initial Catalog=FitnessTrackerDB;Integrated Security=True" />
</connectionStrings>
```

## CRUD Operations

### User Management
- **Create User**: Allows adding a new user.
- **Read Users**: Retrieves all users from the database.
- **Update User**: Modify existing user details.
- **Delete User**: Remove a user from the system.

### Workout Management
- **Create Workout**: Log a new workout session.
- **Read Workouts**: Display all recorded workouts.
- **Update Workout**: Update details of a workout session.
- **Delete Workout**: Delete a workout session.

### Nutrition Management
- **Create Nutrition Entry**: Log food items and calories.
- **Read Nutrition Entries**: View logged nutrition data.
- **Update Nutrition Entry**: Modify recorded nutrition data.
- **Delete Nutrition Entry**: Remove a nutrition entry.

### Progress Tracking
- **Create Progress Entry**: Record a user's weight, BMI, and progress data.
- **Read Progress Entries**: View progress over time.
- **Update Progress Entry**: Update progress data.
- **Delete Progress Entry**: Remove a progress record.


## How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/your-username/fitness-tracker.git
   ````
## Future Enhancements
-User Authentication: Add authentication and authorization for users.
-Improved UI: Enhance the design of the web forms.
-Detailed Analytics: Provide more advanced reporting on workouts, nutrition, and progress.

## ScreenShots
![Screenshot 2024-10-24 153937](https://github.com/user-attachments/assets/80d3e6b6-8396-4fbe-8654-22da49ae0ae2)

![Screenshot 2024-10-24 153944](https://github.com/user-attachments/assets/92af7abb-2eac-4ec3-aa8b-8dc548fbf65f)

![Screenshot 2024-10-24 153952](https://github.com/user-attachments/assets/295fb909-0b3d-4101-b211-3f087b367268)

![Screenshot 2024-10-24 153959](https://github.com/user-attachments/assets/d7644d2e-ed8a-409b-b735-9fb3fd144385)

