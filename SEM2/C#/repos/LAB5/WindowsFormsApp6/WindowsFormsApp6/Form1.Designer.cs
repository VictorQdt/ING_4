
namespace WindowsFormsApp6
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_min = new System.Windows.Forms.Label();
            this.label_sec = new System.Windows.Forms.Label();
            this.label_cent_sec = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_demarrer = new System.Windows.Forms.Button();
            this.button_arreter = new System.Windows.Forms.Button();
            this.button_effacer = new System.Windows.Forms.Button();
            this.button_tour = new System.Windows.Forms.Button();
            this.label_captures = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_cent_sec);
            this.groupBox1.Controls.Add(this.label_sec);
            this.groupBox1.Controls.Add(this.label_min);
            this.groupBox1.Location = new System.Drawing.Point(91, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label_min
            // 
            this.label_min.AutoSize = true;
            this.label_min.Location = new System.Drawing.Point(53, 36);
            this.label_min.Name = "label_min";
            this.label_min.Size = new System.Drawing.Size(0, 13);
            this.label_min.TabIndex = 0;
            // 
            // label_sec
            // 
            this.label_sec.AutoSize = true;
            this.label_sec.Location = new System.Drawing.Point(176, 36);
            this.label_sec.Name = "label_sec";
            this.label_sec.Size = new System.Drawing.Size(0, 13);
            this.label_sec.TabIndex = 1;
            // 
            // label_cent_sec
            // 
            this.label_cent_sec.AutoSize = true;
            this.label_cent_sec.Location = new System.Drawing.Point(294, 36);
            this.label_cent_sec.Name = "label_cent_sec";
            this.label_cent_sec.Size = new System.Drawing.Size(0, 13);
            this.label_cent_sec.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "sec";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "cs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_tour);
            this.groupBox2.Controls.Add(this.button_effacer);
            this.groupBox2.Controls.Add(this.button_arreter);
            this.groupBox2.Controls.Add(this.button_demarrer);
            this.groupBox2.Location = new System.Drawing.Point(91, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button_demarrer
            // 
            this.button_demarrer.Location = new System.Drawing.Point(16, 33);
            this.button_demarrer.Name = "button_demarrer";
            this.button_demarrer.Size = new System.Drawing.Size(75, 23);
            this.button_demarrer.TabIndex = 0;
            this.button_demarrer.Text = "Démarrer";
            this.button_demarrer.UseVisualStyleBackColor = true;
            this.button_demarrer.Click += new System.EventHandler(this.button_demarrer_Click);
            // 
            // button_arreter
            // 
            this.button_arreter.Location = new System.Drawing.Point(111, 33);
            this.button_arreter.Name = "button_arreter";
            this.button_arreter.Size = new System.Drawing.Size(75, 23);
            this.button_arreter.TabIndex = 1;
            this.button_arreter.Text = "Arreter";
            this.button_arreter.UseVisualStyleBackColor = true;
            this.button_arreter.Click += new System.EventHandler(this.button_arreter_Click);
            // 
            // button_effacer
            // 
            this.button_effacer.Location = new System.Drawing.Point(204, 33);
            this.button_effacer.Name = "button_effacer";
            this.button_effacer.Size = new System.Drawing.Size(75, 23);
            this.button_effacer.TabIndex = 2;
            this.button_effacer.Text = "Effacer";
            this.button_effacer.UseVisualStyleBackColor = true;
            this.button_effacer.Click += new System.EventHandler(this.button_effacer_Click);
            // 
            // button_tour
            // 
            this.button_tour.Location = new System.Drawing.Point(297, 33);
            this.button_tour.Name = "button_tour";
            this.button_tour.Size = new System.Drawing.Size(75, 23);
            this.button_tour.TabIndex = 3;
            this.button_tour.Text = "Tour";
            this.button_tour.UseVisualStyleBackColor = true;
            this.button_tour.Click += new System.EventHandler(this.button_tour_Click);
            // 
            // label_captures
            // 
            this.label_captures.AutoSize = true;
            this.label_captures.Location = new System.Drawing.Point(610, 132);
            this.label_captures.Name = "label_captures";
            this.label_captures.Size = new System.Drawing.Size(49, 13);
            this.label_captures.TabIndex = 2;
            this.label_captures.Text = "Captures";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(567, 165);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(149, 134);
            this.listBox1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label_captures);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_cent_sec;
        private System.Windows.Forms.Label label_sec;
        private System.Windows.Forms.Label label_min;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_tour;
        private System.Windows.Forms.Button button_effacer;
        private System.Windows.Forms.Button button_arreter;
        private System.Windows.Forms.Button button_demarrer;
        private System.Windows.Forms.Label label_captures;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

