using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Data;

namespace ProjectHADA {

    /**
     * This class represents the EN (Entidad de Negocio), BE (Bussiness Entity) 
     * in English, of a user.
     */
    public abstract class UserEN {
        /**
         * ATTRIBUTES OF THE CLASS
         */

        /** User's email. */
        protected string email;

        /** User's nickname. */
        protected string nick_name;

        /** User's password. */
        protected string password;

        /** Variable to store the data in the database. */
        protected UserCAD user_cad;

        /**
         * PROPERTIES OF THE CLASS
         * Getters and setters for all the attributes
         */

        /**
         * Property  to set and get the email attribute. 
         */
        public string userEmail {
            get { return this.email; }
            set { email = value;}
        }

        /**
         * Property to set and get the nick_name attribute.
         */
        public string userNickName {
            get { return this.nick_name; }
            set { nick_name = value; }
        }

        /**
         * Property to set and get the password attribute. 
         */
        public string userPassword {
            get { return this.password; }
            set { password = value; }
        }

        /**
         * Parameterized constructor.
         * @param email Email of the user.
         * @param nickname Nickname of the user.
         * @param password Password of the user.
         */
        public UserEN(string email = "", string nickname = "", string password = "") {
            this.email = email;
            this.nick_name = nickname;
            this.password = password;
            user_cad = new UserCAD();
        }

        /*
         * Method for getting the login 
         * @param name Name of the user
         * @param password Password of the user.
         */
        public bool get_login(string name, string password)
        {
            //We create a new user
            bool devolver = false;

            try
            {
                //We create the CAD in order to stablish a connection with the database.
                user_cad = new UserCAD();

                //Getting the information of the user.
                devolver = user_cad.getLogin(name, password);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error creando CharacterCAD : %s", error.Message);
            }

            return devolver;
        }

        public CharacterEN getCharacter(UserPlayer user)
        {
            CharacterEN aux = null;
            try
            {
                user_cad = new UserCAD();
                aux = user_cad.getCharacter(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return aux;
        }

        /** 
         * METHODS OF THE USER
         */

        /**
         * Insert a user in the database.
         */
        public void create_user(){
            try{
                //We create the CAD in order to obtain a connection with the database.
                user_cad = new UserCAD();

                //Once we have opened the connection, we are going to register the user.
                user_cad.registrarUsuario(this);
            }
            catch (Exception error){
                Console.WriteLine(error.Message);
            }
        }

        /**
         * Delete a user from the database.
         */
        public void delete_user(){
            try{
                //We create a CAD in order to stablish the connection with the database.
                user_cad = new UserCAD();

                //Once we have opened the connection, we are going to delete the user from the DB.
                user_cad.deleteUser(this);
            }
            catch (Exception error){
                Console.WriteLine(error.Message);
            }
        }
		
		/**
		 * Method for sending a message to another user.
		 *@param receptor User who is going to receive the message.
		 *@param subject Topic that the player want to talk about.
		 *@param body The content of the message that we want to send.
		 */
		 public void send_A_Message (UserEN receptor, string subject, string body){
			SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);
			MailMessage message = new MailMessage();
			try
			{
				MailAddress fromAddress = new MailAddress(this.email, this.nick_name);
				MailAddress toAddress = new MailAddress(receptor.email, receptor.nick_name);
				message.From = fromAddress;
				message.To.Add(toAddress);
				message.Subject = subject;
				message.Body = body;
				smtpClient.EnableSsl = true;
				smtpClient.Credentials = new System.Net.NetworkCredential(this.email, this.password);
				smtpClient.Send(message);
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR: The message cannot be sent" + ex.Message);
			}
		 }

        /**
         * Convert all the attributes in a string in order to print they if it is 
         * necessary.
         * It is abstract because not all the users has the same attributes 
         * (players has more attributes than admins).
         */
        public abstract string toString();
    }

    /**
     * This class represents the EN (Entidad de Negocio), BE (Bussiness Entity) 
     * in English, of an admin user of the web.
     */
    public class UserAdmin : UserEN {

        /**
         * Parameterized constructor.
         * @param email Email of the user.
         * @param nickname Nickname of the user.
         * @param password Password of the user.
         */
        public UserAdmin(string email, string nickname, string password) : base(email, nickname, password) {}

        /**
         * Ban a player.
         * @param player This represents the player we want to ban.
         */
        public void ban(UserPlayer player)
        {
            player.playerBanned_times++;
            if (player.playerBanned_times < 5)
            {
                player.playerCharacter.decrease_Gold(100 * player.playerBanned_times);
               // user_cad.updateUser(player);
            } else{
				player.delete_player();
			}
        }

        /**
         * Convert all the attributes in a string in order to print they 
         * if it is necessary.
         */
        public override string toString()
        {
            string result;

            result = "Email: " + email + "\nNickname: " + nick_name; 
            result = result + "\nPassword: " + password + "\n";

            return result;
        }
    }


    /**
     * This class represents the EN (Entidad de Negocio), BE (Bussiness Entity) 
     * in English, of a player user of the web.
     */
    public class UserPlayer : UserEN {
        /** ATTRIBUTES OF THE USERPLAYER*/
        
        /** Player's gems. */
        private int gems;

        /** Character of the player. */
        private CharacterEN character;

        /** Times that the user has been banned. */
        private int banned_times;

        /** List of friends of the user. */
        private List<string> friends;


        /** PROPERTIES OF THE USERPLAYER*/

        /**
         * Property to set and get the gems of the player.
         */
        public int playerGems {
            get { return this.gems; }
            set { gems = value; }
        }

        /**
         * Property to set and get the times that the user has been banned.
         */
        public int playerBanned_times
        {
            get { return this.banned_times; }
            set { banned_times = value; }
        }

        /**
         * Property to set and get the character of the player.
         */
        public CharacterEN playerCharacter
        {
            get { return this.character; }
            set { character = value; }
        }

        /**
         * Property to set and get the list of friends of the player.
         */
        public List<string> playerFriends
        {
            get { return friends; }
            set { friends = value; }
        }

        /**
         * Parameterized cosntructor.
         * @param email Email of the player.
         * @param nickname Nickname of the player.
         * @param password Password of the player.
         */
        public UserPlayer(string email, string nickname, string password) : base(email, nickname, password) 
        {
            gems = 0;
            character = null;
            friends = new List<string>();
        }

        /**
         * Method for registering a player. 
         */
                /**
         * Insert a user in the database.
         */
        public int create_player(){
            //Variable for knowing if the player has been created or not.
            int cantidad = 0;

            try{
                //We create the CAD in order to obtain a connection with the database.
                user_cad = new UserCAD();

                //We store if it is possible to create the player or not.
                cantidad = user_cad.registrarUsuario(this);
                
                //Once we have opened the connection, we are going to register the user.
                user_cad.registrarPlayer(this);
            }
            catch (Exception error){
                Console.WriteLine(error.Message);
            }

            return cantidad;
        }
        /**
         * Method for converting gems to gold.
         * @param gems_to_convert Number of gems that the player want to turn into gold.
         */
        public void convert_gems_to_gold(int gems_to_convert)
        {
            if (playerGems >= gems_to_convert)
            {
                int gold_converted = gems_to_convert * 1000;
                playerGems = playerGems - gems_to_convert;
                (playerCharacter).increase_Gold(gold_converted);
            }
            else
            {
                Console.WriteLine("Error: you do not have enough gems.");
            }
        }

        public DataSet listarAmigosEN(string email1)
        {
            DataSet d = user_cad.listarAmigosCAD(email1);
            return d;
        }

        /**
         * Method for deleting a character from the database and from the user.
         */
        public void delete_character()
        {
            //Checking that there is a character
			if(playerCharacter != null){
                //If it is a character, then delete it.
				(playerCharacter).delete_character();

                //Setting the character as null.
				playerCharacter = null;

                //If there is no character...
			} else{
				Console.WriteLine("There is no character to delete.");
			}
        }

        /**
         *  Method for deleting a player from the database.
         */
        public void delete_player()
        {
            //Deleting player.
            user_cad.deleteUser(this);
        }

        /**
         * Method for adding a player to the database.
         * @param nickname The nickname of the new friend of the user.
         */
        public bool add_friend(string email)
        {
            //Variable for knowing if we have added the friend.
            bool added = false;

            //CAD for stablishing the connection.
            UserCAD user_cad = new UserCAD();

            //Adding the friend.
            added = user_cad.addFriend(this, email);

            if (added)
            {
                friends.Add(email);
            }

            return added;
        }

        /**
         * Method for deleting a player to the database.
         * @param nickname The nickname of the new friend of the user.
         */
        public bool delete_friend(string emailDelQueQueremosBorrar)
        {
            //Variable for knowing if the friend has been deleted.
            bool deleted = false;

            //Searching the user in case it is in the list friend.
            int index = friends.IndexOf(emailDelQueQueremosBorrar);

            //If it is in the friend list, then delete it...
            if (index > -1)
            {
                //Deleting from the list
                friends.RemoveAt(index);

                //Deleting from the DB
                deleted = user_cad.deleteFriend(this, emailDelQueQueremosBorrar);
            }

            return deleted;
        }

		/**
		 * Method for buying/obtaining gems from the real shop.
		 * @param gems_To_Buy the gems that we wanted to buy
		 */
		 public void buyings_Gems(int gems_To_Buy){
			//Increase the gems of the user.
			playerGems = playerGems + gems_To_Buy;
			
			//Update the database with the new information.
			user_cad.incrementarGemasUsuario(this, playerGems);
		 }
		
        /**
         * Convert all the attributes in a string in order to print they 
         * if it is necessary.
         */
        public override string toString()
        {
            string result;

            result = "Email: " + email + "\nNickname: " + nick_name;
            result = result + "\nPassword: " + password + "\nGems: " + gems;
            result = result + "\nBanned times: " + banned_times + "\n";
            
            return result;
        }      
    }
}
