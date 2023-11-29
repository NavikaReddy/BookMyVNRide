using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BookMyVNRide_DBMS
{
    public partial class ViewBuses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the bus data and number of bookings
                LoadBusDataWithBookings();
            }
        }

        private void LoadBusDataWithBookings()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

                // Query to get bus data and number of bookings
                string query = @"
                    SELECT
                        b.bno,
                        b.busRoute,
                        b.fare,
                        b.startTime,
                        b.arrivalTime,
                        b.driverContact,
                        COUNT(s.sno) AS NumberOfBookings
                    FROM
                        bus AS b
                        LEFT JOIN students AS s ON b.bno = s.bno
                    GROUP BY
                        b.bno,
                        b.busRoute,
                        b.fare,
                        b.startTime,
                        b.arrivalTime,
                        b.driverContact
                ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            rep.DataSource = dataTable;
                            rep.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, display an error message, or redirect to an error page
                // For demonstration purposes, let's just display the error on the page
                Response.Write("Error: " + ex.Message);
            }

        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)(sender)).CommandArgument.ToString());
            Response.Redirect("EditBusPage.aspx?id=" + id);
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)(sender)).CommandArgument.ToString());
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from boardingPoints where bno=@bno", con);
                cmd.Parameters.AddWithValue("@bno", id);
                int x = cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("delete from bus where bno=@bno", con);
                cmd1.Parameters.AddWithValue("@bno", id);
                x=cmd1.ExecuteNonQuery();
                if(x>0)
                {
                    Response.Redirect("ViewBuses.aspx");
                }
                else
                {
                    Response.Write("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }
        }
    }
}
