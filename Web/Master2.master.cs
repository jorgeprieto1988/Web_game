using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectHADA;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (Menu2.SelectedItem.Text == "Log Out")
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            
            HttpContext.Current.Response.Redirect("~/Home.aspx", true); /* tu pagina de logueo*/
        }
    }
}
