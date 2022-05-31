using System;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class ParametresRecherche : Form
    {
        public ParametresRecherche()
        {
            InitializeComponent();

            foreach (ModeRecherche mr in (ModeRecherche[])Enum.GetValues(typeof(ModeRecherche)))
                cb_typeRecherche.Items.Add(mr.ToString());
            
            cb_typeRecherche.SelectedIndex = 0;

            cb_CasseValeurs.Items.Add("Normal");
            cb_CasseValeurs.Items.Add("Majuscules");
            cb_CasseValeurs.Items.Add("Minuscules");

            cb_CasseBases.Items.Add("Normal");
            cb_CasseBases.Items.Add("Majuscules");
            cb_CasseBases.Items.Add("Minuscules");

            cb_typeRecherche.SelectedIndex = (int)ParamRecherche.ModeRecherche;

            cb_CasseValeurs.SelectedIndex = (int)DB.tcValeur.ModeCasse;
            tb_DebutValeur.Text = DB.tcValeur.debutChaine.ToString();
            tb_LongueurValeur.Text = DB.tcValeur.longueurChaine.ToString();
            tb_FinValeur.Text = DB.tcValeur.finChaine.ToString();

            cb_CasseBases.SelectedIndex = (int)DB.tcBase.ModeCasse;
            tb_DebutBase.Text = DB.tcBase.debutChaine.ToString();
            tb_LongueurBase.Text = DB.tcBase.longueurChaine.ToString();
            tb_FinBase.Text = DB.tcBase.finChaine.ToString();

        }

        private void b_sauvegarder_Click(object sender, EventArgs e)
        {
            ParamRecherche.ModeRecherche = (ModeRecherche)cb_typeRecherche.SelectedIndex;

            //valeur
            DB.tcValeur.ModeCasse = (ModeCasse)cb_CasseValeurs.SelectedIndex;
            DB.tcValeur.debutChaine = (int)tb_DebutValeur.Value;
            DB.tcValeur.longueurChaine = (int)tb_LongueurValeur.Value;
            DB.tcValeur.finChaine = (int)tb_FinValeur.Value;

            //base
            DB.tcBase.ModeCasse = (ModeCasse)cb_CasseBases.SelectedIndex;
            DB.tcBase.debutChaine = (int)tb_DebutBase.Value;
            DB.tcBase.longueurChaine = (int)tb_LongueurBase.Value;
            DB.tcBase.finChaine = (int)tb_FinBase.Value;

            Settings.WriteConfigFile();
            Close();
        }

    }
}
