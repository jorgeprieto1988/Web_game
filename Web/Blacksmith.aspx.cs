using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectHADA;
using System.Text;
using System.Web.SessionState;

using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Blacksmith : System.Web.UI.Page
{
    string strConnString = ConfigurationManager.ConnectionStrings["HADAdatabase_FINAL"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Nickname"]) == "")
        {
            Response.Redirect("~/Login.aspx");
        }

        else if (Convert.ToString(Session["Character"]) == "")
        {
            Response.Redirect("~/firsthero1.aspx");
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    // When the button of the GridView1 is clicked
    protected void Button_click_event(Object sender,EventArgs e)
    {
        Button btn = (Button)sender;
        string CommandName = btn.CommandName;
        string CommandArgument = btn.CommandArgument;

        if (CommandName == "Buy")
        {
            GridViewRow grdrow = (GridViewRow)((Button)sender).NamingContainer;
            string itemName = grdrow.Cells[0].Text;

            CharacterEN character = new CharacterEN();
            character = character.get_character(Session["Character"].ToString());

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            string consulta = "SELECT * FROM items_game WHERE name = @NAME";
            using (SqlCommand com = new SqlCommand(consulta, con))
            {
                com.Parameters.AddWithValue("@NAME", itemName);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                string name = reader["name"].ToString();
                double gold = Convert.ToDouble(reader["gold"].ToString());
                int attack = Convert.ToInt16(reader["extra_attack"].ToString());
                int health = Convert.ToInt16(reader["extra_health"].ToString());
                int defense = Convert.ToInt16(reader["extra_defense"].ToString());
                Item_Game item = new Item_Game(gold, 0, "", name, attack, defense, health);
                character.buy_item(item); // ERROR EN LA SENTENCIA SELECT CUANDO COPIAMOS LA MOCHILA NO DETECTA LA COLUMNA items_game.extra_attack
            }
            con.Close();
            string message = "Item, bought succesfully!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else
        {
            string message = "Wrong command, something went wrong! Try again!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }



    protected void Button_click_event2(Object sender, EventArgs e)
    {
        // When the button of the GridView2 is clicked

        Button btn = (Button)sender;
        string CommandName = btn.CommandName;
        string CommandArgument = btn.CommandArgument;

        if(CommandName == "Sell"){
            GridViewRow grdrow = (GridViewRow)((Button)sender).NamingContainer;
            string itemName = grdrow.Cells[0].Text;

            CharacterEN character = new CharacterEN();
            character = character.get_character(Session["Character"].ToString());

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            string consulta = "SELECT * FROM items_game WHERE name = @NAME";
            using (SqlCommand com = new SqlCommand(consulta, con))
            {
                com.Parameters.AddWithValue("@NAME", itemName);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                string name = reader["name"].ToString();
                double gold = Convert.ToDouble(reader["gold"].ToString());
                int attack = Convert.ToInt16(reader["extra_attack"].ToString());
                int health = Convert.ToInt16(reader["extra_health"].ToString());
                int defense = Convert.ToInt16(reader["extra_defense"].ToString());
                Item_Game item = new Item_Game(gold, 0,"",name,attack,defense,health);
               // character.sell_item(item); // ERROR EN LA SENTENCIA SELECT CUANDO COPIAMOS LA MOCHILA NO DETECTA LA COLUMNA items_game.extra_attack
            }
            con.Close();
            string message = "Item, sold succesfully!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        else
        {
            string message = "Wrong command, something went wrong! Try again!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

    }
}