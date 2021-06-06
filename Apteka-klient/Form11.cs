using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form11 : Form
    {
        String login;
        public Form11(String login)
        { 
            InitializeComponent();
            this.login = login;
            var data1 = "";
            connection c = new connection("127.0.0.1", "0", data1);
            c.Send("8;" + login, data1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
