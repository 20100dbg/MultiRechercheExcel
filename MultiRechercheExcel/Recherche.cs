using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;

namespace MultiRechercheExcel
{
    public partial class Recherche : Form
    {
        GestionProfil fGestionProfil;
        GestionBase fGestionBase;
        SelectionFichier fSelectionFichier;
        ParametresRecherche fParametresRecherche;

        //ModeResultat monModeResultat = ModeResultat.ToutesLesOccurences;

        int nbResultat;
        List<MaBase> basesRecherche = new List<MaBase>();

        public Recherche()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            this.Icon = Properties.Resources.MultiRechercheExcel;
            this.Text += " " + Settings.version;

            if (!SQLiteDB.Connect())
            {
                SQLiteDB.CreateDatabase();
                SQLiteDB.Connect();
                SQLiteDB.InsertDefaultData();
            }

            DB.tcRef = new TransformationChaine();
            DB.tcValeur = new TransformationChaine();

            Settings.Log("Init config");
            Settings.InitConfig();
            Settings.Log("Lecture fichier de config " + Settings.ReadConfigFile());
            //ParamRecherche.RemonterToutesOccurences = true;

            for (int i = 0; i < DB.profilsAction.Count; i++)
                cb_ProfilAction.Items.Add(DB.profilsAction[i].Nom);

            GetListeBases();
            RemplirCBbases();

        }

        private IEnumerable<Valeur> LireValeursXLSX(string filepath, Profil p)
        {
            string filename = Path.GetFileName(filepath);

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

                int nbColsAffichees = (ParamRecherche.ToutesColsAffichees || p.ToutesAffichees) ? totalCols : p.ColsAffichees.Length;
                int nbColsEltecs = (ParamRecherche.ToutesColsEltecs || p.ToutesEltecs) ? totalCols : p.ColsEltecs.Length;

                for (int i = 0; i < nbColsAffichees; i++)
                {
                    int col = (ParamRecherche.ToutesColsAffichees || p.ToutesAffichees) ? i + 1 : p.ColsAffichees[i];
                    DB.entetesColonnes.Add(filename + "-" + col);
                }

                for (int row = 1; row <= totalRows; row++)
                {
                    if (row <= p.NbEntetes) continue;

                    //pour chaque ligne, il faut d'abord récupérer toutes les colonnes à afficher
                    //et les assigner à chaque objet valeur créé pour chaque cols Eltec
                    
                    Dictionary<string, string> cols = new Dictionary<string, string>();
                    
                    for (int j = 0; j < nbColsAffichees; j++)
                    {
                        int col = (ParamRecherche.ToutesColsAffichees || p.ToutesAffichees) ? j + 1 : p.ColsAffichees[j];

                        string makey = filename + "-" + col;
                        string mavalue = myWorksheet.Cells[row, col].Value.ToString();
                        cols.Add(makey, mavalue);

                    }

                    for (int j = 0; j < nbColsEltecs; j++)
                    {
                        int col = (ParamRecherche.ToutesColsEltecs || p.ToutesEltecs) ? j + 1 : p.ColsEltecs[j];
                        
                        if (row <= totalRows && col <= totalCols)
                        {
                            yield return new Valeur
                            {
                                Colonnes2 = new Dictionary<string, string>(cols),
                                FichierValeur = "",
                                FichierRef = filename,
                                ValeurOrigine = myWorksheet.Cells[row, col].Value.ToString(),
                                Trouve = false
                            };
                        }
                        else
                            Settings.Log(filename + " (" + p.Nom + ") : dépassement de colonne");
                    }
                }
            }
        }

        private IEnumerable<Valeur> LireValeursCSV(string filepath, Profil p)
        {
            string filename = Path.GetFileName(filepath);

            StreamReader sr = new StreamReader(filepath);
            int x = 0;

            while (x++ < p.NbEntetes && !sr.EndOfStream)
                sr.ReadLine();

            bool colDone = false;

            while (!sr.EndOfStream)
            {
                String str = sr.ReadLine();
                if (String.IsNullOrWhiteSpace(str)) continue;

                String[] tabLigne = str.Split(new String[] { Profil.GetSeparateurFromIndex(p.IdxSeparateur) }, StringSplitOptions.None);
                

                int nbColsAffichees = (ParamRecherche.ToutesColsAffichees || p.ToutesAffichees) ? tabLigne.Length : p.ColsAffichees.Length;
                int nbColsEltecs = (ParamRecherche.ToutesColsEltecs || p.ToutesEltecs) ? tabLigne.Length : p.ColsEltecs.Length;

                string[] tabAffichees = new string[nbColsAffichees];
                //List<Colonne> cols = new List<Colonne>();
                Dictionary<string, string> cols = new Dictionary<string, string>();

                for (int i = 0; i < nbColsAffichees; i++)
                {
                    int idxCol = (ParamRecherche.ToutesColsAffichees || p.ToutesAffichees) ? i : p.ColsAffichees[i] - 1;

                    if (idxCol < tabLigne.Length)
                    {
                        tabAffichees[i] = tabLigne[idxCol];

                        cols.Add(filename + "-" + idxCol, tabLigne[idxCol]);
                        if (!colDone) DB.entetesColonnes.Add(filename + "-" + (idxCol+1));
                    }
                    else
                        Settings.Log(filename + " (" + p.Nom + ") : dépassement de colonne");
                }
                colDone = true;

                for (int j = 0; j < nbColsEltecs; j++)
                {
                    int idxCol = (ParamRecherche.ToutesColsEltecs || p.ToutesEltecs) ? j : p.ColsEltecs[j] - 1;

                    if (idxCol < tabLigne.Length)
                    {
                        yield return new Valeur
                        {
                            //Colonnes = new List<Colonne>(cols),
                            Colonnes2 = new Dictionary<string, string>(cols),
                            FichierValeur = Path.GetFileName(filepath),
                            FichierRef = "",
                            ValeurOrigine = tabLigne[idxCol],
                            Trouve = false
                        };
                    }
                    else
                        Settings.Log(filename + " (" + p.Nom + ") : dépassement de colonne");
                }
            }
        }

        private IEnumerable<Valeur> LireValeurs(string filepath, Profil p)
        {
            if (filepath.EndsWith(".xlsx"))
            {
                foreach (Valeur v in LireValeursXLSX(filepath, p)) yield return v;
            }
            else
            {
                foreach (Valeur v in LireValeursCSV(filepath, p)) yield return v;
            }
        }

        private void CollecterValeurs()
        {
            string[] tabTB = tb_valValeurs.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tabTB.Length; i++)
            {
                string valOrigine = tabTB[i];
                string valTransforme = TransformerValeur(valOrigine, DB.tcValeur);

                DB.valeurs.Add(new Valeur
                {
                    Colonnes2 = new Dictionary<string, string>(),
                    FichierRef = "",
                    FichierValeur = "entrée manuelle",
                    ValeurOrigine = valOrigine,
                    ValeurTransforme = valTransforme,
                    Trouve = false
                });
            }

            for (int i = 0; i < DB.fichiersValeurs.Count; i++)
            {
                Profil p = DB.profilsRecherche[DB.fichiersValeurs[i].IdxProfil];

                foreach (Valeur v in LireValeurs(DB.fichiersValeurs[i].Chemin, p))
                {
                    if (v.ValeurOrigine != "")
                    {
                        string valOrigine = v.ValeurOrigine;
                        string valTransforme = TransformerValeur(valOrigine, DB.tcValeur);
                        v.ValeurTransforme = valTransforme;
                        v.FichierValeur = Path.GetFileName(DB.fichiersValeurs[i].Chemin);
                        
                        //v.Colonnes2.Clear();

                        DB.valeurs.Add(v);
                    }
                }
            }
        }

        private void ParcourirFichiers()
        {
            string[] tabTB = tb_valReferences.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tabTB.Length; i++)
            {
                int idx = 0;
                string val = TransformerValeur(tabTB[i], DB.tcRef);

                while (idx > -1)
                {
                    idx = DB.valeurs.FindIndex(idx, (x) => { return ComparaisonValeurs(x.ValeurTransforme, val); });

                    if (idx > -1)
                    {
                        if (!DB.valeurs[idx].Trouve)// || monModeResultat == ModeResultat.ToutesLesOccurences)
                        {
                            DB.valeurs[idx].FichierRef = "entrée manuelle";
                            DB.valeurs[idx].Trouve = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < DB.fichiersRefs.Count; i++)
            {
                Profil p = DB.profilsRecherche[DB.fichiersRefs[i].IdxProfil];
                bool foundInFile = false;

                foreach (Valeur v in LireValeurs(DB.fichiersRefs[i].Chemin, p))
                {
                    int idx = -1;

                    do
                    {
                        idx = DB.valeurs.FindIndex(idx + 1, (x) =>
                        {
                            string val = TransformerValeur(v.ValeurOrigine, DB.tcRef);

                            return x.FichierRef != DB.fichiersRefs[i].Chemin &&
                                ComparaisonValeurs(x.ValeurTransforme, val);
                        });

                        if (idx > -1)// && !DB.valeurs[idx].Trouve)
                        {
                            if (!DB.valeurs[idx].Trouve)// || monModeResultat == ModeResultat.ToutesLesOccurences)
                            {
                                //DB.valeurs[idx].Colonnes2 contient les colonnes du fichier VALEUR
                                //v.Colonnes contient les colonnes du fichier REFERENCE
                                DB.valeurs[idx].Colonnes2 = v.Colonnes2;
                                
                                DB.valeurs[idx].FichierRef = Path.GetFileName(DB.fichiersRefs[i].Chemin);
                                DB.valeurs[idx].Trouve = true;
                                foundInFile = true;
                            }
                            /*
                            if (monModeResultat != ModeResultat.ToutesLesOccurences)
                                break;
                            */
                        }

                    } while (idx > -1);

                    if (foundInFile)// && monModeResultat != ModeResultat.ToutesLesOccurences)
                        continue;
                }

                int prct = i / DB.fichiersRefs.Count * 100;
                backgroundWorker1.ReportProgress(prct);
            }
        }

        private void RechercheBase()
        {
            for (int k = 0; k < basesRecherche.Count; k++)
            {
                MaBase baseActuelle = basesRecherche[k];
                
                
                int nbColsAffichees = (ParamRecherche.ToutesColsAffichees || baseActuelle.Profil.ToutesAffichees) ? baseActuelle.NbColonnes : baseActuelle.Profil.ColsAffichees.Length;
                int nbColsEltecs = (ParamRecherche.ToutesColsEltecs || baseActuelle.Profil.ToutesEltecs) ? baseActuelle.NbColonnes : baseActuelle.Profil.ColsEltecs.Length;

                string sql = "SELECT * FROM " + baseActuelle.Nom + " WHERE ";

                // baseActuelle.Profil.ColsEltecs.Length
                for (int j = 0; j < nbColsEltecs; j++)
                {
                    int idxCol = (ParamRecherche.ToutesColsEltecs || baseActuelle.Profil.ToutesEltecs) ? j : baseActuelle.Profil.ColsEltecs[j] - 1;

                    sql += "val" + idxCol + " = '{val}'";
                    if (j < nbColsEltecs - 1) sql += " OR ";
                }

                //baseActuelle.Profil.ColsAffichees.Length
                for (int j = 0; j < nbColsAffichees; j++)
                {
                    int idxCol = (ParamRecherche.ToutesColsAffichees || baseActuelle.Profil.ToutesAffichees) ? j : baseActuelle.Profil.ColsAffichees[j] - 1;
                    DB.entetesColonnes.Add(baseActuelle.Nom + " - val" + (idxCol+1));
                }

                for (int i = 0; i < DB.valeurs.Count; i++)
                {
                    if (DB.valeurs[i].Trouve) continue;

                    string sql2 = sql.Replace("{val}", DB.valeurs[i].ValeurTransforme);
                    SQLiteCommand cmd = new SQLiteCommand(sql2, DB.SQLiteCon);

                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Object[] tab = new Object[rdr.FieldCount];
                            rdr.GetValues(tab);

                            for (int j = 0; j < nbColsAffichees; j++)
                            {
                                int col = (ParamRecherche.ToutesColsAffichees || baseActuelle.Profil.ToutesAffichees) ? j : baseActuelle.Profil.ColsAffichees[j] - 1;

                                DB.valeurs[i].Colonnes2.Add(baseActuelle.Nom + " - val" + (col+1), tab[col].ToString());
                            }

                            DB.valeurs[i].FichierRef = "Base " + baseActuelle.Nom;
                            DB.valeurs[i].Trouve = true;
                        }
                    }
                }
            }
        }

        private void Sauvegarde()
        {
            Settings.Log("Sauvegarde " + Settings.savefilename);

            using (StreamWriter sw = new StreamWriter(Settings.savefilename, false, System.Text.Encoding.GetEncoding(1252)))
            {
                sw.Write("FichierValeur;FichierReference;ValeurOrigine;ValeurTransforme");

                for (int i = 0; i < DB.entetesColonnes.Count; i++)
                {
                    sw.Write(";" + DB.entetesColonnes[i]);
                }
                sw.WriteLine();

                for (int i = 0; i < DB.valeurs.Count; i++)
                {
                    if (DB.valeurs[i].Trouve)
                    {
                        sw.Write(DB.valeurs[i].FichierValeur + ";");
                        sw.Write(DB.valeurs[i].FichierRef + ";");
                        sw.Write(DB.valeurs[i].ValeurOrigine + ";");
                        sw.Write(DB.valeurs[i].ValeurTransforme);

                        for (int j = 0; j < DB.entetesColonnes.Count; j++)
                        {
                            sw.Write(";");

                            if (DB.valeurs[i].Colonnes2.ContainsKey(DB.entetesColonnes[j]))
                                sw.Write(DB.valeurs[i].Colonnes2[DB.entetesColonnes[j]]);
                        }

                        sw.WriteLine();
                    }
                }
            }
        }

        public static string TransformerValeur(string v, TransformationChaine tc)
        {
            //if (tc.valeurDefautDabord && v == "") v = tc.valeurDefaut;

            if (tc.ModeCasse == ModeCasse.Lower)
                v = v.ToLower();
            else if (tc.ModeCasse == ModeCasse.Upper)
                v = v.ToUpper();

            int debut = tc.debutChaine;
            int longueur = tc.longueurChaine;
            int fin = tc.finChaine;

            if (fin > 0)
            {
                if (fin < v.Length)
                {
                    debut = v.Length - fin;
                    if (longueur == 0) longueur = v.Length - debut;
                }
            }
            else
            {
                if (debut > 0 && debut < v.Length) debut -= 1;
                else debut = 0;
                if (longueur == 0) longueur = v.Length;
            }

            if (v.Length > debut + longueur)
                v = v.Substring(debut, longueur);

            if (tc.nbCarPad > 0 && tc.carPad != "")
            {
                if (tc.leftPad) v = v.PadLeft(tc.nbCarPad, tc.carPad[0]);
                else v = v.PadRight(tc.nbCarPad, tc.carPad[0]);
            }

            //if (!tc.valeurDefautDabord && v == "") v = tc.valeurDefaut;

            return v;
        }

        private bool ComparaisonValeurs(string v1, string v2)
        {
            if (ParamRecherche.ModeRecherche == ModeRecherche.Exact)
                return v1 == v2;
            else if (ParamRecherche.ModeRecherche == ModeRecherche.RefContientValeur)
                return v2.Contains(v1);
            else if (ParamRecherche.ModeRecherche == ModeRecherche.ValeurContientRef)
                return v1.Contains(v2);
            else if (ParamRecherche.ModeRecherche == ModeRecherche.RefCommenceParValeur)
                return v2.StartsWith(v1);
            else if (ParamRecherche.ModeRecherche == ModeRecherche.ValeurCommenceParRef)
                return v1.StartsWith(v2);
            else if (ParamRecherche.ModeRecherche == ModeRecherche.RefFinitParValeur)
                return v2.EndsWith(v1);
            else if (ParamRecherche.ModeRecherche == ModeRecherche.ValeurFinitParRef)
                return v1.EndsWith(v2);

            return false;
        }

        private void b_recherche_Click(object sender, EventArgs e)
        {
            //vider les listes
            DB.entetesColonnes.Clear();
            DB.valeurs.Clear();

            basesRecherche.Clear();

            for (int i = 0; i < clb_bases.CheckedItems.Count; i++)
            {
                basesRecherche.Add((MaBase)clb_bases.CheckedItems[i]);
            }

            Settings.savefilename = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_result.csv";

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //remplir le DB.valeurs
            Settings.Log("Collecte des valeurs");
            CollecterValeurs();

            DB.entetesColonnes.Clear();

            //parcourir les fichiers
            Settings.Log("Parcours des fichiers références");
            ParcourirFichiers();

            //recherche dans la base sélectionnée
            Settings.Log("Recherche en base");
            RechercheBase();


            nbResultat = DB.valeurs.FindAll((x) => { return x.Trouve == true; }).Count;
            Settings.Log(nbResultat + " résultats");

            //sauvegarde des résultats
            if (nbResultat > 0)
                Sauvegarde();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;

            MessageBox.Show(nbResultat + " résultats");
            

            if (nbResultat > 0)
            {
                l_filename.Text = Settings.savefilename + " sauvegardé";
                System.Diagnostics.Process.Start(Application.StartupPath + "\\" + Settings.savefilename);
            }
            else
                l_filename.Text = "Pas de résultat";


        }


        #region Transformation
        private void TransformerFichier(string filepath, ProfilAction pa)
        {
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(filepath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var wk = xlPackage.Workbook;
                var ws = wk.Worksheets[0];

                for (int i = 0; i < pa.Actions.Count; i++)
                {
                    ApplyAction(ws, pa.Actions[i]);
                }

                xlPackage.Save();
            }
        }

        private void ApplyAction(ExcelWorksheet ex, ActionFichier af)
        {
            var totalRows = ex.Dimension.End.Row;
            var totalCols = ex.Dimension.End.Column;

            if (af.TypeActionFichier == TypeActionFichier.AjouterColonne)
            {
                ex.InsertColumn(af.IdxDst, 1);
            }
            else if (af.TypeActionFichier == TypeActionFichier.AjouterLigne)
            {
                ex.InsertRow(af.IdxDst, 1);
            }
            else if (af.TypeActionFichier == TypeActionFichier.DeplacerColonne)
            {
                ex.InsertColumn(af.IdxDst, 1);
                Copier(ex, af.IdxSrc, af.IdxDst, false);
                ex.DeleteColumn(af.IdxSrc);
            }
            else if (af.TypeActionFichier == TypeActionFichier.DeplacerLigne)
            {
                ex.InsertRow(af.IdxDst, 1);
                Copier(ex, af.IdxSrc, af.IdxDst, true);
                ex.DeleteRow(af.IdxSrc);
            }
            else if (af.TypeActionFichier == TypeActionFichier.DupliquerColonne)
            {
                ex.InsertColumn(af.IdxDst, 1);
                Copier(ex, af.IdxSrc, af.IdxDst, false);
            }
            else if (af.TypeActionFichier == TypeActionFichier.DupliquerLigne)
            {
                ex.InsertRow(af.IdxDst, 1);
                Copier(ex, af.IdxSrc, af.IdxDst, true);
            }
            else if (af.TypeActionFichier == TypeActionFichier.SupprimerColonne)
            {
                ex.DeleteColumn(af.IdxDst);
            }
            else if (af.TypeActionFichier == TypeActionFichier.SupprimerLigne)
            {
                ex.DeleteRow(af.IdxDst);
            }
            else if (af.TypeActionFichier == TypeActionFichier.TransformerColonne)
            {
                for (int i = 1; i <= totalRows; i++)
                {
                    object o = ex.Cells[i, af.IdxDst].Value;
                    String val = (o != null) ? o.ToString() : "";

                    val = TransformerValeur(val, af.TransChaine);
                    ex.Cells[i, af.IdxDst].SetCellValue(0, 0, val);
                }
            }
            else if (af.TypeActionFichier == TypeActionFichier.TransformerFichier)
            {
                for (int i = 1; i <= totalRows; i++)
                {
                    for (int j = 1; j <= totalCols; j++)
                    {
                        object o = ex.Cells[i, j].Value;
                        String val = (o != null) ? o.ToString() : "";

                        val = TransformerValeur(val, af.TransChaine);
                        ex.Cells[i, j].SetCellValue(0, 0, val);
                    }
                }
            }
        }

        private void Copier(ExcelWorksheet ex, int idxSrc, int idxDst, bool ligne)
        {
            int totalRows = ex.Dimension.End.Row;
            int totalCols = ex.Dimension.End.Column;

            if (ligne)
            {
                for (int i = 1; i <= totalCols; i++)
                {
                    object val = ex.Cells[idxSrc, i].Value;
                    ex.Cells[idxDst, i].SetCellValue(0, 0, val);
                }
            }
            else
            {
                for (int i = 1; i <= totalRows; i++)
                {
                    object val = ex.Cells[i, idxSrc].Value;
                    ex.Cells[i, idxDst].SetCellValue(0, 0, val);
                }
            }
        }
        #endregion

        #region fonctions interface
        private void b_ajouterFichierValeurs_Click(object sender, EventArgs e)
        {
            fSelectionFichier = new SelectionFichier();
            fSelectionFichier.ShowDialog();

            if (!fSelectionFichier.cancelled)
            {
                Fichier f = new Fichier
                {
                    Chemin = fSelectionFichier.filepath,
                    IdxProfil = fSelectionFichier.idxProfil
                };

                DB.fichiersValeurs.Add(f);

                lv_valeurs.Items.Add(new ListViewItem(new String[] {
                    Path.GetFileName(f.Chemin),
                    DB.profilsRecherche[f.IdxProfil].Nom
                }));

                Settings.Log("Ajout fichier valeur " + f.Chemin);
            }
        }

        private void b_ajouterFichierReference_Click(object sender, EventArgs e)
        {
            fSelectionFichier = new SelectionFichier();
            fSelectionFichier.ShowDialog();

            if (!fSelectionFichier.cancelled)
            {
                Fichier f = new Fichier
                {
                    Chemin = fSelectionFichier.filepath,
                    IdxProfil = fSelectionFichier.idxProfil
                };

                DB.fichiersRefs.Add(f);

                lv_references.Items.Add(new ListViewItem(new String[] {
                    Path.GetFileName(f.Chemin),
                    DB.profilsRecherche[f.IdxProfil].Nom
                }));

                Settings.Log("Ajout fichier référence " + f.Chemin);
            }
        }

        private void b_ViderFichiersValeurs_Click(object sender, EventArgs e)
        {
            lv_valeurs.Items.Clear();
            DB.fichiersValeurs.Clear();
        }

        private void b_ViderFichiersReferences_Click(object sender, EventArgs e)
        {
            lv_references.Items.Clear();
            DB.fichiersRefs.Clear();
        }

        private void gestionDesProfilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fGestionProfil == null || !fGestionProfil.CanFocus)
            {
                fGestionProfil = new GestionProfil();
                fGestionProfil.Show();
            }
            else if (fGestionProfil.CanFocus) fGestionProfil.Focus();
        }

        private void paramétrageRechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fParametresRecherche == null || !fParametresRecherche.CanFocus)
            {
                fParametresRecherche = new ParametresRecherche();
                fParametresRecherche.Show();
            }
            else if (fParametresRecherche.CanFocus) fParametresRecherche.Focus();
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Concocté par Marty sur une idée de Kevin" + Environment.NewLine +
                "Contact : vincent.marie@intradef.gouv.fr" + Environment.NewLine +
                Environment.NewLine +
                "Version " + Settings.version + " du " + Settings.dateVersion + Environment.NewLine);
        }

        private void b_ajouterFichierTransformation_Click(object sender, EventArgs e)
        {
            fSelectionFichier = new SelectionFichier();
            fSelectionFichier.ShowDialog();

            if (!fSelectionFichier.cancelled)
            {
                Fichier f = new Fichier
                {
                    Chemin = fSelectionFichier.filepath,
                    IdxProfil = fSelectionFichier.idxProfil
                };

                lb_fichiersTransformation.Items.Add(f);

                Settings.Log("Ajout fichier transformation " + f.Chemin);
            }
        }

        private void b_AppliquerTransformation_Click(object sender, EventArgs e)
        {
            int idxProfil = cb_ProfilAction.SelectedIndex;
            ProfilAction pa = DB.profilsAction[idxProfil];

            for (int i = 0; i < lb_fichiersTransformation.Items.Count; i++)
            {
                Fichier f = (Fichier)lb_fichiersTransformation.Items[i];

                TransformerFichier(f.Chemin, pa);
            }
        }

        #endregion

        private void gestionDesBasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fGestionBase == null || !fGestionBase.CanFocus)
            {
                fGestionBase = new GestionBase(this);
                fGestionBase.Show();
            }
            else if (fGestionBase.CanFocus) fGestionBase.Focus();
        }


        public void GetListeBases()
        {
            DB.bases.Clear();
            string sql = "SELECT nom, profil, nbColonne FROM bases";

            SQLiteCommand cmd = new SQLiteCommand(sql, DB.SQLiteCon);

            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int idxProfil = Profil.GetProfilIdxByName(rdr.GetString(1));
                    DB.bases.Add(new MaBase
                    {
                        Nom = rdr.GetString(0),
                        Profil = DB.profilsRecherche[idxProfil],
                        NbColonnes = rdr.GetInt32(2)
                    });
                }
            }

            for (int i = 0; i < DB.bases.Count; i++)
            {
                DB.bases[i].NbLignes = GestionBase.GetNbRows(DB.bases[i].Nom);
            }
        }


        public void RemplirCBbases()
        {
            clb_bases.Items.Clear();
            
            for (int i = 0; i < DB.bases.Count; i++)
            {
                clb_bases.Items.Add(DB.bases[i]);
            }

        }

    }
}
