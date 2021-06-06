using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form15 : Form
    {
        String login;
        public Form15(String login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data1 = "";
            connection c = new connection("127.0.0.1", "0", data1);
            c.Send("9;" + login + ";" +textBox1.Text, data1);
        }
    }
}
