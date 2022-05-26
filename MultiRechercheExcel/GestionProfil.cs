using System;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class GestionProfil : Form
    {
        public GestionProfil()
        {
            InitializeComponent();
            
            ChargerProfils();
            cb_separateur.Items.Add(";");
            cb_separateur.Items.Add(",");
            cb_separateur.Items.Add("Espace");
            cb_separateur.Items.Add("Tabulation");
        }

        private void ChargerProfils()
        {
            for (int i = 0; i < DB.profils.Count; i++)
            {
                cb_profil.Items.Add(DB.profils[i].Nom);
            }
        }

        private void cb_profil_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxProfil = cb_profil.SelectedIndex;

            if (idxProfil > -1)
            {
                tb_nom_profil.Text = DB.profils[idxProfil].Nom;
                nbEntetes.Value = DB.profils[idxProfil].NbEntetes;
                tb_colEltecs.Text = Profil.getStringFromIntArray(DB.profils[idxProfil].ColsEltecs);
                tb_colCustom.Text = Profil.getStringFromIntArray(DB.profils[idxProfil].ColsCustom);
                cb_separateur.SelectedIndex = DB.profils[idxProfil].IdxSeparateur;
            }
        }


        private void b_new_profil_Click(object sender, EventArgs e)
        {
            tb_nom_profil.Text = "Nouveau profil";
            nbEntetes.Value = 0;
            tb_colEltecs.Text = "1";
            tb_colCustom.Text = "";
            cb_separateur.SelectedIndex = 0;


            Profil p = new Profil
            {
                Nom = tb_nom_profil.Text,
                NbEntetes = (int)nbEntetes.Value,
                ColsEltecs = new int[] { 1 },
                ColsCustom = new int[] { },
                IdxSeparateur = cb_separateur.SelectedIndex
            };
            DB.profils.Add(p);

            cb_profil.Items.Add(p);
            cb_profil.SelectedIndex = cb_profil.Items.Count - 1;
        }


        private void b_del_profil_Click(object sender, EventArgs e)
        {
            int idxProfil = cb_profil.SelectedIndex;

            if (idxProfil > -1)
            {
                DB.profils.RemoveAt(idxProfil);
                cb_profil.Items.RemoveAt(idxProfil);

                cb_profil.SelectedIndex = 0;
                Settings.WriteConfigFile();
            }
        }


        private void b_save_profil_Click(object sender, EventArgs e)
        {
            int idxProfil = cb_profil.SelectedIndex;

            if (idxProfil > -1)
            {
                DB.profils[idxProfil].Nom = tb_nom_profil.Text;
                DB.profils[idxProfil].NbEntetes = (int)nbEntetes.Value;
                DB.profils[idxProfil].ColsEltecs = Profil.getIntArray(tb_colEltecs.Text.ToUpper());
                DB.profils[idxProfil].ColsCustom = Profil.getIntArray(tb_colCustom.Text.ToUpper());
                DB.profils[idxProfil].IdxSeparateur = cb_separateur.SelectedIndex;

                //String colEtecs = Profil.getStringFromIntArray(DB.profils[idxProfil].colsEltecs);
                //String colCustom = Profil.getStringFromIntArray(DB.profils[idxProfil].colsCustom);

                cb_profil.Items[idxProfil] = DB.profils[idxProfil].Nom;
                Settings.WriteConfigFile();

                MessageBox.Show("Profil enregistré");
            }
        }


        private void b_fermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
