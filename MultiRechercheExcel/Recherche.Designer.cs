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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.paramétrageRechercheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesProfilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.b_recherche = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_ViderFichiersBases = new System.Windows.Forms.Button();
            this.lv_bases = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_ajouterFichierBase = new System.Windows.Forms.Button();
            this.tb_valeursBase = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.b_AppliquerTransformation = new System.Windows.Forms.Button();
            this.cb_ProfilAction = new System.Windows.Forms.ComboBox();
            this.lb_fichiersTransformation = new System.Windows.Forms.ListBox();
            this.b_ajouterFichierTransformation = new System.Windows.Forms.Button();
            this.l_filename = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
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
            this.columnHeader2.Width = 90;
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 316);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(294, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paramétrageRechercheToolStripMenuItem,
            this.gestionDesProfilsToolStripMenuItem,
            this.aProposToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // paramétrageRechercheToolStripMenuItem
            // 
            this.paramétrageRechercheToolStripMenuItem.Name = "paramétrageRechercheToolStripMenuItem";
            this.paramétrageRechercheToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.paramétrageRechercheToolStripMenuItem.Text = "Paramétrage recherche";
            this.paramétrageRechercheToolStripMenuItem.Click += new System.EventHandler(this.paramétrageRechercheToolStripMenuItem_Click);
            // 
            // gestionDesProfilsToolStripMenuItem
            // 
            this.gestionDesProfilsToolStripMenuItem.Name = "gestionDesProfilsToolStripMenuItem";
            this.gestionDesProfilsToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.gestionDesProfilsToolStripMenuItem.Text = "Gestion des profils";
            this.gestionDesProfilsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesProfilsToolStripMenuItem_Click);
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aProposToolStripMenuItem.Text = "A propos";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(705, 382);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.l_filename);
            this.tabPage1.Controls.Add(this.b_recherche);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(697, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recherche";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // b_recherche
            // 
            this.b_recherche.Location = new System.Drawing.Point(605, 302);
            this.b_recherche.Name = "b_recherche";
            this.b_recherche.Size = new System.Drawing.Size(86, 37);
            this.b_recherche.TabIndex = 8;
            this.b_recherche.Text = "Recherche";
            this.b_recherche.UseVisualStyleBackColor = true;
            this.b_recherche.Click += new System.EventHandler(this.b_recherche_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_ViderFichiersBases);
            this.groupBox2.Controls.Add(this.lv_bases);
            this.groupBox2.Controls.Add(this.b_ajouterFichierBase);
            this.groupBox2.Controls.Add(this.tb_valeursBase);
            this.groupBox2.Location = new System.Drawing.Point(385, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 276);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bases";
            // 
            // b_ViderFichiersBases
            // 
            this.b_ViderFichiersBases.Location = new System.Drawing.Point(196, 247);
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
            this.columnHeader4.Width = 90;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.b_AppliquerTransformation);
            this.tabPage2.Controls.Add(this.cb_ProfilAction);
            this.tabPage2.Controls.Add(this.lb_fichiersTransformation);
            this.tabPage2.Controls.Add(this.b_ajouterFichierTransformation);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(697, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transformation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // b_AppliquerTransformation
            // 
            this.b_AppliquerTransformation.Location = new System.Drawing.Point(233, 189);
            this.b_AppliquerTransformation.Name = "b_AppliquerTransformation";
            this.b_AppliquerTransformation.Size = new System.Drawing.Size(121, 23);
            this.b_AppliquerTransformation.TabIndex = 6;
            this.b_AppliquerTransformation.Text = "Appliquer";
            this.b_AppliquerTransformation.UseVisualStyleBackColor = true;
            this.b_AppliquerTransformation.Click += new System.EventHandler(this.b_AppliquerTransformation_Click);
            // 
            // cb_ProfilAction
            // 
            this.cb_ProfilAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProfilAction.FormattingEnabled = true;
            this.cb_ProfilAction.Location = new System.Drawing.Point(233, 65);
            this.cb_ProfilAction.Name = "cb_ProfilAction";
            this.cb_ProfilAction.Size = new System.Drawing.Size(121, 21);
            this.cb_ProfilAction.TabIndex = 5;
            // 
            // lb_fichiersTransformation
            // 
            this.lb_fichiersTransformation.FormattingEnabled = true;
            this.lb_fichiersTransformation.Location = new System.Drawing.Point(22, 65);
            this.lb_fichiersTransformation.Name = "lb_fichiersTransformation";
            this.lb_fichiersTransformation.Size = new System.Drawing.Size(161, 147);
            this.lb_fichiersTransformation.TabIndex = 4;
            // 
            // b_ajouterFichierTransformation
            // 
            this.b_ajouterFichierTransformation.Location = new System.Drawing.Point(22, 22);
            this.b_ajouterFichierTransformation.Name = "b_ajouterFichierTransformation";
            this.b_ajouterFichierTransformation.Size = new System.Drawing.Size(104, 23);
            this.b_ajouterFichierTransformation.TabIndex = 3;
            this.b_ajouterFichierTransformation.Text = "Ajouter fichier";
            this.b_ajouterFichierTransformation.UseVisualStyleBackColor = true;
            this.b_ajouterFichierTransformation.Click += new System.EventHandler(this.b_ajouterFichierTransformation_Click);
            // 
            // l_filename
            // 
            this.l_filename.AutoSize = true;
            this.l_filename.Location = new System.Drawing.Point(328, 326);
            this.l_filename.Name = "l_filename";
            this.l_filename.Size = new System.Drawing.Size(0, 13);
            this.l_filename.TabIndex = 9;
            // 
            // Recherche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 411);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Recherche";
            this.Text = "MultiRechercheExcel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_valeursRecherche;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lv_valeurs;
        private System.Windows.Forms.Button b_ajouterFichierValeurs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button b_ViderFichiersValeurs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionDesProfilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramétrageRechercheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button b_recherche;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button b_ViderFichiersBases;
        private System.Windows.Forms.ListView lv_bases;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button b_ajouterFichierBase;
        private System.Windows.Forms.TextBox tb_valeursBase;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button b_AppliquerTransformation;
        private System.Windows.Forms.ComboBox cb_ProfilAction;
        private System.Windows.Forms.Button b_ajouterFichierTransformation;
        private System.Windows.Forms.ListBox lb_fichiersTransformation;
        private System.Windows.Forms.Label l_filename;
    }
}

