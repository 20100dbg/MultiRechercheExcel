namespace MultiRechercheExcel
{
    partial class Recherche
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
            this.tb_valeursRecherche = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lv_recherche = new System.Windows.Forms.ListView();
            this.b_ajouterFichierValeurs = new System.Windows.Forms.Button();
            this.b_gestionProfil = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_base = new System.Windows.Forms.ListView();
            this.b_ajouterFichierBase = new System.Windows.Forms.Button();
            this.tb_valeursBase = new System.Windows.Forms.TextBox();
            this.b_recherche = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_valeursRecherche
            // 
            this.tb_valeursRecherche.Location = new System.Drawing.Point(6, 33);
            this.tb_valeursRecherche.Multiline = true;
            this.tb_valeursRecherche.Name = "tb_valeursRecherche";
            this.tb_valeursRecherche.Size = new System.Drawing.Size(294, 53);
            this.tb_valeursRecherche.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lv_recherche);
            this.groupBox1.Controls.Add(this.b_ajouterFichierValeurs);
            this.groupBox1.Controls.Add(this.tb_valeursRecherche);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 248);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recherche";
            // 
            // lv_recherche
            // 
            this.lv_recherche.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_recherche.FullRowSelect = true;
            this.lv_recherche.GridLines = true;
            this.lv_recherche.HideSelection = false;
            this.lv_recherche.Location = new System.Drawing.Point(6, 136);
            this.lv_recherche.Name = "lv_recherche";
            this.lv_recherche.Size = new System.Drawing.Size(294, 97);
            this.lv_recherche.TabIndex = 3;
            this.lv_recherche.UseCompatibleStateImageBehavior = false;
            this.lv_recherche.View = System.Windows.Forms.View.Details;
            // 
            // b_ajouterFichierValeurs
            // 
            this.b_ajouterFichierValeurs.Location = new System.Drawing.Point(196, 102);
            this.b_ajouterFichierValeurs.Name = "b_ajouterFichierValeurs";
            this.b_ajouterFichierValeurs.Size = new System.Drawing.Size(104, 23);
            this.b_ajouterFichierValeurs.TabIndex = 2;
            this.b_ajouterFichierValeurs.Text = "Ajouter fichier";
            this.b_ajouterFichierValeurs.UseVisualStyleBackColor = true;
            this.b_ajouterFichierValeurs.Click += new System.EventHandler(this.b_ajouterFichierValeurs_Click);
            // 
            // b_gestionProfil
            // 
            this.b_gestionProfil.Location = new System.Drawing.Point(108, 12);
            this.b_gestionProfil.Name = "b_gestionProfil";
            this.b_gestionProfil.Size = new System.Drawing.Size(104, 23);
            this.b_gestionProfil.TabIndex = 4;
            this.b_gestionProfil.Text = "Gestion profil";
            this.b_gestionProfil.UseVisualStyleBackColor = true;
            this.b_gestionProfil.Click += new System.EventHandler(this.b_gestionProfil_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_base);
            this.groupBox2.Controls.Add(this.b_ajouterFichierBase);
            this.groupBox2.Controls.Add(this.tb_valeursBase);
            this.groupBox2.Location = new System.Drawing.Point(397, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 248);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bases";
            // 
            // lv_base
            // 
            this.lv_base.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lv_base.FullRowSelect = true;
            this.lv_base.GridLines = true;
            this.lv_base.HideSelection = false;
            this.lv_base.Location = new System.Drawing.Point(6, 136);
            this.lv_base.Name = "lv_base";
            this.lv_base.Size = new System.Drawing.Size(294, 97);
            this.lv_base.TabIndex = 3;
            this.lv_base.UseCompatibleStateImageBehavior = false;
            this.lv_base.View = System.Windows.Forms.View.Details;
            // 
            // b_ajouterFichierBase
            // 
            this.b_ajouterFichierBase.Location = new System.Drawing.Point(196, 102);
            this.b_ajouterFichierBase.Name = "b_ajouterFichierBase";
            this.b_ajouterFichierBase.Size = new System.Drawing.Size(104, 23);
            this.b_ajouterFichierBase.TabIndex = 2;
            this.b_ajouterFichierBase.Text = "Ajouter fichier";
            this.b_ajouterFichierBase.UseVisualStyleBackColor = true;
            this.b_ajouterFichierBase.Click += new System.EventHandler(this.b_ajouterFichierBase_Click);
            // 
            // tb_valeursBase
            // 
            this.tb_valeursBase.Location = new System.Drawing.Point(6, 33);
            this.tb_valeursBase.Multiline = true;
            this.tb_valeursBase.Name = "tb_valeursBase";
            this.tb_valeursBase.Size = new System.Drawing.Size(294, 53);
            this.tb_valeursBase.TabIndex = 1;
            // 
            // b_recherche
            // 
            this.b_recherche.Location = new System.Drawing.Point(622, 347);
            this.b_recherche.Name = "b_recherche";
            this.b_recherche.Size = new System.Drawing.Size(75, 23);
            this.b_recherche.TabIndex = 5;
            this.b_recherche.Text = "Recherche";
            this.b_recherche.UseVisualStyleBackColor = true;
            this.b_recherche.Click += new System.EventHandler(this.b_recherche_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fichier";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Profil";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fichier";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Profil";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 346);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(294, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // Recherche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 399);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.b_recherche);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.b_gestionProfil);
            this.Controls.Add(this.groupBox1);
            this.Name = "Recherche";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_valeursRecherche;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lv_recherche;
        private System.Windows.Forms.Button b_ajouterFichierValeurs;
        private System.Windows.Forms.Button b_gestionProfil;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_base;
        private System.Windows.Forms.Button b_ajouterFichierBase;
        private System.Windows.Forms.TextBox tb_valeursBase;
        private System.Windows.Forms.Button b_recherche;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

