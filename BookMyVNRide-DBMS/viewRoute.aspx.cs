using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BookMyVNRide_DBMS
{
    public partial class viewRoute : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("sp_getDataById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bno", Request.QueryString["id"]);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;//to use both command and adapter classes together
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
        protected void register_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)(sender)).CommandArgument.ToString());
            Response.Redirect("Register.aspx?id=" + id);
        }
    }
}
