using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form7 : Form
    {
        String login;
        String lek;
        public Form7(String login, String lek)
        {
            InitializeComponent();
            this.login = login;
            this.lek = lek;
            var data1 = "0";
            connection c = new connection("127.0.0.1", "0", data1);
            c.Send("m;" + login + ";" + lek, data1);
            data1 = c.data1;
            string[] subs = data1.Split(";");
            label1.Text = subs[0];
            if (subs.Length >= 4)
            {
                dataGridView1.Rows.Add(new object[] { subs[1], subs[2], subs[3] });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data1 = "";
            connection c = new connection("127.0.0.1", "0", data1);
            c.Send("5;" + login + ";" + lek + ";"+ textBox1.Text, data1);
        }
    }
}
