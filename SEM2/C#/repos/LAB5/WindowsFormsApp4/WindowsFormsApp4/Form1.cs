using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        //compteur 
        int i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            maskedTextBox_tel.Mask = "00 00 00 00 00";
            monthCalendar1.MaxSelectionCount = 1;
            maskedTextBox_tel.BeepOnError = true;
        }

        private void button_ajouter_Click(object sender, EventArgs e)
        {
            //blindages
            if (textBox_nom.Text == "" || textBox_adresse.Text == "" || maskedTextBox_tel.Text == "")
                MessageBox.Show("le champ est vide", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (monthCalendar1.SelectionStart.Date > DateTime.Now.Date)
                MessageBox.Show("date invalide", "date invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (maskedTextBox_tel.MaskFull == false)
                MessageBox.Show("telephone invalide", "telephone invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //On demande confirmation pour l'ajout
                DialogResult res = MessageBox.Show("Etes vous sur d'ajouter ce client ?", "confirmer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    //List box compteur
                    string[] saut = { "", "", "", "" };
                    i++;
                    listBox_compteur.Items.Add(i);
                    listBox_compteur.Items.AddRange(saut);

                    //List box user
                    listBox_user.Items.Add("Nom et prénom :" + textBox_nom.Text);
                    listBox_user.Items.Add("Date d'incription :" + monthCalendar1.SelectionStart.ToShortDateString());
                    listBox_user.Items.Add("Adresse :" + textBox_adresse.Text);
                    listBox_user.Items.Add("Téléphone :" + maskedTextBox_tel.Text);
                    listBox_user.Items.Add("------------------------------------");

                    //on vide les champs
                    textBox_nom.Text = "";
                    textBox_adresse.Text = "";
                    monthCalendar1.SetDate(DateTime.Now.Date);
                    maskedTextBox_tel.Text = "";
                }
            }
        }

        private void button_vider_Click(object sender, EventArgs e)
        {
            if(listBox_compteur.Items.Count != 0)
            {
                //On demande confirmation pour l'ajout
                DialogResult res = MessageBox.Show("Etes vous sur de tout vider ?", "vider", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    //vider les listes
                    listBox_compteur.Items.Clear();
                    listBox_user.Items.Clear();

                    //remettre le compteur à 0
                    i = 0;
                }
            }
        }

        private void button_annuler_Click(object sender, EventArgs e)
        {
            textBox_nom.Text = "";
            textBox_adresse.Text = "";
            monthCalendar1.SetDate(DateTime.Now.Date);
            maskedTextBox_tel.Text = "";
        }
    }
}
