using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BookMyVNRide_DBMS
{
    public partial class AddBus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnreg_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_addBus", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bno", Convert.ToInt32(txtnum.Text));
                cmd.Parameters.AddWithValue("@busRoute", txtbusname.Text.ToString());
                cmd.Parameters.AddWithValue("@fare", Convert.ToInt32(txtfare.Text));
                cmd.Parameters.AddWithValue("@arrivalTime", Convert.ToDateTime(stime.Text));
                cmd.Parameters.AddWithValue("@startTime", Convert.ToDateTime(atime.Text));
                cmd.Parameters.AddWithValue("@driverContact", Convert.ToDecimal(txtmobile.Text));
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    Response.Redirect("AddRoute.aspx");
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