using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;



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
                cmd.CommandType = CommandType.StoredProcedure;
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
                    // Generate and download PDF
                    GenerateAndDownloadPDF(txtname.Text, txtroll.Text, txtbranch.Text, ddlroute.SelectedItem.Value, ddlyear.SelectedItem.Value, ddlboardingpt.SelectedItem.Value, txtmobile.Text);

                    // Display a message to the user
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Bus pass application submitted. PDF has been generated and downloaded.');", true);
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

        private void GenerateAndDownloadPDF(string name, string roll, string branch, string route, string year, string boardingPoint, string phone)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text.
            graphics.DrawString("Name: " + name + "\nRoll no: " + roll + " Branch: "+ branch + "\nRoute: " + route + " Boarding point: " + boardingPoint , font, PdfBrushes.Black, new PointF(0, 0));

            //Saving the PDF to the MemoryStream.
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";

            //Define the file name.
            string fileName = "BusPass.pdf";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", $"attachment; filename={fileName}");
            Response.BinaryWrite(stream.ToArray());
            Response.End();

        }

    }
}
