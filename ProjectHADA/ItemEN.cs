using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHADA
{
    /**
     * This class represents the EN (Entidad de Negocio), BE (Bussiness Entity)
     * in English, of a Item.
     * 
     */
    public abstract class ItemEN
    {
        /** Name of the item*/
        protected string name;

        /** Description of the item*/
        protected string description;

        protected ItemCAD ic;

        /**
         * Parameterized constructor.
         * @param name Name of the item.
         * @param description Description of the item.
         */
        public ItemEN(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        /**Getters and setters*/
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /**
         * This method will insert a new Item in the database
         */
        public void insertBD()
        {
            try
            {
                ic = new ItemCAD(this);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            ic.insert_Item(this);
        }
        /**
         * This method will delete an item from the database
         */
        public void deleteBD()
        {
            try
            {
                ic = new ItemCAD(this);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            ic.delete_Item(this);
        }

        /**
         * This method will update an item at the database
         */
        public void updateBD()
        {
            try
            {
                ic = new ItemCAD(this);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            ic.update_Item(this);
        }
        /** Depending on the type of the item this will return the item as a string*/
        public abstract string toString();
    }
    /**
     * This class represents the EN (Entidad de Negocio), BE (Bussiness Entity)
     * in English, of a Item_life.
     * An Item_life is a item that will be purchased outside the game(gems, skins, etc).
     */
    public class Item_life : ItemEN
    {
        /** Price in euros of the item*/
        private double euros;

        
        /**
         * Parametrized Constructor
         * @param euros Price in euros of the item
         * @param description Description of the item
         * @param name Name of the item
         */
        public Item_life(double euros, string description, string name)
            : base(name, description)           // Calls the base constructor ItemEN
        {
            this.euros = euros;
        }
        /**Getters and setters*/
        public double Euros
        {
            get { return this.euros; }
            set { this.euros = value; }
        }

        /**
         * This will return the Item_life as a String
         */
        public override string toString()
        {
            string str = "";
            str += "Name: " + this.name + "\n";
            str += "Description: " + this.description + "\n";
            str += "Euros: " + this.euros + "\n";
            return str;
        }

        public void insertBagItem(string p)
        {

        }
    }
    /**
     * This class represents the EN (Entidad de Negocio), BE (Bussiness Entity)
     * in English, of a Item_Game.
     * An Item_Game is an item that can be purchased in game.
     */
    public class Item_Game : ItemEN
    {
        /** Price in gold of the item*/
        private double gold;

        /** Stock of the item*/
        private int stock;

        /**
         * Improvement attributes that the item will give
         */
        private int extra_attack;
        private int extra_health;
        private int extra_defense;

        /**
         * Parametrized constructor
         * @param gold Price in gold of the item
         * @param stock Quantity avaible of the item
         * @param description Description of the item
         * @param name Name of the item
         * @param attack Bonus stats of damage that the item gives
         * @param defense Bonus stats of defense that the item gives
         * @param health Bonus stats of health that the item gives
         */ 
        public Item_Game(double gold, int stock, string description, string name, int attack, int defense, int health)
            : base(name, description)
        {
            this.gold = gold;
            this.stock = stock;
            this.extra_attack = attack;
            this.extra_defense = defense;
            this.extra_health = health;
        }

        /** This method will decrease the stock*/
        public void decreaseStock()
        {
            this.stock = this.stock - 1;
            ic.update_Item(this);
        }

        /** This method will increase the stock*/
        public void increaseStock(int value)
        {
            this.stock = stock + value;
            ic.update_Item(this);
        }

        /** Getters and setters */
        public double Gold
        {
            get { return this.gold; }
            set { this.gold = value; }
        }

        public int Stock
        {
            get { return this.stock; }
            set { this.stock = value; }
        }

        public int extra_Attack
        {
            get { return this.extra_attack; }
            set { this.extra_attack = value; }
        }

        public int extra_Health
        {
            get { return this.extra_health; }
            set { this.extra_health = value; }
        }

        public int extra_Defense
        {
            get { return this.extra_defense; }
            set { this.extra_defense = value; }
        }

        public void insertBagItem()
        {
            CharacterEN cen = new CharacterEN();
            cen.buy_item(this);
        }
        /**
         * This method will return the Item_Game as a string
         */
        public override string toString()
        {
            string str = "";
            str += "Name: " + this.name + "\n";
            str += "Description: " + this.description + "\n";
            str += "Gold: " + this.gold + "\n";
            str += "Stock: " + this.stock + "\n";
            str += "Defense: " + this.extra_defense + "\n";
            str += "Health: " + this.extra_health + "\n";
            str += "Attack: " + this.extra_attack + "\n";
            return str;
        }
    }

}