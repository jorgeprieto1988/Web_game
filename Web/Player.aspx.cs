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

public partial class Player : System.Web.UI.Page
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
                if (Convert.ToString(Session["Character"]) == "")
                {
                    Response.Redirect("~/firsthero1.aspx");
                }

                else
                {
                    SqlConnection con = new SqlConnection(strConnString);
                    con.Open();

                    //string nombre_personaje_actual = "select name from character, player where player_nickname = " + Session["Nickname"] + " and character.email = player.email";
                    //str = "select * from character where name = " + nombre_personaje_actual;
                    str = "select * from character, player where player.email = @EMAIL and character.email = player.email";
                    using (com = new SqlCommand(str, con))
                    {
                        com.Parameters.AddWithValue("@EMAIL", Session["email"]);
                        SqlDataReader reader = com.ExecuteReader();
                        reader.Read();

                        // Poner el nombre del personaje
                        Label1.Text = reader["name"].ToString();

                        // Poner la imagen del personaj
                        switch (reader["race"].ToString())
                        {
                            // Dark elf
                            case "1":
                                Image1.ImageUrl = "/images/elf.png";
                                Image1.Visible = true;
                                break;

                            // Human
                            case "2":
                                Image1.ImageUrl = "/images/human.jpg";
                                Image1.Visible = true;
                                break;

                            // Orc
                            case "3":
                                Image1.ImageUrl = "/images/orc.jpg";
                                Image1.Visible = true;
                                break;

                            // Dwarf
                            case "4":
                                Image1.ImageUrl = "/images/dwarf.jpg";
                                Image1.Visible = true;
                                break;

                            // Elf
                            case "5":
                                Image1.ImageUrl = "/images/elf.jpg";
                                Image1.Visible = true;
                                break;
                        }

                        healthp1.Text = reader["health"].ToString();
                        attackp1.Text = reader["attack"].ToString();
                        defensep1.Text = reader["defense"].ToString();
                        experiencep1.Text = reader["experience"].ToString();
                        levelp1.Text = reader["level"].ToString();
                        goldp1.Text = reader["gold"].ToString();
                        pointsp1.Text = reader["points"].ToString();
                        reader.Close();
                    }


                    
                    str = "select * from bag_character where name_ch = @NAME";
                    using (com = new SqlCommand(str, con))
                    {
                        com.Parameters.AddWithValue("@NAME", Label1.Text.ToString());

                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataSet ds = new DataSet();
                        da.Fill(ds);  // fill dataset
                        DropDownList1.DataValueField = ds.Tables[0].Columns["name_ch"].ToString(); // text field name of table dispalyed in dropdown
                        DropDownList1.DataValueField = ds.Tables[0].Columns["name_it"].ToString(); // to retrive specific  textfield name 
                        DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                        DropDownList1.DataBind();  //binding dropdownlist
                    }
                    
                    con.Close();
                }
            }
        }
        catch (Exception ex) { /* imprimir mensaje */ }
    }

    protected void DetailsView1_PageIndexChanging(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}