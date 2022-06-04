namespace MultiRechercheExcel
{
    partial class SelectionFichier
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
            this.b_choisirFichier = new System.Windows.Forms.Button();
            this.cb_profilFichier = new System.Windows.Forms.ComboBox();
            this.l_nomFichier = new System.Windows.Forms.Label();
            this.b_annulerAjout = new System.Windows.Forms.Button();
            this.b_ajouter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_choisirFichier
            // 
            this.b_choisirFichier.Location = new System.Drawing.Point(12, 25);
            this.b_choisirFichier.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_choisirFichier.Name = "b_choisirFichier";
            this.b_choisirFichier.Size = new System.Drawing.Size(74, 23);
            this.b_choisirFichier.TabIndex = 13;
            this.b_choisirFichier.Text = "Parcourir...";
            this.b_choisirFichier.UseVisualStyleBackColor = true;
            this.b_choisirFichier.Click += new System.EventHandler(this.b_choisirFichier_Click);
            // 
            // cb_profilFichier
            // 
            this.cb_profilFichier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_profilFichier.FormattingEnabled = true;
            this.cb_profilFichier.Location = new System.Drawing.Point(307, 32);
            this.cb_profilFichier.Name = "cb_profilFichier";
            this.cb_profilFichier.Size = new System.Drawing.Size(121, 21);
            this.cb_profilFichier.TabIndex = 14;
            this.cb_profilFichier.SelectedIndexChanged += new System.EventHandler(this.cb_profilFichier_SelectedIndexChanged);
            // 
            // l_nomFichier
            // 
            this.l_nomFichier.AutoSize = true;
            this.l_nomFichier.Location = new System.Drawing.Point(102, 30);
            this.l_nomFichier.Name = "l_nomFichier";
            this.l_nomFichier.Size = new System.Drawing.Size(0, 13);
            this.l_nomFichier.TabIndex = 15;
            // 
            // b_annulerAjout
            // 
            this.b_annulerAjout.Location = new System.Drawing.Point(236, 112);
            this.b_annulerAjout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_annulerAjout.Name = "b_annulerAjout";
            this.b_annulerAjout.Size = new System.Drawing.Size(74, 23);
            this.b_annulerAjout.TabIndex = 16;
            this.b_annulerAjout.Text = "Annuler";
            this.b_annulerAjout.UseVisualStyleBackColor = true;
            this.b_annulerAjout.Click += new System.EventHandler(this.b_annulerAjout_Click);
            // 
            // b_ajouter
            // 
            this.b_ajouter.Location = new System.Drawing.Point(132, 111);
            this.b_ajouter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.b_ajouter.Name = "b_ajouter";
            this.b_ajouter.Size = new System.Drawing.Size(74, 23);
            this.b_ajouter.TabIndex = 17;
            this.b_ajouter.Text = "Valider";
            this.b_ajouter.UseVisualStyleBackColor = true;
            this.b_ajouter.Click += new System.EventHandler(this.b_ajouter_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.b_choisirFichier);
            this.panel1.Controls.Add(this.l_nomFichier);
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 101);
            this.panel1.TabIndex = 18;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragOver += new System.Windows.Forms.DragEventHandler(this.panel1_DragOver);
            // 
            // SelectionFichier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 140);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.b_ajouter);
            this.Controls.Add(this.b_annulerAjout);
            this.Controls.Add(this.cb_profilFichier);
            this.Name = "SelectionFichier";
            this.Text = "SelectionFichier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectionFichier_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_choisirFichier;
        private System.Windows.Forms.ComboBox cb_profilFichier;
        private System.Windows.Forms.Label l_nomFichier;
        private System.Windows.Forms.Button b_annulerAjout;
        private System.Windows.Forms.Button b_ajouter;
        private System.Windows.Forms.Panel panel1;
    }
}