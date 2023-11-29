using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookMyVNRide_DBMS
{
    public partial class SearchBuses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getStops();
            }
        }
        public void getStops()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select distinct(stopName) from boardingPoints", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlstop.Items.Clear();
                ddlstop.Items.Add("--Select--");
                ddlstop.DataTextField = "stopName";
                ddlstop.DataValueField = "stopName";
                ddlstop.DataSource = dt;
                ddlstop.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnget_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from bus inner join boardingPoints on bus.bno=boardingPoints.bno where stopName=@stopName", con);
                cmd.Parameters.AddWithValue("@stopName", ddlstop.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;//to use both command and adapter classes together
                da.Fill(dt);
                rep.DataSource = dt;
                rep.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Something went wrong");
            }
            finally
            {
                con.Close();
            }
        }
    }
}