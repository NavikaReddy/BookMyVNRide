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
    public partial class EditBusPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataById();
            }
        }
        public void GetDataById()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from bus where bno=@bno", con);
                cmd.Parameters.AddWithValue("@bno", Request.QueryString["id"]);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtbusname.Text = dr[1].ToString();
                    txtfare.Text = dr[2].ToString();
                    stime.Text = dr[3].ToString();
                    atime.Text = dr[4].ToString();
                    txtmobile.Text = dr[5].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update bus set busRoute=@busRoute,fare=@fare,startTime=@startTime,arrivalTime=@arrivalTime,driverContact=@driverContact where bno=@bno", con);
                cmd.Parameters.AddWithValue("@busRoute", txtbusname.Text);
                cmd.Parameters.AddWithValue("@fare", txtfare.Text);
                cmd.Parameters.AddWithValue("@startTime", stime.Text);
                cmd.Parameters.AddWithValue("@arrivalTime", atime.Text);
                cmd.Parameters.AddWithValue("@driverContact", txtmobile.Text);
                cmd.Parameters.AddWithValue("@bno", Request.QueryString["id"]);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
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