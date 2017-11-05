using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectHADA;
using System.Messaging;
using System.Data;
public partial class FriendList : System.Web.UI.Page
{
    private UserPlayer auxPlayer = new UserPlayer("listfriend2","listfriend2","listfriend2");
    private DataSet d = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Nickname"]) == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            d = auxPlayer.listarAmigosEN(Session["email"].ToString());
            GridView1.DataSource = d;
            GridView1.DataBind();

        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        d = auxPlayer.listarAmigosEN(Session["email"].ToString());
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = d;
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.AutoGenerateSelectButton = true;
        TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox1.Enabled = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //We obtain the nickname of the player.
        string emailDelQueQueremosAgregar = TextBox1.Text;

        //We create a CAD in order to stablish the connection.
        UserCAD cad1 = new UserCAD();

        //We create the user.
        string playerQueSolicitaAmistad = Session["Nickname"].ToString();
        UserPlayer currentPlayer = cad1.getUser(playerQueSolicitaAmistad);

        //We try to add the friend.
        if (currentPlayer.add_friend(emailDelQueQueremosAgregar))
        {
            Label1.Text = "The player has been added to your friend list.";
            Label1.Visible = true;
        }
        else
        {
            Label1.Text = "The player has not been added to your friend list.";
            Label1.Visible = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //We obtain the nickname of the player.
        string emailDelQueQueremosBorrar = TextBox2.Text;

        //We create a CAD in order to stablish the connection.
        UserCAD cad1 = new UserCAD();

        //We create the user.
        string playerQueSolicitaBorrar = Session["Nickname"].ToString();
        UserPlayer currentPlayer = cad1.getUser(playerQueSolicitaBorrar);

        //We try to add the friend.
        if (currentPlayer.delete_friend(emailDelQueQueremosBorrar))
        {
            Label1.Text = "The player has been deleted to your friend list.";
            Label1.Visible = true;
        }
        else
        {
            Label1.Text = "The player has not been deleted to your friend list.";
            Label1.Visible = true;
        }
    }
}