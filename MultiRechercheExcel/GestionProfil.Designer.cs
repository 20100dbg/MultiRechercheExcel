namespace MultiRechercheExcel
{
    partial class GestionProfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionProfil));
            this.b_fermer = new System.Windows.Forms.Button();
            this.cb_separateur = new System.Windows.Forms.ComboBox();
            this.tb_ColsAfficher = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_NomRecherche = new System.Windows.Forms.TextBox();
            this.b_SupprimerRecherche = new System.Windows.Forms.Button();
            this.b_NouveauRecherche = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ProfilRecherche = new System.Windows.Forms.ComboBox();
            this.num_NbEntetes = new System.Windows.Forms.NumericUpDown();
            this.b_SauvegarderProfil = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ColsEltecs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_nomFeuille = new System.Windows.Forms.TextBox();
            this.rb_nomFeuille = new System.Windows.Forms.RadioButton();
            this.rb_numFeuille = new System.Windows.Forms.RadioButton();
            this.num_idxFeuille = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_descendreAction = new System.Windows.Forms.Button();
            this.b_monterAction = new System.Windows.Forms.Button();
            this.b_supprimerAction = new System.Windows.Forms.Button();
            this.l_destination = new System.Windows.Forms.Label();
            this.l_transformation = new System.Windows.Forms.Label();
            this.b_configurerTexte = new System.Windows.Forms.Button();
            this.b_ajouterAction = new System.Windows.Forms.Button();
            this.lv_actions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.num_Destination = new System.Windows.Forms.NumericUpDown();
            this.num_Source = new System.Windows.Forms.NumericUpDown();
            this.l_source = new System.Windows.Forms.Label();
            this.cb_ProfilAction = new System.Windows.Forms.ComboBox();
            this.cb_TypeAction = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.b_SauvegarderAction = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_NomAction = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.b_SupprimerProfilAction = new System.Windows.Forms.Button();
            this.b_NouveauProfilAction = new System.Windows.Forms.Button();
            this.cb_toutesColsEltec = new System.Windows.Forms.CheckBox();
            this.cb_toutesColsAffichees = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_NbEntetes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_idxFeuille)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Destination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Source)).BeginInit();
            this.SuspendLayout();
            // 
            // b_fermer
            // 
            this.b_fermer.Location = new System.Drawing.Point(7, 442);
            this.b_fermer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_fermer.Name = "b_fermer";
            this.b_fermer.Size = new System.Drawing.Size(107, 36);
            this.b_fermer.TabIndex = 49;
            this.b_fermer.Text = "Fermer";
            this.b_fermer.UseVisualStyleBackColor = true;
            this.b_fermer.Click += new System.EventHandler(this.b_fermer_Click);
            // 
            // cb_separateur
            // 
            this.cb_separateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_separateur.FormattingEnabled = true;
            this.cb_separateur.Location = new System.Drawing.Point(165, 260);
            this.cb_separateur.Name = "cb_separateur";
            this.cb_separateur.Size = new System.Drawing.Size(109, 21);
            this.cb_separateur.TabIndex = 64;
            // 
            // tb_ColsAfficher
            // 
            this.tb_ColsAfficher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ColsAfficher.Location = new System.Drawing.Point(165, 164);
            this.tb_ColsAfficher.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_ColsAfficher.Name = "tb_ColsAfficher";
            this.tb_ColsAfficher.Size = new System.Drawing.Size(174, 22);
            this.tb_ColsAfficher.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Colonnes fichier à afficher";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 263);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Separateur de colonnes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Nom du profil";
            // 
            // tb_NomRecherche
            // 
            this.tb_NomRecherche.Location = new System.Drawing.Point(165, 77);
            this.tb_NomRecherche.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_NomRecherche.Name = "tb_NomRecherche";
            this.tb_NomRecherche.Size = new System.Drawing.Size(174, 20);
            this.tb_NomRecherche.TabIndex = 53;
            // 
            // b_SupprimerRecherche
            // 
            this.b_SupprimerRecherche.Location = new System.Drawing.Point(305, 27);
            this.b_SupprimerRecherche.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_SupprimerRecherche.Name = "b_SupprimerRecherche";
            this.b_SupprimerRecherche.Size = new System.Drawing.Size(74, 23);
            this.b_SupprimerRecherche.TabIndex = 52;
            this.b_SupprimerRecherche.Text = "Supprimer";
            this.b_SupprimerRecherche.UseVisualStyleBackColor = true;
            this.b_SupprimerRecherche.Click += new System.EventHandler(this.b_SupprimerRecherche_Click);
            // 
            // b_NouveauRecherche
            // 
            this.b_NouveauRecherche.Location = new System.Drawing.Point(227, 27);
            this.b_NouveauRecherche.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_NouveauRecherche.Name = "b_NouveauRecherche";
            this.b_NouveauRecherche.Size = new System.Drawing.Size(74, 23);
            this.b_NouveauRecherche.TabIndex = 51;
            this.b_NouveauRecherche.Text = "Nouveau...";
            this.b_NouveauRecherche.UseVisualStyleBackColor = true;
            this.b_NouveauRecherche.Click += new System.EventHandler(this.b_NouveauRecherche_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Profil";
            // 
            // cb_ProfilRecherche
            // 
            this.cb_ProfilRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProfilRecherche.FormattingEnabled = true;
            this.cb_ProfilRecherche.Location = new System.Drawing.Point(55, 29);
            this.cb_ProfilRecherche.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ProfilRecherche.Name = "cb_ProfilRecherche";
            this.cb_ProfilRecherche.Size = new System.Drawing.Size(159, 21);
            this.cb_ProfilRecherche.TabIndex = 50;
            this.cb_ProfilRecherche.SelectedIndexChanged += new System.EventHandler(this.cb_profil_SelectedIndexChanged);
            // 
            // num_NbEntetes
            // 
            this.num_NbEntetes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_NbEntetes.Location = new System.Drawing.Point(165, 230);
            this.num_NbEntetes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.num_NbEntetes.Name = "num_NbEntetes";
            this.num_NbEntetes.Size = new System.Drawing.Size(68, 22);
            this.num_NbEntetes.TabIndex = 56;
            // 
            // b_SauvegarderProfil
            // 
            this.b_SauvegarderProfil.Location = new System.Drawing.Point(298, 372);
            this.b_SauvegarderProfil.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_SauvegarderProfil.Name = "b_SauvegarderProfil";
            this.b_SauvegarderProfil.Size = new System.Drawing.Size(89, 40);
            this.b_SauvegarderProfil.TabIndex = 57;
            this.b_SauvegarderProfil.Text = "Sauvegarder";
            this.b_SauvegarderProfil.UseVisualStyleBackColor = true;
            this.b_SauvegarderProfil.Click += new System.EventHandler(this.b_SauvegarderProfil_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 234);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Nb lignes à ignorer";
            // 
            // tb_ColsEltecs
            // 
            this.tb_ColsEltecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ColsEltecs.Location = new System.Drawing.Point(165, 103);
            this.tb_ColsEltecs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_ColsEltecs.Name = "tb_ColsEltecs";
            this.tb_ColsEltecs.Size = new System.Drawing.Size(174, 22);
            this.tb_ColsEltecs.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Colonnes eltecs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_toutesColsAffichees);
            this.groupBox1.Controls.Add(this.cb_toutesColsEltec);
            this.groupBox1.Controls.Add(this.tb_nomFeuille);
            this.groupBox1.Controls.Add(this.rb_nomFeuille);
            this.groupBox1.Controls.Add(this.rb_numFeuille);
            this.groupBox1.Controls.Add(this.num_idxFeuille);
            this.groupBox1.Controls.Add(this.cb_ProfilRecherche);
            this.groupBox1.Controls.Add(this.cb_separateur);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_ColsAfficher);
            this.groupBox1.Controls.Add(this.tb_ColsEltecs);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.b_SauvegarderProfil);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.num_NbEntetes);
            this.groupBox1.Controls.Add(this.tb_NomRecherche);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.b_SupprimerRecherche);
            this.groupBox1.Controls.Add(this.b_NouveauRecherche);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 424);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profil de recherche";
            // 
            // tb_nomFeuille
            // 
            this.tb_nomFeuille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nomFeuille.Location = new System.Drawing.Point(165, 333);
            this.tb_nomFeuille.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_nomFeuille.Name = "tb_nomFeuille";
            this.tb_nomFeuille.Size = new System.Drawing.Size(174, 22);
            this.tb_nomFeuille.TabIndex = 70;
            // 
            // rb_nomFeuille
            // 
            this.rb_nomFeuille.AutoSize = true;
            this.rb_nomFeuille.Location = new System.Drawing.Point(10, 336);
            this.rb_nomFeuille.Name = "rb_nomFeuille";
            this.rb_nomFeuille.Size = new System.Drawing.Size(77, 17);
            this.rb_nomFeuille.TabIndex = 69;
            this.rb_nomFeuille.TabStop = true;
            this.rb_nomFeuille.Text = "Nom feuille";
            this.rb_nomFeuille.UseVisualStyleBackColor = true;
            // 
            // rb_numFeuille
            // 
            this.rb_numFeuille.AutoSize = true;
            this.rb_numFeuille.Checked = true;
            this.rb_numFeuille.Location = new System.Drawing.Point(10, 307);
            this.rb_numFeuille.Name = "rb_numFeuille";
            this.rb_numFeuille.Size = new System.Drawing.Size(92, 17);
            this.rb_numFeuille.TabIndex = 67;
            this.rb_numFeuille.TabStop = true;
            this.rb_numFeuille.Text = "Numero feuille";
            this.rb_numFeuille.UseVisualStyleBackColor = true;
            // 
            // num_idxFeuille
            // 
            this.num_idxFeuille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_idxFeuille.Location = new System.Drawing.Point(165, 305);
            this.num_idxFeuille.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.num_idxFeuille.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_idxFeuille.Name = "num_idxFeuille";
            this.num_idxFeuille.Size = new System.Drawing.Size(68, 22);
            this.num_idxFeuille.TabIndex = 65;
            this.num_idxFeuille.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_descendreAction);
            this.groupBox2.Controls.Add(this.b_monterAction);
            this.groupBox2.Controls.Add(this.b_supprimerAction);
            this.groupBox2.Controls.Add(this.l_destination);
            this.groupBox2.Controls.Add(this.l_transformation);
            this.groupBox2.Controls.Add(this.b_configurerTexte);
            this.groupBox2.Controls.Add(this.b_ajouterAction);
            this.groupBox2.Controls.Add(this.lv_actions);
            this.groupBox2.Controls.Add(this.num_Destination);
            this.groupBox2.Controls.Add(this.num_Source);
            this.groupBox2.Controls.Add(this.l_source);
            this.groupBox2.Controls.Add(this.cb_ProfilAction);
            this.groupBox2.Controls.Add(this.cb_TypeAction);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.b_SauvegarderAction);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tb_NomAction);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.b_SupprimerProfilAction);
            this.groupBox2.Controls.Add(this.b_NouveauProfilAction);
            this.groupBox2.Location = new System.Drawing.Point(427, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 424);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions sur fichiers Excel";
            // 
            // b_descendreAction
            // 
            this.b_descendreAction.Image = ((System.Drawing.Image)(resources.GetObject("b_descendreAction.Image")));
            this.b_descendreAction.Location = new System.Drawing.Point(318, 317);
            this.b_descendreAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_descendreAction.Name = "b_descendreAction";
            this.b_descendreAction.Size = new System.Drawing.Size(27, 32);
            this.b_descendreAction.TabIndex = 79;
            this.b_descendreAction.UseVisualStyleBackColor = true;
            this.b_descendreAction.Click += new System.EventHandler(this.b_descendreAction_Click);
            // 
            // b_monterAction
            // 
            this.b_monterAction.Image = ((System.Drawing.Image)(resources.GetObject("b_monterAction.Image")));
            this.b_monterAction.Location = new System.Drawing.Point(318, 252);
            this.b_monterAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_monterAction.Name = "b_monterAction";
            this.b_monterAction.Size = new System.Drawing.Size(27, 32);
            this.b_monterAction.TabIndex = 78;
            this.b_monterAction.UseVisualStyleBackColor = true;
            this.b_monterAction.Click += new System.EventHandler(this.b_monterAction_Click);
            // 
            // b_supprimerAction
            // 
            this.b_supprimerAction.Location = new System.Drawing.Point(359, 283);
            this.b_supprimerAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_supprimerAction.Name = "b_supprimerAction";
            this.b_supprimerAction.Size = new System.Drawing.Size(68, 36);
            this.b_supprimerAction.TabIndex = 77;
            this.b_supprimerAction.Text = "Supprimer action";
            this.b_supprimerAction.UseVisualStyleBackColor = true;
            this.b_supprimerAction.Click += new System.EventHandler(this.b_supprimerAction_Click);
            // 
            // l_destination
            // 
            this.l_destination.AutoSize = true;
            this.l_destination.Location = new System.Drawing.Point(212, 154);
            this.l_destination.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_destination.Name = "l_destination";
            this.l_destination.Size = new System.Drawing.Size(87, 13);
            this.l_destination.TabIndex = 76;
            this.l_destination.Text = "Index destination";
            // 
            // l_transformation
            // 
            this.l_transformation.AutoSize = true;
            this.l_transformation.Location = new System.Drawing.Point(302, 188);
            this.l_transformation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_transformation.Name = "l_transformation";
            this.l_transformation.Size = new System.Drawing.Size(43, 13);
            this.l_transformation.TabIndex = 75;
            this.l_transformation.Text = "______";
            // 
            // b_configurerTexte
            // 
            this.b_configurerTexte.Location = new System.Drawing.Point(97, 179);
            this.b_configurerTexte.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_configurerTexte.Name = "b_configurerTexte";
            this.b_configurerTexte.Size = new System.Drawing.Size(185, 28);
            this.b_configurerTexte.TabIndex = 74;
            this.b_configurerTexte.Text = "Configurer transformation de texte";
            this.b_configurerTexte.UseVisualStyleBackColor = true;
            this.b_configurerTexte.Click += new System.EventHandler(this.tb_configurerTexte_Click);
            // 
            // b_ajouterAction
            // 
            this.b_ajouterAction.Location = new System.Drawing.Point(320, 213);
            this.b_ajouterAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_ajouterAction.Name = "b_ajouterAction";
            this.b_ajouterAction.Size = new System.Drawing.Size(89, 23);
            this.b_ajouterAction.TabIndex = 73;
            this.b_ajouterAction.Text = "Ajouter action";
            this.b_ajouterAction.UseVisualStyleBackColor = true;
            this.b_ajouterAction.Click += new System.EventHandler(this.b_ajouterAction_Click);
            // 
            // lv_actions
            // 
            this.lv_actions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_actions.FullRowSelect = true;
            this.lv_actions.GridLines = true;
            this.lv_actions.HideSelection = false;
            this.lv_actions.Location = new System.Drawing.Point(6, 252);
            this.lv_actions.Name = "lv_actions";
            this.lv_actions.Size = new System.Drawing.Size(309, 97);
            this.lv_actions.TabIndex = 72;
            this.lv_actions.UseCompatibleStateImageBehavior = false;
            this.lv_actions.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Action";
            this.columnHeader1.Width = 185;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Src";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Dst";
            // 
            // num_Destination
            // 
            this.num_Destination.Location = new System.Drawing.Point(305, 152);
            this.num_Destination.Name = "num_Destination";
            this.num_Destination.Size = new System.Drawing.Size(45, 20);
            this.num_Destination.TabIndex = 69;
            // 
            // num_Source
            // 
            this.num_Source.Location = new System.Drawing.Point(125, 150);
            this.num_Source.Name = "num_Source";
            this.num_Source.Size = new System.Drawing.Size(45, 20);
            this.num_Source.TabIndex = 67;
            // 
            // l_source
            // 
            this.l_source.AutoSize = true;
            this.l_source.Location = new System.Drawing.Point(52, 154);
            this.l_source.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_source.Name = "l_source";
            this.l_source.Size = new System.Drawing.Size(68, 13);
            this.l_source.TabIndex = 66;
            this.l_source.Text = "Index source";
            // 
            // cb_ProfilAction
            // 
            this.cb_ProfilAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProfilAction.FormattingEnabled = true;
            this.cb_ProfilAction.Location = new System.Drawing.Point(55, 29);
            this.cb_ProfilAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_ProfilAction.Name = "cb_ProfilAction";
            this.cb_ProfilAction.Size = new System.Drawing.Size(191, 21);
            this.cb_ProfilAction.TabIndex = 50;
            this.cb_ProfilAction.SelectedIndexChanged += new System.EventHandler(this.cb_ProfilAction_SelectedIndexChanged);
            // 
            // cb_TypeAction
            // 
            this.cb_TypeAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TypeAction.FormattingEnabled = true;
            this.cb_TypeAction.Location = new System.Drawing.Point(165, 123);
            this.cb_TypeAction.Name = "cb_TypeAction";
            this.cb_TypeAction.Size = new System.Drawing.Size(137, 21);
            this.cb_TypeAction.TabIndex = 64;
            this.cb_TypeAction.SelectedIndexChanged += new System.EventHandler(this.cb_TypeAction_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Action";
            // 
            // b_SauvegarderAction
            // 
            this.b_SauvegarderAction.Location = new System.Drawing.Point(340, 372);
            this.b_SauvegarderAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_SauvegarderAction.Name = "b_SauvegarderAction";
            this.b_SauvegarderAction.Size = new System.Drawing.Size(89, 40);
            this.b_SauvegarderAction.TabIndex = 57;
            this.b_SauvegarderAction.Text = "Sauvegarder";
            this.b_SauvegarderAction.UseVisualStyleBackColor = true;
            this.b_SauvegarderAction.Click += new System.EventHandler(this.b_SauvegarderAction_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 80);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "Nom du profil";
            // 
            // tb_NomAction
            // 
            this.tb_NomAction.Location = new System.Drawing.Point(165, 77);
            this.tb_NomAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_NomAction.Name = "tb_NomAction";
            this.tb_NomAction.Size = new System.Drawing.Size(210, 20);
            this.tb_NomAction.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 32);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 60;
            this.label12.Text = "Profil";
            // 
            // b_SupprimerProfilAction
            // 
            this.b_SupprimerProfilAction.Location = new System.Drawing.Point(343, 27);
            this.b_SupprimerProfilAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_SupprimerProfilAction.Name = "b_SupprimerProfilAction";
            this.b_SupprimerProfilAction.Size = new System.Drawing.Size(74, 23);
            this.b_SupprimerProfilAction.TabIndex = 52;
            this.b_SupprimerProfilAction.Text = "Supprimer";
            this.b_SupprimerProfilAction.UseVisualStyleBackColor = true;
            this.b_SupprimerProfilAction.Click += new System.EventHandler(this.b_SupprimerProfilAction_Click);
            // 
            // b_NouveauProfilAction
            // 
            this.b_NouveauProfilAction.Location = new System.Drawing.Point(265, 27);
            this.b_NouveauProfilAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_NouveauProfilAction.Name = "b_NouveauProfilAction";
            this.b_NouveauProfilAction.Size = new System.Drawing.Size(74, 23);
            this.b_NouveauProfilAction.TabIndex = 51;
            this.b_NouveauProfilAction.Text = "Nouveau...";
            this.b_NouveauProfilAction.UseVisualStyleBackColor = true;
            this.b_NouveauProfilAction.Click += new System.EventHandler(this.b_NouveauProfilAction_Click);
            // 
            // cb_toutesColsEltec
            // 
            this.cb_toutesColsEltec.AutoSize = true;
            this.cb_toutesColsEltec.Location = new System.Drawing.Point(165, 129);
            this.cb_toutesColsEltec.Name = "cb_toutesColsEltec";
            this.cb_toutesColsEltec.Size = new System.Drawing.Size(189, 17);
            this.cb_toutesColsEltec.TabIndex = 71;
            this.cb_toutesColsEltec.Text = "Chercher dans toutes les colonnes";
            this.cb_toutesColsEltec.UseVisualStyleBackColor = true;
            this.cb_toutesColsEltec.CheckedChanged += new System.EventHandler(this.cb_toutesColsEltec_CheckedChanged);
            // 
            // cb_toutesColsAffichees
            // 
            this.cb_toutesColsAffichees.AutoSize = true;
            this.cb_toutesColsAffichees.Location = new System.Drawing.Point(165, 192);
            this.cb_toutesColsAffichees.Name = "cb_toutesColsAffichees";
            this.cb_toutesColsAffichees.Size = new System.Drawing.Size(156, 17);
            this.cb_toutesColsAffichees.TabIndex = 72;
            this.cb_toutesColsAffichees.Text = "Afficher toutes les colonnes";
            this.cb_toutesColsAffichees.UseVisualStyleBackColor = true;
            this.cb_toutesColsAffichees.CheckedChanged += new System.EventHandler(this.cb_toutesColsAffichees_CheckedChanged);
            // 
            // GestionProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 491);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.b_fermer);
            this.Name = "GestionProfil";
            this.Text = "GestionProfil";
            ((System.ComponentModel.ISupportInitialize)(this.num_NbEntetes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_idxFeuille)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Destination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Source)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button b_fermer;
        private System.Windows.Forms.ComboBox cb_separateur;
        private System.Windows.Forms.TextBox tb_ColsAfficher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_NomRecherche;
        private System.Windows.Forms.Button b_SupprimerRecherche;
        private System.Windows.Forms.Button b_NouveauRecherche;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_ProfilRecherche;
        private System.Windows.Forms.NumericUpDown num_NbEntetes;
        private System.Windows.Forms.Button b_SauvegarderProfil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ColsEltecs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label l_source;
        private System.Windows.Forms.ComboBox cb_ProfilAction;
        private System.Windows.Forms.ComboBox cb_TypeAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button b_SauvegarderAction;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_NomAction;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button b_SupprimerProfilAction;
        private System.Windows.Forms.Button b_NouveauProfilAction;
        private System.Windows.Forms.NumericUpDown num_Destination;
        private System.Windows.Forms.NumericUpDown num_Source;
        private System.Windows.Forms.ListView lv_actions;
        private System.Windows.Forms.Button b_ajouterAction;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button b_configurerTexte;
        private System.Windows.Forms.Label l_transformation;
        private System.Windows.Forms.Label l_destination;
        private System.Windows.Forms.Button b_supprimerAction;
        private System.Windows.Forms.Button b_monterAction;
        private System.Windows.Forms.Button b_descendreAction;
        private System.Windows.Forms.TextBox tb_nomFeuille;
        private System.Windows.Forms.RadioButton rb_nomFeuille;
        private System.Windows.Forms.RadioButton rb_numFeuille;
        private System.Windows.Forms.NumericUpDown num_idxFeuille;
        private System.Windows.Forms.CheckBox cb_toutesColsAffichees;
        private System.Windows.Forms.CheckBox cb_toutesColsEltec;
    }
}