using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectHADA;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["Nickname"]) == "")
            {
                Response.Redirect("~/Login.aspx");
            }

            MessageEN en = new MessageEN("", Session["email"].ToString());
           
            GridView1.DataSource = en.MostrarMensajes();           
            
            GridView1.DataBind();
        }
        catch (Exception ex) { /* imprimir mensaje */}
    }
}