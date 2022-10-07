using System;
using System.IO;
using System.Text;

namespace MultiRechercheExcel
{
    public static class Settings
    {
        private static string fichierConfig = "MultiRechercheExcel.config.txt";
        public static string dateVersion = "07/10/2022";
        public static string version = "0.0.9";
        public static string savefilename = "";
        public static string dbname = "bases.sqlite";

        private static StringBuilder sbLog = new StringBuilder();
        public static void Log(string s)
        {
            sbLog.AppendLine(DateTime.Now.ToString("yyyyMMdd_HHmmss") + " : " + s);
        }

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
                            ColsEltecs = Profil.GetIntArray(values[1]),
                            ColsAffichees = Profil.GetIntArray(values[2]),
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

                        for (int i = 1; i < values.Length; i++)
                        {
                            String[] invalues = values[i].Split(new char[] { '|' });

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
                                    finChaine = int.Parse(invalues[6]),
                                    carPad = invalues[7],
                                    nbCarPad = int.Parse(invalues[8]),
                                    leftPad = (invalues[9].ToLower() == "true"),
                                    /*
                                    valeurDefaut = invalues[10],
                                    valeurDefautDabord = (invalues[11].ToLower() == "true")
                                    */
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
                        DB.tcValeur.carPad = values[4];
                        DB.tcValeur.nbCarPad = int.Parse(values[5]);
                        DB.tcValeur.leftPad = (values[6].ToLower() == "true");
                        /*
                        DB.tcValeur.valeurDefaut = values[7];
                        DB.tcValeur.valeurDefautDabord = (values[8].ToLower() == "true");
                        */
                    }
                    else if (keyValue[0] == "paramBase")
                    {
                        DB.tcBase.ModeCasse = (ModeCasse)int.Parse(values[0]);
                        DB.tcBase.debutChaine = int.Parse(values[1]);
                        DB.tcBase.longueurChaine = int.Parse(values[2]);
                        DB.tcBase.finChaine = int.Parse(values[3]);
                        DB.tcBase.carPad = values[4];
                        DB.tcBase.nbCarPad = int.Parse(values[5]);
                        DB.tcBase.leftPad = (values[6].ToLower() == "true");
                        /*
                        DB.tcBase.valeurDefaut = values[7];
                        DB.tcBase.valeurDefautDabord = (values[8].ToLower() == "true");
                        */
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
                                af.IdxSrc + "|" + af.IdxDst + "|");

                    if (af.TransChaine == null) sb.Append("0|0|0|0|0|0|0");
                    else
                    {
                        sb.Append((int)af.TransChaine.ModeCasse + "|" +
                                af.TransChaine.debutChaine + "|" +
                                af.TransChaine.longueurChaine + "|" +
                                af.TransChaine.finChaine + "|" +
                                af.TransChaine.carPad + "|" +
                                af.TransChaine.nbCarPad + "|" +
                                af.TransChaine.leftPad);
                    }

                    /*
                    af.TransChaine.valeurDefaut + "|" +
                    af.TransChaine.valeurDefautDabord);
                    */
                }
                sb.Append("\n");
            }

            sb.AppendLine("paramBase=" + (int)DB.tcBase.ModeCasse + ";" +
                                        DB.tcBase.debutChaine + ";" +
                                        DB.tcBase.longueurChaine + ";" +
                                        DB.tcBase.finChaine + ";" +
                                        DB.tcBase.carPad + ";" +
                                        DB.tcBase.nbCarPad + ";" +
                                        DB.tcBase.leftPad);
                                        /*
                                        DB.tcBase.valeurDefaut + ";" +
                                        DB.tcBase.valeurDefautDabord);
                                        */

            sb.AppendLine("paramValeur=" + (int)DB.tcValeur.ModeCasse + ";" +
                                        DB.tcValeur.debutChaine + ";" +
                                        DB.tcValeur.longueurChaine + ";" +
                                        DB.tcValeur.finChaine + ";" +
                                        DB.tcValeur.carPad + ";" +
                                        DB.tcValeur.nbCarPad + ";" +
                                        DB.tcValeur.leftPad);
                                        /*
                                        DB.tcValeur.valeurDefaut + ";" +
                                        DB.tcValeur.valeurDefautDabord);
                                        */


            using (StreamWriter sw = new StreamWriter(Settings.fichierConfig))
            {
                sw.Write(sb.ToString());
            }
        }

    }
}
