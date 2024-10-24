using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace FitnessTrackerWebApp
{
    public partial class Nutrition : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=LAPTOP-1OTJ30TH\SQLEXPRESS;Initial Catalog=FitnessTracker;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNutrition();
            }
        }

        // Create new nutrition entry
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Nutrition (UserId, FoodItem, Calories, DateConsumed) VALUES (@UserId, @FoodItem, @Calories, @DateConsumed)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", int.Parse(txtUserId.Text));
                cmd.Parameters.AddWithValue("@FoodItem", txtFoodItem.Text);
                cmd.Parameters.AddWithValue("@Calories", int.Parse(txtCalories.Text));
                cmd.Parameters.AddWithValue("@DateConsumed", DateTime.Parse(txtDateConsumed.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadNutrition();
            ClearFields();
        }

        // Update nutrition entry
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Nutrition SET UserId=@UserId, FoodItem=@FoodItem, Calories=@Calories, DateConsumed=@DateConsumed WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@UserId", int.Parse(txtUserId.Text));
                cmd.Parameters.AddWithValue("@FoodItem", txtFoodItem.Text);
                cmd.Parameters.AddWithValue("@Calories", int.Parse(txtCalories.Text));
                cmd.Parameters.AddWithValue("@DateConsumed", DateTime.Parse(txtDateConsumed.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadNutrition();
            ClearFields();
        }

        // Delete nutrition entry
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Nutrition WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadNutrition();
            ClearFields();
        }

        // Load all nutrition records
        private void LoadNutrition()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Nutrition";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvNutrition.DataSource = dt;
                gvNutrition.DataBind();
            }
        }

        // Clear all input fields
        private void ClearFields()
        {
            txtId.Text = "";
            txtUserId.Text = "";
            txtFoodItem.Text = "";
            txtCalories.Text = "";
            txtDateConsumed.Text = "";
        }
    }
}
