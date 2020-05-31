using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace TcpExercise
{
    public partial class Form1 : Form
    {
        TcpClient client;
        SpeechSynthesizer sch;
        public const string MessageEncoding = "ISO-8859-1";
        //public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //client = new TcpClient();
            //client.Connect("127.0.0.1", 26009);
            //if (client.Connected)
            //    label3.Text = "Connected";

            
           // Task.Run(() => Read());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SendMessage(richTextBox2.Text);
        }
        public async Task Read()
        {
            var buffer = new byte[4096];
            var ns = client.GetStream();
            while (true)
            {
                var bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) return; // Stream was closed
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));
            }
        }
        private void SendMessage(String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                //Int32 port = 13000;
                //TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = Encoding.GetEncoding(MessageEncoding).GetBytes(message);
               // Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

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
                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
               // client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            //Console.WriteLine("\n Press Enter to continue...");
            //Console.Read();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sch = new SpeechSynthesizer();
            sch.Volume = trackBar1.Value;
            sch.Rate = trackBar2.Value;
            sch.Speak("Yanny");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }
    }
}
