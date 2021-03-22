using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            text_change.Select();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDHtoEuro.Checked)
            {
                label_entree.Text = "DH";
                label_sortie.Text = "EURO";
            }
            else
            {
                label_entree.Text = "";
                label_sortie.Text = "";
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void radioButtonEurotoDH_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEurotoDH.Checked)
            {
                label_entree.Text = "Euro";
                label_sortie.Text = "DH";
            }
            else
            {
                label_entree.Text = "";
                label_sortie.Text = "";
            }
        }

        private void button_convertir_Click(object sender, EventArgs e)
        {
            double change, entree;
            if (text_change.Text == "")
                MessageBox.Show("Valeur de change vide", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!double.TryParse(text_change.Text, out change))
                MessageBox.Show("Valeur de change invalide", "champ invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (change <= 0)
                MessageBox.Show("Valeur de change doit être positive", "champ négatif", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (text_entree.Text == "")
                MessageBox.Show("Montant vide", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!double.TryParse(text_entree.Text, out entree))
                MessageBox.Show("Montant invalide", "champ invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (entree < 0)
                MessageBox.Show("Montant doit être positif", "champ négatif", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (radioButtonDHtoEuro.Checked == false && radioButtonEurotoDH.Checked == false)
                MessageBox.Show("Veuillez sélectionner un sens de conversion", "conversion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (radioButtonDHtoEuro.Checked)
                    text_result.Text = (entree / change).ToString();
                else
                    text_result.Text = (entree * change).ToString();
            }
        }

        private void button_annuler_Click(object sender, EventArgs e)
        {
  
        }

        private void button_annuler_Click_1(object sender, EventArgs e)
        {
            text_change.Text = "";
            text_entree.Text = "";
            text_result.Text = "";
            radioButtonDHtoEuro.Checked = false;
            radioButtonEurotoDH.Checked = false;
            text_change.Select();
        }
    }
}
