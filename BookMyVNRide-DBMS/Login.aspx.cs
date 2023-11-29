using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookMyVNRide_DBMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_login", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", txt_Username.Text);
                cmd.Parameters.AddWithValue("@password", txt_password.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                //execute reader will return datareader class used with command class for select queries
                //execute non query will return number of rows affected used with command class for insert,update,delete
                if (dr.Read())
                {
                    Session["Username"] = dr["email"].ToString();
                    Session["LoginDate"] = System.DateTime.Now.ToShortTimeString();
                    Response.Redirect("AdminHome.aspx");
                }
                else
                {
                    lbl.Text = "Invalid data";
                }
            }
            catch (Exception ex)
            {
                lbl.Text = ex.Message;
            }
            finally
            { con.Close(); }

        }
    }
}