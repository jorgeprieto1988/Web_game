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
public partial class Battle : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["HADAdatabase_FINAL"].ToString();

    SqlCommand com;
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
        BattleEN battleaux = new BattleEN();
        CharacterEN aux = new CharacterEN("", 0, "");
        // CharacterEN p1 = new CharacterEN("p1", 0); //Cogerlo de la sersión
        CharacterEN p1 = aux.get_character(Session["character"].ToString());
        CharacterEN p2 = aux.get_character_random(p1);// Cogerlo de forma random
        battleaux.fight(p1, p2);
        battleaux.create_battle();

        Label1.Text = p1.characterName.ToString().ToUpper();
        Image1.ImageUrl = geturl(p1.characterRace);
        healthp1.Text = p1.characterHEALTH.ToString();
        attackp1.Text=p1.characterATK.ToString();
        defensep1.Text=p1.characterDEF.ToString();
        experiencep1.Text=p1.characterEXP.ToString();
        levelp1.Text=p1.characterLVL.ToString();
        goldp1.Text=p1.characterGold.ToString();
        pointsp1.Text = p1.characterPoints.ToString();


        Label2.Text = p2.characterName.ToString().ToUpper();
        Image2.ImageUrl = geturl(p2.characterRace);
        healthp2.Text = p2.characterHEALTH.ToString();
        attackp2.Text = p2.characterATK.ToString();
        defensep2.Text = p2.characterDEF.ToString();
        experiencep2.Text = p2.characterEXP.ToString();
        levelp2.Text = p2.characterLVL.ToString();
        goldp2.Text = p2.characterGold.ToString();
        pointsp2.Text = p2.characterPoints.ToString();

        if (p1.characterName == battleaux.Battle_name_winner)
        {
            Image4.ImageUrl = Image1.ImageUrl;
            Label3.Text = p1.characterName.ToString().ToUpper();
        }
        else
        {
            Image4.ImageUrl = Image2.ImageUrl;
            Label3.Text = p2.characterName.ToString().ToUpper();
        }
        Session.Remove("Battle");

    }
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }



    protected String geturl(int race)
    {
        // Poner la imagen del personaj
        string aux = "";
        switch (race)
        {
            // Dark elf
            case 1:
                aux = "/images/elf.png";

                break;

            // Human
            case 2:
                aux = "/images/human.jpg";
                
                break;

            // Orc
            case 3:
                aux = "/images/orc.jpg";
                
                break;

            // Dwarf
            case 4:
                aux = "/images/dwarf.jpg";
                
                break;

            // Elf
            case 5:
                aux = "/images/elf.jpg";
                
                break;
        }
        return aux;
    }
}