
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
            this.groupBox_FormGestionNotes = new System.Windows.Forms.GroupBox();
            this.comboBox_Modules = new System.Windows.Forms.ComboBox();
            this.comboBox_numInscription = new System.Windows.Forms.ComboBox();
            this.textBox_Notes = new System.Windows.Forms.TextBox();
            this.textBox_Nom_Prenom = new System.Windows.Forms.TextBox();
            this.label_Notes = new System.Windows.Forms.Label();
            this.label_Module = new System.Windows.Forms.Label();
            this.label_Nom_Prenom = new System.Windows.Forms.Label();
            this.label_numInscription = new System.Windows.Forms.Label();
            this.groupBox_Gestion_Notes_Buttons = new System.Windows.Forms.GroupBox();
            this.button_quitter = new System.Windows.Forms.Button();
            this.button_apercu = new System.Windows.Forms.Button();
            this.button_modifierNote = new System.Windows.Forms.Button();
            this.button_enrengNotes = new System.Windows.Forms.Button();
            this.button_nouveau = new System.Windows.Forms.Button();
            this.dataGridView_Notes = new System.Windows.Forms.DataGridView();
            this.groupBox_FormGestionNotes.SuspendLayout();
            this.groupBox_Gestion_Notes_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Notes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_FormGestionNotes
            // 
            this.groupBox_FormGestionNotes.Controls.Add(this.comboBox_Modules);
            this.groupBox_FormGestionNotes.Controls.Add(this.comboBox_numInscription);
            this.groupBox_FormGestionNotes.Controls.Add(this.textBox_Notes);
            this.groupBox_FormGestionNotes.Controls.Add(this.textBox_Nom_Prenom);
            this.groupBox_FormGestionNotes.Controls.Add(this.label_Notes);
            this.groupBox_FormGestionNotes.Controls.Add(this.label_Module);
            this.groupBox_FormGestionNotes.Controls.Add(this.label_Nom_Prenom);
            this.groupBox_FormGestionNotes.Controls.Add(this.label_numInscription);
            this.groupBox_FormGestionNotes.Location = new System.Drawing.Point(55, 54);
            this.groupBox_FormGestionNotes.Name = "groupBox_FormGestionNotes";
            this.groupBox_FormGestionNotes.Size = new System.Drawing.Size(324, 216);
            this.groupBox_FormGestionNotes.TabIndex = 0;
            this.groupBox_FormGestionNotes.TabStop = false;
            // 
            // comboBox_Modules
            // 
            this.comboBox_Modules.FormattingEnabled = true;
            this.comboBox_Modules.Location = new System.Drawing.Point(183, 113);
            this.comboBox_Modules.Name = "comboBox_Modules";
            this.comboBox_Modules.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Modules.TabIndex = 7;
            this.comboBox_Modules.SelectedIndexChanged += new System.EventHandler(this.comboBox_Modules_SelectedIndexChanged);
            // 
            // comboBox_numInscription
            // 
            this.comboBox_numInscription.FormattingEnabled = true;
            this.comboBox_numInscription.Location = new System.Drawing.Point(183, 26);
            this.comboBox_numInscription.Name = "comboBox_numInscription";
            this.comboBox_numInscription.Size = new System.Drawing.Size(121, 21);
            this.comboBox_numInscription.TabIndex = 6;
            this.comboBox_numInscription.SelectedIndexChanged += new System.EventHandler(this.comboBox_numInscription_SelectedIndexChanged);
            // 
            // textBox_Notes
            // 
            this.textBox_Notes.Location = new System.Drawing.Point(183, 154);
            this.textBox_Notes.Name = "textBox_Notes";
            this.textBox_Notes.Size = new System.Drawing.Size(121, 20);
            this.textBox_Notes.TabIndex = 5;
            // 
            // textBox_Nom_Prenom
            // 
            this.textBox_Nom_Prenom.Location = new System.Drawing.Point(183, 69);
            this.textBox_Nom_Prenom.Name = "textBox_Nom_Prenom";
            this.textBox_Nom_Prenom.Size = new System.Drawing.Size(121, 20);
            this.textBox_Nom_Prenom.TabIndex = 4;
            // 
            // label_Notes
            // 
            this.label_Notes.AutoSize = true;
            this.label_Notes.Location = new System.Drawing.Point(30, 161);
            this.label_Notes.Name = "label_Notes";
            this.label_Notes.Size = new System.Drawing.Size(35, 13);
            this.label_Notes.TabIndex = 3;
            this.label_Notes.Text = "Notes";
            // 
            // label_Module
            // 
            this.label_Module.AutoSize = true;
            this.label_Module.Location = new System.Drawing.Point(30, 116);
            this.label_Module.Name = "label_Module";
            this.label_Module.Size = new System.Drawing.Size(42, 13);
            this.label_Module.TabIndex = 2;
            this.label_Module.Text = "Module";
            // 
            // label_Nom_Prenom
            // 
            this.label_Nom_Prenom.AutoSize = true;
            this.label_Nom_Prenom.Location = new System.Drawing.Point(30, 72);
            this.label_Nom_Prenom.Name = "label_Nom_Prenom";
            this.label_Nom_Prenom.Size = new System.Drawing.Size(79, 13);
            this.label_Nom_Prenom.TabIndex = 1;
            this.label_Nom_Prenom.Text = "Nom et prénom";
            // 
            // label_numInscription
            // 
            this.label_numInscription.AutoSize = true;
            this.label_numInscription.Location = new System.Drawing.Point(30, 29);
            this.label_numInscription.Name = "label_numInscription";
            this.label_numInscription.Size = new System.Drawing.Size(102, 13);
            this.label_numInscription.TabIndex = 0;
            this.label_numInscription.Text = "Numéro d\'inscription";
            // 
            // groupBox_Gestion_Notes_Buttons
            // 
            this.groupBox_Gestion_Notes_Buttons.Controls.Add(this.button_quitter);
            this.groupBox_Gestion_Notes_Buttons.Controls.Add(this.button_apercu);
            this.groupBox_Gestion_Notes_Buttons.Controls.Add(this.button_modifierNote);
            this.groupBox_Gestion_Notes_Buttons.Controls.Add(this.button_enrengNotes);
            this.groupBox_Gestion_Notes_Buttons.Controls.Add(this.button_nouveau);
            this.groupBox_Gestion_Notes_Buttons.Location = new System.Drawing.Point(467, 54);
            this.groupBox_Gestion_Notes_Buttons.Name = "groupBox_Gestion_Notes_Buttons";
            this.groupBox_Gestion_Notes_Buttons.Size = new System.Drawing.Size(192, 216);
            this.groupBox_Gestion_Notes_Buttons.TabIndex = 1;
            this.groupBox_Gestion_Notes_Buttons.TabStop = false;
            // 
            // button_quitter
            // 
            this.button_quitter.Location = new System.Drawing.Point(47, 182);
            this.button_quitter.Name = "button_quitter";
            this.button_quitter.Size = new System.Drawing.Size(114, 23);
            this.button_quitter.TabIndex = 4;
            this.button_quitter.Text = "Quitter";
            this.button_quitter.UseVisualStyleBackColor = true;
            this.button_quitter.Click += new System.EventHandler(this.button_quitter_Click);
            // 
            // button_apercu
            // 
            this.button_apercu.Location = new System.Drawing.Point(47, 144);
            this.button_apercu.Name = "button_apercu";
            this.button_apercu.Size = new System.Drawing.Size(114, 23);
            this.button_apercu.TabIndex = 3;
            this.button_apercu.Text = "Apercu";
            this.button_apercu.UseVisualStyleBackColor = true;
            this.button_apercu.Click += new System.EventHandler(this.button_apercu_Click);
            // 
            // button_modifierNote
            // 
            this.button_modifierNote.Location = new System.Drawing.Point(47, 103);
            this.button_modifierNote.Name = "button_modifierNote";
            this.button_modifierNote.Size = new System.Drawing.Size(114, 23);
            this.button_modifierNote.TabIndex = 2;
            this.button_modifierNote.Text = "Modifier Note";
            this.button_modifierNote.UseVisualStyleBackColor = true;
            this.button_modifierNote.Click += new System.EventHandler(this.button_modifierNote_Click);
            // 
            // button_enrengNotes
            // 
            this.button_enrengNotes.Location = new System.Drawing.Point(47, 62);
            this.button_enrengNotes.Name = "button_enrengNotes";
            this.button_enrengNotes.Size = new System.Drawing.Size(114, 23);
            this.button_enrengNotes.TabIndex = 1;
            this.button_enrengNotes.Text = "Enrengistrer Note";
            this.button_enrengNotes.UseVisualStyleBackColor = true;
            this.button_enrengNotes.Click += new System.EventHandler(this.button_enrengNotes_Click);
            // 
            // button_nouveau
            // 
            this.button_nouveau.Location = new System.Drawing.Point(47, 19);
            this.button_nouveau.Name = "button_nouveau";
            this.button_nouveau.Size = new System.Drawing.Size(114, 23);
            this.button_nouveau.TabIndex = 0;
            this.button_nouveau.Text = "Nouveau";
            this.button_nouveau.UseVisualStyleBackColor = true;
            this.button_nouveau.Click += new System.EventHandler(this.button_nouveau_Click);
            // 
            // dataGridView_Notes
            // 
            this.dataGridView_Notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Notes.Location = new System.Drawing.Point(55, 300);
            this.dataGridView_Notes.Name = "dataGridView_Notes";
            this.dataGridView_Notes.Size = new System.Drawing.Size(604, 150);
            this.dataGridView_Notes.TabIndex = 2;
            // 
            // Gestion_Notes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 508);
            this.Controls.Add(this.dataGridView_Notes);
            this.Controls.Add(this.groupBox_Gestion_Notes_Buttons);
            this.Controls.Add(this.groupBox_FormGestionNotes);
            this.Name = "Gestion_Notes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion_Notes";
            this.Load += new System.EventHandler(this.Gestion_Notes_Load);
            this.groupBox_FormGestionNotes.ResumeLayout(false);
            this.groupBox_FormGestionNotes.PerformLayout();
            this.groupBox_Gestion_Notes_Buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Notes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_FormGestionNotes;
        private System.Windows.Forms.ComboBox comboBox_Modules;
        private System.Windows.Forms.ComboBox comboBox_numInscription;
        private System.Windows.Forms.TextBox textBox_Notes;
        private System.Windows.Forms.TextBox textBox_Nom_Prenom;
        private System.Windows.Forms.Label label_Notes;
        private System.Windows.Forms.Label label_Module;
        private System.Windows.Forms.Label label_Nom_Prenom;
        private System.Windows.Forms.Label label_numInscription;
        private System.Windows.Forms.GroupBox groupBox_Gestion_Notes_Buttons;
        private System.Windows.Forms.Button button_quitter;
        private System.Windows.Forms.Button button_apercu;
        private System.Windows.Forms.Button button_modifierNote;
        private System.Windows.Forms.Button button_enrengNotes;
        private System.Windows.Forms.Button button_nouveau;
        private System.Windows.Forms.DataGridView dataGridView_Notes;
    }
}