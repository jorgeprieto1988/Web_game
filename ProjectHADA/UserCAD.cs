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
using System.Web;


namespace ProjectHADA
{
    /**
     * This class represents the CAD (Componente de Acceso a Datos), 
     * DAC (Data Access Component) in English, of a user.
     */
    public class UserCAD {

       /**
        * Create a new CAD from an database file.
        * @param db the name of the database 
        */
        public UserCAD()
        {
            
        }
        /**
         * return a CharacterEN
         * @param UserEN name of the user
         */
        public CharacterEN getCharacter(UserPlayer usuario)
        {
            return usuario.playerCharacter;
        }
        public bool getLogin(string nickname, string password)
        {   
            //String for getting the email of the user.
            string email = "";

            //We stablish the connexion.
            SqlConnection c = new SqlConnection(db);

            try
            {
                // Opening the connection
                c.Open();

                //We build the SQL command.
                SqlCommand com = new SqlCommand("Select * from usuarios where nick_name ='" + nickname + "' and password='"+password+"'", c);

                //Executing the SQL command.
                SqlDataReader dr = com.ExecuteReader();

                //Getting the email.
                while (dr.Read())
                {
                    email = dr["email"].ToString();
                }
                
                //Closing the DataReader.
                dr.Close();


                if (email.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                c.Close();
            }
        }

        /**
         * Obtain a user from the database.
         * @param nickname The nickname of the user that we want to obtain.
         * @return usuarioADevolver User that we wanted to obtain.
         */
        public UserPlayer getUser(string nickname)
        {
            string email = "";

            //Stablishing the connection.
            SqlConnection c = new SqlConnection(db);

            //Player that we are going to return.
            UserPlayer player = null;

            try
            {
                // Opening the connection
                c.Open();

                //Building the command for searching all the friends
                SqlCommand com = new SqlCommand("select * from usuarios where nick_name ='" + nickname + "'", c);

                //Once we have built the command, we have to read the select.
                SqlDataReader dr = com.ExecuteReader();

                //Variable for storing the Primary Key.
                while (dr.Read())
                {
                    email = dr["email"].ToString();
                }

                //Closing the DataReader.
                dr.Close();

                bool encontrado = false;

                //Once we have the email of the user/player, we have to search it in the List<UserPlayer> and return it.
                for (int i = 0; i <= listplayers.Count && !encontrado; i++)
                {
                    if (listplayers[i].userEmail == email)
                    {
                        encontrado = true;
                        player = listplayers[i];
                    }
                }

                //Getting the character
                CharacterEN aux = new CharacterEN().get_character_byemail(player.userEmail);
                player.playerCharacter = aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }

            return player;
        }

        /**
         * Update the information of a user from the database.
         * @param user The user that we want to update.
         */
        public void actualizarUsuario(UserPlayer user)
        {
            //We stablish the connection.
            SqlConnection c = new SqlConnection(db);

            try
            {
                // Opening the connection
                c.Open();

                //Building the update sql command
                SqlCommand com = new SqlCommand("update usuarios set password = '" + user.userPassword + "' where email = '" + user.userEmail + "'", c);

                //Executing the command
                int executed = com.ExecuteNonQuery();

                //If it has been updated....
                if (executed >= 0)
                {
                    //We obtain the object user from the list.
                    int index = listplayers.IndexOf(user);

                    //Once we have the index of that object, we modify its password.
                    listplayers[index].userPassword = user.userPassword;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                c.Close();
            }
        }

        /**
         * Insert a new user in the database.
         * @param user The user that we want to insert.
         */
        public int registrarUsuario(UserEN user){                   
            //We stablish the connection.
            SqlConnection c = new SqlConnection(db);

            //Variable for knowing if we had registered the user.
            int cantidad = 0;

            try{
                //Opening the connection.
                c.Open();

                //Building the insert sql command.
                SqlCommand com = new SqlCommand("INSERT INTO usuarios VALUES ('" + user.userEmail + "', '" + user.userNickName + "', '" + user.userPassword + "')", c);

                //Executing the sql command
                cantidad = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + " filas afectadas: " + cantidad); //Response.WriteLine
            }
            finally 
            {
                Console.WriteLine(cantidad);
                c.Close(); 
            }

            return cantidad;
        }

        /**
         * Insert a new player in the database.
         * @param user The user that we want to insert.
         */
        public int registrarPlayer(UserPlayer player){
            //Variable for knowing if we have inserted the user.
            int cantidad = 0;

            //We stablish the connection.
            SqlConnection c = new SqlConnection(db);

            try{
                //Opening the connection.
                c.Open();

                //Building the insert sql command.
                SqlCommand com = new SqlCommand("INSERT INTO player VALUES ('" + player.userEmail + "', " + player.playerGems + ", " + player.playerBanned_times + ")", c);

                //Executing the sql command
                cantidad = com.ExecuteNonQuery();

                //If we have registered the user, then add it to the list of players.
                if (cantidad >= 0){
                    listplayers.Add(player);
                    players++;
                }
            } catch (Exception ex){
                throw ex;
            } finally{
                c.Close();
            }

            return cantidad;
        }

        /**
         * Method for obtaining the number of players.
         */
        public int numberOfPlayers()
        {
            return players;
        }

        /**
         * Delete a user from the database.
         * @param user The user that we want to delete.
         */
        public void deleteUser(UserEN user)
        {
            // db = ConfigurationManager.ConnectionStrings["ConnectionString2"].ToString();
            int cantidad = 0;

            //We stablish the connection
            SqlConnection c = new SqlConnection(db);
            
            try
            {
                //Opening the connection
                c.Open();

                //Building the delete sql command for deleting the user of the usuarios table.
                SqlCommand com = new SqlCommand("delete from usuarios where email = '" + user.userEmail + "'", c);
            
                //Executing the sql command
                cantidad = com.ExecuteNonQuery();

                //Building the delete sql command for deleting the user of the player table.
                SqlCommand com1 = new SqlCommand("delete from player where email = '" + user.userEmail + "'", c);
                com1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + " filas afectadas: " + cantidad);
            }
            finally 
            {
                c.Close();
            }
        }

        /**
         * Delete a character from the database.
         * @param name the name of the character.
         */
        public void deleteCharacter(String email)
        {
            // db = ConfigurationManager.ConnectionStrings["ConnectionString2"].ToString();
            int cantidad = 0;

            //We stablish the connection
            SqlConnection c = new SqlConnection(db);

            try
            {
                //Opening the connection
                c.Open();

                //Building the delete sql command for deleting the user of the player table.
                SqlCommand com1 = new SqlCommand("delete from player where email = '" + email + "'", c);
                com1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + " filas afectadas: " + cantidad);
            }
            finally
            {
                c.Close();
            }
        }

        public DataSet listarAmigosCAD(string email1){
            //DataSet which is going to fullfill the GridView Friendlist.
            DataSet bdvirtual = new DataSet();

            //Stablishing the connection
            SqlConnection c = new SqlConnection(db);

            try
            {
                //Opening the connection.
                c.Open();

                //SqlDataAdaptar for fullfilling the bdvirtual.
                SqlDataAdapter da = new SqlDataAdapter("select email2 from is_friend_of where email1 = '" + email1 + "'", c);

                da.Fill(bdvirtual, "is_friend_of");

                return bdvirtual;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

        /**
         * Method for fullfilling the list of players.
         */
        public void fillingListPlayers()
        {
            //Stablishing the connection.
            SqlConnection c = new SqlConnection(db);

            try
            {
                //Opening the connection.
                c.Open();

                //Building the select SQL command
                SqlCommand com = new SqlCommand("select player.email, usuarios.nick_name, usuarios.password, player.gems, player.banned_times from usuarios, player where usuarios.email = player.email", c);

                //Executing the SQL statement.
                SqlDataReader dr = com.ExecuteReader();

                //Fullfilling the list of players.
                while (dr.Read())
                {
                    //Properties of the user.
                    UserPlayer auxPlayer = new UserPlayer(dr["email"].ToString(), dr["nick_name"].ToString(), dr["password"].ToString());

                    auxPlayer.playerGems = Convert.ToInt32(dr["gems"].ToString());
                    auxPlayer.playerBanned_times = Convert.ToInt32(dr["banned_times"].ToString());

                    listplayers.Add(auxPlayer);
                }

                dr.Close();

                //Once we have all the players in the List<UserPlayers>, we have to complete 
                //the list of friends of each player.
                for (int i = 0; i < listplayers.Count; i++)
                {
                    SqlCommand com1 = new SqlCommand("select * from is_friend_of where email1 = '" + listplayers[i].userEmail + "'", c);
                    SqlDataReader dr1 = com1.ExecuteReader();

                    while (dr1.Read())
                    {
                        listplayers[i].playerFriends.Add(dr1["email2"].ToString());
                    }

                    dr1.Close();
                }

                //Once we have the friends, we have to recover now the CharacterEN of the players.
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

	 /**
         * Add a friend to the player's friend list.
         * @param user The user that has a new friend.
         * @param nickname The nickname of the new friend of the user.
         */
        public bool addFriend(UserPlayer user, string emailAagregar)
        {
           //Variable for knowing if we have added a friend.
            bool added = false;

            //Variables auxiliares
            string emailEncontrado = "";
            int cantidadModificada = 0;

            //First, we have to check if it is in the database.
            bool esta = false;

            //Stablishin the connection.
            SqlConnection c = new SqlConnection(db);

            try
            {
                //Opening the connection.
                c.Open();

                //Command for searching the user.
                SqlCommand com = new SqlCommand("SELECT * FROM player WHERE email = '" + emailAagregar + "'", c);

                //Executing the command
                SqlDataReader dr = com.ExecuteReader();

                //Leyendo...
                while(dr.Read()){
                    emailEncontrado = dr["email"].ToString();
                }

                dr.Close();

                //Si lo encontramos...
                if(emailEncontrado != ""){
                    esta = true;
                }

                //Lo anyadimos...
                if(esta){
                    //Building the command.
                    SqlCommand com1 = new SqlCommand("INSERT INTO is_friend_of VALUES('" + user.userEmail + "', '" + emailAagregar + "')", c);
                   cantidadModificada = com1.ExecuteNonQuery();

                    if(cantidadModificada > 0){
                        added = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }

            return added;
        }

        /**
        * Delete a friend to the player's friend list.
        * @param user The user that has a new friend.
        * @param nickname The nickname of the new friend of the user.
        */
        public bool deleteFriend(UserPlayer user, string email)
        {
            //Variable for knowing if we have could delete.
            bool deleted = false;

            //We stablish the connection
            SqlConnection c = new SqlConnection(db);
            try
            {
                //Opening the connection
                c.Open();

                //Building the delete sql command
                SqlCommand com = new SqlCommand("delete from is_friend_of where email1 = '" + user.userEmail + "' and email2 = '" + email + "'", c);

                //Executing the sql command
                int numberOfDelete = com.ExecuteNonQuery(); 
                
                if (numberOfDelete > 0)
                {
                    deleted = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }

            return deleted;
        }
		
        /**
         * Method for increasing the number of gems.
         * @param usuario User to who we want to increase its gems.
         * @param numberOfGems Number of gems that we want to give to the user.
         */
        public void incrementarGemasUsuario(UserPlayer usuario, int numberOfGems)
        {
            //We stablish the connection.
            SqlConnection c = new SqlConnection(db);

            try
            {
                // Opening the connection
                c.Open();

                //Building the update sql command
                SqlCommand com = new SqlCommand("update player set gems = " + numberOfGems + " where email = '" + usuario.userEmail + "'", c);

                //Executing the command
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

        /**
         * Method for getting the friend list.
         * @param nickname Name of the user.
         */ 
        public List<string> getListaAmigos(string nickname)
        {
            //We stablish the connexion.
            SqlConnection c = new SqlConnection(db);

            //Variable which stores the list of friends at the end of the method.
            List<string> listaDeAmigos = new List<string>();

            try
            {
                // Opening the connection
                c.Open();

                //Building the command for searching all the friends
                SqlCommand com = new SqlCommand("select * from is_friend_of where email1 ='" + nickname + "'", c);

                //Once we have built the command, we have to read the select.
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    listaDeAmigos.Add(dr["email2"].ToString());
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }

            return listaDeAmigos;
        }

		/**
		* Insert the new purchase that the player has done.
		* @param user The user that has done the purchase.
		* @param gems Quantity of gems that the user has bought.
		*/
		public void insertNewPurchase(UserPlayer user, int gems){
            SqlConnection conexion = new SqlConnection(db);

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO player VALUES(@EMAIL,@GEMS,@BANS)", conexion);
                command.Parameters.AddWithValue("@EMAIL", user.userEmail);
                command.Parameters.AddWithValue("@GEMS", gems);
                command.Parameters.AddWithValue("@BANS", user.playerBanned_times);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                conexion.Close();
            }
		}
		
		/**
		* Update a purchase that has been done before.
		* @param user The user that has done the purchase.
		*/
		public void updateThePurchase(UserPlayer user){
		
		}

        /**
         * Search if the purchase exist in the list purchases
         * @param purchase The purchase to find
         * @return bool
         * If the purchuase exist, return true, else, return false
         */
        public bool searchingThePurchase(string purchase)
        {
            return true;
        }

        ///////////
        // Data  //
        ///////////

        /** Connection to de database. */
        private string db = ConfigurationManager.ConnectionStrings["HADAdatabase_FINAL"].ToString();

        /** UserEN to use in the database. */
        private UserEN useren;

        /** List of the players that we have in the database. */
        public static List<UserPlayer> listplayers = new List<UserPlayer>();

        /** List of the admins that we have in the database. */
        private List<UserAdmin> listadmins;

        /** Number of players that we have in the database. */
        private int players = 0;

        /** Number of admins that we have in the database. */
        private int admins = 0;
		
		/** Array which contains in each position a string that describes a purchase.*/
		private List<string> purchases; 
    }
}
