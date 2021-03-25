
namespace DataBaseEmission
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numEmissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEmissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dureeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeEmissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emissionsDataSet = new DataBaseEmission.EmissionsDataSet();
            this.tableTableAdapter = new DataBaseEmission.EmissionsDataSetTableAdapters.TableTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_duree_40 = new System.Windows.Forms.RadioButton();
            this.radioButton_duree_20_40 = new System.Windows.Forms.RadioButton();
            this.radioButton_duree_20 = new System.Windows.Forms.RadioButton();
            this.radioButton_duree_TOUT = new System.Windows.Forms.RadioButton();
            this.text_mot_cle = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioButton_date_TOUT = new System.Windows.Forms.RadioButton();
            this.label_type = new System.Windows.Forms.Label();
            this.label_duree = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.label_mot_clef = new System.Windows.Forms.Label();
            this.btn_rechercher = new System.Windows.Forms.Button();
            this.btn_annuler = new System.Windows.Forms.Button();
            this.radioButton_date = new System.Windows.Forms.RadioButton();
            this.label_nb_em = new System.Windows.Forms.Label();
            this.label_emissions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emissionsDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numEmissionDataGridViewTextBoxColumn,
            this.nomDataGridViewTextBoxColumn,
            this.dateEmissionDataGridViewTextBoxColumn,
            this.dureeDataGridViewTextBoxColumn,
            this.typeEmissionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(133, 342);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(546, 136);
            this.dataGridView1.TabIndex = 0;
            // 
            // numEmissionDataGridViewTextBoxColumn
            // 
            this.numEmissionDataGridViewTextBoxColumn.DataPropertyName = "NumEmission";
            this.numEmissionDataGridViewTextBoxColumn.HeaderText = "NumEmission";
            this.numEmissionDataGridViewTextBoxColumn.Name = "numEmissionDataGridViewTextBoxColumn";
            // 
            // nomDataGridViewTextBoxColumn
            // 
            this.nomDataGridViewTextBoxColumn.DataPropertyName = "Nom";
            this.nomDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.nomDataGridViewTextBoxColumn.Name = "nomDataGridViewTextBoxColumn";
            // 
            // dateEmissionDataGridViewTextBoxColumn
            // 
            this.dateEmissionDataGridViewTextBoxColumn.DataPropertyName = "DateEmission";
            this.dateEmissionDataGridViewTextBoxColumn.HeaderText = "DateEmission";
            this.dateEmissionDataGridViewTextBoxColumn.Name = "dateEmissionDataGridViewTextBoxColumn";
            // 
            // dureeDataGridViewTextBoxColumn
            // 
            this.dureeDataGridViewTextBoxColumn.DataPropertyName = "Duree";
            this.dureeDataGridViewTextBoxColumn.HeaderText = "Duree";
            this.dureeDataGridViewTextBoxColumn.Name = "dureeDataGridViewTextBoxColumn";
            // 
            // typeEmissionDataGridViewTextBoxColumn
            // 
            this.typeEmissionDataGridViewTextBoxColumn.DataPropertyName = "TypeEmission";
            this.typeEmissionDataGridViewTextBoxColumn.HeaderText = "TypeEmission";
            this.typeEmissionDataGridViewTextBoxColumn.Name = "typeEmissionDataGridViewTextBoxColumn";
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this.emissionsDataSet;
            // 
            // emissionsDataSet
            // 
            this.emissionsDataSet.DataSetName = "EmissionsDataSet";
            this.emissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_type);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.text_mot_cle);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label_type);
            this.groupBox1.Controls.Add(this.label_duree);
            this.groupBox1.Controls.Add(this.label_date);
            this.groupBox1.Controls.Add(this.label_mot_clef);
            this.groupBox1.Location = new System.Drawing.Point(32, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choisir un filtre et rechercher";
            // 
            // comboBox_type
            // 
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "TOUT",
            "Journal",
            "Documentaire",
            "Film",
            "Serie",
            "Sport",
            "Divers",
            "Fun"});
            this.comboBox_type.Location = new System.Drawing.Point(593, 72);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(121, 21);
            this.comboBox_type.TabIndex = 7;
            this.comboBox_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_type_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton_duree_40);
            this.groupBox3.Controls.Add(this.radioButton_duree_20_40);
            this.groupBox3.Controls.Add(this.radioButton_duree_20);
            this.groupBox3.Controls.Add(this.radioButton_duree_TOUT);
            this.groupBox3.Location = new System.Drawing.Point(401, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(149, 163);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // radioButton_duree_40
            // 
            this.radioButton_duree_40.AutoSize = true;
            this.radioButton_duree_40.Location = new System.Drawing.Point(7, 140);
            this.radioButton_duree_40.Name = "radioButton_duree_40";
            this.radioButton_duree_40.Size = new System.Drawing.Size(62, 17);
            this.radioButton_duree_40.TabIndex = 3;
            this.radioButton_duree_40.TabStop = true;
            this.radioButton_duree_40.Text = "> 40min";
            this.radioButton_duree_40.UseVisualStyleBackColor = true;
            // 
            // radioButton_duree_20_40
            // 
            this.radioButton_duree_20_40.AutoSize = true;
            this.radioButton_duree_20_40.Location = new System.Drawing.Point(6, 102);
            this.radioButton_duree_20_40.Name = "radioButton_duree_20_40";
            this.radioButton_duree_20_40.Size = new System.Drawing.Size(90, 17);
            this.radioButton_duree_20_40.TabIndex = 2;
            this.radioButton_duree_20_40.TabStop = true;
            this.radioButton_duree_20_40.Text = "20min - 40min";
            this.radioButton_duree_20_40.UseVisualStyleBackColor = true;
            // 
            // radioButton_duree_20
            // 
            this.radioButton_duree_20.AutoSize = true;
            this.radioButton_duree_20.Location = new System.Drawing.Point(7, 61);
            this.radioButton_duree_20.Name = "radioButton_duree_20";
            this.radioButton_duree_20.Size = new System.Drawing.Size(65, 17);
            this.radioButton_duree_20.TabIndex = 1;
            this.radioButton_duree_20.TabStop = true;
            this.radioButton_duree_20.Text = "< 20 min";
            this.radioButton_duree_20.UseVisualStyleBackColor = true;
            // 
            // radioButton_duree_TOUT
            // 
            this.radioButton_duree_TOUT.AutoSize = true;
            this.radioButton_duree_TOUT.Location = new System.Drawing.Point(7, 20);
            this.radioButton_duree_TOUT.Name = "radioButton_duree_TOUT";
            this.radioButton_duree_TOUT.Size = new System.Drawing.Size(55, 17);
            this.radioButton_duree_TOUT.TabIndex = 0;
            this.radioButton_duree_TOUT.TabStop = true;
            this.radioButton_duree_TOUT.Text = "TOUT";
            this.radioButton_duree_TOUT.UseVisualStyleBackColor = true;
            // 
            // text_mot_cle
            // 
            this.text_mot_cle.Location = new System.Drawing.Point(24, 72);
            this.text_mot_cle.Name = "text_mot_cle";
            this.text_mot_cle.Size = new System.Drawing.Size(100, 20);
            this.text_mot_cle.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_date);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.radioButton_date_TOUT);
            this.groupBox2.Location = new System.Drawing.Point(151, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(55, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(163, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // radioButton_date_TOUT
            // 
            this.radioButton_date_TOUT.AutoSize = true;
            this.radioButton_date_TOUT.Location = new System.Drawing.Point(17, 20);
            this.radioButton_date_TOUT.Name = "radioButton_date_TOUT";
            this.radioButton_date_TOUT.Size = new System.Drawing.Size(55, 17);
            this.radioButton_date_TOUT.TabIndex = 0;
            this.radioButton_date_TOUT.TabStop = true;
            this.radioButton_date_TOUT.Text = "TOUT";
            this.radioButton_date_TOUT.UseVisualStyleBackColor = true;
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(590, 33);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(35, 13);
            this.label_type.TabIndex = 3;
            this.label_type.Text = "TYPE";
            // 
            // label_duree
            // 
            this.label_duree.AutoSize = true;
            this.label_duree.Location = new System.Drawing.Point(398, 33);
            this.label_duree.Name = "label_duree";
            this.label_duree.Size = new System.Drawing.Size(45, 13);
            this.label_duree.TabIndex = 2;
            this.label_duree.Text = "DUREE";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(148, 33);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(91, 13);
            this.label_date.TabIndex = 1;
            this.label_date.Text = "DATE EMISSION";
            // 
            // label_mot_clef
            // 
            this.label_mot_clef.AutoSize = true;
            this.label_mot_clef.Location = new System.Drawing.Point(21, 33);
            this.label_mot_clef.Name = "label_mot_clef";
            this.label_mot_clef.Size = new System.Drawing.Size(54, 13);
            this.label_mot_clef.TabIndex = 0;
            this.label_mot_clef.Text = "MOT CLE";
            // 
            // btn_rechercher
            // 
            this.btn_rechercher.Location = new System.Drawing.Point(133, 299);
            this.btn_rechercher.Name = "btn_rechercher";
            this.btn_rechercher.Size = new System.Drawing.Size(75, 23);
            this.btn_rechercher.TabIndex = 2;
            this.btn_rechercher.Text = "rechercher";
            this.btn_rechercher.UseVisualStyleBackColor = true;
            this.btn_rechercher.Click += new System.EventHandler(this.btn_rechercher_Click);
            // 
            // btn_annuler
            // 
            this.btn_annuler.Location = new System.Drawing.Point(248, 299);
            this.btn_annuler.Name = "btn_annuler";
            this.btn_annuler.Size = new System.Drawing.Size(75, 23);
            this.btn_annuler.TabIndex = 3;
            this.btn_annuler.Text = "annuler";
            this.btn_annuler.UseVisualStyleBackColor = true;
            this.btn_annuler.Click += new System.EventHandler(this.btn_annuler_Click);
            // 
            // radioButton_date
            // 
            this.radioButton_date.AutoSize = true;
            this.radioButton_date.Location = new System.Drawing.Point(17, 67);
            this.radioButton_date.Name = "radioButton_date";
            this.radioButton_date.Size = new System.Drawing.Size(14, 13);
            this.radioButton_date.TabIndex = 2;
            this.radioButton_date.TabStop = true;
            this.radioButton_date.UseVisualStyleBackColor = true;
            // 
            // label_nb_em
            // 
            this.label_nb_em.AutoSize = true;
            this.label_nb_em.Location = new System.Drawing.Point(407, 299);
            this.label_nb_em.Name = "label_nb_em";
            this.label_nb_em.Size = new System.Drawing.Size(0, 13);
            this.label_nb_em.TabIndex = 4;
            // 
            // label_emissions
            // 
            this.label_emissions.AutoSize = true;
            this.label_emissions.Location = new System.Drawing.Point(439, 299);
            this.label_emissions.Name = "label_emissions";
            this.label_emissions.Size = new System.Drawing.Size(0, 13);
            this.label_emissions.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.label_emissions);
            this.Controls.Add(this.label_nb_em);
            this.Controls.Add(this.btn_annuler);
            this.Controls.Add(this.btn_rechercher);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emissionsDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private EmissionsDataSet emissionsDataSet;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private EmissionsDataSetTableAdapters.TableTableAdapter tableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn numEmissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEmissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dureeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeEmissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton_duree_40;
        private System.Windows.Forms.RadioButton radioButton_duree_20_40;
        private System.Windows.Forms.RadioButton radioButton_duree_20;
        private System.Windows.Forms.RadioButton radioButton_duree_TOUT;
        private System.Windows.Forms.TextBox text_mot_cle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radioButton_date_TOUT;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.Label label_duree;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label_mot_clef;
        private System.Windows.Forms.Button btn_rechercher;
        private System.Windows.Forms.Button btn_annuler;
        private System.Windows.Forms.RadioButton radioButton_date;
        private System.Windows.Forms.Label label_nb_em;
        private System.Windows.Forms.Label label_emissions;
    }
}

