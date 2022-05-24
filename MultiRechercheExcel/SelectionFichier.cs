using System;
using System.IO;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class SelectionFichier : Form
    {
        public bool cancelled = false;
        public string filepath = "";
        public int idxProfil = -1;

        public SelectionFichier()
        {
            InitializeComponent();
            ChargerProfils();
        }

        private void ChargerProfils()
        {
            for (int i = 0; i < DB.profils.Count; i++)
            {
                cb_profilFichier.Items.Add(DB.profils[i].nom);
            }
        }

        private void cb_profilFichier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_profilFichier.SelectedIndex > -1)
            {
                b_ajouter.Enabled = true;
                idxProfil = cb_profilFichier.SelectedIndex;
            }
        }

        private void b_choisirFichier_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.InitialDirectory = Environment.CurrentDirectory;
            opf.Filter = "Fichiers TXT/CSV/XLSX|*.txt;*.csv;*.xlsx";
            opf.ShowDialog();

            if (!String.IsNullOrEmpty(opf.FileName) && File.Exists(opf.FileName))
            {
                filepath = opf.FileName;
                l_nomFichier.Text = Path.GetFileName(opf.FileName);
            }
            
            opf.Dispose();

        }

        private void b_ajouter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void b_annulerAjout_Click(object sender, EventArgs e)
        {
            cancelled = true;
        }

        private void SelectionFichier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (filepath == "" || idxProfil == -1) cancelled = true;
        }
    }
}
