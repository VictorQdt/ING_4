
namespace WindowsFormsApp1
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
            this.text_change = new System.Windows.Forms.TextBox();
            this.radioButtonDHtoEuro = new System.Windows.Forms.RadioButton();
            this.radioButtonEurotoDH = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.text_entree = new System.Windows.Forms.TextBox();
            this.text_result = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_convertir = new System.Windows.Forms.Button();
            this.button_annuler = new System.Windows.Forms.Button();
            this.label_entree = new System.Windows.Forms.Label();
            this.label_sortie = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valeur de change";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "1 euro =";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "dh";
            // 
            // text_change
            // 
            this.text_change.Location = new System.Drawing.Point(275, 47);
            this.text_change.Name = "text_change";
            this.text_change.Size = new System.Drawing.Size(191, 20);
            this.text_change.TabIndex = 3;
            // 
            // radioButtonDHtoEuro
            // 
            this.radioButtonDHtoEuro.AutoSize = true;
            this.radioButtonDHtoEuro.Location = new System.Drawing.Point(69, 112);
            this.radioButtonDHtoEuro.Name = "radioButtonDHtoEuro";
            this.radioButtonDHtoEuro.Size = new System.Drawing.Size(87, 17);
            this.radioButtonDHtoEuro.TabIndex = 4;
            this.radioButtonDHtoEuro.TabStop = true;
            this.radioButtonDHtoEuro.Text = "DH -> EURO";
            this.radioButtonDHtoEuro.UseVisualStyleBackColor = true;
            this.radioButtonDHtoEuro.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonEurotoDH
            // 
            this.radioButtonEurotoDH.AutoSize = true;
            this.radioButtonEurotoDH.Location = new System.Drawing.Point(226, 112);
            this.radioButtonEurotoDH.Name = "radioButtonEurotoDH";
            this.radioButtonEurotoDH.Size = new System.Drawing.Size(87, 17);
            this.radioButtonEurotoDH.TabIndex = 5;
            this.radioButtonEurotoDH.TabStop = true;
            this.radioButtonEurotoDH.Text = "EURO -> DH";
            this.radioButtonEurotoDH.UseVisualStyleBackColor = true;
            this.radioButtonEurotoDH.CheckedChanged += new System.EventHandler(this.radioButtonEurotoDH_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Montant en ";
            // 
            // text_entree
            // 
            this.text_entree.Location = new System.Drawing.Point(358, 168);
            this.text_entree.Name = "text_entree";
            this.text_entree.Size = new System.Drawing.Size(191, 20);
            this.text_entree.TabIndex = 7;
            // 
            // text_result
            // 
            this.text_result.Location = new System.Drawing.Point(358, 207);
            this.text_result.Name = "text_result";
            this.text_result.Size = new System.Drawing.Size(191, 20);
            this.text_result.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Montant en ";
            // 
            // button_convertir
            // 
            this.button_convertir.Location = new System.Drawing.Point(358, 255);
            this.button_convertir.Name = "button_convertir";
            this.button_convertir.Size = new System.Drawing.Size(75, 23);
            this.button_convertir.TabIndex = 10;
            this.button_convertir.Text = "Convertir";
            this.button_convertir.UseVisualStyleBackColor = true;
            this.button_convertir.Click += new System.EventHandler(this.button_convertir_Click);
            // 
            // button_annuler
            // 
            this.button_annuler.Location = new System.Drawing.Point(474, 255);
            this.button_annuler.Name = "button_annuler";
            this.button_annuler.Size = new System.Drawing.Size(75, 23);
            this.button_annuler.TabIndex = 11;
            this.button_annuler.Text = "Annuler";
            this.button_annuler.UseVisualStyleBackColor = true;
            this.button_annuler.Click += new System.EventHandler(this.button_annuler_Click_1);
            // 
            // label_entree
            // 
            this.label_entree.AutoSize = true;
            this.label_entree.Location = new System.Drawing.Point(320, 171);
            this.label_entree.Name = "label_entree";
            this.label_entree.Size = new System.Drawing.Size(10, 13);
            this.label_entree.TabIndex = 12;
            this.label_entree.Text = " ";
            // 
            // label_sortie
            // 
            this.label_sortie.AutoSize = true;
            this.label_sortie.Location = new System.Drawing.Point(320, 210);
            this.label_sortie.Name = "label_sortie";
            this.label_sortie.Size = new System.Drawing.Size(0, 13);
            this.label_sortie.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_sortie);
            this.Controls.Add(this.label_entree);
            this.Controls.Add(this.button_annuler);
            this.Controls.Add(this.button_convertir);
            this.Controls.Add(this.text_result);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_entree);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButtonEurotoDH);
            this.Controls.Add(this.radioButtonDHtoEuro);
            this.Controls.Add(this.text_change);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_change;
        private System.Windows.Forms.RadioButton radioButtonDHtoEuro;
        private System.Windows.Forms.RadioButton radioButtonEurotoDH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_entree;
        private System.Windows.Forms.TextBox text_result;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_convertir;
        private System.Windows.Forms.Button button_annuler;
        private System.Windows.Forms.Label label_entree;
        private System.Windows.Forms.Label label_sortie;
    }
}

