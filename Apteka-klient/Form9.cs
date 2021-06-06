using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form9 : Form
    {
        String login;
        public Form9(String login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10(login, textBox1.Text, textBox2.Text);
            form10.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
