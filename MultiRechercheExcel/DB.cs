using System;
using System.Collections.Generic;

namespace MultiRechercheExcel
{
    public static class DB
    {
        public static List<Profil> profils = new List<Profil>();

        public static List<Fichier> fichiersValeurs = new List<Fichier>();
        public static List<Fichier> fichiersBases = new List<Fichier>();

        public static List<Valeur> valeurs = new List<Valeur>();
        //public static List<string> entetes = new List<string>();

        //nom auto colonne, valeur
        //public static Dictionary<string, string> dicCol = new Dictionary<string, string>();

        //public static List<Colonne> colonnes = new List<Colonne>();
        public static List<string> entetesColonnes = new List<string>();
    }

    public class Colonne
    {
        public string Nom { get; set; }
        public string Valeur { get; set; }
    }

    public class Valeur
    {
        public string ValeurOrigine { get; set; }
        public string FichierValeur { get; set; }
        public string FichierBase { get; set; }
        public List<string> ColonnesValeur { get; set; }
        public List<string> ColonnesBase { get; set; }
        public List<Colonne> Colonnes { get; set; }
        public bool Trouve { get; set; }

        public override bool Equals(object obj)
        {
            return this.ValeurOrigine == ((Valeur)obj).ValeurOrigine;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class Fichier
    {
        public string Nom { get; set; }
        public int IdxProfil { get; set; }
    }
}