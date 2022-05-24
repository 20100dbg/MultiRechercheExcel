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
    }

    public class Valeur
    {
        public string ValeurOrigine { get; set; }
        public string FichierValeur { get; set; }
        public string FichierBase { get; set; }
        public List<string> ColonnesValeur { get; set; }
        public List<string> ColonnesBase { get; set; }
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