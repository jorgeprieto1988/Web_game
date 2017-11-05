using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Configuration;


namespace ProjectHADA
{
    /**
    * This class represents the CAD (Componente de Acceso a Datos), 
    * DAC (Data Access Component) in English, of a character.
    */
    public class CharacterCAD
    {

        public CharacterCAD()
        {

        }

        /**
         * Create a new CAD from a character EN;
         * @param copy the character en 
         */
        public CharacterCAD (CharacterEN copy)
        {
            if (copy == null)
                throw new Exception("CharacterCAD::CharacterCAD(CharacterEN): The introduced character is NULL");
            else
                this.cen = copy;
		}

        /**
         * Obtain a character from the database.
         * @param name The name of the character that we want to obtain.
         * @return CharacterEN the character that we wanted to obtain
         */
        public CharacterEN getCharacter(string name_character) 
        {
           CharacterEN aux = null;
            
            using (SqlConnection conexion = new SqlConnection(db))
            {
                conexion.Open();
                string consulta = "SELECT * FROM character WHERE name = @NAME";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@NAME", name_character);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aux = new CharacterEN(reader["name"].ToString(), Convert.ToInt16(reader["race"].ToString()),reader["email"].ToString());
                            
                            aux.characterATK = Convert.ToInt16(reader["attack"].ToString());
                            aux.characterDEF = Convert.ToInt16(reader["defense"].ToString());
                            aux.characterHEALTH = Convert.ToInt16(reader["health"].ToString());
                            aux.characterEXP = Convert.ToInt16(reader["experience"].ToString());
                            aux.characterLVL = Convert.ToInt16(reader["level"].ToString());
                            aux.characterGold = Convert.ToInt16(reader["gold"].ToString());
                            aux.characterPoints = Convert.ToInt16(reader["points"].ToString());

                            // Para leer la mochila.
                            SqlConnection db_bag = new SqlConnection(db);
                            try
                            {
                                
                                string consulta1 = "select items_game.name, items_game.gold, items_game.extra_attack, items_game.extra_health, items_game.extra_defense from bag_character, items_game where bag_character.name_ch = @NAME and bag_character.name_it = items_game.name";
                                db_bag.Open();
                                SqlCommand com_bag = new SqlCommand(consulta1, db_bag);
                                com_bag.Parameters.AddWithValue("@NAME", aux.characterName);
                                SqlDataReader reader2 = com_bag.ExecuteReader();
                                while (reader2.Read())
                                {

                                    Item_Game item_aux = new Item_Game(Convert.ToDouble(reader2["gold"].ToString()), 0, "", reader["name"].ToString(), Convert.ToInt16(reader["extra_attack"].ToString()), Convert.ToInt16(reader["extra_defense"].ToString()), Convert.ToInt16(reader["extra_health"].ToString()));
                                    aux.characterBag.Add(item_aux);
                                }

                                reader2.Close();
                            }
                            catch (Exception ex) { /*mostrar error*/ }
                            finally
                            {
                                db_bag.Close();

                            }
                        }
                        reader.Close();
                    }
                }
                conexion.Close();
            }
            
            return aux;
        }


        /**
        * get the character in the BBDD by the email of an user!.
        * @param cen the CharacterEN
        */
        public CharacterEN getCharacter_byemail(string email)
        {
            CharacterEN aux = null;

            using (SqlConnection conexion = new SqlConnection(db))
            {
                conexion.Open();
                string consulta = "SELECT * FROM character WHERE email = @NAME";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@NAME", email);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aux = new CharacterEN(reader["name"].ToString(), Convert.ToInt16(reader["race"].ToString()), reader["email"].ToString());

                            aux.characterATK = Convert.ToInt16(reader["attack"].ToString());
                            aux.characterDEF = Convert.ToInt16(reader["defense"].ToString());
                            aux.characterHEALTH = Convert.ToInt16(reader["health"].ToString());
                            aux.characterEXP = Convert.ToInt16(reader["experience"].ToString());
                            aux.characterLVL = Convert.ToInt16(reader["level"].ToString());
                            aux.characterGold = Convert.ToInt16(reader["gold"].ToString());
                            aux.characterPoints = Convert.ToInt16(reader["points"].ToString());

                            // Para leer la mochila.
                            SqlConnection db_bag = new SqlConnection(db);
                            try
                            {
                                db_bag.Open();
                                SqlCommand com_bag = new SqlCommand("select item.name, item.description, items_game.gold, items_game.extra_atack, items_game.extra_health, items_game.extra_defense from bag_character, items_game, item where bag_character.name_ch = characteraux.characterName and bag_character.name_it = items_game.name and bag_character.name_it = item.name");
                                SqlDataReader reader2 = com_bag.ExecuteReader();
                                while (reader2.Read())
                                {

                                    Item_Game item_aux = new Item_Game(Convert.ToDouble(reader2["gold"].ToString()), 0, reader["description"].ToString(), reader["name"].ToString(), Convert.ToInt16(reader["extra_attack"].ToString()), Convert.ToInt16(reader["extra_defense"].ToString()), Convert.ToInt16(reader["extra_health"].ToString()));
                                    aux.characterBag.Add(item_aux);
                                }

                                reader2.Close();
                            }
                            catch (Exception ex) { /*mostrar error*/ }
                            finally
                            {
                                db_bag.Close();

                            }
                        }
                        reader.Close();
                    }
                }
                conexion.Close();
            }

            return aux;
        }


        /**
         * create the character in the BBDD.
         * @param cen the CharacterEN
         */
        public bool create_character(CharacterEN cen)
        {
            bool creado;
            int cantidad = 0;
            SqlConnection c = new SqlConnection(db);
            
            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("INSERT INTO character VALUES ('" + cen.characterName + "', " + cen.characterRace + ", " + cen.characterHEALTH + ", " + cen.characterATK + ", " + cen.characterDEF + ", " + cen.characterEXP + ", " + cen.characterLVL + ", " + cen.characterGold + ", " + cen.characterPoints + ", '" + cen.characterEmail + "');", c);
                cantidad = com.ExecuteNonQuery();
                
                if (cantidad > 0){
                    creado = true;
                }
                    
                else
                    creado = false;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally { c.Close(); }

            return creado;
        }

                
     
        /**
         * Delete the character from the data base and from the listcharacter
         * @param name the name of the character
         * this method is public because the admin can also delete characters
         */
        public bool delete_character(String name)
        {
            int cantidad = 0;

            using (SqlConnection conexion = new SqlConnection(db))
            {
                conexion.Open();
                string consulta = "DELETE FROM character WHERE name = " + name;
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@NAME", cen.characterName);
                    cantidad = command.ExecuteNonQuery();
                }
                conexion.Close();
            }

            return (cantidad > 0);
        }

        /**
        * This method show the ranking of the game
        * This method is public because it show the information shown by the mehod "character" to all people, users and viwers
        */
        public List<CharacterEN> ranking()
        {
            List<CharacterEN> listcharacter = new List<CharacterEN>();
            listcharacter = get_all_characters();

            int i, j, tamano;
            tamano = listcharacter.Count();
            for (i = 0; i < (tamano - 1); i++)
            {
                for (j = (i + 1); j < tamano; j++)
                {
                    if (listcharacter[i].characterLVL > listcharacter[j].characterLVL)
                    {
                        CharacterEN temp = listcharacter[i];
                        listcharacter[i] = listcharacter[j];
                        listcharacter[j] = temp;
                    }
                }
            }

            return listcharacter;
        }

        /**
         * This method show the 10 best characters of the game
         * This method is public because it show the information shown by the mehod "character" to all people, users and viwers
         */
        public List<CharacterEN> top_ten() 
        {
            List<CharacterEN> listcharacter = new List<CharacterEN>();
            listcharacter = ranking();

            List<CharacterEN> resultado = (List<CharacterEN>)listcharacter.Take(10);
            return resultado;
        }

        /**
         * Show all characters in the game
         * This method show the information shown by the mehod "character" to users and admin
         */
        public List<CharacterEN> get_all_characters() 
        {
            List<CharacterEN> listcharacter = new List<CharacterEN>();

            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("select * from character");
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    CharacterEN characteraux = new CharacterEN("", 0,"");
                    characteraux.characterName = dr.GetString(0);
                    characteraux.characterRace = dr.GetInt32(1);
                    characteraux.characterHEALTH = dr.GetInt32(2);
                    characteraux.characterATK = dr.GetInt32(3);
                    characteraux.characterDEF = dr.GetInt32(4);
                    characteraux.characterEXP = dr.GetInt32(5);
                    characteraux.characterLVL = dr.GetInt32(6);
                    characteraux.characterGold = dr.GetInt32(7);
                    characteraux.characterPoints = dr.GetInt32(8);
                    
                    // Para leer la mochila.
                    List<Item_Game> listitems = new List<Item_Game>();
                    SqlConnection db_bag = new SqlConnection("url, variable global");
                    try
                    {
                        db_bag.Open();
                        SqlCommand com_bag = new SqlCommand("select item.name, item.description, items_game.gold, items_game.extra_atack, items_game.extra_health, items_game.extra_defense from bag_character, items_game, item where bag_character.name_ch = characteraux.characterName and bag_character.name_it = items_game.name and bag_character.name_it = item.name");
                        SqlDataReader reader = com_bag.ExecuteReader();
                        while (reader.Read())
                        {

                            Item_Game item_aux = new Item_Game(Convert.ToDouble(reader["gold"].ToString()), 0, reader["description"].ToString(), reader["name"].ToString(), Convert.ToInt16(reader["extra_attack"].ToString()), Convert.ToInt16(reader["extra_defense"].ToString()), Convert.ToInt16(reader["extra_health"].ToString()));
                            listitems.Add(item_aux);
                        }

                        reader.Close();
                    }
                    catch (Exception ex) { /*mostrar error*/ }
                    finally
                    {
                        db_bag.Close();

                    }

                    listcharacter.Add(characteraux);
                }
                dr.Close();

            }
            catch (Exception ex) { /*mostrar error*/ }
            finally
            {
                c.Close();

            }
            return listcharacter;		
		}

        /**
         * This method update the attributes of the character in the database and in the listcharacters
         * @param cen the CharacterEn
         */
        public bool update_character(CharacterEN cen)
        {
            if (cen == null)
                throw new Exception("CharacterEN::update_character(): The character is Null");

            int cantidad = 0;

            using (SqlConnection conexion = new SqlConnection(db))
            {
                conexion.Open();
                string consulta = "UPDATE character SET name = @NAME, race = @RACE, health = @HEALTH, attack = @ATTACK, defense = @DEFENSE, experience = @EXPERIENCE, level = @LEVEL, gold = @GOLD, points = @POINTS WHERE name = @NAME";
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@NAME", cen.characterName);
                    command.Parameters.AddWithValue("@RACE", cen.characterRace);
                    command.Parameters.AddWithValue("@HEALTH", cen.characterHEALTH);
                    command.Parameters.AddWithValue("@ATTACK", cen.characterATK);
                    command.Parameters.AddWithValue("@DEFENSE", cen.characterDEF);
                    command.Parameters.AddWithValue("@EXPERIENCE", cen.characterEXP);
                    command.Parameters.AddWithValue("@LEVEL", cen.characterLVL);
                    command.Parameters.AddWithValue("@GOLD", cen.characterGold);
                    command.Parameters.AddWithValue("@POINTS", cen.characterPoints);
                    cantidad = command.ExecuteNonQuery();
                }
                conexion.Close();
            }

            return (cantidad > 0);
        }

        //Funcion que devuelve un personaje random (de Jorge)
        public CharacterEN getRandomCharacter(CharacterEN jugador)
        {
            List<CharacterEN> listcharacter = new List<CharacterEN>();

            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from character where level="+ jugador.characterLVL +" and name <> '"+ jugador.characterName+"';",c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    CharacterEN characteraux = new CharacterEN("", 0,"");
                    characteraux.characterName = dr.GetString(0);
                    characteraux.characterRace = dr.GetInt32(1);
                    characteraux.characterHEALTH = dr.GetInt32(2);
                    characteraux.characterATK = dr.GetInt32(3);
                    characteraux.characterDEF = dr.GetInt32(4);
                    characteraux.characterEXP = dr.GetInt32(5);
                    characteraux.characterLVL = dr.GetInt32(6);
                    characteraux.characterGold = dr.GetInt32(7);
                    characteraux.characterPoints = dr.GetInt32(8);

                    // Para leer la mochila.
                    List<Item_Game> listitems = new List<Item_Game>();
                    SqlConnection db_bag = new SqlConnection(db);
                    try
                    {
                        db_bag.Open();
                        SqlCommand com_bag = new SqlCommand("select item.name, item.description, items_game.gold, items_game.extra_atack, items_game.extra_health, items_game.extra_defense from bag_character, items_game, item where bag_character.name_ch = characteraux.characterName and bag_character.name_it = items_game.name and bag_character.name_it = item.name");
                        SqlDataReader reader = com_bag.ExecuteReader();
                        while (reader.Read())
                        {

                            Item_Game item_aux = new Item_Game(Convert.ToDouble(reader["gold"].ToString()), 0, reader["description"].ToString(), reader["name"].ToString(), Convert.ToInt16(reader["extra_attack"].ToString()), Convert.ToInt16(reader["extra_defense"].ToString()), Convert.ToInt16(reader["extra_health"].ToString()));
                            listitems.Add(item_aux);
                        }

                        reader.Close();
                    }
                    catch (Exception ex) { /*mostrar error*/ }
                    finally
                    {
                        db_bag.Close();

                    }

                    listcharacter.Add(characteraux);
                }
                dr.Close();

            }
            catch (Exception ex) { /*mostrar error*/ }
            finally
            {
                c.Close();

            }
            Random rndm = new Random();
            int num_char = listcharacter.Count() - 1;
            int random_index = rndm.Next(0, num_char);
            CharacterEN randomcharacter = new CharacterEN("", 0,"");
            randomcharacter = listcharacter[random_index];

            return randomcharacter;
        }


        ///////////
        // Data  //
        ///////////

        /** Connection to database */
        private string db = ConfigurationManager.ConnectionStrings["HADAdatabase_FINAL"].ToString();

        /** CharacterEN to use in the database. */
        private CharacterEN cen;

        /** List of the Characters that we have in the database. */
        private List<CharacterEN> listcharacters;

        /** Number of characters that we have in the database. */
        private int characters = 0;
    }
}