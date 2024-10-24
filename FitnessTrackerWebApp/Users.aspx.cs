using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitnessTrackerWebApp
{
    public partial class Users : System.Web.UI.Page
    {
        // Connection string to your SQL Server
       
        private string connectionString = @"Data Source=LAPTOP-1OTJ30TH\SQLEXPRESS;Initial Catalog=FitnessTracker;Integrated Security=True";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        // Create a new user
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Name, Email, Age) VALUES (@Name, @Email, @Age)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadUsers();
            ClearFields();
        }

        // Update an existing user
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Name=@Name, Email=@Email, Age=@Age WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadUsers();
            ClearFields();
        }

        // Delete an existing user
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadUsers();
            ClearFields();
        }

        // Load all users from the database
        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        // Clear the input fields
        private void ClearFields()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtAge.Text = "";
        }
    }
}
