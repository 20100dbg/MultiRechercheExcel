using System;
using System.IO;
using System.Text;

namespace MultiRechercheExcel
{
    public static class Settings
    {
        private static string fichierConfig = "MultiRechercheExcel.config.txt";
        public static string dateVersion = "24/05/2022";
        public static string version = "0.0.1";


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
                            nom = values[0],
                            colsEltecs = Profil.getIntArray(values[1]),
                            colsCustom = Profil.getIntArray(values[2]),
                            nbEntetes = int.Parse(values[3]),
                            separateur = int.Parse(values[4])
                        };
                        DB.profils.Add(p);
                    }
                    else if (keyValue[0] == "paramValeur")
                    {
                        DB.prValeur.ModeCasse = (ModeCasse)int.Parse(values[0]);
                        DB.prValeur.debutChaine = int.Parse(values[1]);
                        DB.prValeur.longueurChaine = int.Parse(values[2]);
                        DB.prValeur.finChaine = int.Parse(values[3]);
                    }
                    else if (keyValue[0] == "paramBase")
                    {
                        DB.prBase.ModeCasse = (ModeCasse)int.Parse(values[0]);
                        DB.prBase.debutChaine = int.Parse(values[1]);
                        DB.prBase.longueurChaine = int.Parse(values[2]);
                        DB.prBase.finChaine = int.Parse(values[3]);
                    }
                }
            }
            return true;
        }

        public static void WriteConfigFile()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < DB.profils.Count; i++)
            {
                sb.AppendLine("profil=" +
                    DB.profils[i].nom + ";" +
                    String.Join(",", DB.profils[i].colsEltecs) + ";" +
                    String.Join(",", DB.profils[i].colsCustom) + ";" +
                    DB.profils[i].nbEntetes + ";" +
                    DB.profils[i].separateur);
            }

            sb.AppendLine("paramBase=" + DB.prBase.ModeCasse + ";" +
                                        DB.prBase.debutChaine + ";" +
                                        DB.prBase.longueurChaine + ";" +
                                        DB.prBase.finChaine);

            sb.AppendLine("paramValeur=" + DB.prValeur.ModeCasse + ";" +
                                        DB.prValeur.debutChaine + ";" +
                                        DB.prValeur.longueurChaine + ";" +
                                        DB.prValeur.finChaine);

            using (StreamWriter sw = new StreamWriter(Settings.fichierConfig))
            {
                sw.Write(sb.ToString());
            }
        }
        
        public static void LoadDefaut()
        {
            DB.profils.Add(new Profil { nom = "Fichier texte", colsEltecs = new int[] { 1 }, colsCustom = new int[] { }, nbEntetes = 0, separateur = 0 });
            DB.profils.Add(new Profil { nom = "SPAER", colsEltecs = new int[] { 14, 15, 16, 20, 21 }, colsCustom = new int[] { 2 }, nbEntetes = 2, separateur = 1 });
            DB.profils.Add(new Profil { nom = "NETHAWK", colsEltecs = new int[] { 5, 7, 17 }, colsCustom = new int[] { 3, 4, 18 }, nbEntetes = 2, separateur = 1 });
            DB.profils.Add(new Profil { nom = "DEMETER", colsEltecs = new int[] { 8, 9, 11, 13, 14 }, colsCustom = new int[] { 1, 42, 43 }, nbEntetes = 2, separateur = 1 });

        }

    }
}
