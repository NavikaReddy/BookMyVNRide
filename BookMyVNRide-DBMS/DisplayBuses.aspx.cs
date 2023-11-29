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
    public partial class DisplayBuses : System.Web.UI.Page
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
                SqlDataAdapter da = new SqlDataAdapter("sp_getAllData", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rep.DataSource = dt;
                rep.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void viewRoute_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)(sender)).CommandArgument.ToString());
            Response.Redirect("ViewRoute.aspx?id=" + id);
        }
    }
}