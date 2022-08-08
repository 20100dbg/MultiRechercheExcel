using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class GestionProfil : Form
    {
        ConfigTransformation fConfigTransformation;
        List<ActionFichier> actions = new List<ActionFichier>();
        TransformationChaine tc = null;

        public GestionProfil()
        {
            InitializeComponent();
            this.Icon = MultiRechercheExcel.Properties.Resources.MultiRechercheExcel;

            l_transformation.Text = "";
            cb_separateur.Items.Add("Point virgule");
            cb_separateur.Items.Add("Virgule");
            cb_separateur.Items.Add("Espace");
            cb_separateur.Items.Add("Tabulation");

            ChargerProfils();

            foreach (TypeActionFichier typeAction in (TypeActionFichier[])Enum.GetValues(typeof(TypeActionFichier)))
                cb_TypeAction.Items.Add(typeAction);

            cb_TypeAction.SelectedIndex = 0;
            
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
                razProfilAction();

                tb_NomAction.Text = DB.profilsAction[idxProfil].Nom;
                actions.AddRange(DB.profilsAction[idxProfil].Actions);

                for (int i = 0; i < DB.profilsAction[idxProfil].Actions.Count; i++)
                {
                    ActionFichier af = DB.profilsAction[idxProfil].Actions[i];
                    lv_actions.Items.Add(new ListViewItem(new String[] {
                        af.TypeActionFichier.ToString(),
                        af.IdxSrc.ToString(),
                        af.IdxDst.ToString(),
                        ""
                    }));
                }
                
            }
        }

        private void cb_TypeAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TypeAction.SelectedIndex > -1)
            {
                TypeActionFichier typeActionFichier = (TypeActionFichier)cb_TypeAction.SelectedItem;

                l_source.Visible = num_Source.Visible = false;
                l_destination.Visible = num_Destination.Visible = true;

                if (typeActionFichier == TypeActionFichier.DeplacerColonne ||
                    typeActionFichier == TypeActionFichier.DeplacerLigne ||
                    typeActionFichier == TypeActionFichier.DupliquerColonne ||
                    typeActionFichier == TypeActionFichier.DupliquerLigne)
                {
                    l_source.Visible = num_Source.Visible = true;
                }

                if (typeActionFichier == TypeActionFichier.TransformerFichier)
                    l_destination.Visible = num_Destination.Visible = false;

                if (typeActionFichier == TypeActionFichier.TransformerColonne ||
                    typeActionFichier == TypeActionFichier.TransformerFichier)
                {
                    b_configurerTexte.Visible = true;
                }
                else
                    b_configurerTexte.Visible = false;
            }
        }

        private void razProfilAction()
        {
            tb_NomAction.Text = "";
            actions = new List<ActionFichier>();
            tc = null;

            num_Destination.Value = num_Source.Value = 0;
            lv_actions.Items.Clear();
        }

        private void b_NouveauProfilAction_Click(object sender, EventArgs e)
        {
            razProfilAction();
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

                if (cb_ProfilAction.Items.Count > 0)
                    cb_ProfilAction.SelectedIndex = 0;

                razProfilAction();
                
                Settings.WriteConfigFile();
            }
        }


        private void b_ajouterAction_Click(object sender, EventArgs e)
        {
            ActionFichier af = new ActionFichier
            {
                TransChaine = tc,
                IdxSrc = (int)num_Source.Value,
                IdxDst = (int)num_Destination.Value,
                TypeActionFichier = (TypeActionFichier)cb_TypeAction.SelectedItem
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
                DB.profilsAction[idxProfil].Actions.Clear();
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

        private void tb_configurerTexte_Click(object sender, EventArgs e)
        {
            fConfigTransformation = new ConfigTransformation(null);
            fConfigTransformation.ShowDialog();

            l_transformation.Text = "";
        }

        private void b_supprimerAction_Click(object sender, EventArgs e)
        {
            int idxProfil = cb_ProfilAction.SelectedIndex;

            if (idxProfil > -1)
            {
                for (int i = lv_actions.Items.Count - 1; i >= 0; i--)
                {
                    if (lv_actions.Items[i].Selected)
                    {
                        //DB.profilsAction[idxProfil].Actions.RemoveAt(i);
                        actions.RemoveAt(i);
                        lv_actions.Items.RemoveAt(i);
                    }

                }
            }
        }

        private void b_monterAction_Click(object sender, EventArgs e)
        {
            if (lv_actions.SelectedIndices.Count == 0 ||
                lv_actions.SelectedIndices[0] == 0) return;

            int idx = lv_actions.SelectedIndices[0];
            ActionFichier af = actions[idx];
            actions.RemoveAt(idx);
            actions.Insert(idx - 1, af);

            ListViewItem lvi = lv_actions.Items[idx];
            lv_actions.Items.RemoveAt(idx);
            lv_actions.Items.Insert(idx - 1, lvi);
            
        }

        private void b_descendreAction_Click(object sender, EventArgs e)
        {
            if (lv_actions.SelectedIndices.Count == 0 ||
                lv_actions.SelectedIndices[0] == lv_actions.Items.Count - 1) return;

            int idx = lv_actions.SelectedIndices[0];
            ActionFichier af = actions[idx];
            actions.RemoveAt(idx);
            actions.Insert(idx + 1, af);
            

            ListViewItem lvi = lv_actions.Items[idx];
            lv_actions.Items.RemoveAt(idx);
            lv_actions.Items.Insert(idx + 1, lvi);
        }
    }
}
