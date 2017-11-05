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
    public class MessageEN
    {
        /**
          * ATTRIBUTES OF THE MESSAGE
        */

        /*Id of the message*/
        private static int current_id = 0;

        private int id;

        /*context of the message*/
        private string text;

        /*sender name*/
        private string sender;

	    /*receiver name*/
        private string receiver;

        private MessageCAD message_cad;

        /**
        * PROPERTIES OF THE Message
        */

        public int Message_id
        {
            get { return this.id; }
            set { id = value; }
        }

        public static int Message_current_id
        {
            get { return current_id; }
            set { current_id = value; }
        }

        public string Message_text
        {
            get { return this.text; }
            set { text = value; }
        }

        public string Message_sender
        {
            get { return this.sender; }
            set { sender = value; }
        }

        public string Message_receiver
        {
            get { return this.receiver; }
            set { receiver = value; }
        }

        public MessageEN()
        {
            sender = "";
            receiver = "";
            text = "";
            id = 0;
        }
  
        public MessageEN(string sender, string receiver)
        {
            this.sender = sender;
            this.receiver = receiver;
        }

        public DataSet MostrarMensajes()
        {
            MessageCAD c = new MessageCAD();
            DataSet a = new DataSet();
            a =c.Listarmensajes(this.Message_receiver);
            return a;
        }

        public bool create_message()
        {
            bool creado = false;
            try
            {
                message_cad = new MessageCAD();
                Message_id = Message_current_id;
                Message_current_id = Message_current_id + 1;
                creado = message_cad.createMessage(this);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            return creado;
        }

        public void delete_message()
        {
            try
            {
                message_cad = new MessageCAD();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            message_cad.deleteMessage(this);
        }

        public void get_message()
        {
            try
            {
                message_cad = new MessageCAD();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            message_cad.getMessage(this);
        }


 
    }
}
