using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apteka_klient
{
    public partial class Form6 : Form
    {
        String login;
        String lek;
        
        public Form6(String login, String lek)
        {
            InitializeComponent();
            this.login = login;
            this.lek = lek;
            var data1 = "0";
            connection c = new connection("127.0.0.1", "0", data1);
            c.Send("4;" + login + ";" + lek, data1);
            data1 = c.data1;
            string[] subs = data1.Split(";");
            label1.Text = subs[0];
            if(subs.Length>=4)
            {
                dataGridView1.Rows.Add(new object[] { subs[1], subs[2], subs[3] });
            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7(login, lek);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8(login, lek);
            form8.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
