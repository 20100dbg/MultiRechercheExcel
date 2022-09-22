namespace MultiRechercheExcel
{
    partial class GestionBase
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
            this.lb_bases = new System.Windows.Forms.ListBox();
            this.cb_profil = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_creer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_nom = new System.Windows.Forms.TextBox();
            this.b_supprimer = new System.Windows.Forms.Button();
            this.b_importer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_bases
            // 
            this.lb_bases.FormattingEnabled = true;
            this.lb_bases.Location = new System.Drawing.Point(290, 12);
            this.lb_bases.Name = "lb_bases";
            this.lb_bases.Size = new System.Drawing.Size(188, 186);
            this.lb_bases.TabIndex = 0;
            // 
            // cb_profil
            // 
            this.cb_profil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_profil.FormattingEnabled = true;
            this.cb_profil.Location = new System.Drawing.Point(72, 50);
            this.cb_profil.Name = "cb_profil";
            this.cb_profil.Size = new System.Drawing.Size(121, 21);
            this.cb_profil.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.b_creer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_nom);
            this.groupBox1.Controls.Add(this.cb_profil);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 165);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Créer une base";
            // 
            // b_creer
            // 
            this.b_creer.Location = new System.Drawing.Point(121, 136);
            this.b_creer.Name = "b_creer";
            this.b_creer.Size = new System.Drawing.Size(104, 23);
            this.b_creer.TabIndex = 5;
            this.b_creer.Text = "Créer la base";
            this.b_creer.UseVisualStyleBackColor = true;
            this.b_creer.Click += new System.EventHandler(this.b_creer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Profil";
            // 
            // tb_nom
            // 
            this.tb_nom.Location = new System.Drawing.Point(72, 24);
            this.tb_nom.Name = "tb_nom";
            this.tb_nom.Size = new System.Drawing.Size(100, 20);
            this.tb_nom.TabIndex = 2;
            // 
            // b_supprimer
            // 
            this.b_supprimer.Location = new System.Drawing.Point(290, 218);
            this.b_supprimer.Name = "b_supprimer";
            this.b_supprimer.Size = new System.Drawing.Size(110, 23);
            this.b_supprimer.TabIndex = 6;
            this.b_supprimer.Text = "Supprimer la base";
            this.b_supprimer.UseVisualStyleBackColor = true;
            this.b_supprimer.Click += new System.EventHandler(this.b_supprimer_Click);
            // 
            // b_importer
            // 
            this.b_importer.Location = new System.Drawing.Point(490, 12);
            this.b_importer.Name = "b_importer";
            this.b_importer.Size = new System.Drawing.Size(76, 29);
            this.b_importer.TabIndex = 7;
            this.b_importer.Text = "Importer";
            this.b_importer.UseVisualStyleBackColor = true;
            this.b_importer.Click += new System.EventHandler(this.b_importer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Il faudra importer un premier fichier pour \r\ninitialiser la base";
            // 
            // GestionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 253);
            this.Controls.Add(this.b_importer);
            this.Controls.Add(this.b_supprimer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_bases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GestionBase";
            this.Text = "GestionBase";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_bases;
        private System.Windows.Forms.ComboBox cb_profil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_nom;
        private System.Windows.Forms.Button b_creer;
        private System.Windows.Forms.Button b_supprimer;
        private System.Windows.Forms.Button b_importer;
        private System.Windows.Forms.Label label3;
    }
}