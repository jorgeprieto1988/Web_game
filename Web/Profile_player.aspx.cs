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

public partial class Profile_player : System.Web.UI.Page
{
    string strConnString = ConfigurationManager.ConnectionStrings["HADAdatabase_FINAL"].ToString();
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
            else
            {
                SqlConnection con = new SqlConnection(strConnString);
                con.Open();

                str = "SELECT usuarios.nick_name, player.email, gems, banned_times FROM player, usuarios WHERE player.email = @EMAIL and player.email = usuarios.email";
                using (com = new SqlCommand(str, con))
                {
                    com.Parameters.AddWithValue("@EMAIL", Session["email"]);
                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();

                    // Poner el nombre del usuario
                    Label1.Text = reader["nick_name"].ToString();
                    // Poner el email del usuario
                    Label7.Text = reader["email"].ToString();
                    // Poner las gemas que tiene el usuario
                    Label3.Text = reader["gems"].ToString();
                    // Poner las veces que ha sido baneado el usuario
                    Label5.Text = reader["banned_times"].ToString();
                    reader.Close();
                }
            }

        }
         catch (Exception ex) { /* imprimir mensaje */ }
    }
    

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Hacer que si el usuario no tiene personaje se vaya a la página firsthero1.aspx
        if (Session["character"].ToString() == "")
        {
            Response.Redirect("~/firsthero1.aspx");
        }
        else
            Response.Redirect("~/Player");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // No debe hacer nada, sólo hay que ir a la página Shop
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Comento esto porque la mejora de borrar el personaje no está acabada
        /*
        UserCAD user = new UserCAD();
        user.deleteCharacter(Session["email"].ToString());
        */
    }
}