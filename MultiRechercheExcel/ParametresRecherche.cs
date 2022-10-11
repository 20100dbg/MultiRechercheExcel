using System;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class ParametresRecherche : Form
    {
        TransformationChaine tcValeurs;
        TransformationChaine tcBases;
        ConfigTransformation fConfigTransformation;

        public ParametresRecherche()
        {
            InitializeComponent();
            this.Icon = MultiRechercheExcel.Properties.Resources.MultiRechercheExcel;

            foreach (ModeRecherche mr in (ModeRecherche[])Enum.GetValues(typeof(ModeRecherche)))
                cb_typeRecherche.Items.Add(mr.ToString());
            
            cb_typeRecherche.SelectedIndex = 0;

            tcValeurs = DB.tcValeur;
            tcBases = DB.tcRef;

            l_tcValeurs.Text = tcValeurs.ToString();
            l_tcBases.Text = tcBases.ToString();

            cb_remonterToutesOccurences.Checked = ParamRecherche.RemonterToutesOccurences;
        }

        private void b_sauvegarder_Click(object sender, EventArgs e)
        {
            ParamRecherche.ModeRecherche = (ModeRecherche)cb_typeRecherche.SelectedIndex;
            ParamRecherche.RemonterToutesOccurences = cb_remonterToutesOccurences.Checked;

            if (tcValeurs != null) DB.tcValeur = tcValeurs;
            if (tcBases != null) DB.tcRef = tcBases;

            Settings.WriteConfigFile();
            Close();
        }

        private void b_tcValeurs_Click(object sender, EventArgs e)
        {
            fConfigTransformation = new ConfigTransformation(tcValeurs);
            fConfigTransformation.ShowDialog();

            if (!fConfigTransformation.cancelled)
            {
                tcValeurs = fConfigTransformation.tc.Clone();
                l_tcValeurs.Text = tcValeurs.ToString();
            }
                
        }

        private void b_tcBases_Click(object sender, EventArgs e)
        {
            fConfigTransformation = new ConfigTransformation(tcBases);
            fConfigTransformation.ShowDialog();

            if (!fConfigTransformation.cancelled)
            {
                tcBases = fConfigTransformation.tc.Clone();
                l_tcBases.Text = tcBases.ToString();
            }
        }
    }
}
