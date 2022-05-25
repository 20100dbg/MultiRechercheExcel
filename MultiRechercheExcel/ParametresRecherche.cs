using System;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class ParametresRecherche : Form
    {
        public ParametresRecherche()
        {
            InitializeComponent();

            cb_typeRecherche.Items.Add("Exact");
            cb_typeRecherche.Items.Add("Contient");
            cb_typeRecherche.Items.Add("Commence par");
            cb_typeRecherche.Items.Add("Finit par");

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

            if (!int.TryParse(tb_DebutValeur.Text, out DB.prValeur.debutChaine)) DB.prValeur.debutChaine = 0;
            if (!int.TryParse(tb_LongueurValeur.Text, out DB.prValeur.longueurChaine)) DB.prValeur.longueurChaine = 0;
            if (!int.TryParse(tb_FinValeur.Text, out DB.prValeur.finChaine)) DB.prValeur.finChaine = 0;

            //base
            DB.prBase.ModeCasse = (ModeCasse)cb_CasseBases.SelectedIndex;

            if (!int.TryParse(tb_DebutBase.Text, out DB.prBase.debutChaine)) DB.prBase.debutChaine = 0;
            if (!int.TryParse(tb_LongueurBase.Text, out DB.prBase.longueurChaine)) DB.prBase.longueurChaine = 0;
            if (!int.TryParse(tb_FinBase.Text, out DB.prBase.finChaine)) DB.prBase.finChaine = 0;

            Settings.WriteConfigFile();
            Close();
        }
    }
}
