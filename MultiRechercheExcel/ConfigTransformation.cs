using System;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class ConfigTransformation : Form
    {
        public TransformationChaine tc = null;
        public bool cancelled = true;

        public ConfigTransformation(TransformationChaine tcInit)
        {
            InitializeComponent();

            foreach (ModeCasse modeCasse in (ModeCasse[])Enum.GetValues(typeof(ModeCasse)))
                cb_CasseAction.Items.Add(modeCasse);
            cb_CasseAction.SelectedIndex = 0;

            if (tcInit != null)
            {
                cb_CasseAction.SelectedIndex = (int)tcInit.ModeCasse;
                num_DebutAction.Value = tcInit.debutChaine;
                num_FinAction.Value = tcInit.finChaine;
                num_LongueurAction.Value = tcInit.longueurChaine;
                num_nbCarPad.Value = tcInit.nbCarPad;
                tb_carPad.Text = tcInit.carPad;
                cb_padLeft.Checked = tcInit.leftPad;
                /*
                tb_valeurDefaut.Text = tcInit.valeurDefaut;
                cb_valeurDefautDabord.Checked = tcInit.valeurDefautDabord;
                */
            }
        }

        private TransformationChaine BuildConfig()
        {
            TransformationChaine tc = new TransformationChaine
            {
                ModeCasse = (ModeCasse)cb_CasseAction.SelectedItem,
                debutChaine = (int)num_DebutAction.Value,
                longueurChaine = (int)num_LongueurAction.Value,
                finChaine = (int)num_FinAction.Value,
                /*
                valeurDefaut = tb_valeurDefaut.Text,
                valeurDefautDabord = cb_valeurDefautDabord.Checked,
                */
                carPad = tb_carPad.Text,
                nbCarPad = (int)num_nbCarPad.Value,
                leftPad = cb_padLeft.Checked
            };

            return tc;
        }

        private void b_tester_Click(object sender, EventArgs e)
        {
            TransformationChaine tc = BuildConfig();
            string s = tb_testEntree.Text;

            s = Recherche.TransformerValeur(s, tc);
            tb_testResultat.Text = s;
        }

        private void b_valider_Click(object sender, EventArgs e)
        {
            cancelled = false;
            tc = BuildConfig();
            Close();
        }

    }
}
