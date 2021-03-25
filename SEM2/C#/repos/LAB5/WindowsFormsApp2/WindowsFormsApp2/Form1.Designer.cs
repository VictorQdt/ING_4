
namespace WindowsFormsApp2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prix_base = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.prix_ht = new System.Windows.Forms.Label();
            this.tva = new System.Windows.Forms.Label();
            this.prix_ttc = new System.Windows.Forms.Label();
            this.text_HT = new System.Windows.Forms.TextBox();
            this.text_tva = new System.Windows.Forms.TextBox();
            this.text_prix_TTC = new System.Windows.Forms.TextBox();
            this.button_calculer = new System.Windows.Forms.Button();
            this.button_reinitialiser = new System.Windows.Forms.Button();
            this.button_quitter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prix de base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type de billet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Réduction";
            // 
            // prix_base
            // 
            this.prix_base.Location = new System.Drawing.Point(230, 56);
            this.prix_base.Name = "prix_base";
            this.prix_base.Size = new System.Drawing.Size(100, 20);
            this.prix_base.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Première Classe",
            "Deuxième Classe"});
            this.listBox1.Location = new System.Drawing.Point(230, 112);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 30);
            this.listBox1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pas de réduction",
            "Carte jeune",
            "Carte adulte",
            "Carte famille"});
            this.comboBox1.Location = new System.Drawing.Point(230, 178);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // prix_ht
            // 
            this.prix_ht.AutoSize = true;
            this.prix_ht.Location = new System.Drawing.Point(106, 245);
            this.prix_ht.Name = "prix_ht";
            this.prix_ht.Size = new System.Drawing.Size(42, 13);
            this.prix_ht.TabIndex = 6;
            this.prix_ht.Text = "Prix HT";
            // 
            // tva
            // 
            this.tva.AutoSize = true;
            this.tva.Location = new System.Drawing.Point(106, 280);
            this.tva.Name = "tva";
            this.tva.Size = new System.Drawing.Size(28, 13);
            this.tva.TabIndex = 7;
            this.tva.Text = "TVA";
            // 
            // prix_ttc
            // 
            this.prix_ttc.AutoSize = true;
            this.prix_ttc.Location = new System.Drawing.Point(109, 318);
            this.prix_ttc.Name = "prix_ttc";
            this.prix_ttc.Size = new System.Drawing.Size(48, 13);
            this.prix_ttc.TabIndex = 8;
            this.prix_ttc.Text = "Prix TTC";
            // 
            // text_HT
            // 
            this.text_HT.Location = new System.Drawing.Point(230, 242);
            this.text_HT.Name = "text_HT";
            this.text_HT.Size = new System.Drawing.Size(100, 20);
            this.text_HT.TabIndex = 9;
            // 
            // text_tva
            // 
            this.text_tva.Location = new System.Drawing.Point(230, 280);
            this.text_tva.Name = "text_tva";
            this.text_tva.Size = new System.Drawing.Size(100, 20);
            this.text_tva.TabIndex = 10;
            // 
            // text_prix_TTC
            // 
            this.text_prix_TTC.Location = new System.Drawing.Point(230, 318);
            this.text_prix_TTC.Name = "text_prix_TTC";
            this.text_prix_TTC.Size = new System.Drawing.Size(100, 20);
            this.text_prix_TTC.TabIndex = 11;
            // 
            // button_calculer
            // 
            this.button_calculer.Location = new System.Drawing.Point(112, 373);
            this.button_calculer.Name = "button_calculer";
            this.button_calculer.Size = new System.Drawing.Size(75, 23);
            this.button_calculer.TabIndex = 12;
            this.button_calculer.Text = "Calculer";
            this.button_calculer.UseVisualStyleBackColor = true;
            this.button_calculer.Click += new System.EventHandler(this.button_calculer_Click);
            // 
            // button_reinitialiser
            // 
            this.button_reinitialiser.Location = new System.Drawing.Point(254, 373);
            this.button_reinitialiser.Name = "button_reinitialiser";
            this.button_reinitialiser.Size = new System.Drawing.Size(75, 23);
            this.button_reinitialiser.TabIndex = 13;
            this.button_reinitialiser.Text = "Réinitialiser";
            this.button_reinitialiser.UseVisualStyleBackColor = true;
            this.button_reinitialiser.Click += new System.EventHandler(this.button_reinitialiser_Click);
            // 
            // button_quitter
            // 
            this.button_quitter.Location = new System.Drawing.Point(399, 373);
            this.button_quitter.Name = "button_quitter";
            this.button_quitter.Size = new System.Drawing.Size(75, 23);
            this.button_quitter.TabIndex = 14;
            this.button_quitter.Text = "Quitter";
            this.button_quitter.UseVisualStyleBackColor = true;
            this.button_quitter.Click += new System.EventHandler(this.button_quitter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_quitter);
            this.Controls.Add(this.button_reinitialiser);
            this.Controls.Add(this.button_calculer);
            this.Controls.Add(this.text_prix_TTC);
            this.Controls.Add(this.text_tva);
            this.Controls.Add(this.text_HT);
            this.Controls.Add(this.prix_ttc);
            this.Controls.Add(this.tva);
            this.Controls.Add(this.prix_ht);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.prix_base);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox prix_base;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label prix_ht;
        private System.Windows.Forms.Label tva;
        private System.Windows.Forms.Label prix_ttc;
        private System.Windows.Forms.TextBox text_HT;
        private System.Windows.Forms.TextBox text_tva;
        private System.Windows.Forms.TextBox text_prix_TTC;
        private System.Windows.Forms.Button button_calculer;
        private System.Windows.Forms.Button button_reinitialiser;
        private System.Windows.Forms.Button button_quitter;
    }
}

