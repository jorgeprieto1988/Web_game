using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectHADA;



    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Nickname"]) == "")
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        //GEMAS 100
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
           
            UserPlayer player = new UserPlayer(Session["Email"].ToString(), Session["Nickname"].ToString(), Session["Password"].ToString());
            UserCAD aux = new UserCAD();
            aux.insertNewPurchase(player,100);
            
        }
        // GEMAS 200
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            UserPlayer player = new UserPlayer(Session["Email"].ToString(), Session["Nickname"].ToString(), Session["Password"].ToString());
            UserCAD aux = new UserCAD();
            aux.insertNewPurchase(player, 200);
        }
        // GEMAS 500
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            UserPlayer player = new UserPlayer(Session["Email"].ToString(), Session["Nickname"].ToString(), Session["Password"].ToString());
            UserCAD aux = new UserCAD();
            aux.insertNewPurchase(player, 500);
        }
        //GEMAS 1000
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            UserPlayer player = new UserPlayer(Session["Email"].ToString(), Session["Nickname"].ToString(), Session["Password"].ToString());
            UserCAD aux = new UserCAD();
            aux.insertNewPurchase(player, 1000);
        }

        //CESTA
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
        //POLO
        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Item_life item = new Item_life(25, "Polo", "An amazing polo with our logo!");
            item.insertBD();
        }
}