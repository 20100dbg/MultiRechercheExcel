using System;
using System.Collections.Generic;

namespace MultiRechercheExcel
{
    public enum ModeRecherche { Exact, Contains, StartsWith, EndsWith };
    public enum ModeCasse { Normal, Upper, Lower };

    public static class DB
    {
        public static List<Profil> profils = new List<Profil>();

        public static List<Fichier> fichiersValeurs = new List<Fichier>();
        public static List<Fichier> fichiersBases = new List<Fichier>();

        public static List<Valeur> valeurs = new List<Valeur>();
        public static List<string> entetesColonnes = new List<string>();

        public static ParamRecherche prValeur { get; set; }
        public static ParamRecherche prBase { get; set; }
    }

    public class Colonne
    {
        public string Nom { get; set; }
        public string Valeur { get; set; }
    }

    public class Valeur
    {
        public string ValeurOrigine { get; set; }
        public string ValeurTransforme { get; set; }
        public string FichierValeur { get; set; }
        public string FichierBase { get; set; }
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

    public class ParamRecherche
    {
        public static ModeRecherche ModeRecherche = ModeRecherche.Exact;
        public ModeCasse ModeCasse = ModeCasse.Normal;
        public int debutChaine = 0;
        public int longueurChaine = 0;
        public int finChaine = 0;
    }
}