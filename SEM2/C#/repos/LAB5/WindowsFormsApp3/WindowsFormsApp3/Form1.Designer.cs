
namespace WindowsFormsApp3
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
            this.listBox_gauche = new System.Windows.Forms.ListBox();
            this.listBox_droite = new System.Windows.Forms.ListBox();
            this.button_droite_item = new System.Windows.Forms.Button();
            this.button_gauche_item = new System.Windows.Forms.Button();
            this.button_droite_list = new System.Windows.Forms.Button();
            this.button_gauche_list = new System.Windows.Forms.Button();
            this.button_gauche_up = new System.Windows.Forms.Button();
            this.button_gauche_down = new System.Windows.Forms.Button();
            this.button_gauche_AZ = new System.Windows.Forms.Button();
            this.button_gauche_ZA = new System.Windows.Forms.Button();
            this.button_droite_UP = new System.Windows.Forms.Button();
            this.button_droite_AZ = new System.Windows.Forms.Button();
            this.button_droite_DOWN = new System.Windows.Forms.Button();
            this.button_droite_ZA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_gauche
            // 
            this.listBox_gauche.FormattingEnabled = true;
            this.listBox_gauche.Items.AddRange(new object[] {
            "Langage C",
            "Langage Java",
            "Langage C++",
            "Langage C#",
            "HTML",
            "CSS",
            "JavaScript"});
            this.listBox_gauche.Location = new System.Drawing.Point(109, 81);
            this.listBox_gauche.Name = "listBox_gauche";
            this.listBox_gauche.Size = new System.Drawing.Size(189, 186);
            this.listBox_gauche.TabIndex = 0;
            // 
            // listBox_droite
            // 
            this.listBox_droite.FormattingEnabled = true;
            this.listBox_droite.Location = new System.Drawing.Point(450, 81);
            this.listBox_droite.Name = "listBox_droite";
            this.listBox_droite.Size = new System.Drawing.Size(185, 186);
            this.listBox_droite.TabIndex = 1;
            // 
            // button_droite_item
            // 
            this.button_droite_item.Location = new System.Drawing.Point(332, 81);
            this.button_droite_item.Name = "button_droite_item";
            this.button_droite_item.Size = new System.Drawing.Size(75, 23);
            this.button_droite_item.TabIndex = 2;
            this.button_droite_item.Text = ">";
            this.button_droite_item.UseVisualStyleBackColor = true;
            this.button_droite_item.Click += new System.EventHandler(this.button_droite_item_Click);
            // 
            // button_gauche_item
            // 
            this.button_gauche_item.Location = new System.Drawing.Point(332, 137);
            this.button_gauche_item.Name = "button_gauche_item";
            this.button_gauche_item.Size = new System.Drawing.Size(75, 23);
            this.button_gauche_item.TabIndex = 3;
            this.button_gauche_item.Text = "<";
            this.button_gauche_item.UseVisualStyleBackColor = true;
            this.button_gauche_item.Click += new System.EventHandler(this.button_gauche_item_Click);
            // 
            // button_droite_list
            // 
            this.button_droite_list.Location = new System.Drawing.Point(332, 189);
            this.button_droite_list.Name = "button_droite_list";
            this.button_droite_list.Size = new System.Drawing.Size(75, 23);
            this.button_droite_list.TabIndex = 4;
            this.button_droite_list.Text = ">>";
            this.button_droite_list.UseVisualStyleBackColor = true;
            this.button_droite_list.Click += new System.EventHandler(this.button_droite_list_Click);
            // 
            // button_gauche_list
            // 
            this.button_gauche_list.Location = new System.Drawing.Point(332, 244);
            this.button_gauche_list.Name = "button_gauche_list";
            this.button_gauche_list.Size = new System.Drawing.Size(75, 23);
            this.button_gauche_list.TabIndex = 5;
            this.button_gauche_list.Text = "<<";
            this.button_gauche_list.UseVisualStyleBackColor = true;
            this.button_gauche_list.Click += new System.EventHandler(this.button_gauche_list_Click);
            // 
            // button_gauche_up
            // 
            this.button_gauche_up.Location = new System.Drawing.Point(109, 295);
            this.button_gauche_up.Name = "button_gauche_up";
            this.button_gauche_up.Size = new System.Drawing.Size(75, 23);
            this.button_gauche_up.TabIndex = 6;
            this.button_gauche_up.Text = "UP";
            this.button_gauche_up.UseVisualStyleBackColor = true;
            this.button_gauche_up.Click += new System.EventHandler(this.button_gauche_up_Click);
            // 
            // button_gauche_down
            // 
            this.button_gauche_down.Location = new System.Drawing.Point(223, 295);
            this.button_gauche_down.Name = "button_gauche_down";
            this.button_gauche_down.Size = new System.Drawing.Size(75, 23);
            this.button_gauche_down.TabIndex = 7;
            this.button_gauche_down.Text = "DOWN";
            this.button_gauche_down.UseVisualStyleBackColor = true;
            this.button_gauche_down.Click += new System.EventHandler(this.button_gauche_down_Click);
            // 
            // button_gauche_AZ
            // 
            this.button_gauche_AZ.Location = new System.Drawing.Point(109, 343);
            this.button_gauche_AZ.Name = "button_gauche_AZ";
            this.button_gauche_AZ.Size = new System.Drawing.Size(75, 23);
            this.button_gauche_AZ.TabIndex = 8;
            this.button_gauche_AZ.Text = "A-Z";
            this.button_gauche_AZ.UseVisualStyleBackColor = true;
            this.button_gauche_AZ.Click += new System.EventHandler(this.button_gauche_AZ_Click);
            // 
            // button_gauche_ZA
            // 
            this.button_gauche_ZA.Location = new System.Drawing.Point(223, 343);
            this.button_gauche_ZA.Name = "button_gauche_ZA";
            this.button_gauche_ZA.Size = new System.Drawing.Size(75, 23);
            this.button_gauche_ZA.TabIndex = 9;
            this.button_gauche_ZA.Text = "Z-A";
            this.button_gauche_ZA.UseVisualStyleBackColor = true;
            this.button_gauche_ZA.Click += new System.EventHandler(this.button_gauche_ZA_Click);
            // 
            // button_droite_UP
            // 
            this.button_droite_UP.Location = new System.Drawing.Point(450, 295);
            this.button_droite_UP.Name = "button_droite_UP";
            this.button_droite_UP.Size = new System.Drawing.Size(75, 23);
            this.button_droite_UP.TabIndex = 10;
            this.button_droite_UP.Text = "UP";
            this.button_droite_UP.UseVisualStyleBackColor = true;
            this.button_droite_UP.Click += new System.EventHandler(this.button_droite_UP_Click);
            // 
            // button_droite_AZ
            // 
            this.button_droite_AZ.Location = new System.Drawing.Point(450, 343);
            this.button_droite_AZ.Name = "button_droite_AZ";
            this.button_droite_AZ.Size = new System.Drawing.Size(75, 23);
            this.button_droite_AZ.TabIndex = 11;
            this.button_droite_AZ.Text = "A-Z";
            this.button_droite_AZ.UseVisualStyleBackColor = true;
            this.button_droite_AZ.Click += new System.EventHandler(this.button_droite_AZ_Click);
            // 
            // button_droite_DOWN
            // 
            this.button_droite_DOWN.Location = new System.Drawing.Point(560, 295);
            this.button_droite_DOWN.Name = "button_droite_DOWN";
            this.button_droite_DOWN.Size = new System.Drawing.Size(75, 23);
            this.button_droite_DOWN.TabIndex = 12;
            this.button_droite_DOWN.Text = "DOWN";
            this.button_droite_DOWN.UseVisualStyleBackColor = true;
            this.button_droite_DOWN.Click += new System.EventHandler(this.button_droite_DOWN_Click);
            // 
            // button_droite_ZA
            // 
            this.button_droite_ZA.Location = new System.Drawing.Point(560, 343);
            this.button_droite_ZA.Name = "button_droite_ZA";
            this.button_droite_ZA.Size = new System.Drawing.Size(75, 23);
            this.button_droite_ZA.TabIndex = 13;
            this.button_droite_ZA.Text = "Z-A";
            this.button_droite_ZA.UseVisualStyleBackColor = true;
            this.button_droite_ZA.Click += new System.EventHandler(this.button_droite_ZA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_droite_ZA);
            this.Controls.Add(this.button_droite_DOWN);
            this.Controls.Add(this.button_droite_AZ);
            this.Controls.Add(this.button_droite_UP);
            this.Controls.Add(this.button_gauche_ZA);
            this.Controls.Add(this.button_gauche_AZ);
            this.Controls.Add(this.button_gauche_down);
            this.Controls.Add(this.button_gauche_up);
            this.Controls.Add(this.button_gauche_list);
            this.Controls.Add(this.button_droite_list);
            this.Controls.Add(this.button_gauche_item);
            this.Controls.Add(this.button_droite_item);
            this.Controls.Add(this.listBox_droite);
            this.Controls.Add(this.listBox_gauche);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_gauche;
        private System.Windows.Forms.ListBox listBox_droite;
        private System.Windows.Forms.Button button_droite_item;
        private System.Windows.Forms.Button button_gauche_item;
        private System.Windows.Forms.Button button_droite_list;
        private System.Windows.Forms.Button button_gauche_list;
        private System.Windows.Forms.Button button_gauche_up;
        private System.Windows.Forms.Button button_gauche_down;
        private System.Windows.Forms.Button button_gauche_AZ;
        private System.Windows.Forms.Button button_gauche_ZA;
        private System.Windows.Forms.Button button_droite_UP;
        private System.Windows.Forms.Button button_droite_AZ;
        private System.Windows.Forms.Button button_droite_DOWN;
        private System.Windows.Forms.Button button_droite_ZA;
    }
}

