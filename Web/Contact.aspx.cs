using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using ProjectHADA;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        MailMessage message = new MailMessage();

        try
        {
            // Remitente
            MailAddress fromAddress = new MailAddress(TextBox2.Text.ToString());
            // Destinatario (nosotros)
            // Email: projectHADAgame@gmail.com
            // Password: projecthada
            MailAddress toAddress = new MailAddress("projectHADAgame@gmail.com");

            message.From = fromAddress;
            message.To.Add(toAddress);

            // Asunto
            message.Subject = TextBox3.Text.ToString();

            // Cuerpo
            message.Body = TextBox1.Text.ToString() + " (" + TextBox2.Text.ToString() + ") \n \nSend the following message: \n \nSubject: " + TextBox3.Text.ToString() + "\n \nMessage: " + TextBox4.Text.ToString();

            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new System.Net.NetworkCredential("projectHADAgame@gmail.com", "projecthada");
            smtpClient.Send(message);
            Label2.Text = "Message has been sent.";
            Label2.Visible = true;
        }
        catch (Exception ex)
        {
            Label2.Text = "Message has not been sent.";
            Label2.Visible = true;
        }
    }
}