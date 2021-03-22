
namespace WindowsFormsApp4
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
            this.label_nom = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.label_adresse = new System.Windows.Forms.Label();
            this.label_tel = new System.Windows.Forms.Label();
            this.textBox_nom = new System.Windows.Forms.TextBox();
            this.textBox_adresse = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.maskedTextBox_tel = new System.Windows.Forms.MaskedTextBox();
            this.button_annuler = new System.Windows.Forms.Button();
            this.button_ajouter = new System.Windows.Forms.Button();
            this.button_vider = new System.Windows.Forms.Button();
            this.listBox_compteur = new System.Windows.Forms.ListBox();
            this.listBox_user = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label_nom
            // 
            this.label_nom.AutoSize = true;
            this.label_nom.Location = new System.Drawing.Point(72, 73);
            this.label_nom.Name = "label_nom";
            this.label_nom.Size = new System.Drawing.Size(79, 13);
            this.label_nom.TabIndex = 0;
            this.label_nom.Text = "Nom et prénom";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(68, 132);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(83, 13);
            this.label_date.TabIndex = 1;
            this.label_date.Text = "Date d\'incription";
            // 
            // label_adresse
            // 
            this.label_adresse.AutoSize = true;
            this.label_adresse.Location = new System.Drawing.Point(106, 289);
            this.label_adresse.Name = "label_adresse";
            this.label_adresse.Size = new System.Drawing.Size(45, 13);
            this.label_adresse.TabIndex = 2;
            this.label_adresse.Text = "Adresse";
            // 
            // label_tel
            // 
            this.label_tel.AutoSize = true;
            this.label_tel.Location = new System.Drawing.Point(93, 338);
            this.label_tel.Name = "label_tel";
            this.label_tel.Size = new System.Drawing.Size(58, 13);
            this.label_tel.TabIndex = 3;
            this.label_tel.Text = "Téléphone";
            // 
            // textBox_nom
            // 
            this.textBox_nom.Location = new System.Drawing.Point(168, 70);
            this.textBox_nom.Name = "textBox_nom";
            this.textBox_nom.Size = new System.Drawing.Size(227, 20);
            this.textBox_nom.TabIndex = 4;
            // 
            // textBox_adresse
            // 
            this.textBox_adresse.Location = new System.Drawing.Point(168, 289);
            this.textBox_adresse.Name = "textBox_adresse";
            this.textBox_adresse.Size = new System.Drawing.Size(227, 20);
            this.textBox_adresse.TabIndex = 5;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(168, 102);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 7;
            // 
            // maskedTextBox_tel
            // 
            this.maskedTextBox_tel.Location = new System.Drawing.Point(168, 335);
            this.maskedTextBox_tel.Name = "maskedTextBox_tel";
            this.maskedTextBox_tel.Size = new System.Drawing.Size(227, 20);
            this.maskedTextBox_tel.TabIndex = 8;
            // 
            // button_annuler
            // 
            this.button_annuler.Location = new System.Drawing.Point(483, 315);
            this.button_annuler.Name = "button_annuler";
            this.button_annuler.Size = new System.Drawing.Size(75, 23);
            this.button_annuler.TabIndex = 9;
            this.button_annuler.Text = "Annuler";
            this.button_annuler.UseVisualStyleBackColor = true;
            this.button_annuler.Click += new System.EventHandler(this.button_annuler_Click);
            // 
            // button_ajouter
            // 
            this.button_ajouter.Location = new System.Drawing.Point(598, 315);
            this.button_ajouter.Name = "button_ajouter";
            this.button_ajouter.Size = new System.Drawing.Size(75, 23);
            this.button_ajouter.TabIndex = 10;
            this.button_ajouter.Text = "Ajouter";
            this.button_ajouter.UseVisualStyleBackColor = true;
            this.button_ajouter.Click += new System.EventHandler(this.button_ajouter_Click);
            // 
            // button_vider
            // 
            this.button_vider.Location = new System.Drawing.Point(707, 315);
            this.button_vider.Name = "button_vider";
            this.button_vider.Size = new System.Drawing.Size(75, 23);
            this.button_vider.TabIndex = 11;
            this.button_vider.Text = "Vider";
            this.button_vider.UseVisualStyleBackColor = true;
            this.button_vider.Click += new System.EventHandler(this.button_vider_Click);
            // 
            // listBox_compteur
            // 
            this.listBox_compteur.FormattingEnabled = true;
            this.listBox_compteur.Location = new System.Drawing.Point(447, 70);
            this.listBox_compteur.Name = "listBox_compteur";
            this.listBox_compteur.Size = new System.Drawing.Size(81, 199);
            this.listBox_compteur.TabIndex = 12;
            // 
            // listBox_user
            // 
            this.listBox_user.FormattingEnabled = true;
            this.listBox_user.Location = new System.Drawing.Point(556, 70);
            this.listBox_user.Name = "listBox_user";
            this.listBox_user.Size = new System.Drawing.Size(257, 199);
            this.listBox_user.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 499);
            this.Controls.Add(this.listBox_user);
            this.Controls.Add(this.listBox_compteur);
            this.Controls.Add(this.button_vider);
            this.Controls.Add(this.button_ajouter);
            this.Controls.Add(this.button_annuler);
            this.Controls.Add(this.maskedTextBox_tel);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.textBox_adresse);
            this.Controls.Add(this.textBox_nom);
            this.Controls.Add(this.label_tel);
            this.Controls.Add(this.label_adresse);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_nom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nom;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label_adresse;
        private System.Windows.Forms.Label label_tel;
        private System.Windows.Forms.TextBox textBox_nom;
        private System.Windows.Forms.TextBox textBox_adresse;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_tel;
        private System.Windows.Forms.Button button_annuler;
        private System.Windows.Forms.Button button_ajouter;
        private System.Windows.Forms.Button button_vider;
        private System.Windows.Forms.ListBox listBox_compteur;
        private System.Windows.Forms.ListBox listBox_user;
    }
}

