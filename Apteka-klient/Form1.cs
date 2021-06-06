using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            String data1 = null;
            connection c = new connection("127.0.0.1", "0", data1);
            c.Send("1", data1);
            label3.Text = c.data1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 settingsForm = new Form2();

            // Show the settings form
            settingsForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String data1 = null;
            String login = textBox1.Text;
            String password = textBox2.Text;

            connection c = new connection("127.0.0.1", "0", data1);
            c.Send("2;"+login+";"+password, data1);
            char foo = '0';
            if (c.data1 != null)
            {
                foo = c.data1[0];
            }


            int bar = foo - '0';
            if (bar == 0)
            {
                label3.Text = "blad polaczenia";
                
            } else if(bar!=2)
            {
                label3.Text = "blad logowania, zaloguj sie ponownie";
            }

            else 
            {
                Form3 Form3 = new Form3(c.data1);

                // Show the settings form
                Form3.Show();
                //this.Close();
            }

        }
    }
}
