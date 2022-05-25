using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace MultiRechercheExcel
{
    public partial class Recherche : Form
    {
        GestionProfil fGestionProfil;
        SelectionFichier fSelectionFichier;
        ParametresRecherche fParametresRecherche;

        public Recherche()
        {
            InitializeComponent();

            DB.prBase = new ParamRecherche();
            DB.prValeur = new ParamRecherche();

            Settings.ReadConfigFile();

        }

        private void b_gestionProfil_Click(object sender, EventArgs e)
        {
            if (fGestionProfil == null || !fGestionProfil.CanFocus)
            {
                fGestionProfil = new GestionProfil();
                fGestionProfil.Show();
            }
            else if (fGestionProfil.CanFocus) fGestionProfil.Focus();
        }

        private void b_ajouterFichierValeurs_Click(object sender, EventArgs e)
        {
            fSelectionFichier = new SelectionFichier();
            fSelectionFichier.ShowDialog();

            if (!fSelectionFichier.cancelled)
            {
                Fichier f = new Fichier
                {
                    Nom = fSelectionFichier.filepath,
                    IdxProfil = fSelectionFichier.idxProfil
                };

                DB.fichiersValeurs.Add(f);

                lv_recherche.Items.Add(new ListViewItem(new String[] {
                    Path.GetFileName(f.Nom),
                    DB.profils[f.IdxProfil].nom
                }));
            }
        }

        private void b_ajouterFichierBase_Click(object sender, EventArgs e)
        {
            fSelectionFichier = new SelectionFichier();
            fSelectionFichier.ShowDialog();

            if (!fSelectionFichier.cancelled)
            {
                Fichier f = new Fichier
                {
                    Nom = fSelectionFichier.filepath,
                    IdxProfil = fSelectionFichier.idxProfil
                };

                DB.fichiersBases.Add(f);

                lv_base.Items.Add(new ListViewItem(new String[] {
                    Path.GetFileName(f.Nom),
                    DB.profils[f.IdxProfil].nom
                }));
            }
        }


        private IEnumerable<Valeur> LireValeursXLSX(string filepath, int idxProfil)
        {
            string filename = Path.GetFileName(filepath);

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(filepath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var myWorksheet = xlPackage.Workbook.Worksheets[0];
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalCols = myWorksheet.Dimension.End.Column;

                Profil p = DB.profils[idxProfil];
                bool colDone = false;

                for (int row = 1; row <= totalRows; row++)
                {
                    if (row <= p.nbEntetes) continue;

                    //pour chaque ligne, il faut d'abord récupérer toutes les colonnes custom
                    //et les assigner à chaque objet valeur créé pour chaque cols Eltec

                    string[] tabCustom = new string[p.colsCustom.Length];
                    List<Colonne> cols = new List<Colonne>();

                    for (int j = 0; j < p.colsCustom.Length; j++)
                    {
                        int col = p.colsCustom[j];
                        tabCustom[j] = myWorksheet.Cells[row, col].Value.ToString();

                        cols.Add(new Colonne
                        {
                            Nom = filename + "-" + j,
                            Valeur = myWorksheet.Cells[row, col].Value.ToString()
                        });
                    }

                    if (!colDone)
                    {
                        for (int i = 0; i < cols.Count; i++) DB.entetesColonnes.Add(cols[i].Nom);
                        colDone = true;
                    }


                    for (int j = 0; j < p.colsEltecs.Length; j++)
                    {
                        int col = p.colsEltecs[j];

                        yield return new Valeur
                        {
                            Colonnes = new List<Colonne>(cols),
                            FichierValeur = filename,
                            FichierBase = "",
                            ValeurOrigine = myWorksheet.Cells[row, col].Value.ToString(),
                            Trouve = false
                        };
                    }
                }
            }
        }

        private IEnumerable<Valeur> LireValeursCSV(string filepath, int idxProfil)
        {
            Profil p = DB.profils[idxProfil];
            string filename = Path.GetFileName(filepath);

            StreamReader sr = new StreamReader(filepath);
            int x = 0;
            bool colDone = false;

            while (x++ < p.nbEntetes && !sr.EndOfStream)
                sr.ReadLine();

            while (!sr.EndOfStream)
            {
                String str = sr.ReadLine();
                if (String.IsNullOrWhiteSpace(str)) continue;

                String[] tabLigne = str.Split(new String[] { Profil.GetSeparateurFromIndex(p.separateur) }, StringSplitOptions.None);

                string[] tabCustom = new string[p.colsCustom.Length];
                List<Colonne> cols = new List<Colonne>();

                for (int i = 0; i < p.colsCustom.Length; i++)
                {
                    tabCustom[i] = tabLigne[p.colsCustom[i] - 1];

                    cols.Add(new Colonne
                    {
                        Nom = filename + "-" + i,
                        Valeur = tabLigne[p.colsCustom[i] - 1]
                    });
                }

                if (!colDone)
                {
                    for (int i = 0; i < cols.Count; i++) DB.entetesColonnes.Add(cols[i].Nom);
                    colDone = true;
                }


                for (int j = 0; j < p.colsEltecs.Length; j++)
                {
                    yield return new Valeur
                    {
                        Colonnes = new List<Colonne>(cols),
                        FichierValeur = Path.GetFileName(filepath),
                        FichierBase = "",
                        ValeurOrigine = tabLigne[p.colsEltecs[j] - 1],
                        Trouve = false
                    };
                }
            }
        }


        private bool InArray(int x, int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == x) return true;
            }
            return false;
        }


        private void CollecterValeurs()
        {
            string[] tabTB = tb_valeursRecherche.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tabTB.Length; i++)
            {
                string valOrigine = tabTB[i];
                string valTransforme = TransformerValeur(valOrigine, DB.prValeur);

                DB.valeurs.Add(new Valeur
                {
                    Colonnes = new List<Colonne>(),
                    FichierBase = "",
                    FichierValeur = "entrée manuelle",
                    ValeurOrigine = valOrigine,
                    ValeurTransforme = valTransforme,
                    Trouve = false
                }); ;
            }

            for (int i = 0; i < DB.fichiersValeurs.Count; i++)
            {
                if (DB.fichiersValeurs[i].Nom.EndsWith(".xlsx"))
                {
                    foreach (Valeur v in LireValeursXLSX(DB.fichiersValeurs[i].Nom, DB.fichiersValeurs[i].IdxProfil))
                    {
                        string valOrigine = v.ValeurOrigine;
                        string valTransforme = TransformerValeur(valOrigine, DB.prValeur);
                        v.ValeurTransforme = valTransforme;

                        DB.valeurs.Add(v);
                    }
                }
                else
                {
                    foreach (Valeur v in LireValeursCSV(DB.fichiersValeurs[i].Nom, DB.fichiersValeurs[i].IdxProfil))
                    {
                        string valOrigine = v.ValeurOrigine;
                        string valTransforme = TransformerValeur(valOrigine, DB.prValeur);
                        v.ValeurTransforme = valTransforme;

                        DB.valeurs.Add(v);
                    }
                }
            }
        }

        private void ParcourirFichiers()
        {
            string[] tabTB = tb_valeursBase.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tabTB.Length; i++)
            {
                int idx = DB.valeurs.FindIndex((x) => { return ComparaisonValeurs(x.ValeurTransforme, tabTB[i], DB.prBase); });
                if (idx > -1)
                {
                    DB.valeurs[idx].FichierBase = "entrée manuelle";
                    DB.valeurs[idx].Trouve = true;
                }
            }

            for (int i = 0; i < DB.fichiersBases.Count; i++)
            {
                if (DB.fichiersBases[i].Nom.EndsWith(".xlsx"))
                {
                    foreach (Valeur v in LireValeursXLSX(DB.fichiersBases[i].Nom, DB.fichiersBases[i].IdxProfil))
                    {
                        int idx = DB.valeurs.FindIndex((x) => { return ComparaisonValeurs(x.ValeurTransforme, v.ValeurOrigine, DB.prBase); });
                        if (idx > -1)
                        {
                            DB.valeurs[idx].Colonnes.AddRange(v.Colonnes);
                            DB.valeurs[idx].FichierBase = Path.GetFileName(DB.fichiersBases[i].Nom);
                            DB.valeurs[idx].Trouve = true;
                        }
                    }
                }
                else if (DB.fichiersBases[i].Nom.EndsWith(".csv"))
                {
                    foreach (Valeur v in LireValeursCSV(DB.fichiersBases[i].Nom, DB.fichiersBases[i].IdxProfil))
                    {
                        int idx = DB.valeurs.FindIndex((x) => { return ComparaisonValeurs(x.ValeurTransforme, v.ValeurOrigine, DB.prBase); });
                        if (idx > -1)
                        {
                            DB.valeurs[idx].Colonnes.AddRange(v.Colonnes);
                            DB.valeurs[idx].FichierBase = Path.GetFileName(DB.fichiersBases[i].Nom);
                            DB.valeurs[idx].Trouve = true;
                        }
                    }
                }

                int prct = i / DB.fichiersBases.Count * 100;
                backgroundWorker1.ReportProgress(prct);
            }
        }

        private void Sauvegarde()
        {
            using (StreamWriter sw = new StreamWriter("result.csv", false, System.Text.Encoding.GetEncoding(1252)))
            {
                sw.Write("FichierValeur;FichierBase;ValeurOrigine;ValeurTransforme");

                for (int i = 0; i < DB.entetesColonnes.Count; i++)
                {
                    sw.Write(";" + DB.entetesColonnes[i]);
                }
                sw.Write("\n");

                for (int i = 0; i < DB.valeurs.Count; i++)
                {
                    if (DB.valeurs[i].Trouve)
                    {
                        sw.Write(DB.valeurs[i].FichierValeur + ";");
                        sw.Write(DB.valeurs[i].FichierBase + ";");
                        sw.Write(DB.valeurs[i].ValeurOrigine + ";");
                        sw.Write(DB.valeurs[i].ValeurTransforme);


                        for (int j = 0; j < DB.entetesColonnes.Count; j++)
                        {
                            sw.Write(";");

                            for (int k = 0; k < DB.valeurs[i].Colonnes.Count; k++)
                            {
                                if (DB.entetesColonnes[j] == DB.valeurs[i].Colonnes[k].Nom)
                                    sw.Write(DB.valeurs[i].Colonnes[k].Valeur);
                            }
                        }

                        sw.WriteLine();
                    }
                }
            }
        }

        private string TransformerValeur(string v, ParamRecherche pr)
        {
            if (pr.ModeCasse == ModeCasse.Lower)
                v = v.ToLower();
            else if (pr.ModeCasse == ModeCasse.Upper)
                v = v.ToUpper();

            //est ce que la chaine doit etre tronquée

            if (pr.debutChaine > 0 || pr.longueurChaine > 0 || pr.finChaine > 0)
            {
                int longueur = pr.longueurChaine;
                int debut = pr.debutChaine;
                int fin = pr.finChaine;

                if (debut > 0) debut -= 1;
                else debut = 0;

                if (longueur == 0)
                {
                    if (fin > 0) fin -= 1;
                    longueur = fin - debut;
                }

                v = v.Substring(debut, longueur);
            }


            return v;
        }



        private bool ComparaisonValeurs(string v1, string v2, ParamRecherche pr)
        {
            //v1 = valeur, déjà transformé
            //v2 = base, à transformer ici si besoin

            v2 = TransformerValeur(v2, pr);


            if (ParamRecherche.ModeRecherche == ModeRecherche.Exact)
                return v1 == v2;
            else if (ParamRecherche.ModeRecherche == ModeRecherche.Contains)
                return v2.Contains(v1);
            else if (ParamRecherche.ModeRecherche == ModeRecherche.StartsWith)
                return v2.Contains(v1);
            else if (ParamRecherche.ModeRecherche == ModeRecherche.EndsWith)
                return v2.EndsWith(v1);

            return false;
        }

        private void b_recherche_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //remplir le DB.valeurs
            CollecterValeurs();

            //parcourir les fichiers
            ParcourirFichiers();

            //sauvegarde des résultats
            Sauvegarde();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
        }

        private void b_parametrageRecherche_Click(object sender, EventArgs e)
        {
            if (fParametresRecherche == null || !fParametresRecherche.CanFocus)
            {
                fParametresRecherche = new ParametresRecherche();
                fParametresRecherche.Show();
            }
            else if (fParametresRecherche.CanFocus) fParametresRecherche.Focus();
        }
    }
}
