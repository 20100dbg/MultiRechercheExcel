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
            for (int i = 0; i < DB.profilsRecherche.Count; i++)
            {
                cb_profilFichier.Items.Add(DB.profilsRecherche[i].Nom);
            }
        }

        private void cb_profilFichier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_profilFichier.SelectedIndex > -1)
            {
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
                ChargerFichier(opf.FileName);
            }
            
            opf.Dispose();

        }

        private void ChargerFichier(string filepath)
        {
            this.filepath = filepath;
            l_nomFichier.Text = Path.GetFileName(filepath);
        }

        private void b_ajouter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void b_annulerAjout_Click(object sender, EventArgs e)
        {
            cancelled = true;
            Close();
        }

        private void SelectionFichier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (filepath == "" || idxProfil == -1) cancelled = true;
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string filename = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            ChargerFichier(filename);
        }
    }
}
