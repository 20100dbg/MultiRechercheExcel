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
                        string str = myWorksheet.Cells[row, col].Value.ToString();
                        stab[col - 1] = str.Replace("'", "''");
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

                string[] tabLigne = str.Split(new String[] { Profil.GetSeparateurFromIndex(p.IdxSeparateur) }, StringSplitOptions.None);

                for (int i = 0; i < tabLigne.Length; i++)
                {
                    tabLigne[i] = tabLigne[i].Replace("'", "''");
                }
                
                tab.Add(tabLigne);
            }

            return tab;
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
                        DB.bases[DB.bases.Count - 1].NbLignes = GetNbRows(DB.bases[DB.bases.Count - 1].Nom);

                        RemplirBases();

                        MessageBox.Show("Creation de base : ok");
                    }
                }
                else
                    MessageBox.Show("erreur de sélection de fichier");
            }
        }



        private void b_importer_Click(object sender, EventArgs e)
        {
            int idx = lb_bases.SelectedIndex;
            if (idx == -1)
            {
                MessageBox.Show("Pas de base sélectionnée");
                return;
            }

            string filename = SelectionFichier();

            if (filename != "")
            {
                MaBase b = DB.bases[idx];

                List<string[]> tab = new List<string[]>();

                if (filename.EndsWith(".xlsx")) tab = LireXLSX(filename, b.Profil);
                else tab = LireCSV(filename, b.Profil);

                if (tab.Count > 0)
                {
                    Importer(tab, b.Nom, tab[0].Length);
                    DB.bases[idx].NbLignes = GetNbRows(DB.bases[idx].Nom);
                    RemplirBases();

                    MessageBox.Show("Import : ok");
                }
                    
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
            catch (Exception e)
            {
                MessageBox.Show("Import : " + e.Message);
            }

        }


        public static int GetNbRows(string nomBase)
        {
            string sql = "SELECT count(*) FROM " + nomBase;
            SQLiteCommand cmd = new SQLiteCommand(sql, DB.SQLiteCon);
            int nbResult = -1;

            try
            {
                SQLiteDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read()) nbResult = sdr.GetInt32(0);
                sdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("NbRows : " + e.Message);
            }

            return nbResult;
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
                    
                    MessageBox.Show("Base supprimée");
                }
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
            catch (Exception e)
            {
                MessageBox.Show("Suppression : " + e.Message);
            }
        }

        private void b_viderBase_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Vider ?", "Confirmation", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                int idx = lb_bases.SelectedIndex;
                if (idx > -1)
                {
                    MaBase b = DB.bases[idx];
                    ViderBase(b.Nom);
                    DB.bases[idx].NbLignes = 0;

                    RemplirBases();

                    MessageBox.Show("Base vidée");
                }
            }
        }

        private void ViderBase(string nom)
        {
            string sql = "DELETE FROM " + nom;
            SQLiteCommand cmd = new SQLiteCommand(sql, DB.SQLiteCon);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Vider : " + e.Message);
            }
        }
    }
}