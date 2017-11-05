using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Configuration;

namespace ProjectHADA
{
    /**
     * This class represents the CAD (Componente de Acceso a DAtos), 
     * DAC (Data Access Component) in English, of a Item.
     */
    public class ItemCAD
    {
        /** We create the conexion to the database*/
        public ItemCAD(ItemEN item)
        {
            if (item == null)
                throw new Exception("ItemCAD::ItemCAD(ItemEN): The introduced item is NULL");
            else
                this.item = item;
            items++;
        }
        /**
         * Obtain a Item from the database
         * @param name the name of the item
         * @return ItemEn the item that we wanted to obtain
         */
        public ItemEN getItem(string name)
        {
            ItemEN aux = null;
            /*
            SqlConnection c = new SqlConnection(sql);
            DataSet bdvirtual = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Cliente", c);
            da.Fill(bdvirtual, "cliente");
            return aux;
             * */
            using (SqlConnection conexion = new SqlConnection(db))
            {
                conexion.Open();
                string consulta1 = "SELECT * FROM items_game WHERE name = @NAME";
                string consulta2 = "SELECT * FROM items_life WHERE name = @NAME";

                using (SqlCommand command1 = new SqlCommand(consulta1, conexion))
                {
                    command1.Parameters.AddWithValue("@NAME", name);
                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aux = new Item_Game(Convert.ToDouble(reader["gold"].ToString()), Convert.ToInt16(reader["stock"].ToString()), reader["description"].ToString(), reader["name"].ToString(), Convert.ToInt16(reader["extra_attack"].ToString()), Convert.ToInt16(reader["extra_defense"].ToString()), Convert.ToInt16(reader["extra_health"].ToString()));
                        }
                        reader.Close();
                    }
                }
                if (aux == null) // Si el objeto no pertenecia a los item_game
                {
                    using (SqlCommand command2 = new SqlCommand(consulta2, conexion))
                    {
                        command2.Parameters.AddWithValue("@NAME", name);
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            while(reader2.Read())
                            {
                                aux = new Item_life(Convert.ToInt16(reader2["euros"].ToString()),null,reader2["name"].ToString());
                            }
                            reader2.Close();
                        }
                        conexion.Close();
                    }
                }
            }
                              
            return aux;
        }

        /** 
         * This method will show all the Item_life of the shop
         */
        public void show_Items_Life()
        {
            string consulta = "SELECT * from items_life";
            using (SqlConnection conexion = new SqlConnection(db))
            {
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            ItemEN aux = new Item_life(Convert.ToDouble(reader["euros"].ToString()), null, reader["name"].ToString());
                            almacen.Add(aux);
                        }
                    }
                }
            }
        }
        /**
         * This method will show all the Item_Game of the shop
         */
        public void show_Items_Game()
        {
            string consulta = "SELECT * from items_game";
            using (SqlConnection conexion = new SqlConnection(db))
            {
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ItemEN aux;
                            aux = new Item_Game(Convert.ToDouble(reader["gold"].ToString()), Convert.ToInt16(reader["stock"].ToString()), reader["description"].ToString(), reader["name"].ToString(), Convert.ToInt16(reader["extra_attack"].ToString()), Convert.ToInt16(reader["extra_defense"].ToString()), Convert.ToInt16(reader["extra_health"].ToString()));
                            almacen.Add(aux);
                        }
                    }
                }
            }
        }

        /**
         *  This method will update a Item_Game in the database
         */
        public bool update_Item(ItemEN update_item)
        {
            if (update_item == null)
                throw new Exception("ItemCAD::update_item(): The item is Null");

            int cantidad = 0;

            using (SqlConnection conexion = new SqlConnection(db))
            {
                Item_life aux = new Item_life(0,"",update_item.Name); // MIRAR ESTO
                conexion.Open();
                string consulta = "UPDATE items_life SET name = @NAME, euros = @EUROS WHERE name = @NAME";
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@NAME", aux.Name);
                    command.Parameters.AddWithValue("@EUROS", aux.Euros);
                    cantidad = command.ExecuteNonQuery();
                }
                conexion.Close();
                items++;
            }
            
            if(cantidad == 0) // Si esto es cierto es que es un objeto items_game
            {
                using (SqlConnection conexion = new SqlConnection(db))
                {
                    Item_Game aux = new Item_Game(0, 0, "", update_item.Name, 0, 0, 0); // MIRAR ESTO
                    conexion.Open();
                    string consulta = "UPDATE items_game SET name = @NAME, gold = @GOLD, extra_attack = @ATTACK, extra_defense = @DEFENSE, extra_health = @HEALTH WHERE name = @NAME";
                    using (SqlCommand command = new SqlCommand(consulta, conexion))
                    {
                        command.Parameters.AddWithValue("@NAME", aux.Name);
                        command.Parameters.AddWithValue("@GOLD", aux.Gold);
                        command.Parameters.AddWithValue("@ATTACK", aux.extra_Attack);
                        command.Parameters.AddWithValue("@DEFENSE", aux.extra_Defense);
                        command.Parameters.AddWithValue("@HEALTH", aux.extra_Health);
                        cantidad = command.ExecuteNonQuery();
                    }
                    conexion.Close();
                    items++;
                }
            }
            
            return (cantidad > 0);
        }

        /**
         *  This method will insert a Item_Game
         */
        public void insert_Item(ItemEN insert_item)
        {
            int cantidad = 0;

            using (SqlConnection conexion = new SqlConnection(db))
            {
                Item_life aux = new Item_life(0, "", insert_item.Name); // MIRAR ESTO
                conexion.Open();
                string consulta = "INSERT INTO items_life VALUES(@NAME, @EUROS)";
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@NAME", aux.Name);
                    command.Parameters.AddWithValue("@EUROS", aux.Euros);
                    cantidad = command.ExecuteNonQuery();
                }
                conexion.Close();
                items--;
            }

            if (cantidad == 0) // Si esto es cierto es que es un objeto items_game
            {
                using (SqlConnection conexion = new SqlConnection(db))
                {
                    Item_Game aux = new Item_Game(0, 0, "", insert_item.Name, 0, 0, 0); // MIRAR ESTO
                    conexion.Open();
                    string consulta = "INSERT INTO items_game VALUES(@NAME, @GOLD, @ATTACK, @DEFENSE, @HEALTH)";
                    using (SqlCommand command = new SqlCommand(consulta, conexion))
                    {
                        command.Parameters.AddWithValue("@NAME", aux.Name);
                        command.Parameters.AddWithValue("@GOLD", aux.Gold);
                        command.Parameters.AddWithValue("@ATTACK", aux.extra_Attack);
                        command.Parameters.AddWithValue("@DEFENSE", aux.extra_Defense);
                        command.Parameters.AddWithValue("@HEALTH", aux.extra_Health);
                        cantidad = command.ExecuteNonQuery();
                    }
                    conexion.Close();
                    items--;
                }
            }
        }
        /**
         * This method will delete a Item
         */
        public void delete_Item(ItemEN delete_item)
        {
            int cantidad = 0;

            using (SqlConnection conexion = new SqlConnection(db))
            {
                Item_life aux = new Item_life(0, "", delete_item.Name); // MIRAR ESTO
                conexion.Open();
                string consulta = "DELETE FROM items_life WHERE name = @NAME";
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@NAME", aux.Name);
                    cantidad = command.ExecuteNonQuery();
                }
                conexion.Close();
            }

            if (cantidad == 0) // Si esto es cierto es que es un objeto items_game
            {
                using (SqlConnection conexion = new SqlConnection(db))
                {
                    Item_Game aux = new Item_Game(0, 0, "", delete_item.Name, 0, 0, 0); // MIRAR ESTO
                    conexion.Open();
                    string consulta = "DELETE FROM items_game WHERE name = @NAME";
                    using (SqlCommand command = new SqlCommand(consulta, conexion))
                    {
                        command.Parameters.AddWithValue("@NAME", aux.Name);
                        cantidad = command.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
        }


        ///////////
        // Data  //
        ///////////

        /** Connection to de database. */
        private string db = ConfigurationManager.ConnectionStrings["HADAdatabase"].ToString();

       /** ItemEN to use in the database. */
        private ItemEN item;

        /** List of the Items that we have in the database. */
        private List<ItemEN> almacen;

        /** Number of Items that we have in the database. */
        private int items = 0;

    }
}
