
namespace TPNOTE2
{
    partial class Gestion_Notes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_numInscription = new System.Windows.Forms.ComboBox();
            this.textBox_Nom_Prenom = new System.Windows.Forms.TextBox();
            this.comboBox_Modules = new System.Windows.Forms.ComboBox();
            this.textBox_Notes = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_nouveau = new System.Windows.Forms.Button();
            this.button_enrengNotes = new System.Windows.Forms.Button();
            this.button_modifierNote = new System.Windows.Forms.Button();
            this.button_apercu = new System.Windows.Forms.Button();
            this.button_quitter = new System.Windows.Forms.Button();
            this.dataGridView_Notes = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Notes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Notes);
            this.groupBox1.Controls.Add(this.comboBox_Modules);
            this.groupBox1.Controls.Add(this.textBox_Nom_Prenom);
            this.groupBox1.Controls.Add(this.comboBox_numInscription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numéro d\'inscription";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom et Prénom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Module";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Note";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBox_numInscription
            // 
            this.comboBox_numInscription.FormattingEnabled = true;
            this.comboBox_numInscription.Location = new System.Drawing.Point(247, 29);
            this.comboBox_numInscription.Name = "comboBox_numInscription";
            this.comboBox_numInscription.Size = new System.Drawing.Size(177, 24);
            this.comboBox_numInscription.TabIndex = 4;
            this.comboBox_numInscription.SelectedIndexChanged += new System.EventHandler(this.comboBox_numInscription_SelectedIndexChanged);
            // 
            // textBox_Nom_Prenom
            // 
            this.textBox_Nom_Prenom.Location = new System.Drawing.Point(245, 64);
            this.textBox_Nom_Prenom.Name = "textBox_Nom_Prenom";
            this.textBox_Nom_Prenom.Size = new System.Drawing.Size(178, 22);
            this.textBox_Nom_Prenom.TabIndex = 5;
            this.textBox_Nom_Prenom.TextChanged += new System.EventHandler(this.textBox_Nom_Prenom_TextChanged);
            // 
            // comboBox_Modules
            // 
            this.comboBox_Modules.FormattingEnabled = true;
            this.comboBox_Modules.Location = new System.Drawing.Point(245, 99);
            this.comboBox_Modules.Name = "comboBox_Modules";
            this.comboBox_Modules.Size = new System.Drawing.Size(177, 24);
            this.comboBox_Modules.TabIndex = 6;
            this.comboBox_Modules.SelectedIndexChanged += new System.EventHandler(this.comboBox_Modules_SelectedIndexChanged);
            // 
            // textBox_Notes
            // 
            this.textBox_Notes.Location = new System.Drawing.Point(244, 134);
            this.textBox_Notes.Name = "textBox_Notes";
            this.textBox_Notes.Size = new System.Drawing.Size(178, 22);
            this.textBox_Notes.TabIndex = 7;
            this.textBox_Notes.TextChanged += new System.EventHandler(this.textBox_Notes_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_quitter);
            this.groupBox2.Controls.Add(this.button_apercu);
            this.groupBox2.Controls.Add(this.button_modifierNote);
            this.groupBox2.Controls.Add(this.button_enrengNotes);
            this.groupBox2.Controls.Add(this.button_nouveau);
            this.groupBox2.Location = new System.Drawing.Point(550, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 259);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // button_nouveau
            // 
            this.button_nouveau.Location = new System.Drawing.Point(15, 22);
            this.button_nouveau.Name = "button_nouveau";
            this.button_nouveau.Size = new System.Drawing.Size(356, 36);
            this.button_nouveau.TabIndex = 0;
            this.button_nouveau.Text = "Nouveau";
            this.button_nouveau.UseVisualStyleBackColor = true;
            this.button_nouveau.Click += new System.EventHandler(this.button_nouveau_Click);
            // 
            // button_enrengNotes
            // 
            this.button_enrengNotes.Location = new System.Drawing.Point(15, 67);
            this.button_enrengNotes.Name = "button_enrengNotes";
            this.button_enrengNotes.Size = new System.Drawing.Size(356, 36);
            this.button_enrengNotes.TabIndex = 1;
            this.button_enrengNotes.Text = "Enregistrer Note";
            this.button_enrengNotes.UseVisualStyleBackColor = true;
            this.button_enrengNotes.Click += new System.EventHandler(this.button_enrengNotes_Click);
            // 
            // button_modifierNote
            // 
            this.button_modifierNote.Location = new System.Drawing.Point(15, 111);
            this.button_modifierNote.Name = "button_modifierNote";
            this.button_modifierNote.Size = new System.Drawing.Size(356, 36);
            this.button_modifierNote.TabIndex = 2;
            this.button_modifierNote.Text = "Modifier Note";
            this.button_modifierNote.UseVisualStyleBackColor = true;
            this.button_modifierNote.Click += new System.EventHandler(this.button_modifierNote_Click);
            // 
            // button_apercu
            // 
            this.button_apercu.Location = new System.Drawing.Point(15, 159);
            this.button_apercu.Name = "button_apercu";
            this.button_apercu.Size = new System.Drawing.Size(356, 36);
            this.button_apercu.TabIndex = 3;
            this.button_apercu.Text = "Apercu";
            this.button_apercu.UseVisualStyleBackColor = true;
            this.button_apercu.Click += new System.EventHandler(this.button_apercu_Click);
            // 
            // button_quitter
            // 
            this.button_quitter.Location = new System.Drawing.Point(15, 207);
            this.button_quitter.Name = "button_quitter";
            this.button_quitter.Size = new System.Drawing.Size(356, 36);
            this.button_quitter.TabIndex = 4;
            this.button_quitter.Text = "Quitter";
            this.button_quitter.UseVisualStyleBackColor = true;
            this.button_quitter.Click += new System.EventHandler(this.button_quitter_Click);
            // 
            // dataGridView_Notes
            // 
            this.dataGridView_Notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Notes.Location = new System.Drawing.Point(12, 288);
            this.dataGridView_Notes.Name = "dataGridView_Notes";
            this.dataGridView_Notes.RowHeadersWidth = 51;
            this.dataGridView_Notes.RowTemplate.Height = 24;
            this.dataGridView_Notes.Size = new System.Drawing.Size(924, 176);
            this.dataGridView_Notes.TabIndex = 2;
            this.dataGridView_Notes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Notes_CellContentClick);
            // 
            // Gestion_Notes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dataGridView_Notes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Gestion_Notes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Gestion_Notes";
            this.Load += new System.EventHandler(this.Gestion_Notes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Notes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Notes;
        private System.Windows.Forms.ComboBox comboBox_Modules;
        private System.Windows.Forms.TextBox textBox_Nom_Prenom;
        private System.Windows.Forms.ComboBox comboBox_numInscription;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_quitter;
        private System.Windows.Forms.Button button_apercu;
        private System.Windows.Forms.Button button_modifierNote;
        private System.Windows.Forms.Button button_enrengNotes;
        private System.Windows.Forms.Button button_nouveau;
        private System.Windows.Forms.DataGridView dataGridView_Notes;
    }
}