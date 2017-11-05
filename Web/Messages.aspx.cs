using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectHADA;

using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Messages : System.Web.UI.Page
{
    string strConnString = ConfigurationManager.ConnectionStrings["HADAdatabase_FINAL"].ConnectionString;
    string str;
    SqlCommand com;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["Nickname"]) == "")
            {
                Response.Redirect("~/Login.aspx");
            }

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            str = "SELECT email FROM player";
            SqlCommand com2 = new SqlCommand(str, con);

            SqlDataAdapter da = new SqlDataAdapter(com2);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset
            DropDownList1.DataValueField = ds.Tables[0].Columns["email"].ToString(); // text field name of table dispalyed in dropdown
            DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            DropDownList1.DataBind();  //binding dropdownlist

            con.Close();
        }
        catch (Exception ex) { /* Imprimir mensaje */}
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        MessageEN aux = new MessageEN();
        aux.Message_text = TextBox1.Text.ToString();
        aux.Message_sender = Session["email"].ToString();
        aux.Message_receiver = DropDownList2.SelectedItem.Text;

        bool creado = false; 
        creado = aux.create_message();

        if (creado == true)
        {
            Label1.Text = "Message has been sent.";
            Label1.Visible = true;
        }

        else
        {
            Label1.Text = "Message has not been sent.";
            Label1.Visible = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}