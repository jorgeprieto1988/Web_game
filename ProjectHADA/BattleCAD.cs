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
     * This class represents the CAD (Componente de Acceso a DAtos), 
     * DAC (Data Access Component) in English, of a Battle.
     */
    class BattleCAD
    {
        /**
         * Create a new CAD from an database file.
         * @param db the name of the database 
         */
   
        public BattleCAD(BattleEN battle)
        {
            if (battle == null)
                throw new Exception("BattleCAD::BattleCAD(BattleEN): The introduced battle is NULL");
            else
                this.be = battle;
        }

        public BattleCAD(string dbf)
        {

        }


        /**
         * Show all the battles
         * @param name the name of the character
         * @return List<BattleEn> the list with all battles
         * Search all the battles by the name of a  character in the BBDD
         * If this character exist, show all his battles
         */

        public List<BattleEN> listBattles(string nameplayer)
        {
            List<BattleEN> listbattle = new List<BattleEN>();
           
            SqlConnection c = new SqlConnection("url,variable global");
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from battle");
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    BattleEN battleaux = new BattleEN();
                    battleaux.Battle_id= dr.GetInt16(0);
                    battleaux.Battle_name_winner=dr.GetString(1);
                battleaux.Battle_p1_hp=dr.GetInt16(2);
                battleaux.Battle_p2_hp=dr.GetInt16(3);
                battleaux.Battle_gold_reward=dr.GetInt16(4);
                battleaux.Battle_experience_earned=dr.GetInt16(5);
                battleaux.Battle_p1_name=dr.GetString(6);
                battleaux.Battle_p2_name=dr.GetString(7);
                listbattle.Add(battleaux);
                }
                dr.Close();
              
            }
            catch (Exception ex) { /*mostrar error*/ }
            finally
            {
                c.Close();
              
            }
            return listbattle; //comprobar esto;
        }


        public DataSet ObtainBattles()
        {
            SqlConnection conn = null;
            DataSet dsBattles = null;
            // Encapsula todo el acceso a datos dentro del try
            string comando = "Select * from battle";
            try
            {
                conn = new SqlConnection("url,variable global");
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter (comando, conn);
                dsBattles = new DataSet();
                sqlAdaptador.Fill (dsBattles);
                return dsBattles;
            }
            catch (SqlException sqlex)
            {
            throw new Exception ("Error en la consulta de clientes por ciudad: " );
            }
            catch (Exception ex)
            {
            // Captura la condición general y la reenvía.
            throw ex;
            }
            finally
            {
            if(conn != null) conn.Close(); // Se asegura de cerrar la conexión.
            }}


        /**
         * Show the basic stats of a battle
         * @param id the id of a battle
         * @return BattleEn the battle that we wanted to obtain
         * Search a battle by the id of a  battle in the BBDD
         * If this battle exist, show all his atributtes
         */
        public BattleEN getBattle(int id)
        {
            BattleEN battleaux=new BattleEN();
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from battle where id_battle="+ id+";",c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    battleaux.Battle_id= dr.GetInt16(0);
                    battleaux.Battle_name_winner=dr.GetString(1);
                battleaux.Battle_p1_hp=dr.GetInt16(2);
                battleaux.Battle_p2_hp=dr.GetInt16(3);
                battleaux.Battle_gold_reward=dr.GetInt16(4);
                battleaux.Battle_experience_earned=dr.GetInt16(5);
                battleaux.Battle_p1_name=dr.GetString(6);
                battleaux.Battle_p2_name=dr.GetString(7);
                    
                }
                dr.Close();
              
            }
            catch (Exception ex) { /*mostrar error*/ }
            finally
            {
                c.Close();
              
            }
            return battleaux; //comprobar esto;
        }


        public bool createBattle(BattleEN cen)
        {
            bool insertado;
            BattleEN cl = cen;
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(db);
            insertado = false;

            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("INSERT INTO battle (name_winner,p1_hp,p2_hp,gold_reward,experience_earned,name1,name2) VALUES ('" + cen.Battle_name_winner + "', " + cen.Battle_p1_hp + ", " + cen.Battle_p2_hp + ", " + cen.Battle_gold_reward + ", " + cen.Battle_experience_earned + ", '" + cen.Battle_p1_name + "', '" + cen.Battle_p2_name + "')", c);
                com.ExecuteNonQuery();
                insertado = true;


            }
            catch (Exception ex)
            {
                insertado = false;
                throw ex;

            }
            finally { c.Close(); }

            return insertado;
        }

        /**
         * insert the battle in the BBDD
         * @param battle the BattleEN
         */
        public bool createBattle2(BattleEN battle)
        {
            bool cambiado;
            BattleEN cl = battle;
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from battle", c);
                da.Fill(bdvirtual, "battle");
                DataTable t = new DataTable();
                t = bdvirtual.Tables["battle"];
                DataRow nuevafila = t.NewRow();
                nuevafila[1] = cl.Battle_name_winner;
                nuevafila[2] = cl.Battle_p1_hp;
                nuevafila[3] = cl.Battle_p2_hp;
                nuevafila[4] = cl.Battle_gold_reward;
                nuevafila[5] = cl.Battle_experience_earned;
                nuevafila[6] = cl.Battle_p1_name;
                nuevafila[7] = cl.Battle_p2_name;
                t.Rows.Add(nuevafila);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(bdvirtual, "battle");
                cambiado = true;

            }
            catch (Exception ex)
            {
                cambiado = false;

            }
            finally { c.Close(); }

            return cambiado;

        }

        /**
         * Delete the Battle from the database
         * @param id the id of the battle
         */

        public void deleteBattle(int id)
        {

        }

        /**
         * This method update the attributes of the battle in the database
         * @param battle the BattleEN
         */

        public void updateBattle(BattleEN battle)
        {

        }

        ///////////
        // Data  //
        ///////////

        /** Connection to de database. */
        private string db = ConfigurationManager.ConnectionStrings["HADAdatabase"].ToString();

        /** BattleEn to use in the database. */
        private BattleEN be;

        /** List of the battles that we have in the database. */
        private List<BattleEN> listbattles;

        /** Number of battles that we have in the database. */
        private int battles = 0;
       

    }
}
