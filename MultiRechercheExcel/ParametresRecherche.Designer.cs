namespace MultiRechercheExcel
{
    partial class ParametresRecherche
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l_tcValeurs = new System.Windows.Forms.Label();
            this.b_tcValeurs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c = new System.Windows.Forms.GroupBox();
            this.l_tcBases = new System.Windows.Forms.Label();
            this.b_tcBases = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_typeRecherche = new System.Windows.Forms.ComboBox();
            this.b_sauvegarder = new System.Windows.Forms.Button();
            this.cb_remonterToutesOccurences = new System.Windows.Forms.CheckBox();
            this.cb_ToutesColsEltec = new System.Windows.Forms.CheckBox();
            this.cb_toutesColsAffichees = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.c.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.l_tcValeurs);
            this.groupBox1.Controls.Add(this.b_tcValeurs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valeurs";
            // 
            // l_tcValeurs
            // 
            this.l_tcValeurs.AutoSize = true;
            this.l_tcValeurs.Location = new System.Drawing.Point(6, 68);
            this.l_tcValeurs.Name = "l_tcValeurs";
            this.l_tcValeurs.Size = new System.Drawing.Size(31, 13);
            this.l_tcValeurs.TabIndex = 6;
            this.l_tcValeurs.Text = "____";
            // 
            // b_tcValeurs
            // 
            this.b_tcValeurs.Location = new System.Drawing.Point(125, 63);
            this.b_tcValeurs.Name = "b_tcValeurs";
            this.b_tcValeurs.Size = new System.Drawing.Size(75, 23);
            this.b_tcValeurs.TabIndex = 5;
            this.b_tcValeurs.Text = "Choisir";
            this.b_tcValeurs.UseVisualStyleBackColor = true;
            this.b_tcValeurs.Click += new System.EventHandler(this.b_tcValeurs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Transformation de chaine";
            // 
            // c
            // 
            this.c.Controls.Add(this.l_tcBases);
            this.c.Controls.Add(this.b_tcBases);
            this.c.Controls.Add(this.label3);
            this.c.Location = new System.Drawing.Point(240, 12);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(224, 115);
            this.c.TabIndex = 12;
            this.c.TabStop = false;
            this.c.Text = "Références";
            // 
            // l_tcBases
            // 
            this.l_tcBases.AutoSize = true;
            this.l_tcBases.Location = new System.Drawing.Point(14, 68);
            this.l_tcBases.Name = "l_tcBases";
            this.l_tcBases.Size = new System.Drawing.Size(31, 13);
            this.l_tcBases.TabIndex = 9;
            this.l_tcBases.Text = "____";
            // 
            // b_tcBases
            // 
            this.b_tcBases.Location = new System.Drawing.Point(133, 63);
            this.b_tcBases.Name = "b_tcBases";
            this.b_tcBases.Size = new System.Drawing.Size(75, 23);
            this.b_tcBases.TabIndex = 8;
            this.b_tcBases.Text = "Choisir";
            this.b_tcBases.UseVisualStyleBackColor = true;
            this.b_tcBases.Click += new System.EventHandler(this.b_tcBases_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Transformation de chaine";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Type de recherche";
            // 
            // cb_typeRecherche
            // 
            this.cb_typeRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_typeRecherche.FormattingEnabled = true;
            this.cb_typeRecherche.Location = new System.Drawing.Point(137, 163);
            this.cb_typeRecherche.Name = "cb_typeRecherche";
            this.cb_typeRecherche.Size = new System.Drawing.Size(165, 21);
            this.cb_typeRecherche.TabIndex = 13;
            // 
            // b_sauvegarder
            // 
            this.b_sauvegarder.Location = new System.Drawing.Point(360, 271);
            this.b_sauvegarder.Name = "b_sauvegarder";
            this.b_sauvegarder.Size = new System.Drawing.Size(104, 29);
            this.b_sauvegarder.TabIndex = 14;
            this.b_sauvegarder.Text = "Sauvegarder";
            this.b_sauvegarder.UseVisualStyleBackColor = true;
            this.b_sauvegarder.Click += new System.EventHandler(this.b_sauvegarder_Click);
            // 
            // cb_remonterToutesOccurences
            // 
            this.cb_remonterToutesOccurences.AutoSize = true;
            this.cb_remonterToutesOccurences.Location = new System.Drawing.Point(21, 203);
            this.cb_remonterToutesOccurences.Name = "cb_remonterToutesOccurences";
            this.cb_remonterToutesOccurences.Size = new System.Drawing.Size(282, 17);
            this.cb_remonterToutesOccurences.TabIndex = 16;
            this.cb_remonterToutesOccurences.Text = "Remonter toutes les occurences au lieu de la première";
            this.cb_remonterToutesOccurences.UseVisualStyleBackColor = true;
            this.cb_remonterToutesOccurences.Visible = false;
            // 
            // cb_ToutesColsEltec
            // 
            this.cb_ToutesColsEltec.AutoSize = true;
            this.cb_ToutesColsEltec.Location = new System.Drawing.Point(21, 239);
            this.cb_ToutesColsEltec.Name = "cb_ToutesColsEltec";
            this.cb_ToutesColsEltec.Size = new System.Drawing.Size(189, 17);
            this.cb_ToutesColsEltec.TabIndex = 17;
            this.cb_ToutesColsEltec.Text = "Chercher dans toutes les colonnes";
            this.cb_ToutesColsEltec.UseVisualStyleBackColor = true;
            // 
            // cb_toutesColsAffichees
            // 
            this.cb_toutesColsAffichees.AutoSize = true;
            this.cb_toutesColsAffichees.Location = new System.Drawing.Point(21, 262);
            this.cb_toutesColsAffichees.Name = "cb_toutesColsAffichees";
            this.cb_toutesColsAffichees.Size = new System.Drawing.Size(156, 17);
            this.cb_toutesColsAffichees.TabIndex = 18;
            this.cb_toutesColsAffichees.Text = "Afficher toutes les colonnes";
            this.cb_toutesColsAffichees.UseVisualStyleBackColor = true;
            // 
            // ParametresRecherche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 302);
            this.Controls.Add(this.cb_toutesColsAffichees);
            this.Controls.Add(this.cb_ToutesColsEltec);
            this.Controls.Add(this.cb_remonterToutesOccurences);
            this.Controls.Add(this.b_sauvegarder);
            this.Controls.Add(this.cb_typeRecherche);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.c);
            this.Controls.Add(this.groupBox1);
            this.Name = "ParametresRecherche";
            this.Text = "ParamRecherche";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.c.ResumeLayout(false);
            this.c.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox c;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_typeRecherche;
        private System.Windows.Forms.Button b_sauvegarder;
        private System.Windows.Forms.Label l_tcValeurs;
        private System.Windows.Forms.Button b_tcValeurs;
        private System.Windows.Forms.Label l_tcBases;
        private System.Windows.Forms.Button b_tcBases;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_remonterToutesOccurences;
        private System.Windows.Forms.CheckBox cb_ToutesColsEltec;
        private System.Windows.Forms.CheckBox cb_toutesColsAffichees;
    }
}