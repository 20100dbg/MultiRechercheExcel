using System;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class SelectionFichier : Form
    {
        public SelectionFichier()
        {
            InitializeComponent();
        }

        private void ChargerProfils()
        {

        }

        private void cb_profilFichier_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxProfil = cb_profilFichier.SelectedIndex;
            
            if (idxProfil > -1)
            {
                b_ajouter.Enabled = true;

            }
        }

        private void b_choisirFichier_Click(object sender, EventArgs e)
        {
            //maj label
        }

        private void b_ajouter_Click(object sender, EventArgs e)
        {
            //renvoyer filepath + profil choisi
        }

        private void b_annulerAjout_Click(object sender, EventArgs e)
        {
            //renvoyer vide
        }
    }
}
