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
        if (Convert.ToString(Session["Nickname"]) == "")
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        CharacterEN cen=new CharacterEN("",0,"");

        if (DarkElf.Checked)
        {
            cen = new CharacterEN(TextBox1.Text, 1, Session["email"].ToString());
            cen.insert_character();
        }
        else if (Human.Checked)
        {
            cen = new CharacterEN(TextBox1.Text, 2, Session["email"].ToString());
            cen.insert_character();
        }

        else if (Orc.Checked)
        {
            cen = new CharacterEN(TextBox1.Text, 3, Session["email"].ToString());
            cen.insert_character();
        }
        else if (Dwarf.Checked)
        {
            cen = new CharacterEN(TextBox1.Text, 4, Session["email"].ToString());
            cen.insert_character();
        }
        else if (Elf.Checked)
        {
            cen = new CharacterEN(TextBox1.Text, 5, Session["email"].ToString());
            cen.insert_character();
        }
        else
        {
            Label3.Visible = true;
        }

       // cen.insert_character();
        if (cen.characterName != "")
            Session.Add("Character", cen.characterName);
        Response.Redirect("~/Player.aspx");
    }
  
}