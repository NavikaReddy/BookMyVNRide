using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace BookMyVNRide_DBMS
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    getRouteNo();
            }
        }

        public void getRouteNo()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from bus", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlroute.Items.Clear();
                ddlroute.Items.Add("--Select--");
                ddlroute.DataTextField = "bno";
                ddlroute.DataValueField = "bno";
                ddlroute.DataSource = dt;
                ddlroute.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddlroute_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from boardingPoints where bno=@bno", con);
                cmd.Parameters.AddWithValue("@bno", ddlroute.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                ddlboardingpt.Items.Clear();
                ddlboardingpt.Items.Add("--Select--");
                ddlboardingpt.DataTextField = "stopName";
                ddlboardingpt.DataValueField = "stopName";
                ddlboardingpt.DataSource = dt;
                ddlboardingpt.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }
        }

        protected void btnreg_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sname", txtname.Text);
                cmd.Parameters.AddWithValue("@rollno", txtroll.Text);
                cmd.Parameters.AddWithValue("@branch", txtbranch.Text);
                cmd.Parameters.AddWithValue("@bno", ddlroute.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@yearOfStd", ddlyear.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@boardingPoint", ddlboardingpt.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@phone", txtmobile.Text);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Get your bus pass at college');", true);
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