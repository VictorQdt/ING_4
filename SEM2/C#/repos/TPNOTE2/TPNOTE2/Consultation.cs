using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace TPNOTE2
{
    public partial class Consultation : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\victo\Documents\ING_4\SEM2\C#\repos\TPNOTE2\TPNOTE2\DatabaseTP2.mdf;Integrated Security=True");
        /// <summary>
        /// Function to get the id of a module given its name
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
        /// <summary>
        /// Constructor that fills the combo boxes from the database
        /// </summary>
        public Consultation()
        {
            
            InitializeComponent();
            textBox1.ReadOnly = true;
            connection.Open();
            SqlCommand command1 = new SqlCommand();
            String request1 = "select Nom_Mod from Module";
            command1.CommandText = request1;
            command1.Connection = connection;
            SqlDataReader dr1 = command1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1.GetValue(0).ToString());
            }
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            
        }
        /// <summary>
        /// On selection of an item, shows the grades from all students and the average grade of the class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int moduleNum = getNumModule(comboBox1.SelectedItem.ToString());
            var moyenneList = new List<float>();
            connection.Open();
            SqlCommand command = new SqlCommand();
            String request = "select E.Num_Etu, Nom_Etu, Prenom_Etu, Note FROM  Etudiant E, Notes N WHERE E.Num_Etu = N.Num_Etu AND N.Num_Mod = @p1";
            command.Parameters.AddWithValue("P1", moduleNum);
            command.CommandText = request;
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();
            DataTable dt = new DataTable();
            ///Loads the grade in the datatable
            dt.Load(dr);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dr.Close();
            SqlCommand command1 = new SqlCommand();
            String request1 = "select E.Num_Etu, Nom_Etu, Prenom_Etu, Note FROM  Etudiant E, Notes N WHERE E.Num_Etu = N.Num_Etu AND N.Num_Mod = @p1";
            command1.Parameters.AddWithValue("P1", moduleNum);
            command1.CommandText = request;
            command1.Connection = connection;
            SqlDataReader dr1 = command1.ExecuteReader();
            /// get the average grade of the class and put its in moyenne classe 
            while (dr1.Read())
            {
                moyenneList.Add(float.Parse(dr1.GetValue(3).ToString()));
            }
            dr1.Close();
            connection.Close();
            if (moyenneList.Any())
            {
                float moyenne = moyenneList.Average();
                textBox1.Text = moyenne.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
