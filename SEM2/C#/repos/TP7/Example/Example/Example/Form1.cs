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

namespace Example
{
    public partial class Form1 : Form
    {
     
        
        SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = Etudiant; Integrated Security = True");
    
        
        public Form1()
        {
            InitializeComponent();
         

        }
        public void affichage1()
        {
            SqlCommand command2 = new SqlCommand();
            String query2 = "select * from Etudiant1";
            command2.CommandText = query2;
            command2.Connection = connection;

            SqlDataReader dreader = command2.ExecuteReader();
            DataTable datatable = new DataTable();

            datatable.Load(dreader);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = datatable;
           
        }
        public void affichage2()
        {
            SqlCommand command3 = new SqlCommand();
            String query3 = "select * from Etudiant1";
            command3.CommandText = query3;
            command3.Connection = connection;

            DataSet dataset = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            dataAdapter.SelectCommand = command3;
            dataset.Clear();
            dataAdapter.Fill(dataset, "T1");

            dataGridView1.DataBindings.Clear();
            dataGridView1.DataBindings.Add("datasource", dataset, "T1");

            dataGridView1.DataBindings.Clear();
            dataGridView1.DataBindings.Add("text", dataset, "T1.ID");

            dataGridView1.DataBindings.Clear();
            dataGridView1.DataBindings.Add("text", dataset, "T1.Nom");

            dataGridView1.DataBindings.Clear();
            dataGridView1.DataBindings.Add("text", dataset, "T1.Prenom");

           
           


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            connection.Open();
            MessageBox.Show("l'etat de connexion :  " + connection.State, "Connexion");



        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand command1 = new SqlCommand();
            
            String query1 = "insert into Etudiant1 values(@p1,@p2,@p3)";

            command1.Parameters.AddWithValue("P1", textBox1.Text);
            command1.Parameters.AddWithValue("P2", textBox2.Text);
            command1.Parameters.AddWithValue("P3", textBox3.Text);
            command1.CommandText = query1;
            command1.Connection = connection;
            int x = command1.ExecuteNonQuery();
            if (x != 0)
                MessageBox.Show("bien Ajouté");
             affichage1();
            // affichage2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            affichage1();
            //affichage2();





            //    do
            //    {
            //        while (dreader.Read())
            //            MessageBox.Show(dreader.GetString(0)+ dreader.GetString(1)+dreader.GetString(2));

            //    }
            //    while (dreader.NextResult());

            //}
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
            MessageBox.Show("Etat de connexion " + connection.State);

        }
    }
}
