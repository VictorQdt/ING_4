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

namespace DataBaseEmission
{
    public partial class Form1 : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Emissions.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'emissionsDataSet.Table'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //this.tableTableAdapter.Fill(this.emissionsDataSet.Table);
            initialiser();

        }

        private void initialiser()   //procédure qui permet de charger le contenu de la table client dans le Datagridview
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


        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_rechercher_Click(object sender, EventArgs e)
        {
            if (text_mot_cle.Text == "" && radioButton_date.Checked == false && radioButton_date_TOUT.Checked == false && radioButton_duree_TOUT.Checked == false && radioButton_duree_20.Checked == false && radioButton_duree_20_40.Checked == false && radioButton_duree_40.Checked == false && comboBox_type.SelectedIndex == -1)
            {
                dataGridView1.DataSource = null;
                label_nb_em.Text = "";
                MessageBox.Show("Aucun filtre selectionné!!", "Filtre", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string req, req1 = "", req2 = "", req3 = "", req4 = "";
                req = "select * from [table] where 1=1 ";

                if (text_mot_cle.Text != "")
                    req1 = " and nom like'%" + text_mot_cle.Text + "%'";

                if (radioButton_date.Checked)
                    req2 = " and dateemission='" + dateTimePicker1.Value.ToShortDateString() + "'";

                if (radioButton_duree_20.Checked)
                    req3 = " and duree<20";
                if (radioButton_duree_20_40.Checked)
                    req3 = " and duree between 20 and 40";
                if (radioButton_duree_40.Checked)
                    req3 = " and duree>40";

                if (comboBox_type.SelectedIndex != -1 && comboBox_type.SelectedIndex != 0)
                    req4 = " and type='" + comboBox_type.SelectedItem + "'";

                req = req + req1 + req2 + req3 + req4;
                MessageBox.Show(req);

                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = req;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = t;
                label_nb_em.Text = t.Rows.Count + " Emission(s) trouvées"; //Nombre des lignes dans le DataTable
                dr.Close();
                connection.Close();

            }
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            text_mot_cle.Text = "";
            comboBox_type.SelectedIndex = -1;
            label_nb_em.Text = ""; //Nombre des emissions
            dataGridView1.DataSource = null;
            radioButton_date.Checked = false;
            radioButton_date_TOUT.Checked = false;
            radioButton_duree_20.Checked = false;
            radioButton_duree_20_40.Checked = false;
            radioButton_duree_40.Checked = false;
            radioButton_duree_TOUT.Checked = false;
        }
    }
}
