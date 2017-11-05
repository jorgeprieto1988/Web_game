using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace ProjectHADA
{
    /**
     * This class represents the EN (Entidad de Negocio), BE (Bussiness Entity) 
     * in English, of a character.
     */
    public class CharacterEN
    {
        /**
         * PRIVATE
         */

      

        /** Name of the character */
        private string name;

        /** Race of the character */
        private int race;

        /** Strength of the character */
        private int ATK;

        /** Defense of the character */
        private int DEF;

        /** Health points of the character */
        private int HEALTH;

        /** Experience of the character */
        private int EXP;

        /** Level of the character */
        private int LVL;

        /** Money of the character */
        private double gold;

        /** Bag of the character */
        private List<Item_Game> bagCharacter;

        /** Points to update attributes */
        private int points;

        /** CharacterCad */
        private CharacterCAD c_cad;

        /** ItemCad */
        private ItemCAD item_aux;

        /** email of the user */
        private String email;


        /**
        * PROPERTIES OF THE CLASS
        * Getters and setters for all the attributes
        */

        /**
         * Property to set and get the name attribute.
         */
        public string characterName
        {
            get { return this.name; }
            set { name = value; }
        }

        //EMAIL
        public String characterEmail
        {
            get { return this.email; }
            set { email = value; }
        }

        /**
         * Property to set and get the race attribute.
         */
        public int characterRace
        {
            get { return this.race; }
            set { race = value; }
        }

        /**
         * Property to set and get the ATK attribute.
         */
        public int characterATK
        {
            get { return this.ATK; }
            set { ATK = value; }
        }

        /**
         * Property to set and get the DEF attribute.
         */
        public int characterDEF
        {
            get { return this.DEF; }
            set { DEF = value; }
        }

        /**
         * Property to set and get the HEALTH attribute.
         */
        public int characterHEALTH
        {
            get { return this.HEALTH; }
            set { HEALTH = value; }
        }

        /**
         * Property to set and get the EXP attribute.
         */
        public int characterEXP
        {
            get { return this.EXP; }
            set { EXP = value; }
        }

        /**
         * Property to set and get the LVL attribute.
         */
        public int characterLVL
        {
            get { return this.LVL; }
            set { LVL = value; }
        }

        /**
         * Property to set and get the gold attribute.
         */
        public double characterGold
        {
            get { return this.gold; }
            set { gold = value; }
        }

        /**
         * Property to set and get the bagCharacter attribute.
         */
        public List<Item_Game> characterBag 
        {
            get { return bagCharacter; }
            set { bagCharacter = value;  }
        }

        /**
         * Property to set and get the points attribute
         */
        public int characterPoints
        {
            get { return points; }
            set { points = value; }
        }



        /**
         * METHODS OF THE CHARACTER
         */
        

        /**
         * Parameterized constructor.
         * @param name The name of the character
         * @param race The race of the character
         * create a new Character
         */
        public CharacterEN(string name, int race,string email) 
        {
            this.name = name;
            this.race = race;
            this.atributes(race);
            this.email = email;
            gold = 0;
            EXP = 0;
            LVL = 1;

        }

        public CharacterEN()
        {
            // TODO: Complete member initialization
        }

        /**
         * Inicialize the attributes if the character
         * @param race The race of the character
         * Depending the race of the character, the initial attributes changes
         */
        public void atributes(int race)
        {
           //if (race == "Dark elf") {
            if(race == 1) {
                this.ATK = 30;
                this.DEF = 1;
                this.HEALTH = 29;
            }

           //else if (race == "Human") {
            else if(race == 2) {
                this.ATK = 20;
                this.DEF = 10;
                this.HEALTH = 30;
            }
                
            //else if (race == "Orc") {
            else if (race == 3) {
                this.ATK = 22;
                this.DEF = 8;
                this.HEALTH = 30;
            }

            //else if (race == "Dwarf") {
            else if (race == 4) {
                this.ATK = 15;
                this.DEF = 15;
                this.HEALTH = 30;
            }

            //else if (race == "Elf") {
            else if (race == 5)
            {
                this.ATK = 30;
                this.DEF = 5;
                this.HEALTH = 25;
            }
       }

        /**
         * Insert a charcter in the database
         */
        public void insert_character()
        {
            try
            {
                c_cad = new CharacterCAD();
                c_cad.create_character(this);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error creando CharacterCad : %s ", error.Message);
                return;
            }
        }

        /**
         * Delete a character from the database
         */
        public void delete_character()
        {
            try
            {
                c_cad = new CharacterCAD();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error creando CharacterCAD : %s", error.Message);
                return;
            }

            c_cad.delete_character(this.name);
        }

        /**
         * Update a character in the database
         */
        public void update_character()
        {
            try
            {
                c_cad = new CharacterCAD(this);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error creando CharacterCAD : %s", error.Message);
                return;
            }

            c_cad.update_character(this);
        }

        /**
         * Get a character from the database
         */
        public CharacterEN get_character(string name_character)
        {
            try
            {
                c_cad = new CharacterCAD(this);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error creando CharacterCAD : %s", error.Message);
            }

            CharacterEN devolver = c_cad.getCharacter(name_character);

            return devolver;

        }

        /**
        * Get a character from the database
        */
        public CharacterEN get_character_byemail(string email)
        {
            try
            {
                c_cad = new CharacterCAD(this);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error creando CharacterCAD : %s", error.Message);
            }

            CharacterEN devolver = c_cad.getCharacter_byemail(email);

            return devolver;

        }


        public CharacterEN get_character_random(CharacterEN player)
        {
            try
            {
                c_cad = new CharacterCAD(this);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error creando CharacterCAD : %s", error.Message);
            }

            CharacterEN devolver = c_cad.getRandomCharacter(player);

            return devolver;

        }

        /**
         * Increase the atack of the character in 1 point;
         */
        public void increase_ATK()
        {
            this.ATK++;
            update_character();
        }

        /**
         * Increase the defense of the character in 1 point;
         */
        public void increase_DEF()
        {
            this.DEF++;
            update_character();
        }

        /**
         * Increase the maximum health of the character in 1 point;
         */
        public void increase_HEALTH()
        {
            this.HEALTH++;
            update_character();
        }

        /**
         * Increase the level of the character in 1 point;
         */
        public void increase_LVL() 
        {
                this.LVL++;
                update_character();
        }

        /**
         * Increase the experience of the character
         * @param incremento the increase of experience
         * if we have more than 100 points of experience, increaseLvL, and reduce the experience in 100 points
         */
        public void increase_EXP(int i)
        {
            EXP = EXP + i;

            if (EXP > 100) {
                this.increase_LVL();
                EXP = EXP - 100;
            }

            update_character();
        }


        /**
         * Increase the gold of the character
         * @param incremento The increase of gold
         */
        public void increase_Gold(double i)
        {
            gold = gold + i;
            update_character();
        }

        /**
         * Decrease the gold of the character
         * @param reduccion The decrease of gold
         */
        public void decrease_Gold(double i)
        {
            if (i <= gold)
                gold = gold - i;
            else
            {
               Console.WriteLine("No enough gold");
            }

            update_character();
        }

        /**
         * Increase the availabel points
         */
        public void increase_points()
        {
            this.points++;
            update_character();
        }

        /**
         * Decrease the available points
         */
        public void decrease_points()
        {
            if(points>0)
                this.points--;
            else
                Console.WriteLine("Error, no available points");

            update_character();

        }

        /*
         * return the basic attributes of the character as string
         * @return s the basic attributes into string
         * this string is use to show attributes to viewers(non-registred) and other players that want tofight with you
         */
        public string tolowString() 
        {
            string s;
            
            s =  name + " LVL " + LVL + "\n";
            s += "Race : " + race + "\n";
            
            return s;
        }

        /**
         * return all attributes of the character as string
         * @return s the character convert into string
         * this string is use to show attributes to the user and admin
         */
        public string toallString()
        {
            string s;

            s  = "Name : " + name + "\n";
            s += "Race : " + race + "\n";
            s += "LVL : " + LVL + "\n";
            s += "Experience : " + EXP + "\n";
            s += "ATK : " + ATK + "\n";
            s += "DEF: " + DEF + "\n";
            s += "HEALTH :" + HEALTH + "\n";
            
            return s;
        }

        /**
         *Buy an item from the Shop
         *@param item the Item_game that you want to buy
         *this method add the item to de bag, decrease the availabe gold and decrease the stock attribute of the item. If you already have the item, the program stop and write the message
         */
        public void buy_item(Item_Game item)
        {
            
            decrease_Gold(item.Gold);
            
            bagCharacter.Add(item);
            update_stats(item, 1);
            update_character();

            try
            {
                c_cad = new CharacterCAD(this);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error creando CharacterCAD : %s", error.Message);
                return;
            }

            string done = name + " buys " + item.Name;

           // c_cad.update_buys2(this.name, item.Name, done); // Se ha borrado el metodo update_buys2 de CharacterCAD

            item.decreaseStock();
            
        }
        /**
         * Sell the item
         * @param item the Item_Game to sell
         * remove the item to the bagcharacter and increase gold (70% of the true value of the item)
         */
        public void sell_item(Item_Game item) 
        {
            double aux = 70 * item.Gold / 100;
            
            increase_Gold(aux);

            bagCharacter.Remove(item);
            update_stats(item, 2);
            update_character();

            try
            {
                item_aux = new ItemCAD(item);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error vendiendo item : %s", error.Message);
                return;
            }
            
            if (item_aux.getItem(item.Name) != null)
            {
                item.increaseStock(1);
            }

        }

        /**
         * Update the stats of the character
         * @param item the item that we buy or sell
         * @param x to know if we buy or sell a item
         * if x==1 then we buy and item and we need to increase our attributes, else decrease it
         * Update the stats of the player and call update_character() to update the database
         */
        public void update_stats(Item_Game item, int x)
        {
            if (x == 1) 
            {
                ATK += item.extra_Attack;
                DEF += item.extra_Defense;
                HEALTH += item.extra_Health; 
            }

            else
            {
                ATK -= item.extra_Attack;
                DEF -= item.extra_Defense;
                HEALTH -= item.extra_Health;
            }    
            
        }


        public DataSet ListCharacters()
        {
            DataSet bdvirtual = new DataSet();
            try
            {
                
                SqlConnection c = new SqlConnection(sql);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM character", c);
                da.Fill(bdvirtual, "character");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creando base de datos virtual ::CharacterEN::ListCharacters : %s", ex.Message);
                
            }
            return bdvirtual;
        }
        /** Connection to database */
        private string sql = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\ConnectionString2;User Instance=true";

    }
}
