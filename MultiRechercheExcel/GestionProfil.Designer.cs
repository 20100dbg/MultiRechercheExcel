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
            this.b_fermer = new System.Windows.Forms.Button();
            this.cb_separateur = new System.Windows.Forms.ComboBox();
            this.tb_colCustom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_nom_profil = new System.Windows.Forms.TextBox();
            this.b_del_profil = new System.Windows.Forms.Button();
            this.b_new_profil = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_profil = new System.Windows.Forms.ComboBox();
            this.nbEntetes = new System.Windows.Forms.NumericUpDown();
            this.b_save_profil = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_colEltecs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nbEntetes)).BeginInit();
            this.SuspendLayout();
            // 
            // b_fermer
            // 
            this.b_fermer.Location = new System.Drawing.Point(334, 320);
            this.b_fermer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_fermer.Name = "b_fermer";
            this.b_fermer.Size = new System.Drawing.Size(89, 23);
            this.b_fermer.TabIndex = 49;
            this.b_fermer.Text = "Fermer";
            this.b_fermer.UseVisualStyleBackColor = true;
            this.b_fermer.Click += new System.EventHandler(this.b_fermer_Click);
            // 
            // cb_separateur
            // 
            this.cb_separateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_separateur.FormattingEnabled = true;
            this.cb_separateur.Location = new System.Drawing.Point(171, 192);
            this.cb_separateur.Name = "cb_separateur";
            this.cb_separateur.Size = new System.Drawing.Size(109, 21);
            this.cb_separateur.TabIndex = 64;
            // 
            // tb_colCustom
            // 
            this.tb_colCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_colCustom.Location = new System.Drawing.Point(171, 114);
            this.tb_colCustom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_colCustom.Name = "tb_colCustom";
            this.tb_colCustom.Size = new System.Drawing.Size(210, 22);
            this.tb_colCustom.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Colonnes fichier à afficher";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 195);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Separateur de colonnes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Nom du profil";
            // 
            // tb_nom_profil
            // 
            this.tb_nom_profil.Location = new System.Drawing.Point(171, 60);
            this.tb_nom_profil.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_nom_profil.Name = "tb_nom_profil";
            this.tb_nom_profil.Size = new System.Drawing.Size(210, 20);
            this.tb_nom_profil.TabIndex = 53;
            // 
            // b_del_profil
            // 
            this.b_del_profil.Location = new System.Drawing.Point(349, 10);
            this.b_del_profil.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_del_profil.Name = "b_del_profil";
            this.b_del_profil.Size = new System.Drawing.Size(74, 23);
            this.b_del_profil.TabIndex = 52;
            this.b_del_profil.Text = "Supprimer";
            this.b_del_profil.UseVisualStyleBackColor = true;
            this.b_del_profil.Click += new System.EventHandler(this.b_del_profil_Click);
            // 
            // b_new_profil
            // 
            this.b_new_profil.Location = new System.Drawing.Point(271, 10);
            this.b_new_profil.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_new_profil.Name = "b_new_profil";
            this.b_new_profil.Size = new System.Drawing.Size(74, 23);
            this.b_new_profil.TabIndex = 51;
            this.b_new_profil.Text = "Nouveau...";
            this.b_new_profil.UseVisualStyleBackColor = true;
            this.b_new_profil.Click += new System.EventHandler(this.b_new_profil_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Profil";
            // 
            // cb_profil
            // 
            this.cb_profil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_profil.FormattingEnabled = true;
            this.cb_profil.Location = new System.Drawing.Point(61, 12);
            this.cb_profil.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_profil.Name = "cb_profil";
            this.cb_profil.Size = new System.Drawing.Size(191, 21);
            this.cb_profil.TabIndex = 50;
            this.cb_profil.SelectedIndexChanged += new System.EventHandler(this.cb_profil_SelectedIndexChanged);
            // 
            // nbEntetes
            // 
            this.nbEntetes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbEntetes.Location = new System.Drawing.Point(171, 162);
            this.nbEntetes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nbEntetes.Name = "nbEntetes";
            this.nbEntetes.Size = new System.Drawing.Size(68, 22);
            this.nbEntetes.TabIndex = 56;
            // 
            // b_save_profil
            // 
            this.b_save_profil.Location = new System.Drawing.Point(334, 235);
            this.b_save_profil.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_save_profil.Name = "b_save_profil";
            this.b_save_profil.Size = new System.Drawing.Size(89, 40);
            this.b_save_profil.TabIndex = 57;
            this.b_save_profil.Text = "Sauvegarder";
            this.b_save_profil.UseVisualStyleBackColor = true;
            this.b_save_profil.Click += new System.EventHandler(this.b_save_profil_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Nb lignes d\'entêtes";
            // 
            // tb_colEltecs
            // 
            this.tb_colEltecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_colEltecs.Location = new System.Drawing.Point(171, 86);
            this.tb_colEltecs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_colEltecs.Name = "tb_colEltecs";
            this.tb_colEltecs.Size = new System.Drawing.Size(210, 22);
            this.tb_colEltecs.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Colonnes eltecs";
            // 
            // GestionProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 364);
            this.Controls.Add(this.cb_separateur);
            this.Controls.Add(this.tb_colCustom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_nom_profil);
            this.Controls.Add(this.b_del_profil);
            this.Controls.Add(this.b_new_profil);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_profil);
            this.Controls.Add(this.nbEntetes);
            this.Controls.Add(this.b_save_profil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_colEltecs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_fermer);
            this.Name = "GestionProfil";
            this.Text = "GestionProfil";
            ((System.ComponentModel.ISupportInitialize)(this.nbEntetes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b_fermer;
        private System.Windows.Forms.ComboBox cb_separateur;
        private System.Windows.Forms.TextBox tb_colCustom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_nom_profil;
        private System.Windows.Forms.Button b_del_profil;
        private System.Windows.Forms.Button b_new_profil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_profil;
        private System.Windows.Forms.NumericUpDown nbEntetes;
        private System.Windows.Forms.Button b_save_profil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_colEltecs;
        private System.Windows.Forms.Label label1;
    }
}