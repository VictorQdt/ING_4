
namespace DataBase
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
            this.cINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRENOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vILLEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testDataSet = new DataBase.TestDataSet();
            this.tableTableAdapter = new DataBase.TestDataSetTableAdapters.TableTableAdapter();
            this.label_cin = new System.Windows.Forms.Label();
            this.label_nom = new System.Windows.Forms.Label();
            this.label_prenom = new System.Windows.Forms.Label();
            this.label_ville = new System.Windows.Forms.Label();
            this.label_tel = new System.Windows.Forms.Label();
            this.label_num = new System.Windows.Forms.Label();
            this.label_slash = new System.Windows.Forms.Label();
            this.label_total = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.text_cin = new System.Windows.Forms.TextBox();
            this.text_nom = new System.Windows.Forms.TextBox();
            this.text_prenom = new System.Windows.Forms.TextBox();
            this.text_ville = new System.Windows.Forms.TextBox();
            this.text_tel = new System.Windows.Forms.TextBox();
            this.btn_premier = new System.Windows.Forms.Button();
            this.btn_suivant = new System.Windows.Forms.Button();
            this.btn_precedent = new System.Windows.Forms.Button();
            this.btn_dernier = new System.Windows.Forms.Button();
            this.btn_quitter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_nouveau = new System.Windows.Forms.Button();
            this.btn_rechercher = new System.Windows.Forms.Button();
            this.btn_ajouter = new System.Windows.Forms.Button();
            this.btn_modifier = new System.Windows.Forms.Button();
            this.btn_supprimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cINDataGridViewTextBoxColumn,
            this.nOMDataGridViewTextBoxColumn,
            this.pRENOMDataGridViewTextBoxColumn,
            this.vILLEDataGridViewTextBoxColumn,
            this.tELDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(122, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // cINDataGridViewTextBoxColumn
            // 
            this.cINDataGridViewTextBoxColumn.DataPropertyName = "CIN";
            this.cINDataGridViewTextBoxColumn.HeaderText = "CIN";
            this.cINDataGridViewTextBoxColumn.Name = "cINDataGridViewTextBoxColumn";
            // 
            // nOMDataGridViewTextBoxColumn
            // 
            this.nOMDataGridViewTextBoxColumn.DataPropertyName = "NOM";
            this.nOMDataGridViewTextBoxColumn.HeaderText = "NOM";
            this.nOMDataGridViewTextBoxColumn.Name = "nOMDataGridViewTextBoxColumn";
            // 
            // pRENOMDataGridViewTextBoxColumn
            // 
            this.pRENOMDataGridViewTextBoxColumn.DataPropertyName = "PRENOM";
            this.pRENOMDataGridViewTextBoxColumn.HeaderText = "PRENOM";
            this.pRENOMDataGridViewTextBoxColumn.Name = "pRENOMDataGridViewTextBoxColumn";
            // 
            // vILLEDataGridViewTextBoxColumn
            // 
            this.vILLEDataGridViewTextBoxColumn.DataPropertyName = "VILLE";
            this.vILLEDataGridViewTextBoxColumn.HeaderText = "VILLE";
            this.vILLEDataGridViewTextBoxColumn.Name = "vILLEDataGridViewTextBoxColumn";
            // 
            // tELDataGridViewTextBoxColumn
            // 
            this.tELDataGridViewTextBoxColumn.DataPropertyName = "TEL";
            this.tELDataGridViewTextBoxColumn.HeaderText = "TEL";
            this.tELDataGridViewTextBoxColumn.Name = "tELDataGridViewTextBoxColumn";
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this.testDataSet;
            // 
            // testDataSet
            // 
            this.testDataSet.DataSetName = "TestDataSet";
            this.testDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // label_cin
            // 
            this.label_cin.AutoSize = true;
            this.label_cin.Location = new System.Drawing.Point(131, 26);
            this.label_cin.Name = "label_cin";
            this.label_cin.Size = new System.Drawing.Size(25, 13);
            this.label_cin.TabIndex = 1;
            this.label_cin.Text = "CIN";
            // 
            // label_nom
            // 
            this.label_nom.AutoSize = true;
            this.label_nom.Location = new System.Drawing.Point(131, 66);
            this.label_nom.Name = "label_nom";
            this.label_nom.Size = new System.Drawing.Size(32, 13);
            this.label_nom.TabIndex = 2;
            this.label_nom.Text = "NOM";
            // 
            // label_prenom
            // 
            this.label_prenom.AutoSize = true;
            this.label_prenom.Location = new System.Drawing.Point(128, 103);
            this.label_prenom.Name = "label_prenom";
            this.label_prenom.Size = new System.Drawing.Size(54, 13);
            this.label_prenom.TabIndex = 3;
            this.label_prenom.Text = "PRENOM";
            // 
            // label_ville
            // 
            this.label_ville.AutoSize = true;
            this.label_ville.Location = new System.Drawing.Point(131, 145);
            this.label_ville.Name = "label_ville";
            this.label_ville.Size = new System.Drawing.Size(36, 13);
            this.label_ville.TabIndex = 4;
            this.label_ville.Text = "VILLE";
            // 
            // label_tel
            // 
            this.label_tel.AutoSize = true;
            this.label_tel.Location = new System.Drawing.Point(131, 188);
            this.label_tel.Name = "label_tel";
            this.label_tel.Size = new System.Drawing.Size(27, 13);
            this.label_tel.TabIndex = 5;
            this.label_tel.Text = "TEL";
            // 
            // label_num
            // 
            this.label_num.AutoSize = true;
            this.label_num.Location = new System.Drawing.Point(546, 115);
            this.label_num.Name = "label_num";
            this.label_num.Size = new System.Drawing.Size(0, 13);
            this.label_num.TabIndex = 6;
            // 
            // label_slash
            // 
            this.label_slash.AutoSize = true;
            this.label_slash.Location = new System.Drawing.Point(578, 115);
            this.label_slash.Name = "label_slash";
            this.label_slash.Size = new System.Drawing.Size(12, 13);
            this.label_slash.TabIndex = 7;
            this.label_slash.Text = "/";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(610, 115);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(0, 13);
            this.label_total.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.text_tel);
            this.groupBox1.Controls.Add(this.text_ville);
            this.groupBox1.Controls.Add(this.text_prenom);
            this.groupBox1.Controls.Add(this.text_nom);
            this.groupBox1.Controls.Add(this.text_cin);
            this.groupBox1.Location = new System.Drawing.Point(226, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 206);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // text_cin
            // 
            this.text_cin.Location = new System.Drawing.Point(0, 11);
            this.text_cin.Name = "text_cin";
            this.text_cin.Size = new System.Drawing.Size(100, 20);
            this.text_cin.TabIndex = 0;
            // 
            // text_nom
            // 
            this.text_nom.Location = new System.Drawing.Point(0, 46);
            this.text_nom.Name = "text_nom";
            this.text_nom.Size = new System.Drawing.Size(100, 20);
            this.text_nom.TabIndex = 1;
            // 
            // text_prenom
            // 
            this.text_prenom.Location = new System.Drawing.Point(2, 83);
            this.text_prenom.Name = "text_prenom";
            this.text_prenom.Size = new System.Drawing.Size(100, 20);
            this.text_prenom.TabIndex = 2;
            // 
            // text_ville
            // 
            this.text_ville.Location = new System.Drawing.Point(0, 125);
            this.text_ville.Name = "text_ville";
            this.text_ville.Size = new System.Drawing.Size(100, 20);
            this.text_ville.TabIndex = 3;
            // 
            // text_tel
            // 
            this.text_tel.Location = new System.Drawing.Point(0, 168);
            this.text_tel.Name = "text_tel";
            this.text_tel.Size = new System.Drawing.Size(100, 20);
            this.text_tel.TabIndex = 4;
            // 
            // btn_premier
            // 
            this.btn_premier.Location = new System.Drawing.Point(122, 234);
            this.btn_premier.Name = "btn_premier";
            this.btn_premier.Size = new System.Drawing.Size(75, 23);
            this.btn_premier.TabIndex = 10;
            this.btn_premier.Text = "premier";
            this.btn_premier.UseVisualStyleBackColor = true;
            this.btn_premier.Click += new System.EventHandler(this.btn_premier_Click);
            // 
            // btn_suivant
            // 
            this.btn_suivant.Location = new System.Drawing.Point(413, 234);
            this.btn_suivant.Name = "btn_suivant";
            this.btn_suivant.Size = new System.Drawing.Size(75, 23);
            this.btn_suivant.TabIndex = 11;
            this.btn_suivant.Text = "suivant";
            this.btn_suivant.UseVisualStyleBackColor = true;
            this.btn_suivant.Click += new System.EventHandler(this.btn_suivant_Click);
            // 
            // btn_precedent
            // 
            this.btn_precedent.Location = new System.Drawing.Point(264, 234);
            this.btn_precedent.Name = "btn_precedent";
            this.btn_precedent.Size = new System.Drawing.Size(75, 23);
            this.btn_precedent.TabIndex = 12;
            this.btn_precedent.Text = "precedent";
            this.btn_precedent.UseVisualStyleBackColor = true;
            this.btn_precedent.Click += new System.EventHandler(this.btn_precedent_Click);
            // 
            // btn_dernier
            // 
            this.btn_dernier.Location = new System.Drawing.Point(591, 234);
            this.btn_dernier.Name = "btn_dernier";
            this.btn_dernier.Size = new System.Drawing.Size(75, 23);
            this.btn_dernier.TabIndex = 13;
            this.btn_dernier.Text = "dernier";
            this.btn_dernier.UseVisualStyleBackColor = true;
            this.btn_dernier.Click += new System.EventHandler(this.btn_dernier_Click);
            // 
            // btn_quitter
            // 
            this.btn_quitter.Location = new System.Drawing.Point(66, 166);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(75, 23);
            this.btn_quitter.TabIndex = 14;
            this.btn_quitter.Text = "quitter";
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.btn_quitter_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_supprimer);
            this.groupBox2.Controls.Add(this.btn_modifier);
            this.groupBox2.Controls.Add(this.btn_ajouter);
            this.groupBox2.Controls.Add(this.btn_rechercher);
            this.groupBox2.Controls.Add(this.btn_nouveau);
            this.groupBox2.Controls.Add(this.btn_quitter);
            this.groupBox2.Location = new System.Drawing.Point(449, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 195);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // btn_nouveau
            // 
            this.btn_nouveau.Location = new System.Drawing.Point(66, 11);
            this.btn_nouveau.Name = "btn_nouveau";
            this.btn_nouveau.Size = new System.Drawing.Size(75, 23);
            this.btn_nouveau.TabIndex = 15;
            this.btn_nouveau.Text = "nouveau";
            this.btn_nouveau.UseVisualStyleBackColor = true;
            this.btn_nouveau.Click += new System.EventHandler(this.btn_nouveau_Click);
            // 
            // btn_rechercher
            // 
            this.btn_rechercher.Location = new System.Drawing.Point(66, 41);
            this.btn_rechercher.Name = "btn_rechercher";
            this.btn_rechercher.Size = new System.Drawing.Size(75, 23);
            this.btn_rechercher.TabIndex = 16;
            this.btn_rechercher.Text = "rechercher";
            this.btn_rechercher.UseVisualStyleBackColor = true;
            this.btn_rechercher.Click += new System.EventHandler(this.btn_rechercher_Click);
            // 
            // btn_ajouter
            // 
            this.btn_ajouter.Location = new System.Drawing.Point(66, 74);
            this.btn_ajouter.Name = "btn_ajouter";
            this.btn_ajouter.Size = new System.Drawing.Size(75, 23);
            this.btn_ajouter.TabIndex = 17;
            this.btn_ajouter.Text = "ajouter";
            this.btn_ajouter.UseVisualStyleBackColor = true;
            this.btn_ajouter.Click += new System.EventHandler(this.btn_ajouter_Click);
            // 
            // btn_modifier
            // 
            this.btn_modifier.Location = new System.Drawing.Point(66, 108);
            this.btn_modifier.Name = "btn_modifier";
            this.btn_modifier.Size = new System.Drawing.Size(75, 23);
            this.btn_modifier.TabIndex = 18;
            this.btn_modifier.Text = "modifier";
            this.btn_modifier.UseVisualStyleBackColor = true;
            this.btn_modifier.Click += new System.EventHandler(this.btn_modifier_Click);
            // 
            // btn_supprimer
            // 
            this.btn_supprimer.Location = new System.Drawing.Point(66, 138);
            this.btn_supprimer.Name = "btn_supprimer";
            this.btn_supprimer.Size = new System.Drawing.Size(75, 23);
            this.btn_supprimer.TabIndex = 19;
            this.btn_supprimer.Text = "supprimer";
            this.btn_supprimer.UseVisualStyleBackColor = true;
            this.btn_supprimer.Click += new System.EventHandler(this.btn_supprimer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_dernier);
            this.Controls.Add(this.btn_precedent);
            this.Controls.Add(this.btn_suivant);
            this.Controls.Add(this.btn_premier);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.label_slash);
            this.Controls.Add(this.label_num);
            this.Controls.Add(this.label_tel);
            this.Controls.Add(this.label_ville);
            this.Controls.Add(this.label_prenom);
            this.Controls.Add(this.label_nom);
            this.Controls.Add(this.label_cin);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private TestDataSet testDataSet;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private TestDataSetTableAdapters.TableTableAdapter tableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cINDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRENOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vILLEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tELDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label_cin;
        private System.Windows.Forms.Label label_nom;
        private System.Windows.Forms.Label label_prenom;
        private System.Windows.Forms.Label label_ville;
        private System.Windows.Forms.Label label_tel;
        private System.Windows.Forms.Label label_num;
        private System.Windows.Forms.Label label_slash;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox text_tel;
        private System.Windows.Forms.TextBox text_ville;
        private System.Windows.Forms.TextBox text_prenom;
        private System.Windows.Forms.TextBox text_nom;
        private System.Windows.Forms.TextBox text_cin;
        private System.Windows.Forms.Button btn_premier;
        private System.Windows.Forms.Button btn_suivant;
        private System.Windows.Forms.Button btn_precedent;
        private System.Windows.Forms.Button btn_dernier;
        private System.Windows.Forms.Button btn_quitter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_supprimer;
        private System.Windows.Forms.Button btn_modifier;
        private System.Windows.Forms.Button btn_ajouter;
        private System.Windows.Forms.Button btn_rechercher;
        private System.Windows.Forms.Button btn_nouveau;
    }
}

