using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectHADA;

public partial class Fight : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Nickname"]) == "")
        {
            Response.Redirect("~/Login.aspx");
        }

        if (Convert.ToString(Session["Character"]) == "")
        {
            Response.Redirect("~/firsthero1.aspx");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        BattleEN battleaux = new BattleEN();
        CharacterEN aux=new CharacterEN("",0,"");
       // CharacterEN p1 = new CharacterEN("p1", 0); //Cogerlo de la sersión
        CharacterEN p1 = aux.get_character(Session["character"].ToString());
        CharacterEN p2 = aux.get_character_random(p1);// Cogerlo de forma random

        // Application.Lock();
        Application["Battles_Count"] = Convert.ToInt32(Application["Battles_Count"]) + 1;
        battleaux.Battle_id = Convert.ToInt32(Application["Battles_Count"]);
        battleaux.fight(p1, p2);
        battleaux.create_battle();
        Session.Add("Battle",(Convert.ToInt32(Application["Battles_Count"])));
       // Application.UnLock();
        Response.Redirect("~/Battle.aspx");
    }
}