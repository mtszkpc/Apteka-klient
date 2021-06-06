using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form2 : Form
    {
        public static string Encrypt(string textToEncrypt, string publicKeyString)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    rsa.FromXmlString(publicKeyString.ToString());
                    var encryptedData = rsa.Encrypt(bytesToEncrypt, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        void Rejestracja(String server, String dane)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port);
                String message = dane;
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);
                stream.Flush();

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                Byte[] bytes = new Byte[256];
                String data1 = null;
                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.

                
                int i;

                //!!!!!!!!!!!!!!!!!!!!!!
                //stream.DataAvailable
                //while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                //{
                    // Translate data bytes to a ASCII string.
                    //data1 = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    //label6.Text =data1;

                    // Process the data sent by the client.

                //}
                //string publicKeyString = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                //label6.Text = publicKeyString;
                //String textToEncrypt = dane;
                //string encryptedText = Encrypt(textToEncrypt, publicKeyString);
                //data = System.Text.Encoding.ASCII.GetBytes(encryptedText);
                //stream.Write(data, 0, data.Length);

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            //Console.Read();
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imie = textBox1.Text;
            string nazwisko = textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text;
            string password2 = textBox5.Text;
            if (imie.Length == 0 || nazwisko.Length == 0 || username.Length == 0 || password.Length == 0 || password2.Length == 0)
            {
                label6.ForeColor = System.Drawing.Color.Red;
                label6.Text = "Podano niepoprawne dane";
            }
            else if (password != password2)
            {
                label6.ForeColor = System.Drawing.Color.Red;
                label6.Text = "Różne hasło";

            }
            else if (password.Length<5)
            {
                label6.ForeColor = System.Drawing.Color.Red;
                label6.Text = "Za krótkie hasło";

            }
            else
            {
                
                label6.Text = "Utworzono konto";
                String data1 = imie + ";" + nazwisko + ";" + username + ";" + password;
                connection c = new connection("127.0.0.1", "0", data1);
                c.Send("3;" + data1, data1);
                string[] subs = c.data1.Split(";");
                if (subs[0].Equals("login zajety"))
                {
                    label6.Text = "login zajety";
                    label6.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label6.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
