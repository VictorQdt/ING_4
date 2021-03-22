using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // button >
        private void button_droite_item_Click(object sender, EventArgs e) 
        {
            if (listBox_gauche.SelectedIndex == -1)
                MessageBox.Show("please select an item from left list", "nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                listBox_droite.Items.Add(listBox_gauche.SelectedItem);
                listBox_gauche.Items.RemoveAt(listBox_gauche.SelectedIndex);
            }
        }

        // button <
        private void button_gauche_item_Click(object sender, EventArgs e)
        {
            if (listBox_droite.SelectedIndex == -1)
                MessageBox.Show("please select an item from right list", "nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                listBox_gauche.Items.Add(listBox_droite.SelectedItem);
                listBox_droite.Items.RemoveAt(listBox_droite.SelectedIndex);
            }
        }

        // button >>
        private void button_droite_list_Click(object sender, EventArgs e)
        {
            listBox_droite.Items.AddRange(listBox_gauche.Items);
            listBox_gauche.Items.Clear();
        }

        // button <<
        private void button_gauche_list_Click(object sender, EventArgs e)
        {
            listBox_gauche.Items.AddRange(listBox_droite.Items);
            listBox_droite.Items.Clear();
        }

        // gauche UP
        private void button_gauche_up_Click(object sender, EventArgs e)
        {
            int pos = listBox_gauche.SelectedIndex;
            string tpm;
            if(pos == -1)
                MessageBox.Show("please select an item from left list", "nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (pos != 0) // pos[0] = 1er item
            {
                //on permute les éléments p et p-1 de la liste
                tpm = listBox_gauche.Items[pos - 1].ToString();
                listBox_gauche.Items[pos - 1] = listBox_gauche.Items[pos];
                listBox_gauche.Items[pos] = tpm;

                //l'élément sélectioné remonte
                listBox_gauche.SelectedIndex = pos - 1;
            }
        }

        // gauche DOWN
        private void button_gauche_down_Click(object sender, EventArgs e)
        {
            int pos = listBox_gauche.SelectedIndex;
            string tpm;
            if (pos == -1)
                MessageBox.Show("please select an item from left list", "nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (pos != listBox_gauche.Items.Count-1) // dernier item 
            {
                //on permute les éléments p et p+1 de la liste
                tpm = listBox_gauche.Items[pos + 1].ToString();
                listBox_gauche.Items[pos + 1] = listBox_gauche.Items[pos];
                listBox_gauche.Items[pos] = tpm;

                //l'élément sélectioné remonte
                listBox_gauche.SelectedIndex = pos + 1;
            }
        }

        // gauche AZ
        private void button_gauche_AZ_Click(object sender, EventArgs e)
        {
            listBox_gauche.Sorted = false;
            listBox_gauche.Sorted = true;
        }

        // gauche ZA
        private void button_gauche_ZA_Click(object sender, EventArgs e)
        {
            int j = 0;
            //trier la liste
            listBox_gauche.Sorted = false;
            listBox_gauche.Sorted = true;

            string[] s = new string[listBox_gauche.Items.Count]; //tableau string de la taille des items

            //on inverse les éléments du tableau
            for (int i = listBox_gauche.Items.Count-1; i>=0; i--)
            {
                s[j] = listBox_gauche.Items[i].ToString();
                j++;
            }

            listBox_gauche.Items.Clear();
            listBox_gauche.Sorted = false;
            // On ajoute la liste triée Z -> A
            listBox_gauche.Items.AddRange(s);
        }

        // droite UP
        private void button_droite_UP_Click(object sender, EventArgs e)
        {
            int pos = listBox_droite.SelectedIndex;
            string tpm;
            if (pos == -1)
                MessageBox.Show("please select an item from right list", "nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (pos != 0) // pos[0] = 1er item
            {
                //on permute les éléments p et p-1 de la liste
                tpm = listBox_droite.Items[pos - 1].ToString();
                listBox_droite.Items[pos - 1] = listBox_droite.Items[pos];
                listBox_droite.Items[pos] = tpm;

                //l'élément sélectioné remonte
                listBox_droite.SelectedIndex = pos - 1;
            }
        }

        // droite DOWN
        private void button_droite_DOWN_Click(object sender, EventArgs e)
        {
            int pos = listBox_droite.SelectedIndex;
            string tpm;
            if (pos == -1)
                MessageBox.Show("please select an item from right list", "nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (pos != listBox_droite.Items.Count - 1) // dernier item 
            {
                //on permute les éléments p et p+1 de la liste
                tpm = listBox_droite.Items[pos + 1].ToString();
                listBox_droite.Items[pos + 1] = listBox_droite.Items[pos];
                listBox_droite.Items[pos] = tpm;

                //l'élément sélectioné remonte
                listBox_droite.SelectedIndex = pos + 1;
            }
        }

        // droite AZ
        private void button_droite_AZ_Click(object sender, EventArgs e)
        {
            listBox_droite.Sorted = false;
            listBox_droite.Sorted = true;
        }

        private void button_droite_ZA_Click(object sender, EventArgs e)
        {
            int j = 0;
            //trier la liste
            listBox_droite.Sorted = false;
            listBox_droite.Sorted = true;

            string[] s = new string[listBox_droite.Items.Count]; //tableau string de la taille des items

            //on inverse les éléments du tableau
            for (int i = listBox_droite.Items.Count - 1; i >= 0; i--)
            {
                s[j] = listBox_droite.Items[i].ToString();
                j++;
            }

            listBox_droite.Items.Clear();
            listBox_droite.Sorted = false;
            // On ajoute la liste triée Z -> A
            listBox_droite.Items.AddRange(s);
        }
    }
}
