using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace FitnessTrackerWebApp
{
    public partial class Progress : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=LAPTOP-1OTJ30TH\SQLEXPRESS;Initial Catalog=FitnessTracker;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProgress();
            }
        }

        // Create new progress entry
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Progress (UserId, Weight, BMI, DateRecorded) VALUES (@UserId, @Weight, @BMI, @DateRecorded)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", int.Parse(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Weight", decimal.Parse(txtWeight.Text));
                cmd.Parameters.AddWithValue("@BMI", decimal.Parse(txtBMI.Text));
                cmd.Parameters.AddWithValue("@DateRecorded", DateTime.Parse(txtDateRecorded.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadProgress();
            ClearFields();
        }

        // Update progress entry
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Progress SET UserId=@UserId, Weight=@Weight, BMI=@BMI, DateRecorded=@DateRecorded WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@UserId", int.Parse(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Weight", decimal.Parse(txtWeight.Text));
                cmd.Parameters.AddWithValue("@BMI", decimal.Parse(txtBMI.Text));
                cmd.Parameters.AddWithValue("@DateRecorded", DateTime.Parse(txtDateRecorded.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadProgress();
            ClearFields();
        }

        // Delete progress entry
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Progress WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadProgress();
            ClearFields();
        }

        // Load all progress entries
        private void LoadProgress()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Progress";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvProgress.DataSource = dt;
                gvProgress.DataBind();
            }
        }

        // Clear input fields
        private void ClearFields()
        {
            txtId.Text = "";
            txtUserId.Text = "";
            txtWeight.Text = "";
            txtBMI.Text = "";
            txtDateRecorded.Text = "";
        }
    }
}
