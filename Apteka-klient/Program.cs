using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Apteka_klient
{
    public class connection
    {
        String server;
        String port;
        public String data1;
        public connection(String server, String port, String data1)
        {
            this.server = server;
            this.port = port;
            this.data1 = data1;
        }
        public void Send(String dane, String data1)
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

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                this.data1 = responseData;

                // Close everything.
                stream.Close();
                //client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            //NetworkStream nwStream = client.GetStream();
            //byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            // int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            //data1 = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            //string publicKeyString = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            //label6.Text = publicKeyString;
            //String textToEncrypt = dane;
            //string encryptedText = Encrypt(textToEncrypt, publicKeyString);
            //data = System.Text.Encoding.ASCII.GetBytes(encryptedText);
            //stream.Write(data, 0, data.Length);


        }
        public class Program
        {

            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                String data1 = null;
                connection connect = new connection("127.0.0.1", "0", data1);

                connect.Send("0", data1);

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}