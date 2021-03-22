using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataBase
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'testDataSet.Table'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //this.tableTableAdapter.Fill(this.testDataSet.Table);
            actualiser(); //charger le contenu de la table client dans le datagridwiew au démarrage du formulaire
            label_total.Text = nombre_total().ToString();
        }

        private void actualiser()   //procédure qui permet de charger le contenu de la table client dans le Datagridview
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from [table]", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTable;
            dataReader.Close();
            connection.Close();
        }

        private int nombre_total() // fonction qui retourne le nombre de clients
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select count(cin) from [table]", connection);
            int c = int.Parse(cmd.ExecuteScalar().ToString());
            connection.Close();
            return c;
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_premier_Click(object sender, EventArgs e)
        {
            int cpt = 0; //compteur qui détermine l'ordre du client dans la table
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from [table]", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read()) //pointer sur le prmier client s'il existe
            {
                text_cin.Text = dataReader[0].ToString();
                text_nom.Text = dataReader[1].ToString();
                text_prenom.Text = dataReader[2].ToString();
                text_ville.Text = dataReader[3].ToString();
                text_tel.Text = dataReader[4].ToString();
                cpt++;
                label_num.Text = cpt.ToString();
                dataGridView1.ClearSelection();
                dataGridView1.Rows[cpt - 1].Selected = true; //sélectionner le client chargé dans le DATAGRIDVIEW
            }
            dataReader.Close();
            connection.Close();
        }

        private void btn_dernier_Click(object sender, EventArgs e)
        {
            int cpt = 0;
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from [table]", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) //parcourir les clients jusqu'à le dernier
            {
                text_cin.Text = dataReader[0].ToString();
                text_nom.Text = dataReader[1].ToString();
                text_prenom.Text = dataReader[2].ToString();
                text_ville.Text = dataReader[3].ToString();
                text_tel.Text = dataReader[4].ToString();
                cpt++;
                label_num.Text = cpt.ToString();
                dataGridView1.ClearSelection();
                dataGridView1.Rows[cpt - 1].Selected = true;
            }
            dataReader.Close();
            connection.Close();
        }

        private void btn_suivant_Click(object sender, EventArgs e)
        {
            int cpt = 0;
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from [table]", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) //parcourir la table
            {
                cpt++;
                if (dataReader[0].ToString() == text_cin.Text) //trouver le client chargé
                {
                    if (dataReader.Read()) //pointer sur le client suivant
                    {
                        text_cin.Text = dataReader[0].ToString();
                        text_nom.Text = dataReader[1].ToString();
                        text_prenom.Text = dataReader[2].ToString();
                        text_ville.Text = dataReader[3].ToString();
                        text_tel.Text = dataReader[4].ToString();
                        cpt++;
                        label_num.Text = cpt.ToString();
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[cpt - 1].Selected = true;
                    }
                    break;
                }
            }
            dataReader.Close();
            connection.Close();
        }

        private void btn_precedent_Click(object sender, EventArgs e)
        {
            int cpt = 0;
            connection.Open();
            string c = text_cin.Text; //parceque le CIN s'écrase au fur et à mesure du parcours
            SqlCommand cmd = new SqlCommand("select * from [table]", connection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) //parcourir la table
            {
                if (dataReader[0].ToString() != c) // écraser tous le clients différents du client chargé
                {
                    text_cin.Text = dataReader[0].ToString();
                    text_nom.Text = dataReader[1].ToString();
                    text_prenom.Text = dataReader[2].ToString();
                    text_ville.Text = dataReader[3].ToString();
                    text_tel.Text = dataReader[4].ToString();
                    cpt++;
                    label_num.Text = cpt.ToString();
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[cpt - 1].Selected = true;
                }
                else
                    break; //arreter le parcours donc les zones de texte restent contenir les infos du client précédent du client déja chargé.
            }
            dataReader.Close();
            connection.Close();
        }

        private bool rechercher_cin(string s) //fonction qui permet de vérifier l'existence d'un client
        {
            bool exist = false;
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from [table] where cin='" + s + "'";
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
                exist = true;

            dataReader.Close();
            connection.Close();
            return exist;
        }

        private void btn_nouveau_Click(object sender, EventArgs e)
        {
            text_cin.Text = "";
            text_nom.Text = ""; ;
            text_prenom.Text = "";
            text_ville.Text = "";
            text_tel.Text = "";
        }

        private void btn_rechercher_Click(object sender, EventArgs e)
        {
            if (text_cin.Text == "") //controle de saisie sur le champ CIN
                MessageBox.Show("Champ CIN vide!!", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (rechercher_cin(text_cin.Text) == false) // le client recherché n'existe pas
            {
                // vider les valeurs des recherches précédentes
                text_nom.Text = ""; 
                text_prenom.Text = "";
                text_ville.Text = "";
                text_tel.Text = "";
                MessageBox.Show("Client introuvable", "introuvable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                text_cin.Focus(); //selectionner le champ CIN pour une éventuelle resaisie
                text_cin.SelectAll(); 
            }
            else // le client existe : on l'affiche
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from [table] where cin='" + text_cin.Text + "'";
                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read(); // un seul client 
                text_nom.Text = dataReader[1].ToString();
                text_prenom.Text = dataReader[2].ToString();
                text_ville.Text = dataReader[3].ToString();
                text_tel.Text = dataReader[4].ToString();
                dataReader.Close();
                connection.Close();

            }
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            if (text_cin.Text == "" || text_nom.Text == "" || text_prenom.Text == "" || text_ville.Text == "" || text_tel.Text == "")
            {
                MessageBox.Show("Champ vide!!", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (rechercher_cin(text_cin.Text) == true) // vérification de l'unicité du client dont le CIN est saisi dans la zone CIN
            {

                MessageBox.Show("Client existe déja", "existant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                text_cin.Focus();
                text_cin.SelectAll();
            }
            else // on peut bien ajouter le client
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = String.Format("insert into [table] values('{0}','{1}','{2}','{3}','{4}')", text_cin.Text, text_nom.Text, text_prenom.Text, text_ville.Text, text_tel.Text);
                //int r = cmd.ExecuteNonQuery(); // ou ecrire cmd.ExecuteNonQuery() sans retour
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Client bien ajouté", "ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close(); // fermer la connexion avant d'appeler la méthode actualiser
                    actualiser(); //charger à nouveau les données pour afficher le nouveau client
                }

            }
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (text_cin.Text == "" || text_nom.Text == "" || text_prenom.Text == "" || text_ville.Text == "" || text_tel.Text == "") //controle de saisie
            {
                MessageBox.Show("Champ vide!!", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (rechercher_cin(text_cin.Text) == false) // vérification de l'existence du client dont le CIN est saisi dans la zone CIN
            {

                MessageBox.Show("Client Introuvable", "Introuvable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                text_cin.Focus();
                text_cin.SelectAll(); //selectionner le champ CIN pour une éventuelle resaisie
            }
            else // on peut modifier le client
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = String.Format("update [table] set nom='{0}',prenom='{1}',ville='{2}',tel='{3}' where cin='{4}'", text_nom.Text, text_prenom.Text, text_ville.Text, text_tel.Text, text_cin.Text);
                // int r = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Client bien Modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    actualiser();
                }

            }
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            if (text_cin.Text == "") //controle de saisie
            {
                MessageBox.Show("Champ CIN vide!!", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (rechercher_cin(text_cin.Text) == false) // vérification de l'existence du client dont le CIN est saisi dans la zone CIN
            {
                MessageBox.Show("Client Introuvable", "Introuvable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                text_cin.Focus();
                text_cin.SelectAll(); //selectionner le champ CIN pour une éventuelle resaisie
            }
            else
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = String.Format("delete from [table] where cin='{0}'", text_cin.Text);
                //int r = cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Client bien Supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_nouveau.PerformClick(); //appeler le bouton nouveau pour vider les champs
                    connection.Close();
                    actualiser();
                }

            }
        }
    }
}
