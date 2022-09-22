using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MultiRechercheExcel
{
    public partial class GestionBase : Form
    {
        Recherche fRecherche;

        public GestionBase(Recherche r)
        {
            InitializeComponent();
            this.fRecherche = r;

            for (int i = 0; i < DB.profilsRecherche.Count; i++)
            {
                cb_profil.Items.Add(DB.profilsRecherche[i]);
            }

            RemplirBases();
        }

        private void RemplirBases()
        {
            lb_bases.Items.Clear();

            for (int i = 0; i < DB.bases.Count; i++)
            {
                lb_bases.Items.Add(DB.bases[i]);
            }
        }

        private void b_creer_Click(object sender, EventArgs e)
        {
            if (cb_profil.SelectedIndex > -1)
            {
                string filepath = SelectionFichier();

                if (filepath != "")
                {
                    Profil p = (Profil)cb_profil.SelectedItem;
                    string nomBase = tb_nom.Text;

                    List<string[]> tab = new List<string[]>();
                    if (filepath.EndsWith(".xlsx")) tab = LireXLSX(filepath, p);
                    else tab = LireCSV(filepath, p);

                    if (tab.Count > 0)
                    {
                        int nbColonne = tab[0].Length;
                        CreerBase(nomBase, p, nbColonne);

                        Importer(tab, nomBase, nbColonne);

                        RemplirBases();

                        MessageBox.Show("base créée");
                    }
                }
            }
        }


        private void b_supprimer_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Supprimer ?", "Confirmation", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                if (lb_bases.SelectedIndex > -1)
                {
                    MaBase b = (MaBase)lb_bases.SelectedItem;
                    SupprimerBase(b.Nom);
                    
                    RemplirBases();
                }
            }
        }


        private void b_importer_Click(object sender, EventArgs e)
        {
            if (lb_bases.SelectedIndex == -1)
            {
                MessageBox.Show("Pas de base sélectionnée");
                return;
            }

            string filename = SelectionFichier();

            if (filename != "")
            {
                MaBase b = (MaBase)lb_bases.SelectedItem;

                List<string[]> tab = new List<string[]>();

                if (filename.EndsWith(".xlsx")) tab = LireXLSX(filename, b.Profil);
                else tab = LireCSV(filename, b.Profil);

                if (tab.Count > 0)
                    Importer(tab, b.Nom, tab[0].Length);
            }
        }


        private string SelectionFichier()
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.InitialDirectory = Environment.CurrentDirectory;
            opf.Filter = "Fichiers TXT/CSV/XLSX|*.txt;*.csv;*.xlsx";
            opf.ShowDialog();

            if (!String.IsNullOrEmpty(opf.FileName) && File.Exists(opf.FileName))
            {
                return opf.FileName;
            }
            return "";
        }


        private void CreerBase(string nom, Profil p, int nbColonne)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9_]");
            nom = rgx.Replace(nom, "");

            int idx = MaBase.GetIdxFromNom(nom);
            if (idx > -1) return;


            string sql = "CREATE TABLE " + nom + "(";

            for (int i = 1; i <= nbColonne; i++)
            {
                sql += "val" + i + " text";
                if (i < nbColonne) sql += ",";
            }

            sql += ")";

            SQLiteCommand cmd = new SQLiteCommand(sql, DB.SQLiteCon);

            try
            {
                cmd.ExecuteNonQuery();

                //inserer dans bases
                sql = "INSERT INTO bases VALUES ('" + nom + "', '" + p.Nom + "', '" + nbColonne + "')";
                cmd = new SQLiteCommand(sql, DB.SQLiteCon);
                cmd.ExecuteNonQuery();

                DB.bases.Add(new MaBase
                {
                    Nom = nom,
                    Profil = p,
                    NbColonnes = nbColonne
                });
                fRecherche.RemplirCBbases();
            }
            catch
            {
                //MessageBox.Show(e.Message);
            }

            
        }

        
        private void SupprimerBase(string nom)
        {
            string sql = "DROP TABLE " + nom;
            SQLiteCommand cmd = new SQLiteCommand(sql, DB.SQLiteCon);

            try
            {
                cmd.ExecuteNonQuery();
                DB.bases.RemoveAt(MaBase.GetIdxFromNom(nom));
                fRecherche.RemplirCBbases();
            }
            catch
            {

            }
        }


        private void Importer(List<string[]> tab, string nomBase, int nbColonne)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO " + nomBase);

            sql.Append("(");
            for (int i = 1; i <= nbColonne; i++)
            {
                sql.Append("val" + i);
                if (i < nbColonne) sql.Append(",");
            }
            sql.Append(") VALUES ");

            for (int i = 0; i < tab.Count; i++)
            {
                sql.Append("('");
                sql.Append(String.Join("','", tab[i]));
                sql.Append("')");

                if (i < tab.Count - 1) sql.Append(",");
            }

            SQLiteCommand cmd = new SQLiteCommand(sql.ToString(), DB.SQLiteCon);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }

        }


        private List<string[]> LireXLSX(string filepath, Profil p)
        {
            List<string[]> tab = new List<string[]>();

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(filepath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var myWorksheet = xlPackage.Workbook.Worksheets[0];

                if (p.IdxFeuille > -1 && xlPackage.Workbook.Worksheets.Count > p.IdxFeuille)
                {
                    myWorksheet = xlPackage.Workbook.Worksheets[p.IdxFeuille];
                }
                else if (p.NomFeuille != "")
                {
                    myWorksheet = xlPackage.Workbook.Worksheets[p.NomFeuille];
                }

                var totalRows = myWorksheet.Dimension.End.Row;
                var totalCols = myWorksheet.Dimension.End.Column;

                for (int row = 1; row <= totalRows; row++)
                {
                    if (row <= p.NbEntetes) continue;
                    string[] stab = new string[totalCols];

                    for (int col = 1; col <= totalCols; col++)
                    {
                        stab[col - 1] = myWorksheet.Cells[row, col].Value.ToString();
                    }

                    tab.Add(stab);
                }
            }

            return tab;
        }


        private List<string[]> LireCSV(string filepath, Profil p)
        {
            List<string[]> tab = new List<string[]>();

            StreamReader sr = new StreamReader(filepath);
            int x = 0;

            while (x++ < p.NbEntetes && !sr.EndOfStream)
                sr.ReadLine();

            while (!sr.EndOfStream)
            {
                String str = sr.ReadLine();
                if (String.IsNullOrWhiteSpace(str)) continue;

                String[] tabLigne = str.Split(new String[] { Profil.GetSeparateurFromIndex(p.IdxSeparateur) }, StringSplitOptions.None);
                tab.Add(tabLigne);
            }

            return tab;
        }


    }
}