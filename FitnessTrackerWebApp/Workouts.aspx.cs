using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace FitnessTrackerWebApp
{
    public partial class Workouts : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=LAPTOP-1OTJ30TH\SQLEXPRESS;Initial Catalog=FitnessTracker;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadWorkouts();
            }
        }

        // Create a new workout entry
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Workouts (UserId, WorkoutType, Duration, CaloriesBurned) VALUES (@UserId, @WorkoutType, @Duration, @CaloriesBurned)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", int.Parse(txtUserId.Text));
                cmd.Parameters.AddWithValue("@WorkoutType", txtWorkoutType.Text);
                cmd.Parameters.AddWithValue("@Duration", int.Parse(txtDuration.Text));
                cmd.Parameters.AddWithValue("@CaloriesBurned", int.Parse(txtCaloriesBurned.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadWorkouts();
            ClearFields();
        }

        // Update workout entry
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Workouts SET UserId=@UserId, WorkoutType=@WorkoutType, Duration=@Duration, CaloriesBurned=@CaloriesBurned WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@UserId", int.Parse(txtUserId.Text));
                cmd.Parameters.AddWithValue("@WorkoutType", txtWorkoutType.Text);
                cmd.Parameters.AddWithValue("@Duration", int.Parse(txtDuration.Text));
                cmd.Parameters.AddWithValue("@CaloriesBurned", int.Parse(txtCaloriesBurned.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadWorkouts();
            ClearFields();
        }

        // Delete workout entry
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Workouts WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadWorkouts();
            ClearFields();
        }

        // Load all workouts from the database
        private void LoadWorkouts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Workouts";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvWorkouts.DataSource = dt;
                gvWorkouts.DataBind();
            }
        }

        // Clear all input fields
        private void ClearFields()
        {
            txtId.Text = "";
            txtUserId.Text = "";
            txtWorkoutType.Text = "";
            txtDuration.Text = "";
            txtCaloriesBurned.Text = "";
        }
    }
}
