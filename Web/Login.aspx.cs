using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectHADA;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //Obtaining the user players from the DataBase
        if (!IsPostBack)
        {
            //Connecting with the database
            UserCAD user_cad = new UserCAD();

            //Fullfilling the list of players.
            user_cad.fillingListPlayers();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            UserPlayer user = new UserPlayer("", TextBox1.Text, TextBox2.Text);
            bool obtenido;
            
            obtenido = user.get_login(TextBox1.Text, TextBox2.Text);

            if (obtenido == true)
            {
                UserCAD auxcad = new UserCAD();
                user = auxcad.getUser(TextBox1.Text);

                Session.Add("Nickname", TextBox1.Text);
                Session.Add("Email", user.userEmail);
                Session.Add("Password", TextBox2.Text);
                // Por defecto el timeout son 20 minutos.

                CharacterEN aux = user.getCharacter(user);
                if (aux == null)
                {
                    Response.Redirect("~/firsthero1.aspx");
                }
                else
                {
                    Session.Add("Character", aux.characterName);
                    Response.Redirect("~/Profile_player.aspx");
                }
            }
        }
    }
}