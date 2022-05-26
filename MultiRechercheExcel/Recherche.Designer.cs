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
            this.b_ViderFichiersValeurs = new System.Windows.Forms.Button();
            this.lv_valeurs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_ajouterFichierValeurs = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_ViderFichiersBases = new System.Windows.Forms.Button();
            this.lv_bases = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_ajouterFichierBase = new System.Windows.Forms.Button();
            this.tb_valeursBase = new System.Windows.Forms.TextBox();
            this.b_recherche = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionDesProfilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramétrageRechercheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.b_ViderFichiersValeurs);
            this.groupBox1.Controls.Add(this.lv_valeurs);
            this.groupBox1.Controls.Add(this.b_ajouterFichierValeurs);
            this.groupBox1.Controls.Add(this.tb_valeursRecherche);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 276);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valeurs";
            // 
            // b_ViderFichiersValeurs
            // 
            this.b_ViderFichiersValeurs.Location = new System.Drawing.Point(196, 247);
            this.b_ViderFichiersValeurs.Name = "b_ViderFichiersValeurs";
            this.b_ViderFichiersValeurs.Size = new System.Drawing.Size(104, 23);
            this.b_ViderFichiersValeurs.TabIndex = 4;
            this.b_ViderFichiersValeurs.Text = "Vider fichiers";
            this.b_ViderFichiersValeurs.UseVisualStyleBackColor = true;
            this.b_ViderFichiersValeurs.Click += new System.EventHandler(this.b_ViderFichiersValeurs_Click);
            // 
            // lv_valeurs
            // 
            this.lv_valeurs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_valeurs.FullRowSelect = true;
            this.lv_valeurs.GridLines = true;
            this.lv_valeurs.HideSelection = false;
            this.lv_valeurs.Location = new System.Drawing.Point(6, 136);
            this.lv_valeurs.Name = "lv_valeurs";
            this.lv_valeurs.Size = new System.Drawing.Size(294, 97);
            this.lv_valeurs.TabIndex = 3;
            this.lv_valeurs.UseCompatibleStateImageBehavior = false;
            this.lv_valeurs.View = System.Windows.Forms.View.Details;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_ViderFichiersBases);
            this.groupBox2.Controls.Add(this.lv_bases);
            this.groupBox2.Controls.Add(this.b_ajouterFichierBase);
            this.groupBox2.Controls.Add(this.tb_valeursBase);
            this.groupBox2.Location = new System.Drawing.Point(397, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 276);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bases";
            // 
            // b_ViderFichiersBases
            // 
            this.b_ViderFichiersBases.Location = new System.Drawing.Point(202, 247);
            this.b_ViderFichiersBases.Name = "b_ViderFichiersBases";
            this.b_ViderFichiersBases.Size = new System.Drawing.Size(104, 23);
            this.b_ViderFichiersBases.TabIndex = 5;
            this.b_ViderFichiersBases.Text = "Vider fichiers";
            this.b_ViderFichiersBases.UseVisualStyleBackColor = true;
            this.b_ViderFichiersBases.Click += new System.EventHandler(this.b_ViderFichiersBases_Click);
            // 
            // lv_bases
            // 
            this.lv_bases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lv_bases.FullRowSelect = true;
            this.lv_bases.GridLines = true;
            this.lv_bases.HideSelection = false;
            this.lv_bases.Location = new System.Drawing.Point(6, 136);
            this.lv_bases.Name = "lv_bases";
            this.lv_bases.Size = new System.Drawing.Size(294, 97);
            this.lv_bases.TabIndex = 3;
            this.lv_bases.UseCompatibleStateImageBehavior = false;
            this.lv_bases.View = System.Windows.Forms.View.Details;
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
            this.b_recherche.Location = new System.Drawing.Point(593, 346);
            this.b_recherche.Name = "b_recherche";
            this.b_recherche.Size = new System.Drawing.Size(86, 37);
            this.b_recherche.TabIndex = 5;
            this.b_recherche.Text = "Recherche";
            this.b_recherche.UseVisualStyleBackColor = true;
            this.b_recherche.Click += new System.EventHandler(this.b_recherche_Click);
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
            this.progressBar1.Location = new System.Drawing.Point(18, 360);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(294, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesProfilsToolStripMenuItem,
            this.paramétrageRechercheToolStripMenuItem,
            this.aProposToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(725, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionDesProfilsToolStripMenuItem
            // 
            this.gestionDesProfilsToolStripMenuItem.Name = "gestionDesProfilsToolStripMenuItem";
            this.gestionDesProfilsToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.gestionDesProfilsToolStripMenuItem.Text = "Gestion des profils";
            this.gestionDesProfilsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesProfilsToolStripMenuItem_Click);
            // 
            // paramétrageRechercheToolStripMenuItem
            // 
            this.paramétrageRechercheToolStripMenuItem.Name = "paramétrageRechercheToolStripMenuItem";
            this.paramétrageRechercheToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.paramétrageRechercheToolStripMenuItem.Text = "Paramétrage recherche";
            this.paramétrageRechercheToolStripMenuItem.Click += new System.EventHandler(this.paramétrageRechercheToolStripMenuItem_Click);
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aProposToolStripMenuItem.Text = "A propos";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // Recherche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 399);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.b_recherche);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Recherche";
            this.Text = "MultiRechercheExcel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_valeursRecherche;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lv_valeurs;
        private System.Windows.Forms.Button b_ajouterFichierValeurs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_bases;
        private System.Windows.Forms.Button b_ajouterFichierBase;
        private System.Windows.Forms.TextBox tb_valeursBase;
        private System.Windows.Forms.Button b_recherche;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button b_ViderFichiersValeurs;
        private System.Windows.Forms.Button b_ViderFichiersBases;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionDesProfilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramétrageRechercheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
    }
}

