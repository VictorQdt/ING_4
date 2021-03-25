
namespace WindowsFormsApp5
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
            this.radioButton_rouge = new System.Windows.Forms.RadioButton();
            this.radioButton_vert = new System.Windows.Forms.RadioButton();
            this.radioButton_bleu = new System.Windows.Forms.RadioButton();
            this.button_play = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label_frequence = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton_rouge
            // 
            this.radioButton_rouge.AutoSize = true;
            this.radioButton_rouge.Location = new System.Drawing.Point(33, 29);
            this.radioButton_rouge.Name = "radioButton_rouge";
            this.radioButton_rouge.Size = new System.Drawing.Size(33, 17);
            this.radioButton_rouge.TabIndex = 0;
            this.radioButton_rouge.TabStop = true;
            this.radioButton_rouge.Text = "R";
            this.radioButton_rouge.UseVisualStyleBackColor = true;
            // 
            // radioButton_vert
            // 
            this.radioButton_vert.AutoSize = true;
            this.radioButton_vert.Location = new System.Drawing.Point(170, 29);
            this.radioButton_vert.Name = "radioButton_vert";
            this.radioButton_vert.Size = new System.Drawing.Size(32, 17);
            this.radioButton_vert.TabIndex = 1;
            this.radioButton_vert.TabStop = true;
            this.radioButton_vert.Text = "V";
            this.radioButton_vert.UseVisualStyleBackColor = true;
            // 
            // radioButton_bleu
            // 
            this.radioButton_bleu.AutoSize = true;
            this.radioButton_bleu.Location = new System.Drawing.Point(322, 29);
            this.radioButton_bleu.Name = "radioButton_bleu";
            this.radioButton_bleu.Size = new System.Drawing.Size(32, 17);
            this.radioButton_bleu.TabIndex = 2;
            this.radioButton_bleu.TabStop = true;
            this.radioButton_bleu.Text = "B";
            this.radioButton_bleu.UseVisualStyleBackColor = true;
            // 
            // button_play
            // 
            this.button_play.Location = new System.Drawing.Point(227, 193);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(75, 23);
            this.button_play.TabIndex = 3;
            this.button_play.Text = "Play";
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(367, 193);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 4;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(153, 283);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(384, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label_frequence
            // 
            this.label_frequence.AutoSize = true;
            this.label_frequence.Location = new System.Drawing.Point(62, 283);
            this.label_frequence.Name = "label_frequence";
            this.label_frequence.Size = new System.Drawing.Size(85, 13);
            this.label_frequence.TabIndex = 6;
            this.label_frequence.Text = "Fréquence OMS";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(543, 283);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(20, 13);
            this.label_time.TabIndex = 7;
            this.label_time.Text = "1S";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_rouge);
            this.groupBox1.Controls.Add(this.radioButton_vert);
            this.groupBox1.Controls.Add(this.radioButton_bleu);
            this.groupBox1.Location = new System.Drawing.Point(153, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 62);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
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
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_frequence);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_play);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_rouge;
        private System.Windows.Forms.RadioButton radioButton_vert;
        private System.Windows.Forms.RadioButton radioButton_bleu;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label_frequence;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

