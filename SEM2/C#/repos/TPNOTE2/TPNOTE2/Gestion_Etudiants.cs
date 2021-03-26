using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace TPNOTE2
{
    public partial class Gestion_Etudiants : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\victo\Documents\ING_4\SEM2\C#\repos\TPNOTE2\TPNOTE2\DatabaseTP2.mdf;Integrated Security=True");
        public Gestion_Etudiants()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, System.EventArgs e)
        {

        }
        /// <summary>
        /// Checks if any field is empty and 
        /// </summary>
        /// <returns> a boolean that say if a field is empty</returns>
        private Boolean isEmpty()
        {
            if (textBoxNum_Etu.Text == "" || textBoxNom.Text == "" || textBoxPrenom.Text == "")
            {
                //MessageBox.Show("Merci de remplir tous les champs du formulaire");
                return true;
            }
            else return false;
        }
        /// <summary>
        /// empties all the fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNouveau_Click(object sender, System.EventArgs e)
        {
            textBoxNum_Etu.Text = "";
            textBoxNom.Text = "";
            textBoxPrenom.Text = "";
            naissance.Value = System.DateTime.Today;
        }
        /// <summary>
        /// Calls the function recherche given the id put in the text box num etu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecherche_Click(object sender, System.EventArgs e)
        {

            recherche(int.Parse(textBoxNum_Etu.Text), sender, e);
            
        }
        /// <summary>
        /// Research the informations about a student given its id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recherche(int id, Object sender, System.EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            String request = "select * from Etudiant where Num_Etu = @p1";
            command.Parameters.AddWithValue("P1", id);
            command.CommandText = request;
            command.Connection = connection;

            Object result = command.ExecuteScalar();
            if (result == null)
            {
                MessageBox.Show("Pas d'étudiants avec ce numéro");
                buttonNouveau_Click(sender, e);
                connection.Close();
            }
            else
            {
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    textBoxNum_Etu.Text = dr[0].ToString();
                    textBoxNom.Text = dr[1].ToString();
                    textBoxPrenom.Text = dr[2].ToString();
                    naissance.Value = DateTime.Parse(dr[3].ToString());

                }
                connection.Close();
            }
        }
        /// <summary>
        /// Makes sure that only numbers are put in this field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNum_Etu_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxNum_Etu.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBoxNum_Etu.Text = textBoxNum_Etu.Text.Remove(textBoxNum_Etu.Text.Length - 1);
            }
        }

        private void textBoxNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void naissance_ValueChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Adds to the database a new student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Merci de remplir tous les champs du formulaire");
            } else
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                String request = "insert into Etudiant values(@p1,@p2,@p3,@p4)";
                command.Parameters.AddWithValue("P1", int.Parse(textBoxNum_Etu.Text));
                command.Parameters.AddWithValue("P2", textBoxNom.Text);
                command.Parameters.AddWithValue("P3", textBoxPrenom.Text);
                command.Parameters.AddWithValue("P4", naissance.Value);
                command.CommandText = request;
                command.Connection = connection;
                try
                {
                    int x = command.ExecuteNonQuery();
                    if (x != 0) MessageBox.Show("Bien ajouté !");
                    else
                    {
                        MessageBox.Show("Erreur lors de l'insertion, vérifiez que le numéro étudiant n'existe pas");
                        textBoxNum_Etu.Text = "";
                    }
                    connection.Close();
                } catch(Exception e1)
                {
                    MessageBox.Show("Erreur lors de l'insertion, vérifiez que le numéro étudiant n'existe pas");
                    textBoxNum_Etu.Text = "";
                    connection.Close();
                }
                
            }
        }
        /// <summary>
        /// Modifies a student informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Merci de remplir tous les champs du formulaire");
            }
            else
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                String request = "update Etudiant set Nom_Etu = @p2, Prenom_Etu = @p3, DateN_Etu = @p4 where Num_Etu = @p1";
                command.Parameters.AddWithValue("P1", int.Parse(textBoxNum_Etu.Text));
                command.Parameters.AddWithValue("P2", textBoxNom.Text);
                command.Parameters.AddWithValue("P3", textBoxPrenom.Text);
                command.Parameters.AddWithValue("P4", naissance.Value);
                command.CommandText = request;
                command.Connection = connection;
                try
                {
                    int x = command.ExecuteNonQuery();
                    if (x != 0)
                    {
                        MessageBox.Show("Bien modifié !");
                        connection.Close();
                        buttonRecherche_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'insertion, vérifiez que le numéro étudiant existe");
                        textBoxNum_Etu.Text = "";
                        connection.Close();
                    }
                    
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1);
                    MessageBox.Show("Erreur lors de l'insertion, vérifiez que le numéro étudiant n'existe pas");
                    textBoxNum_Etu.Text = "";
                    connection.Close();
                }

            }
        }
        /// <summary>
        /// Deletes a student from the database with the id put in student num
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {

            connection.Open();
            SqlCommand command = new SqlCommand();
            String request = "delete from Etudiant where Num_Etu = @p1";
            command.Parameters.AddWithValue("P1", int.Parse(textBoxNum_Etu.Text));
            command.CommandText = request;
            command.Connection = connection;

            int x = command.ExecuteNonQuery();
            if (x == 0)
            {
                MessageBox.Show("Pas d'étudiants avec ce numéro");
                buttonNouveau_Click(sender, e);
                connection.Close();
            }
            else
            {
                MessageBox.Show("Etudiant bien supprimé");
                buttonNouveau_Click(sender, e);
                connection.Close();
            }

        }
        /// <summary>
        /// Quits this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Display the informations of the first student of the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDebut_Click(object sender, EventArgs e)
        {
            int id = 0;
            connection.Open();
            SqlCommand command = new SqlCommand();
            String request = "select min(Num_Etu) from Etudiant";
            command.CommandText = request;
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                id = int.Parse(dr[0].ToString());
            }
                connection.Close();
            recherche(id, sender, e);
        }
        /// <summary>
        /// Display the information of the previous student in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMoins_Click(object sender, EventArgs e)
        {
            int min = -1;
            connection.Open();
            SqlCommand command = new SqlCommand();
            String request = "select min(Num_Etu) from Etudiant";
            command.CommandText = request;
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                min = int.Parse(dr[0].ToString());
            }
            connection.Close();

            if (textBoxNum_Etu.Text == "" || int.Parse(textBoxNum_Etu.Text) <= min) buttonDebut_Click(sender, e);
            else
            {

                int i = 0;
                int id = 0;
                connection.Open();
                SqlCommand command1 = new SqlCommand();
                String request1 = "select Num_Etu from Etudiant";
                command1.CommandText = request1;
                command1.Connection = connection;
                SqlDataReader dr1 = command1.ExecuteReader();
                while (dr1.Read())
                {
                    Console.WriteLine(dr1.GetValue(0));
                    if ((int)dr1.GetValue(0) < int.Parse(textBoxNum_Etu.Text))
                    {
                        id = (int)dr1.GetValue(0);
                        i++;
                    }                    
                    else
                    {
                        dr1.Close();
                        break;
                   }
                }
                connection.Close();
                recherche(id, sender, e);
            }
            
        }
        /// <summary>
        /// Display the informations of the next student of the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlus_Click(object sender, EventArgs e)
        {

            int max = -1;
            connection.Open();
            SqlCommand command = new SqlCommand();
            String request = "select max(Num_Etu) from Etudiant";
            command.CommandText = request;
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                max = int.Parse(dr[0].ToString());
            }
            connection.Close();

            if (textBoxNum_Etu.Text == "" || int.Parse(textBoxNum_Etu.Text) >= max) button4_Click(sender, e);
            else
            {

                int i = 0;
                int id = 0;
                connection.Open();
                SqlCommand command1 = new SqlCommand();
                String request1 = "select Num_Etu from Etudiant";
                command1.CommandText = request1;
                command1.Connection = connection;
                SqlDataReader dr1 = command1.ExecuteReader();
                while (dr1.Read())
                {
                    Console.WriteLine(dr1.GetValue(0));
                    if ((int)dr1.GetValue(0) <= int.Parse(textBoxNum_Etu.Text))
                    {

                    }
                    else
                    {
                        id = (int)dr1.GetValue(0);
                        dr1.Close();
                        break;
                    }
                }
                connection.Close();
                recherche(id, sender, e);
            }

        }
        /// <summary>
        /// Display the informations of the last student of the databases
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            int id = 0;
            connection.Open();
            SqlCommand command = new SqlCommand();
            String request = "select max(Num_Etu) from Etudiant";
            command.CommandText = request;
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                id = int.Parse(dr[0].ToString());
            }
            connection.Close();
            recherche(id, sender, e);

        }

        private void Gestion_Etudiants_Load(object sender, EventArgs e)
        {

        }
    }
}
