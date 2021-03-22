using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_calculer_Click(object sender, EventArgs e)
        {
            double prix;

            //Blindage
            if (prix_base.Text == "")
                MessageBox.Show("Indiquer un prix de base SVP", "vide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(!double.TryParse(prix_base.Text, out prix))
                MessageBox.Show("Prix de base invalide", "invalilde", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(listBox1.SelectedIndex == -1)
                MessageBox.Show("Indiquer un type de billet SVP", "type billet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("Indiquer une réduction SVP", "reduction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //Tout est ok on peut effectuer les calculs
                double prixht;

                //Listbox
                if (listBox1.SelectedIndex == 1) //2eme classe
                    prixht = prix;
                else //1ere classe
                    prixht = prix + (prix * 0.2);

                //Combobox
                if (comboBox1.SelectedIndex == 1) //jeune
                    prixht -= (prixht * 0.4);
                else if (comboBox1.SelectedIndex == 2) //adulte
                    prixht -= (prixht * 0.3);
                else if (comboBox1.SelectedIndex == 2) //famille
                    prixht -= (prixht * 0.5);

                //Results
                text_HT.Text = prixht.ToString();
                text_tva.Text = "20%";
                text_prix_TTC.Text = (prixht + prixht * 0.2).ToString();
            }
        }

        private void button_reinitialiser_Click(object sender, EventArgs e)
        {
            prix_base.Text = "";
            listBox1.ClearSelected();
            comboBox1.SelectedIndex = -1;
            text_HT.Text = "";
            text_tva.Text = "";
            text_prix_TTC.Text = "";
        }

        private void button_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
