using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BookMyVNRide_DBMS
{
    public partial class AddRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic can be placed here if needed
        }

        protected void submitRoutesButton_Click(object sender, EventArgs e)
        {
            string busRouteNo = busRouteNoTextBox.Text.Trim();
            string routesInput = routesTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(busRouteNo) && !string.IsNullOrEmpty(routesInput))
            {
                string[] routesArray = routesInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (routesArray.Length > 0)
                {
                    try
                    {
                        // Save the data to the database (replace the connection string with your own)
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
                        {
                            con.Open();

                            foreach (string route in routesArray)
                            {
                                string insertQuery = "INSERT INTO boardingPoints (stopName, bno) VALUES (@StopName, @Bno)";
                                using (SqlCommand command = new SqlCommand(insertQuery, con))
                                {
                                    command.Parameters.AddWithValue("@StopName", route);
                                    command.Parameters.AddWithValue("@Bno", busRouteNo);
                                    command.ExecuteNonQuery();
                                }
                            }
                        }

                        // If the routes are successfully inserted, clear the textboxes
                        Response.Redirect("ViewBuses.aspx");

                        // You can also display a success message or redirect to another page
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception, display an error message, or redirect to an error page
                        // For demonstration purposes, let's just display the error on the page
                        Response.Write("Error: " + ex.Message);
                    }
                }
                else
                {
                    // Handle the case when no routes are entered
                    // For demonstration purposes, let's just display a message
                    Response.Write("Please enter at least one route.");
                }
            }
            else
            {
                // Handle the case when either bus route number or routes input is empty
                // For demonstration purposes, let's just display a message
                Response.Write("Please enter both bus route number and routes.");
            }
        }
    }
}
