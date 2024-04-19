using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MailKit.Net.Smtp;
using MailKit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvioSmtpMailKit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurações do servidor SMTP do Outlook
            string host = "smtp.office365.com";
            int port = 587;
            bool useSsl = false;

            // Configurações da conta de e-mail
            string username = "email";
            string password = "senha";

            // Cria a mensagem de e-mail
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Remetente", "email"));
            message.To.Add(new MailboxAddress("Destinatário", "email"));
            message.Subject = "Assunto";
            message.Body = new TextPart("plain")
            {
                Text = "Parabens"
            };

           
                using (var client = new SmtpClient())
                {
                    client.Connect(host, port, useSsl);

                    // Autenticação usando nome de usuário e senha de aplicativo
                    client.Authenticate(username, password);

                    // Envio do e-mail
                    client.Send(message);
                    client.Disconnect(true);
                }

                
           
         
           
        }
    }
}
