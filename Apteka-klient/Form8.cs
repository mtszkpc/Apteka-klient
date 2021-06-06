using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form8 : Form
    {
        String login;
        String lek;
        public Form8(String login, String lek)
        {
            InitializeComponent();
            this.login = login;
            this.lek = lek;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data1 = "";
            connection c = new connection("127.0.0.1", "0", data1);
            c.Send("6;" + login + ";" + lek + ";" + textBox1.Text, data1);
        }
    }
}
