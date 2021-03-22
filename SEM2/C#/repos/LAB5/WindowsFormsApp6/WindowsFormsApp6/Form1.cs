using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        int cs = 0;
        int sec = 0;
        int min = 0;
        int cpt = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            label_min.Text = "00";
            label_sec.Text = "00";
            label_cent_sec.Text = "00";
        }

        private void button_demarrer_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cs++;
            if (cs < 10)
            {
                label_cent_sec.Text = "0" + cs;
            } else
            {
                label_cent_sec.Text = cs.ToString();
            }

            if (cs == 100)
            {
                cs = 0;
                sec++;
                if (sec < 10)
                {
                    label_sec.Text = "0" + sec;
                } else
                {
                    label_sec.Text = sec.ToString();
                }

                if(sec == 60)
                {
                    sec = 0;
                    min++;
                    if (min < 10)
                    {
                        label_min.Text = "0" + min;
                    } else
                    {
                        label_min.Text = min.ToString();
                    }
                }
            }
        }

        private void button_arreter_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button_effacer_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            cs = 0;
            sec = 0;
            min = 0;
            cpt = 0;
            label_cent_sec.Text = "0";
            label_sec.Text = "0";
            label_min.Text = "0";
            listBox1.Items.Clear();
        }

        private void button_tour_Click(object sender, EventArgs e)
        {
            cpt++;
            listBox1.Items.Add("tour " + cpt + ": " + label_min.Text + ":" + label_sec.Text + ":" + label_cent_sec);
        }
    }
}
