using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class GestionProfil : Form
    {
        List<ActionFichier> actions = new List<ActionFichier>();

        public GestionProfil()
        {
            InitializeComponent();
            
            cb_separateur.Items.Add("Point virgule");
            cb_separateur.Items.Add("Virgule");
            cb_separateur.Items.Add("Espace");
            cb_separateur.Items.Add("Tabulation");

            ChargerProfils();

            foreach (TypeActionFichier typeAction in (TypeActionFichier[])Enum.GetValues(typeof(TypeActionFichier)))
                cb_TypeAction.Items.Add(typeAction);

            foreach (ModeCasse modeCasse in (ModeCasse[])Enum.GetValues(typeof(ModeCasse)))
                cb_CasseAction.Items.Add(modeCasse);

            cb_TypeAction.SelectedIndex = 0;
            cb_CasseAction.SelectedIndex = 0;
        }

        private void ChargerProfils()
        {
            for (int i = 0; i < DB.profilsRecherche.Count; i++)
                cb_ProfilRecherche.Items.Add(DB.profilsRecherche[i].Nom);

            for (int i = 0; i < DB.profilsAction.Count; i++)
                cb_ProfilAction.Items.Add(DB.profilsAction[i].Nom);
        }

        private void cb_profil_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxProfil = cb_ProfilRecherche.SelectedIndex;

            if (idxProfil > -1)
            {
                tb_NomRecherche.Text = DB.profilsRecherche[idxProfil].Nom;
                num_NbEntetes.Value = DB.profilsRecherche[idxProfil].NbEntetes;
                tb_ColsEltecs.Text = Profil.getStringFromIntArray(DB.profilsRecherche[idxProfil].ColsEltecs);
                tb_ColsAfficher.Text = Profil.getStringFromIntArray(DB.profilsRecherche[idxProfil].ColsAffichees);
                cb_separateur.SelectedIndex = DB.profilsRecherche[idxProfil].IdxSeparateur;
            }
        }


        private void b_NouveauRecherche_Click(object sender, EventArgs e)
        {
            tb_NomRecherche.Text = "Nouveau profil";
            num_NbEntetes.Value = 0;
            tb_ColsEltecs.Text = "1";
            tb_ColsAfficher.Text = "";
            cb_separateur.SelectedIndex = 0;


            Profil p = new Profil
            {
                Nom = tb_NomRecherche.Text,
                NbEntetes = (int)num_NbEntetes.Value,
                ColsEltecs = new int[] { 1 },
                ColsAffichees = new int[] { },
                IdxSeparateur = cb_separateur.SelectedIndex
            };
            DB.profilsRecherche.Add(p);

            cb_ProfilRecherche.Items.Add(p);
            cb_ProfilRecherche.SelectedIndex = cb_ProfilRecherche.Items.Count - 1;
        }


        private void b_SupprimerRecherche_Click(object sender, EventArgs e)
        {
            int idxProfil = cb_ProfilRecherche.SelectedIndex;

            if (idxProfil > -1)
            {
                DB.profilsRecherche.RemoveAt(idxProfil);
                cb_ProfilRecherche.Items.RemoveAt(idxProfil);

                cb_ProfilRecherche.SelectedIndex = 0;
                Settings.WriteConfigFile();
            }
        }


        private void b_SauvegarderProfil_Click(object sender, EventArgs e)
        {
            int idxProfil = cb_ProfilRecherche.SelectedIndex;

            if (idxProfil > -1)
            {
                DB.profilsRecherche[idxProfil].Nom = tb_NomRecherche.Text;
                DB.profilsRecherche[idxProfil].NbEntetes = (int)num_NbEntetes.Value;
                DB.profilsRecherche[idxProfil].ColsEltecs = Profil.getIntArray(tb_ColsEltecs.Text.ToUpper());
                DB.profilsRecherche[idxProfil].ColsAffichees = Profil.getIntArray(tb_ColsAfficher.Text.ToUpper());
                DB.profilsRecherche[idxProfil].IdxSeparateur = cb_separateur.SelectedIndex;

                cb_ProfilRecherche.Items[idxProfil] = DB.profilsRecherche[idxProfil].Nom;
                Settings.WriteConfigFile();

                MessageBox.Show("Profil enregistré");
            }
        }



        private void cb_ProfilAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxProfil = cb_ProfilAction.SelectedIndex;

            if (idxProfil > -1)
            {
                tb_NomAction.Text = DB.profilsAction[idxProfil].Nom;
            }
        }

        private void cb_TypeAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TypeAction.SelectedIndex > -1)
            {
                TypeActionFichier typeActionFichier = (TypeActionFichier)cb_TypeAction.SelectedItem;

                if (typeActionFichier == TypeActionFichier.TransformerColonne ||
                    typeActionFichier == TypeActionFichier.TransformerFichier)
                {
                    groupBox3.Visible = true;
                }
                else
                    groupBox3.Visible = false;
            }
        }


        private void b_NouveauProfilAction_Click(object sender, EventArgs e)
        {
            tb_NomAction.Text = "Nouveau profil";

            ProfilAction pa = new ProfilAction
            {
                Nom = tb_NomAction.Text,
                Actions = new List<ActionFichier>()
            };
            DB.profilsAction.Add(pa);

            cb_ProfilAction.Items.Add(pa);
            cb_ProfilAction.SelectedIndex = cb_ProfilAction.Items.Count - 1;
        }


        private void b_SupprimerProfilAction_Click(object sender, EventArgs e)
        {
            int idxProfil = cb_ProfilAction.SelectedIndex;

            if (idxProfil > -1)
            {
                DB.profilsAction.RemoveAt(idxProfil);
                cb_ProfilAction.Items.RemoveAt(idxProfil);

                cb_ProfilAction.SelectedIndex = 0;
                Settings.WriteConfigFile();
            }
        }


        private void b_ajouterAction_Click(object sender, EventArgs e)
        {
            ActionFichier af = new ActionFichier
            {
                TypeActionFichier = (TypeActionFichier)cb_TypeAction.SelectedItem,
                IdxSrc = (int)num_Source.Value,
                IdxDst = (int)num_Destination.Value,
                TransChaine = new TransformationChaine
                {
                    ModeCasse = (ModeCasse)cb_CasseAction.SelectedItem,
                    debutChaine = (int)num_DebutAction.Value,
                    longueurChaine = (int)num_LongueurAction.Value,
                    finChaine = (int)num_FinAction.Value
                }
            };

            actions.Add(af);
            lv_actions.Items.Add(new ListViewItem(new String[] {
                af.TypeActionFichier.ToString(),
                af.IdxSrc.ToString(),
                af.IdxDst.ToString(),
                ""
                }));
        }

        private void b_SauvegarderAction_Click(object sender, EventArgs e)
        {
            int idxProfil = cb_ProfilAction.SelectedIndex;

            if (idxProfil > -1)
            {
                DB.profilsAction[idxProfil].Nom = tb_NomAction.Text;
                DB.profilsAction[idxProfil].Actions.AddRange(actions);

                cb_ProfilAction.Items[idxProfil] = DB.profilsAction[idxProfil].Nom;
                Settings.WriteConfigFile();

                actions.Clear();
                lv_actions.Items.Clear();

                MessageBox.Show("Profil enregistré");
            }
        }

        private void b_fermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
