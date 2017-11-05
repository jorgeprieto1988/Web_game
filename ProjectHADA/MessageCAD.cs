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
    public class MessageCAD
    {
     

        public MessageCAD()
        {
            
        }

        public MessageCAD(MessageEN message_en)
        {
            if (message_en == null)
                throw new Exception("ItemCAD::ItemCAD(ItemEN): The introduced item is NULL");
            else
                this.msg_en = message_en;
        }
        
        public MessageEN getMessage(MessageEN message_en)
        {
            MessageEN aux = null;
            
            using (SqlConnection conexion = new SqlConnection(db))
            {
                conexion.Open();
                string consulta1 = "SELECT * FROM messages WHERE id = @ID";

                using (SqlCommand command1 = new SqlCommand(consulta1, conexion))
                {
                    command1.Parameters.AddWithValue("@ID", message_en.Message_id);
                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aux = new MessageEN(reader["sender"].ToString(), reader["receiver"].ToString());
                        }
                        reader.Close();
                    }
                }
            }

            return aux;
        }
        

        public bool createMessage(MessageEN message_en)
        {
            bool creado = false;
            int cantidadModificada = 0;

            //Stablishing the connection.
            SqlConnection conexion = new SqlConnection(db);

            try
            {
                //Opening the connection.
                conexion.Open();

                //Building the command.
                SqlCommand com = new SqlCommand("INSERT INTO Messages(sender,receiver,text) VALUES ('" + message_en.Message_sender + "', '" + message_en.Message_receiver + "', '" + message_en.Message_text + "')", conexion);
                
                //Executing the command.
                cantidadModificada = com.ExecuteNonQuery();

                if (cantidadModificada > 0)
                {
                    creado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return creado;
        }

        public void deleteMessage(MessageEN message_en)
        {
            using (SqlConnection conexion = new SqlConnection(db))
            {
                conexion.Open();
                string consulta = "DELETE FROM message WHERE id = @ID";
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@ID", message_en.Message_id);
                }
                conexion.Close();
            }
        }

        public DataSet Listarmensajes(string nombre_user)
        {
            DataSet bdvirtual = new DataSet();
             try
        {
            
            SqlConnection c = new SqlConnection(db);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Messages where receiver='"+ nombre_user +"';", c);
            da.Fill(bdvirtual);
            
        }
             catch (Exception ex) { /* imprimir mensaje */}
             return bdvirtual;
        }


        public List<MessageEN> get_all_messages(string nombre_user)
        {
            List<MessageEN> listmessages = new List<MessageEN>();

            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
            
                SqlCommand com = new SqlCommand("select * from Messages where reciever='"+ nombre_user +"';");
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    MessageEN message = new MessageEN("","");
                    message.Message_id = dr.GetInt16(0);
                    message.Message_receiver = dr.GetString(1);
                    message.Message_sender = dr.GetString(2);
                    message.Message_text = dr.GetString(3);
                    // Para leer la mochila.
                    listmessages.Add(message);
                }

                dr.Close();

            }
            catch (Exception ex) { /*mostrar error*/ }
            finally
            {
                c.Close();

            }
            return listmessages;
        }

        ///////////
        // Data  //
        ///////////

        /** Connection to de database. */
        private string db = ConfigurationManager.ConnectionStrings["HADAdatabase_FINAL"].ToString();

        /** ItemEN to use in the database. */
        private MessageEN msg_en;
    }
}
