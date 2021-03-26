using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TPNOTE2
{
    public partial class Gestion_Notes : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\victo\Documents\ING_4\SEM2\C#\repos\TPNOTE2\TPNOTE2\DatabaseTP2.mdf;Integrated Security=True");

        /// <summary>
        /// Function that return the number of a module with it's name
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        private int getNumModule(string moduleName)
        {
            int numModule = 0;
            connection.Open();
            SqlCommand cmd = new SqlCommand("select Num_Mod from [Module] where Nom_Mod = '" + moduleName + "'", connection);
            SqlDataReader data = cmd.ExecuteReader();
            if (!data.HasRows) // no results with the sql request
            {
                data.Close();
                connection.Close();
            }
            else // we have our result
            {
                data.Read();
                numModule = int.Parse(data[0].ToString());
            }
            data.Close();
            connection.Close();
            return numModule;
        }
        /// </summary>
        /// <param name="numEtu"></param>
        /// <param name="numMod"></param>
        /// <returns></returns>
        private float getNoteEtudiant(int numEtu, int numMod)
        {
            float noteEtudiant = -1;
            connection.Open();
            SqlCommand cmd = new SqlCommand("select Note from [Notes] where Num_Etu = " + numEtu + "and Num_Mod = " + numMod, connection);
            SqlDataReader data = cmd.ExecuteReader();
            if (!data.HasRows) // no results with the sql request
            {
                data.Close();
                connection.Close();
            }
            else // we have our result
            {
                data.Read();
                noteEtudiant = float.Parse(data[0].ToString());
            }
            data.Close();
            connection.Close();
            return noteEtudiant;
        }
       
        public Gestion_Notes()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Au lancement du form les combobox sont remplis avec les données de la database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gestion_Notes_Load(object sender, System.EventArgs e)
        {
            SqlDataAdapter da;
            DataTable dataTable = new DataTable();
            connection.Open();

            //Fill comboBox numEtu
            SqlCommand cmd1 = new SqlCommand("SELECT Num_Etu FROM [Etudiant]", connection);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox_numInscription.Items.Add(dr1[0]);
            }
            dr1.Close();

            // Fill comboBox nomMod
            SqlCommand cmd2 = new SqlCommand("SELECT Nom_Mod FROM [Module]", connection);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox_Modules.Items.Add(dr2[0]);
            }
            dr2.Close();
            connection.Close();
        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }

        private void label4_Click(object sender, System.EventArgs e)
        {

        }

        /// <summary>
        /// Listener of the comboBox "Numéro d'inscription" : display his name & firstname
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_numInscription_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset values
            dataGridView_Notes.DataSource = null;
            comboBox_Modules.SelectedIndex = -1;
            textBox_Notes.Text = "";

            //something has been selected
            if (comboBox_numInscription.SelectedIndex != -1)
            {
                connection.Open();
                // Sql request with the selected index
                int num_etu = int.Parse(comboBox_numInscription.SelectedItem.ToString());
                Console.WriteLine(num_etu);
                SqlCommand cmd = new SqlCommand("select Nom_Etu, Prenom_Etu from [Etudiant] where Num_Etu = " + num_etu, connection);
                SqlDataReader data = cmd.ExecuteReader();
                if (!data.HasRows) // no results with the sql request
                {
                    data.Close();
                    connection.Close();
                }
                else // we have our result
                {
                    data.Read();
                    string prenom = (string)data[0];
                    string nom = (string)data[1];
                    // check if the index selected correspond to a name 
                    textBox_Nom_Prenom.Text = prenom + " " + nom;
                }
                data.Close();
                connection.Close();
            }
        }

        private void textBox_Nom_Prenom_TextChanged(object sender, System.EventArgs e)
        {

        }

        /// <summary>
        /// Listener of the comboBox "Module" : display the grade of the student in the selected module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            //initialize the grade to null 
            textBox_Notes.Text = "";

            //check if a module and a num are selected in comboBoxes
            if (comboBox_Modules.SelectedIndex != -1)
            {
                if (comboBox_numInscription.SelectedIndex != -1)
                {
                    // Get the num of the student
                    int numEtu = int.Parse(comboBox_numInscription.SelectedItem.ToString());
                    // Get the name of the module
                    string nameMod = comboBox_Modules.SelectedItem.ToString();

                    //Call the 2 functions in order to get the numMod & the noteEtu
                    int numMod = getNumModule(nameMod);
                    float noteEtu = getNoteEtudiant(numEtu, numMod);

                    // We check if we have a grade returned
                    if (noteEtu != -1)
                    {
                        textBox_Notes.Text = noteEtu.ToString();
                    }
                    else
                    {
                        textBox_Notes.Text = "no grade";
                    }
                }
            }
        }

        private void textBox_Notes_TextChanged(object sender, System.EventArgs e)
        {

        }

        /// <summary>
        /// Listener of button "Nouveau" : reset all the form to default values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_nouveau_Click(object sender, EventArgs e)
        {
            comboBox_numInscription.SelectedIndex = -1;
            textBox_Nom_Prenom.Text = "";
            comboBox_Modules.SelectedIndex = -1;
            textBox_Notes.Text = "";
            dataGridView_Notes.DataSource = null;
        }

        /// <summary>
        /// Listener of the button "Enrengistrer" : register the grade of a student & check if conditions are good
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_enrengNotes_Click(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(textBox_Notes.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox_Notes.Text = "";
            }
            else
            {
                float noteEtu = float.Parse(textBox_Notes.Text.ToString());

                int numEtu = int.Parse(comboBox_numInscription.SelectedItem.ToString());
                int numMod = getNumModule(comboBox_Modules.SelectedItem.ToString());

                //Check all conditions before inserting the grade

                // 1 : text fields not empty
                if (comboBox_numInscription.Text == "" || textBox_Nom_Prenom.Text == "" || comboBox_Modules.Text == "" || textBox_Notes.Text == "")
                {
                    MessageBox.Show("empty fields", "empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // 2 : valid item selected for numEtu
                else if (comboBox_numInscription.SelectedIndex == -1)
                {
                    MessageBox.Show("no num inscription selected", "no num inscription selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // 3 : valid item selected for module
                else if (comboBox_Modules.SelectedIndex == -1)
                {
                    MessageBox.Show("no module selected", "no module selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // 4 : the grade already exists
                else if (getNoteEtudiant(numEtu, numMod) != -1)
                {
                    MessageBox.Show("grade already exists", "grade already exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // everything is ok : we can insert the grade
                else
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    //SqlCommand cmd = new SqlCommand("insert into [Notes] values ('" + numEtu + "','" + numMod + "','" + noteEtu + "')", connection);
                    cmd.CommandText = "INSERT INTO [Notes] VALUES (@numEtu,@numMod,@noteEtu)";
                    cmd.Parameters.AddWithValue("@numEtu", numEtu);
                    cmd.Parameters.AddWithValue("@numMod", numMod);
                    cmd.Parameters.AddWithValue("@noteEtu", noteEtu);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("grade registered", "grade registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // close connection & refresh the list
                    connection.Close();
                    button_apercu.PerformClick();
                }

            }
            
        }

        /// <summary>
        /// Listener of the button "Modifier Notes" : change the grade of a student in a given module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_modifierNote_Click(object sender, EventArgs e)
        {
            float noteEtu = float.Parse(textBox_Notes.Text.ToString());

            int numEtu = int.Parse(comboBox_numInscription.SelectedItem.ToString());
            int numMod = getNumModule(comboBox_Modules.SelectedItem.ToString());

            //Check all conditions before changing the grade
            // 1 : text fields not empty
            if (comboBox_numInscription.Text == "" || textBox_Nom_Prenom.Text == "" || comboBox_Modules.Text == "" || textBox_Notes.Text == "")
            {
                MessageBox.Show("empty fields", "empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 2 : valid item selected for numEtu
            else if (comboBox_numInscription.SelectedIndex == -1)
            {
                MessageBox.Show("no num inscription selected", "no num inscription selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 3 : valid item selected for module
            else if (comboBox_Modules.SelectedIndex == -1)
            {
                MessageBox.Show("no module selected", "no module selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // everything is ok : we can change the grade
            else
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE [Notes] SET Note = @noteEtu Where Num_Etu = @numEtu and Num_Mod = @numMod";
                cmd.Parameters.AddWithValue("@noteEtu", noteEtu);
                cmd.Parameters.AddWithValue("@numEtu", numEtu);
                cmd.Parameters.AddWithValue("@numMod", numMod);
                cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("no grade modified", "no grade modified", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("grade modified", "grade modified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //close connection & refresh the dataGridView
                    connection.Close();
                    button_apercu.PerformClick();
                }

            }
        }

        /// <summary>
        /// Listener of button "Apercu" : display the grade of the selected student indise the DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_apercu_Click(object sender, EventArgs e)
        {
            // If a student is selected
            if (comboBox_numInscription.SelectedIndex != -1)
            {
                int numEtu = int.Parse(comboBox_numInscription.SelectedItem.ToString());
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT m.Nom_Mod, n.Note FROM [Notes] n INNER JOIN [Module] m ON m.Num_Mod = n.Num_Mod WHERE Num_Etu = " + numEtu, connection);
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dataGridView_Notes.DataSource = null;
                dataGridView_Notes.DataSource = dataTable;
                dataReader.Close();
                connection.Close();
            }
        }

        private void button_quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_Notes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
