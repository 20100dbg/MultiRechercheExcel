﻿using System;
using System.IO;
using System.Text;

namespace MultiRechercheExcel
{
    public static class Settings
    {
        private static string fichierConfig = "MultiRechercheExcel.config.txt";
        public static string dateVersion = "31/05/2022";
        public static string version = "0.0.4";
        public static string savefilename = "";

        public static bool ReadConfigFile()
        {
            if (!File.Exists(Settings.fichierConfig)) return false;

            using (StreamReader sr = new StreamReader(Settings.fichierConfig))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line)) continue;

                    String[] keyValue = line.Split(new char[] { '=' });
                    String[] values = keyValue[1].Split(new char[] { ';' });

                    if (keyValue[0] == "profil")
                    {
                        Profil p = new Profil
                        {
                            Nom = values[0],
                            ColsEltecs = Profil.getIntArray(values[1]),
                            ColsAffichees = Profil.getIntArray(values[2]),
                            NbEntetes = int.Parse(values[3]),
                            IdxSeparateur = int.Parse(values[4])
                        };
                        DB.profilsRecherche.Add(p);
                    }
                    else if (keyValue[0] == "profilAction")
                    {
                        ProfilAction pa = new ProfilAction
                        {
                            Nom = values[0],
                            Actions = new System.Collections.Generic.List<ActionFichier>()
                        };

                        for (int i = 0; i < values.Length; i++)
                        {
                            String[] invalues = values[1].Split(new char[] { '|' });

                            pa.Actions.Add(new ActionFichier
                            {
                                TypeActionFichier = (TypeActionFichier)int.Parse(invalues[0]),
                                IdxSrc = int.Parse(invalues[1]),
                                IdxDst = int.Parse(invalues[2]),
                                TransChaine = new TransformationChaine
                                {
                                    ModeCasse = (ModeCasse)int.Parse(invalues[3]),
                                    debutChaine = int.Parse(invalues[4]),
                                    longueurChaine = int.Parse(invalues[5]),
                                    finChaine = int.Parse(invalues[6])
                                }
                            });
                        }

                        DB.profilsAction.Add(pa);
                    }
                    else if (keyValue[0] == "paramValeur")
                    {
                        DB.tcValeur.ModeCasse = (ModeCasse)int.Parse(values[0]);
                        DB.tcValeur.debutChaine = int.Parse(values[1]);
                        DB.tcValeur.longueurChaine = int.Parse(values[2]);
                        DB.tcValeur.finChaine = int.Parse(values[3]);
                    }
                    else if (keyValue[0] == "paramBase")
                    {
                        DB.tcBase.ModeCasse = (ModeCasse)int.Parse(values[0]);
                        DB.tcBase.debutChaine = int.Parse(values[1]);
                        DB.tcBase.longueurChaine = int.Parse(values[2]);
                        DB.tcBase.finChaine = int.Parse(values[3]);
                    }
                }
            }
            return true;
        }

        public static void WriteConfigFile()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < DB.profilsRecherche.Count; i++)
            {
                sb.AppendLine("profil=" +
                    DB.profilsRecherche[i].Nom + ";" +
                    String.Join(",", DB.profilsRecherche[i].ColsEltecs) + ";" +
                    String.Join(",", DB.profilsRecherche[i].ColsAffichees) + ";" +
                    DB.profilsRecherche[i].NbEntetes + ";" +
                    DB.profilsRecherche[i].IdxSeparateur);
            }

            for (int i = 0; i < DB.profilsAction.Count; i++)
            {
                sb.Append("profilAction=" + DB.profilsAction[i].Nom);

                for (int j = 0; j < DB.profilsAction[i].Actions.Count; j++)
                {
                    ActionFichier af = DB.profilsAction[i].Actions[j];

                    sb.Append(";" + (int)af.TypeActionFichier + "|" +
                                af.IdxSrc + "|" + af.IdxDst + "|" +
                                (int)af.TransChaine.ModeCasse + "|" +
                                af.TransChaine.debutChaine + "|" +
                                af.TransChaine.longueurChaine + "|" +
                                af.TransChaine.finChaine);
                }
                sb.Append("\n");
            }

            sb.AppendLine("paramBase=" + (int)DB.tcBase.ModeCasse + ";" +
                                        DB.tcBase.debutChaine + ";" +
                                        DB.tcBase.longueurChaine + ";" +
                                        DB.tcBase.finChaine);

            sb.AppendLine("paramValeur=" + (int)DB.tcValeur.ModeCasse + ";" +
                                        DB.tcValeur.debutChaine + ";" +
                                        DB.tcValeur.longueurChaine + ";" +
                                        DB.tcValeur.finChaine);

            using (StreamWriter sw = new StreamWriter(Settings.fichierConfig))
            {
                sw.Write(sb.ToString());
            }
        }
        
        public static void LoadDefaut()
        {
            DB.profilsRecherche.Add(new Profil { Nom = "Fichier texte", ColsEltecs = new int[] { 1 }, ColsAffichees = new int[] { }, NbEntetes = 0, IdxSeparateur = 0 });
            DB.profilsRecherche.Add(new Profil { Nom = "SPAER", ColsEltecs = new int[] { 14, 15, 16, 20, 21 }, ColsAffichees = new int[] { 2 }, NbEntetes = 2, IdxSeparateur = 1 });
            DB.profilsRecherche.Add(new Profil { Nom = "NETHAWK", ColsEltecs = new int[] { 5, 7, 17 }, ColsAffichees = new int[] { 3, 4, 18 }, NbEntetes = 2, IdxSeparateur = 1 });
            DB.profilsRecherche.Add(new Profil { Nom = "DEMETER", ColsEltecs = new int[] { 8, 9, 11, 13, 14 }, ColsAffichees = new int[] { 1, 42, 43 }, NbEntetes = 2, IdxSeparateur = 1 });
        }

    }
}
