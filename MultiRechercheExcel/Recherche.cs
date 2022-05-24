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

        public Recherche()
        {
            InitializeComponent();

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


        private void LireValeursXLSX(string filepath, int idxProfil)
        {
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(filepath)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var myWorksheet = xlPackage.Workbook.Worksheets[0];
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalCols = myWorksheet.Dimension.End.Column;

                Profil p = DB.profils[idxProfil];

                for (int row = 1; row <= totalRows; row++)
                {
                    if (row <= p.nbEntetes) continue;

                    //pour chaque ligne, il faut d'abord récupérer toutes les colonnes custom
                    //et les assigner à chaque objet valeur créé pour chaque cols Eltec

                    string[] tabCustom = new string[p.colsCustom.Length];

                    for (int j = 0; j < p.colsCustom.Length; j++)
                    {
                        int col = p.colsCustom[j];
                        tabCustom[j] = myWorksheet.Cells[row, col].Value.ToString();
                    }

                    for (int j = 0; j < p.colsEltecs.Length; j++)
                    {
                        DB.valeurs.Add(new Valeur
                        {
                            ColonnesBase = new List<string>(),
                            ColonnesValeur = new List<string>(tabCustom),
                            FichierBase = "",
                            FichierValeur = Path.GetFileName(filepath),
                            ValeurOrigine = myWorksheet.Cells[row, j].Value.ToString(),
                            Trouve = false
                        });
                    }
                }
            }
        }

        private void LireValeursCSV(string filepath, int idxProfil)
        {
            Profil p = DB.profils[idxProfil];

            StreamReader sr = new StreamReader(filepath);
            int x = 0;

            while (x++ < p.nbEntetes && !sr.EndOfStream)
                sr.ReadLine();

            while (!sr.EndOfStream)
            {
                String str = sr.ReadLine();
                if (String.IsNullOrWhiteSpace(str)) continue;

                String[] tabLigne = str.Split(new String[] { Profil.GetSeparateurFromIndex(p.separateur) }, StringSplitOptions.None);

                string[] tabCustom = new string[p.colsCustom.Length];

                for (int i = 0; i < p.colsCustom.Length; i++)
                {
                    tabCustom[i] = tabLigne[p.colsCustom[i] - 1];
                }

                for (int j = 0; j < p.colsEltecs.Length; j++)
                {
                    DB.valeurs.Add(new Valeur
                    {
                        ColonnesBase = new List<string>(),
                        ColonnesValeur = new List<string>(tabCustom),
                        FichierBase = "",
                        FichierValeur = Path.GetFileName(filepath),
                        ValeurOrigine = tabLigne[p.colsEltecs[j] - 1],
                        Trouve = false
                    });
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
                DB.valeurs.Add(new Valeur
                {
                    ColonnesBase = new List<string>(),
                    ColonnesValeur = new List<string>(),
                    FichierBase = "",
                    FichierValeur = "entrée manuelle",
                    ValeurOrigine = tabTB[i],
                    Trouve = false
                });
            }

            for (int i = 0; i < DB.fichiersValeurs.Count; i++)
            {
                if (DB.fichiersValeurs[i].Nom.EndsWith(".xlsx"))
                    LireValeursXLSX(DB.fichiersValeurs[i].Nom, DB.fichiersValeurs[i].IdxProfil);
                else
                    LireValeursCSV(DB.fichiersValeurs[i].Nom, DB.fichiersValeurs[i].IdxProfil);
            }
        }

        private void ParcourirFichiers()
        {
            for (int i = 0; i < DB.fichiersBases.Count; i++)
            {
                Profil p = DB.profils[DB.fichiersBases[i].IdxProfil];

                //XLSX
                if (DB.fichiersBases[i].Nom.EndsWith(".xlsx"))
                {

                    using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(DB.fichiersBases[i].Nom)))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var myWorksheet = xlPackage.Workbook.Worksheets[0];
                        var totalRows = myWorksheet.Dimension.End.Row;

                        for (int row = 1; row <= totalRows; row++)
                        {
                            if (row <= p.nbEntetes) continue;

                            string[] tabCustom = new string[p.colsCustom.Length];

                            for (int j = 0; j < p.colsCustom.Length; j++)
                            {
                                int col = p.colsCustom[j];
                                tabCustom[j] = myWorksheet.Cells[row, col].Value.ToString();
                            }

                            for (int j = 0; j < p.colsEltecs.Length; j++)
                            {
                                int col = p.colsEltecs[j];
                                string val = myWorksheet.Cells[row, col].Value.ToString();

                                int idx = DB.valeurs.FindIndex((x) => { return x.ValeurOrigine == val; });
                                if (idx > -1)
                                {
                                    DB.valeurs[idx].ColonnesBase.AddRange(tabCustom);
                                    DB.valeurs[idx].FichierBase = Path.GetFileName(DB.fichiersBases[i].Nom);
                                    DB.valeurs[idx].Trouve = true;
                                }
                            }
                        }
                    }
                }
                else if (DB.fichiersBases[i].Nom.EndsWith(".csv"))
                {
                    StreamReader sr = new StreamReader(DB.fichiersBases[i].Nom);
                    int x = 0;

                    while (x++ < p.nbEntetes && !sr.EndOfStream)
                        sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        String str = sr.ReadLine();
                        if (String.IsNullOrWhiteSpace(str)) continue;

                        String[] tabLigne = str.Split(new String[] { Profil.GetSeparateurFromIndex(p.separateur) }, StringSplitOptions.None);

                        string[] tabCustom = new string[p.colsCustom.Length];

                        for (int j = 0; j < p.colsCustom.Length; j++)
                        {
                            tabCustom[j] = tabLigne[p.colsCustom[j]];
                        }

                        for (int j = 0; j < p.colsEltecs.Length; j++)
                        {
                            string val = tabLigne[p.colsEltecs[j]];
                            int idx = DB.valeurs.FindIndex((y) => { return y.ValeurOrigine == val; });
                            if (idx > -1)
                            {
                                DB.valeurs[idx].ColonnesBase.AddRange(tabCustom);
                                DB.valeurs[idx].FichierBase = Path.GetFileName(DB.fichiersBases[i].Nom);
                                DB.valeurs[idx].Trouve = true;
                            }
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
                sw.WriteLine("FichierValeur;FichierBase;ValeurOrigine;ColonnesValeur;ColonnesBase");

                for (int i = 0; i < DB.valeurs.Count; i++)
                {
                    if (DB.valeurs[i].Trouve)
                    {
                        sw.Write(DB.valeurs[i].FichierValeur + ";");
                        sw.Write(DB.valeurs[i].FichierBase + ";");
                        sw.Write(DB.valeurs[i].ValeurOrigine + ";");

                        string colValeurs = String.Join(";", DB.valeurs[i].ColonnesValeur.ToArray());
                        string colBase = String.Join(";", DB.valeurs[i].ColonnesBase.ToArray());

                        sw.Write(colValeurs + ";");
                        sw.Write(colBase);

                        sw.WriteLine();
                    }
                }
            }
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
    }
}
