using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHADA
/**
* This class represents the EN (Entidad de Negocio), BE (Bussiness Entity) 
* in English, of a battle between two characters.
*/
{
    public class BattleEN
    {
        /**
     * ATTRIBUTES OF THE Battle
     */

        /*Id of the battle*/
        private int id_battle;

        /*Winner*/
        private string name_winner;

        /*HP left p1*/
        private int p1_hp;

        /*HP left p2*/
        private int p2_hp;

        /*Name of p1*/
        private string p1_name;

        /*Name of p2*/
        private string p2_name;

        /*gold reward*/
        private int gold_reward;

        /*experience earned */
        private int experience_earned;

        private BattleCAD bc;

    
      /**
      * PROPERTIES OF THE CLASS Battle
      * Getters and setters for all the attributes
      */


        /**
        * Property  to set and get the id attribute. 
        */
        public int Battle_id
        {
            get { return this.id_battle; }
            set { id_battle = value; }
        }

        /**
        * Property  to set and get the name_winner attribute. 
        */
        public string Battle_name_winner
        {
            get { return this.name_winner; }
            set { name_winner = value; }
        }

        /**
      * Property  to set and get the p1_name attribute. 
      */
        public String Battle_p1_name
        {
            get { return this.p1_name; }
            set { p1_name = value; }
        }

        /**
        * Property  to set and get the p2_name attribute. 
        */
        public String Battle_p2_name
        {
            get { return this.p2_name; }
            set { p1_name = value; }
        }

        /**
        * Property  to set and get the p1_hp attribute. 
        */
        public int Battle_p1_hp
        {
            get { return this.p1_hp; }
            set { p1_hp = value; }
        }

        /**
        * Property  to set and get the p2_hp attribute. 
        */
        public int Battle_p2_hp
        {
            get { return this.p2_hp; }
            set { p1_hp = value; }
        }

        /**
        * Property  to set and get the gold_reward attribute. 
        */
        public int Battle_gold_reward
        {
            get { return this.gold_reward; }
            set { gold_reward = value; }
        }

        /**
        * Property  to set and get the experience_earned attribute. 
        */
        public int Battle_experience_earned
        {
            get { return this.experience_earned; }
            set { experience_earned = value; }
        }


        /** 
        * METHODS OF THE Battle
        */

        public BattleEN() 
        {
            id_battle = 0;
            name_winner="";
            p1_hp = 0;
            p2_hp=0;
            p1_name="";
            p2_name="";
            gold_reward=0;
            experience_earned = 0;

        }

        public BattleEN(int id)
        {
            name_winner = "";
            p1_hp = 0;
            p2_hp = 0;
            p1_name = "";
            p2_name = "";
            gold_reward = 0;
            id_battle = id;
        }
        /**
        * Insert a Battle in the database.
        */
        public void create_battle()
        {
            try
            {
                bc = new BattleCAD("./database");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error creando BattleCad : %s ", error.Message);
                return;
            }

            bc.createBattle(this);
        }

        /**
        * Delete a battle from the database.
        */
        public void delete_battle()
        {
            try
            {
                bc = new BattleCAD("./database");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error borrando BattleCad : %s ", error.Message);
                return;
            }

            bc.deleteBattle(id_battle);
        }

        /**
        * Returns all the battles of a character from the database.
        */
        public void view_allbattles(CharacterEN player)
        {
            try
            {
                bc = new BattleCAD("./database");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error mostrando BattleCad : %s ", error.Message);
                return;
            }
            bc.listBattles(player.characterName);
        }


        /**
        * Returns a battle from the database.
        */
        public BattleEN view_battle(int id)
        {
            try
            {
                bc = new BattleCAD("./database");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error mostrando BattleCad : %s ", error.Message);
                
            }

           return bc.getBattle(id);            
        }
       
        /**
        * Update a battle in the database.
        */
        public void update_battle()
        {
            try
            {
                bc = new BattleCAD("./database");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error actualizando CharacterCad : %s ", error.Message);
                return;
            }

            bc.updateBattle(this);
        }

        /**Mehotd with the algorithm of the battle
         * @param p1 one of the characters who going to battle
         * @param p2 the other character
         * It calculates a random number from 1 to 10 plus the attack of the player, minus the defense of the other player
         * and that's the damage that the opposite player suffer
         * When one of the hp of each character decrease from below 0, the fight ends
         */
        public void fight( CharacterEN p1,  CharacterEN p2){
            Random rndm = new Random();
            int damage;
            int hp1 = p1.characterHEALTH;
            int hp2 = p2.characterHEALTH;

            while (hp1 > 0 && hp2 > 0)
            {
                damage = rndm.Next(0, 10); // % Luck
                int attack1 = ((p1.characterATK + damage) - p2.characterDEF);
                if (attack1 > 0)
                {
                    hp2 = hp2 - attack1;
                }
                else 
                    hp2--;
                if (hp2 > 0)
                {
                    damage = rndm.Next(0, 10); // % Luck
                    int attack2 = ((p2.characterATK + damage) - p1.characterDEF);
                    if (attack2 > 0)
                    {
                        hp1 = hp1 - attack2;
                    }
                    else
                    {
                        hp1--;
                    }
                }
            }
            if (hp2 <= 0) //Then we finally put the stats of the battle into the parameters and call create_battle;
            {
                name_winner = p1.characterName;
                gold_reward = 100 * p1.characterLVL;
                p1.increase_Gold(gold_reward);
                experience_earned = 1 + p1.characterLVL;
                p1.increase_EXP(experience_earned);
            }
            else
            {
                name_winner = p2.characterName;
                gold_reward = 100 * p2.characterLVL;
                p2.increase_Gold(gold_reward);
                experience_earned = 1 + p1.characterLVL;
                
            }

            p1_hp = hp1;
            p2_hp = hp2;
            p1_name = p1.characterName;
            p2_name = p2.characterName;

            create_battle();
        }

        /**
         * This method convert the battle into a string
         * @return s the battle converted into a string
         */
        public string toString()
        {
            string s;

            s  = "Id : " + id_battle + "\n" + "Winner : " + name_winner + "\n";
            s += "Life player 1 : " + p1_hp + "\n" + "Life player 2: " + p1_hp + "\n";
            s += "Name player 1 : " + p1_name + "\n" + "Name player 2: " + p2_name + "\n";
            s += "Gold :" + gold_reward + "\n" + "Experience earned:" + experience_earned + "\n";

            return s;
        }
    }
}
