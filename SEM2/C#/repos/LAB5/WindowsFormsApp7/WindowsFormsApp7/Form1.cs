using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            text_pwd.UseSystemPasswordChar = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 30;
            progressBar1.Step = 1;
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if(progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                MessageBox.Show("Time out", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void button_connexion_Click(object sender, EventArgs e)
        {
            if(text_login.Text == "login" && text_pwd.Text == "pwd")
            {
                timer1.Stop();
                MessageBox.Show("Bienvenue !", "acces ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Login ou password incorrect", "acces refuse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_annuler_Click(object sender, EventArgs e)
        {
            text_login.Text = "";
            text_pwd.Text = "";
            text_login.Select();
        }
    }
}
