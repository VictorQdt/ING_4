
namespace TPNOTE2
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseTP2DataSet = new TPNOTE2.DatabaseTP2DataSet();
            this.tableTableAdapter = new TPNOTE2.DatabaseTP2DataSetTableAdapters.TableTableAdapter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_Gestion = new System.Windows.Forms.ToolStripDropDownButton();
            this.gestionDesEtudiantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_Consultation = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Quitter = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseTP2DataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this.databaseTP2DataSet;
            // 
            // databaseTP2DataSet
            // 
            this.databaseTP2DataSet.DataSetName = "DatabaseTP2DataSet";
            this.databaseTP2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_Gestion,
            this.toolStripButton_Consultation,
            this.toolStripButton_Quitter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
<<<<<<< HEAD
            this.toolStrip1.Size = new System.Drawing.Size(1067, 27);
=======
            this.toolStrip1.Size = new System.Drawing.Size(905, 25);
>>>>>>> c766acf11f6fdfc97ead3b983c2bbd1e28a171f1
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton_Gestion
            // 
            this.toolStripDropDownButton_Gestion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_Gestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesEtudiantsToolStripMenuItem,
            this.gestionDesNotesToolStripMenuItem});
            this.toolStripDropDownButton_Gestion.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_Gestion.Image")));
            this.toolStripDropDownButton_Gestion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_Gestion.Name = "toolStripDropDownButton_Gestion";
            this.toolStripDropDownButton_Gestion.Size = new System.Drawing.Size(73, 24);
            this.toolStripDropDownButton_Gestion.Text = "Gestion";
            this.toolStripDropDownButton_Gestion.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripDropDownButton_Gestion.ToolTipText = "toolStripDropDownButton_Gestion";
            // 
            // gestionDesEtudiantsToolStripMenuItem
            // 
            this.gestionDesEtudiantsToolStripMenuItem.Name = "gestionDesEtudiantsToolStripMenuItem";
            this.gestionDesEtudiantsToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.gestionDesEtudiantsToolStripMenuItem.Text = "Gestion des etudiants";
            this.gestionDesEtudiantsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesEtudiantsToolStripMenuItem_Click);
            // 
            // gestionDesNotesToolStripMenuItem
            // 
            this.gestionDesNotesToolStripMenuItem.Name = "gestionDesNotesToolStripMenuItem";
            this.gestionDesNotesToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.gestionDesNotesToolStripMenuItem.Text = "Gestion des notes";
            this.gestionDesNotesToolStripMenuItem.Click += new System.EventHandler(this.gestionDesNotesToolStripMenuItem_Click);
            // 
            // toolStripButton_Consultation
            // 
            this.toolStripButton_Consultation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Consultation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Consultation.Name = "toolStripButton_Consultation";
<<<<<<< HEAD
            this.toolStripButton_Consultation.Size = new System.Drawing.Size(96, 24);
=======
            this.toolStripButton_Consultation.Size = new System.Drawing.Size(79, 22);
>>>>>>> c766acf11f6fdfc97ead3b983c2bbd1e28a171f1
            this.toolStripButton_Consultation.Text = "Consultation";
            this.toolStripButton_Consultation.ToolTipText = "toolStripButton_Consultation";
            this.toolStripButton_Consultation.Click += new System.EventHandler(this.toolStripButton_Consultation_Click);
            // 
            // toolStripButton_Quitter
            // 
            this.toolStripButton_Quitter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Quitter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Quitter.Image")));
            this.toolStripButton_Quitter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Quitter.Name = "toolStripButton_Quitter";
<<<<<<< HEAD
            this.toolStripButton_Quitter.Size = new System.Drawing.Size(59, 24);
=======
            this.toolStripButton_Quitter.Size = new System.Drawing.Size(48, 22);
>>>>>>> c766acf11f6fdfc97ead3b983c2bbd1e28a171f1
            this.toolStripButton_Quitter.Text = "Quitter";
            this.toolStripButton_Quitter.Click += new System.EventHandler(this.toolStripButton_Quitter_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1067, 554);
=======
            this.ClientSize = new System.Drawing.Size(905, 536);
>>>>>>> c766acf11f6fdfc97ead3b983c2bbd1e28a171f1
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Menu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseTP2DataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DatabaseTP2DataSet databaseTP2DataSet;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private DatabaseTP2DataSetTableAdapters.TableTableAdapter tableTableAdapter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_Gestion;
        private System.Windows.Forms.ToolStripMenuItem gestionDesEtudiantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_Consultation;
        private System.Windows.Forms.ToolStripButton toolStripButton_Quitter;
    }
}

