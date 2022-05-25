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
            cb_typeRecherche.SelectedIndex = 0;

            cb_CasseValeurs.Items.Add("Normal");
            cb_CasseValeurs.Items.Add("Majuscules");
            cb_CasseValeurs.Items.Add("Minuscules");
            cb_CasseValeurs.SelectedIndex = 0;

            cb_CasseBases.Items.Add("Normal");
            cb_CasseBases.Items.Add("Majuscules");
            cb_CasseBases.Items.Add("Minuscules");
            cb_CasseBases.SelectedIndex = 0;
        }

        private void b_sauvegarder_Click(object sender, EventArgs e)
        {
            ParamRecherche.ModeRecherche = (ModeRecherche)cb_typeRecherche.SelectedIndex;

            //valeur
            DB.prValeur.ModeCasse = (ModeCasse)cb_CasseValeurs.SelectedIndex;
            DB.prValeur.debutChaine = int.Parse(tb_DebutValeur.Text);
            DB.prValeur.longueurChaine = int.Parse(tb_LongueurValeur.Text);
            DB.prValeur.finChaine = int.Parse(tb_FinValeur.Text);

            //base
            DB.prBase.ModeCasse = (ModeCasse)cb_CasseBases.SelectedIndex;
            DB.prBase.debutChaine = int.Parse(tb_DebutBase.Text);
            DB.prBase.longueurChaine = int.Parse(tb_LongueurBase.Text);
            DB.prBase.finChaine = int.Parse(tb_FinBase.Text);

            Settings.WriteConfigFile();
        }
    }
}
