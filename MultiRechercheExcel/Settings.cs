using System;
using System.IO;
using System.Text;

namespace MultiRechercheExcel
{
    public static class Settings
    {
        private static string fichierConfig = "MultiRechercheExcel.config.txt";
        public static string dateVersion = "25/05/2022";
        public static string version = "0.0.2";


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
                            ColsCustom = Profil.getIntArray(values[2]),
                            NbEntetes = int.Parse(values[3]),
                            IdxSeparateur = int.Parse(values[4])
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
                    DB.profils[i].Nom + ";" +
                    String.Join(",", DB.profils[i].ColsEltecs) + ";" +
                    String.Join(",", DB.profils[i].ColsCustom) + ";" +
                    DB.profils[i].NbEntetes + ";" +
                    DB.profils[i].IdxSeparateur);
            }

            sb.AppendLine("paramBase=" + (int)DB.prBase.ModeCasse + ";" +
                                        DB.prBase.debutChaine + ";" +
                                        DB.prBase.longueurChaine + ";" +
                                        DB.prBase.finChaine);

            sb.AppendLine("paramValeur=" + (int)DB.prValeur.ModeCasse + ";" +
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
            DB.profils.Add(new Profil { Nom = "Fichier texte", ColsEltecs = new int[] { 1 }, ColsCustom = new int[] { }, NbEntetes = 0, IdxSeparateur = 0 });
            DB.profils.Add(new Profil { Nom = "SPAER", ColsEltecs = new int[] { 14, 15, 16, 20, 21 }, ColsCustom = new int[] { 2 }, NbEntetes = 2, IdxSeparateur = 1 });
            DB.profils.Add(new Profil { Nom = "NETHAWK", ColsEltecs = new int[] { 5, 7, 17 }, ColsCustom = new int[] { 3, 4, 18 }, NbEntetes = 2, IdxSeparateur = 1 });
            DB.profils.Add(new Profil { Nom = "DEMETER", ColsEltecs = new int[] { 8, 9, 11, 13, 14 }, ColsCustom = new int[] { 1, 42, 43 }, NbEntetes = 2, IdxSeparateur = 1 });
        }

    }
}
