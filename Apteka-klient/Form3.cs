using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form3 : Form
    {
        public Form3(String data1)
        {

            InitializeComponent();
            string[] subs = data1.Split(";");
            String login = subs[1];
            label2.Text = subs[1];
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(label2.Text);
            form4.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9(label2.Text);
            form9.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11(label2.Text);
            form11.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15(label2.Text);
            form15.Show();
        }
    }
}
