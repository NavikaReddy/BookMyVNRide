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
    public partial class DisplayStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
        public void GetData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_getAllStudents", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rep.DataSource = dt;
                rep.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }    
        }

        protected void del_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from students", con);
                int x = cmd.ExecuteNonQuery();
                if(x>0)
                {
                    GetData();
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