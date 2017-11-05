using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectHADA;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Variable for indicating if the register is successfully or not.
        int created = 0;

        //We create the user/player object.
        UserPlayer player= new UserPlayer(TextBox5.Text, TextBox2.Text, TextBox3.Text);
        
        //Once we have the object done, we have to register it.
        created = player.create_player();

        //If we have created the user, then we have to say that the validation is OK.
        if (created > 0)
        {
            Label5.Text = "Registration has been done successfully.";
            Label5.Visible = true;
            Response.Redirect("~/Login.aspx");
        }
        else if (created <= 0)
        {
            Label5.Text = "The registration has failed.";
            Label5.Visible = true;
        }
    }
}