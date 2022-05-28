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

            cb_CasseValeurs.SelectedIndex = (int)DB.prValeur.ModeCasse;
            tb_DebutValeur.Text = DB.prValeur.debutChaine.ToString();
            tb_LongueurValeur.Text = DB.prValeur.longueurChaine.ToString();
            tb_FinValeur.Text = DB.prValeur.finChaine.ToString();

            cb_CasseBases.SelectedIndex = (int)DB.prBase.ModeCasse;
            tb_DebutBase.Text = DB.prBase.debutChaine.ToString();
            tb_LongueurBase.Text = DB.prBase.longueurChaine.ToString();
            tb_FinBase.Text = DB.prBase.finChaine.ToString();

        }

        private void b_sauvegarder_Click(object sender, EventArgs e)
        {
            ParamRecherche.ModeRecherche = (ModeRecherche)cb_typeRecherche.SelectedIndex;

            //valeur
            DB.prValeur.ModeCasse = (ModeCasse)cb_CasseValeurs.SelectedIndex;
            DB.prValeur.debutChaine = (int)tb_DebutValeur.Value;
            DB.prValeur.longueurChaine = (int)tb_LongueurValeur.Value;
            DB.prValeur.finChaine = (int)tb_FinValeur.Value;

            //base
            DB.prBase.ModeCasse = (ModeCasse)cb_CasseBases.SelectedIndex;
            DB.prBase.debutChaine = (int)tb_DebutBase.Value;
            DB.prBase.longueurChaine = (int)tb_LongueurBase.Value;
            DB.prBase.finChaine = (int)tb_FinBase.Value;

            Settings.WriteConfigFile();
            Close();
        }

    }
}
