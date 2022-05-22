using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class GestionProfil : Form
    {
        public GestionProfil()
        {
            InitializeComponent();
        }

        private void cb_profil_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxProfil = cb_profil.SelectedIndex;

            if (idxProfil > -1)
            {
                tb_nom_profil.Text = DB.profils[idxProfil].nom;
                nbEntetes.Value = DB.profils[idxProfil].nbEntetes;
                tb_colEltecs.Text = Profil.getStringFromIntArray(DB.profils[idxProfil].colsEltecs);
                tb_colCustom.Text = Profil.getStringFromIntArray(DB.profils[idxProfil].colsCustom);
                cb_separateur.SelectedIndex = DB.profils[idxProfil].separateur;
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
                nom = tb_nom_profil.Text,
                nbEntetes = (int)nbEntetes.Value,
                colsEltecs = new int[] { 1 },
                colsCustom = new int[] { },
                separateur = cb_separateur.SelectedIndex
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
            }
        }


        private void b_save_profil_Click(object sender, EventArgs e)
        {
            int idxProfil = cb_profil.SelectedIndex;

            if (idxProfil > -1)
            {
                DB.profils[idxProfil].nom = tb_nom_profil.Text;
                DB.profils[idxProfil].nbEntetes = (int)nbEntetes.Value;
                DB.profils[idxProfil].colsEltecs = Profil.getIntArray(tb_colEltecs.Text.ToUpper());
                DB.profils[idxProfil].colsCustom = Profil.getIntArray(tb_colCustom.Text.ToUpper());
                DB.profils[idxProfil].separateur = cb_separateur.SelectedIndex;

                String colEtecs = Profil.getStringFromIntArray(DB.profils[idxProfil].colsEltecs);
                String colCustom = Profil.getStringFromIntArray(DB.profils[idxProfil].colsCustom);

                cb_profil.Items[idxProfil] = DB.profils[idxProfil].nom;
                MessageBox.Show("Profil enregistré");
            }
        }


        private void RefreshProfils()
        {
            cb_profil.Items.AddRange(DB.profils.ToArray());
            if (cb_profil.Items.Count > 0) cb_profil.SelectedIndex = 0;
        }

        private void b_fermer_Click(object sender, EventArgs e)
        {

        }
    }
}
