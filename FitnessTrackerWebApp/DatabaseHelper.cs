using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class DatabaseHelper
{
    private string connectionString = ConfigurationManager.ConnectionStrings["FitnessTrackerDB"].ConnectionString;

    // ============================ User CRUD ============================

    // Create User
    public void CreateUser(string name, string email, int age)
    {
        string query = "INSERT INTO Users (Name, Email, Age) VALUES (@Name, @Email, @Age)";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Age", age);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Read Users
    public DataTable GetUsers()
    {
        DataTable dt = new DataTable();
        string query = "SELECT * FROM Users";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
        }
        return dt;
    }

    // Update User
    public void UpdateUser(int id, string name, string email, int age)
    {
        string query = "UPDATE Users SET Name = @Name, Email = @Email, Age = @Age WHERE Id = @Id";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Age", age);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Delete User
    public void DeleteUser(int id)
    {
        string query = "DELETE FROM Users WHERE Id = @Id";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // ============================ Workout CRUD ============================

    // Create Workout
    public void CreateWorkout(int userId, string workoutType, int duration, int caloriesBurned)
    {
        string query = "INSERT INTO Workouts (UserId, WorkoutType, Duration, CaloriesBurned) VALUES (@UserId, @WorkoutType, @Duration, @CaloriesBurned)";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@WorkoutType", workoutType);
                cmd.Parameters.AddWithValue("@Duration", duration);
                cmd.Parameters.AddWithValue("@CaloriesBurned", caloriesBurned);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Read Workouts
    public DataTable GetWorkouts()
    {
        DataTable dt = new DataTable();
        string query = "SELECT * FROM Workouts";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
        }
        return dt;
    }

    // Update Workout
    public void UpdateWorkout(int id, string workoutType, int duration, int caloriesBurned)
    {
        string query = "UPDATE Workouts SET WorkoutType = @WorkoutType, Duration = @Duration, CaloriesBurned = @CaloriesBurned WHERE Id = @Id";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@WorkoutType", workoutType);
                cmd.Parameters.AddWithValue("@Duration", duration);
                cmd.Parameters.AddWithValue("@CaloriesBurned", caloriesBurned);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Delete Workout
    public void DeleteWorkout(int id)
    {
        string query = "DELETE FROM Workouts WHERE Id = @Id";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // ============================ Nutrition CRUD ============================

    // Create Nutrition Entry
    public void CreateNutrition(int userId, string foodItem, int calories, DateTime dateConsumed)
    {
        string query = "INSERT INTO Nutrition (UserId, FoodItem, Calories, DateConsumed) VALUES (@UserId, @FoodItem, @Calories, @DateConsumed)";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@FoodItem", foodItem);
                cmd.Parameters.AddWithValue("@Calories", calories);
                cmd.Parameters.AddWithValue("@DateConsumed", dateConsumed);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Read Nutrition Entries
    public DataTable GetNutrition()
    {
        DataTable dt = new DataTable();
        string query = "SELECT * FROM Nutrition";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
        }
        return dt;
    }

    // Update Nutrition Entry
    public void UpdateNutrition(int id, string foodItem, int calories, DateTime dateConsumed)
    {
        string query = "UPDATE Nutrition SET FoodItem = @FoodItem, Calories = @Calories, DateConsumed = @DateConsumed WHERE Id = @Id";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@FoodItem", foodItem);
                cmd.Parameters.AddWithValue("@Calories", calories);
                cmd.Parameters.AddWithValue("@DateConsumed", dateConsumed);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Delete Nutrition Entry
    public void DeleteNutrition(int id)
    {
        string query = "DELETE FROM Nutrition WHERE Id = @Id";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // ============================ Progress CRUD ============================

    // Create Progress Entry
    public void CreateProgress(int userId, decimal weight, decimal bmi, DateTime dateRecorded)
    {
        string query = "INSERT INTO Progress (UserId, Weight, BMI, DateRecorded) VALUES (@UserId, @Weight, @BMI, @DateRecorded)";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Weight", weight);
                cmd.Parameters.AddWithValue("@BMI", bmi);
                cmd.Parameters.AddWithValue("@DateRecorded", dateRecorded);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Read Progress Entries
    public DataTable GetProgress()
    {
        DataTable dt = new DataTable();
        string query = "SELECT * FROM Progress";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
        }
        return dt;
    }

    // Update Progress Entry
    public void UpdateProgress(int id, decimal weight, decimal bmi, DateTime dateRecorded)
    {
        string query = "UPDATE Progress SET Weight = @Weight, BMI = @BMI, DateRecorded = @DateRecorded WHERE Id = @Id";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Weight", weight);
                cmd.Parameters.AddWithValue("@BMI", bmi);
                cmd.Parameters.AddWithValue("@DateRecorded", dateRecorded);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Delete Progress Entry
    public void DeleteProgress(int id)
    {
        string query = "DELETE FROM Progress WHERE Id = @Id";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
