using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // default properties trackbar
            trackBar1.Minimum = 0; //0ms
            trackBar1.Maximum = 10; //1s
            trackBar1.TickFrequency = 1; //unité = 100ms
            trackBar1.Enabled = false;

            //radio buttons
            groupBox1.Select();

            //button stop
            button_stop.Enabled = false;
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            //blindage fréquence
            if(trackBar1.Value != trackBar1.Minimum)
            {
                timer1.Start();
            }
            button_stop.Enabled = true;
            button_play.Enabled = false;
            trackBar1.Enabled = true;
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button_stop.Enabled = false;
            button_play.Enabled = true;
            trackBar1.Enabled = false;
            radioButton_bleu.Checked = false;
            radioButton_rouge.Checked = false;
            radioButton_vert.Checked = false;
            this.BackColor = DefaultBackColor;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButton_rouge.Checked)
            {
                radioButton_bleu.Checked = false;
                radioButton_vert.Checked = false;
                this.BackColor = Color.Red;
            }
            else if (radioButton_vert.Checked)
            {
                radioButton_bleu.Checked = false;
                radioButton_rouge.Checked = false;
                this.BackColor = Color.Green;
            }
            else if (radioButton_bleu.Checked)
            {
                radioButton_rouge.Checked = false;
                radioButton_vert.Checked = false;
                this.BackColor = Color.Blue;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Stop();
            if (trackBar1.Value != trackBar1.Minimum)
            {
                timer1.Interval = trackBar1.Value * 100;
                timer1.Start();
            }
        }
    }
}
