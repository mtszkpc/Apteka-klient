using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form4 : Form
    {
        String login;
        public Form4(String login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(login, textBox1.Text);
            form.Show();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
