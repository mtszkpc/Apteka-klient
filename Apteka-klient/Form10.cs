using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form10 : Form
    {
        String miasto;
        String ulica;
        String login;
        public Form10(String login, String miasto, string ulica)
        {
            InitializeComponent();
            this.miasto = miasto;
            this.ulica = ulica;
            this.login = login;
            var data1 = "";
            connection c = new connection("127.0.0.1", "0", data1);
            c.Send("7;" + login + ";" + miasto + ";" + ulica, data1);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
}
