
namespace TPNOTE2
{
    partial class Gestion_Etudiants
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
            this.groupInfos = new System.Windows.Forms.GroupBox();
            this.naissance = new System.Windows.Forms.DateTimePicker();
            this.labelDateN = new System.Windows.Forms.Label();
            this.labelPrénom = new System.Windows.Forms.Label();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.labelNom = new System.Windows.Forms.Label();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.labelNum_Etu = new System.Windows.Forms.Label();
            this.textBoxNum_Etu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonQuitter = new System.Windows.Forms.Button();
            this.buttonSupprimer = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.buttonRecherche = new System.Windows.Forms.Button();
            this.buttonNouveau = new System.Windows.Forms.Button();
            this.groupBoxFleches = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMoins = new System.Windows.Forms.Button();
            this.buttonDebut = new System.Windows.Forms.Button();
            this.groupInfos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxFleches.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupInfos
            // 
            this.groupInfos.Controls.Add(this.naissance);
            this.groupInfos.Controls.Add(this.labelDateN);
            this.groupInfos.Controls.Add(this.labelPrénom);
            this.groupInfos.Controls.Add(this.textBoxPrenom);
            this.groupInfos.Controls.Add(this.labelNom);
            this.groupInfos.Controls.Add(this.textBoxNom);
            this.groupInfos.Controls.Add(this.labelNum_Etu);
            this.groupInfos.Controls.Add(this.textBoxNum_Etu);
            this.groupInfos.Location = new System.Drawing.Point(52, 48);
            this.groupInfos.Name = "groupInfos";
            this.groupInfos.Size = new System.Drawing.Size(673, 334);
            this.groupInfos.TabIndex = 0;
            this.groupInfos.TabStop = false;
            this.groupInfos.Text = "Infos";
            this.groupInfos.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // naissance
            // 
            this.naissance.Location = new System.Drawing.Point(281, 272);
            this.naissance.Name = "naissance";
            this.naissance.Size = new System.Drawing.Size(217, 22);
            this.naissance.TabIndex = 8;
            this.naissance.ValueChanged += new System.EventHandler(this.naissance_ValueChanged);
            // 
            // labelDateN
            // 
            this.labelDateN.AutoSize = true;
            this.labelDateN.Location = new System.Drawing.Point(30, 277);
            this.labelDateN.Name = "labelDateN";
            this.labelDateN.Size = new System.Drawing.Size(126, 17);
            this.labelDateN.TabIndex = 7;
            this.labelDateN.Text = "Date de naissance";
            this.labelDateN.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelPrénom
            // 
            this.labelPrénom.AutoSize = true;
            this.labelPrénom.Location = new System.Drawing.Point(30, 197);
            this.labelPrénom.Name = "labelPrénom";
            this.labelPrénom.Size = new System.Drawing.Size(57, 17);
            this.labelPrénom.TabIndex = 5;
            this.labelPrénom.Text = "Prénom";
            this.labelPrénom.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Location = new System.Drawing.Point(281, 198);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(218, 22);
            this.textBoxPrenom.TabIndex = 4;
            this.textBoxPrenom.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Location = new System.Drawing.Point(30, 127);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(37, 17);
            this.labelNom.TabIndex = 3;
            this.labelNom.Text = "Nom";
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(281, 122);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(218, 22);
            this.textBoxNom.TabIndex = 2;
            this.textBoxNom.TextChanged += new System.EventHandler(this.textBoxNom_TextChanged);
            // 
            // labelNum_Etu
            // 
            this.labelNum_Etu.AutoSize = true;
            this.labelNum_Etu.Location = new System.Drawing.Point(30, 47);
            this.labelNum_Etu.Name = "labelNum_Etu";
            this.labelNum_Etu.Size = new System.Drawing.Size(137, 17);
            this.labelNum_Etu.TabIndex = 1;
            this.labelNum_Etu.Text = "Numéro d\'inscription";
            // 
            // textBoxNum_Etu
            // 
            this.textBoxNum_Etu.Location = new System.Drawing.Point(281, 48);
            this.textBoxNum_Etu.Name = "textBoxNum_Etu";
            this.textBoxNum_Etu.Size = new System.Drawing.Size(218, 22);
            this.textBoxNum_Etu.TabIndex = 0;
            this.textBoxNum_Etu.TextChanged += new System.EventHandler(this.textBoxNum_Etu_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonQuitter);
            this.groupBox1.Controls.Add(this.buttonSupprimer);
            this.groupBox1.Controls.Add(this.buttonModifier);
            this.groupBox1.Controls.Add(this.buttonAjouter);
            this.groupBox1.Controls.Add(this.buttonRecherche);
            this.groupBox1.Controls.Add(this.buttonNouveau);
            this.groupBox1.Location = new System.Drawing.Point(767, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 333);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.Location = new System.Drawing.Point(15, 281);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(241, 46);
            this.buttonQuitter.TabIndex = 5;
            this.buttonQuitter.Text = "Quitter";
            this.buttonQuitter.UseVisualStyleBackColor = true;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.Location = new System.Drawing.Point(15, 229);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(241, 46);
            this.buttonSupprimer.TabIndex = 4;
            this.buttonSupprimer.Text = "Supprimer";
            this.buttonSupprimer.UseVisualStyleBackColor = true;
            this.buttonSupprimer.Click += new System.EventHandler(this.buttonSupprimer_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.Location = new System.Drawing.Point(15, 174);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(241, 46);
            this.buttonModifier.TabIndex = 3;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = true;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(15, 122);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(241, 46);
            this.buttonAjouter.TabIndex = 2;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // buttonRecherche
            // 
            this.buttonRecherche.Location = new System.Drawing.Point(15, 70);
            this.buttonRecherche.Name = "buttonRecherche";
            this.buttonRecherche.Size = new System.Drawing.Size(241, 46);
            this.buttonRecherche.TabIndex = 1;
            this.buttonRecherche.Text = "Recherche par numéro";
            this.buttonRecherche.UseVisualStyleBackColor = true;
            this.buttonRecherche.Click += new System.EventHandler(this.buttonRecherche_Click);
            // 
            // buttonNouveau
            // 
            this.buttonNouveau.Location = new System.Drawing.Point(15, 18);
            this.buttonNouveau.Name = "buttonNouveau";
            this.buttonNouveau.Size = new System.Drawing.Size(241, 46);
            this.buttonNouveau.TabIndex = 0;
            this.buttonNouveau.Text = "Nouveau";
            this.buttonNouveau.UseVisualStyleBackColor = true;
            this.buttonNouveau.Click += new System.EventHandler(this.buttonNouveau_Click);
            // 
            // groupBoxFleches
            // 
            this.groupBoxFleches.Controls.Add(this.button4);
            this.groupBoxFleches.Controls.Add(this.buttonPlus);
            this.groupBoxFleches.Controls.Add(this.buttonMoins);
            this.groupBoxFleches.Controls.Add(this.buttonDebut);
            this.groupBoxFleches.Location = new System.Drawing.Point(52, 410);
            this.groupBoxFleches.Name = "groupBoxFleches";
            this.groupBoxFleches.Size = new System.Drawing.Size(981, 94);
            this.groupBoxFleches.TabIndex = 2;
            this.groupBoxFleches.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(744, 34);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(207, 39);
            this.button4.TabIndex = 3;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Location = new System.Drawing.Point(501, 34);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(207, 39);
            this.buttonPlus.TabIndex = 2;
            this.buttonPlus.Text = ">";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonMoins
            // 
            this.buttonMoins.Location = new System.Drawing.Point(260, 34);
            this.buttonMoins.Name = "buttonMoins";
            this.buttonMoins.Size = new System.Drawing.Size(207, 39);
            this.buttonMoins.TabIndex = 1;
            this.buttonMoins.Text = "<";
            this.buttonMoins.UseVisualStyleBackColor = true;
            this.buttonMoins.Click += new System.EventHandler(this.buttonMoins_Click);
            // 
            // buttonDebut
            // 
            this.buttonDebut.Location = new System.Drawing.Point(18, 34);
            this.buttonDebut.Name = "buttonDebut";
            this.buttonDebut.Size = new System.Drawing.Size(207, 39);
            this.buttonDebut.TabIndex = 0;
            this.buttonDebut.Text = "<<";
            this.buttonDebut.UseVisualStyleBackColor = true;
            this.buttonDebut.Click += new System.EventHandler(this.buttonDebut_Click);
            // 
            // Gestion_Etudiants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.groupBoxFleches);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupInfos);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Gestion_Etudiants";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion_Etudiants";
            this.groupInfos.ResumeLayout(false);
            this.groupInfos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxFleches.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupInfos;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Label labelNum_Etu;
        private System.Windows.Forms.TextBox textBoxNum_Etu;
        private System.Windows.Forms.Label labelDateN;
        private System.Windows.Forms.Label labelPrénom;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.DateTimePicker naissance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonQuitter;
        private System.Windows.Forms.Button buttonSupprimer;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonRecherche;
        private System.Windows.Forms.Button buttonNouveau;
        private System.Windows.Forms.GroupBox groupBoxFleches;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMoins;
        private System.Windows.Forms.Button buttonDebut;
    }
}