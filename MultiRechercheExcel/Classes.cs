﻿using System;
using System.Collections.Generic;

namespace MultiRechercheExcel
{
    public enum ModeRecherche
    {
        Exact, BaseContientValeur, ValeurContientBase,
        BaseCommenceParValeur, ValeurCommenceParBase,
        BaseFinitParValeur, ValeurFinitParBase
    };

    public enum ModeCasse { Normal, Upper, Lower };

    public enum TypeActionFichier { 
        AjouterColonne, SupprimerColonne, DeplacerColonne, DupliquerColonne,
        AjouterLigne, SupprimerLigne, DeplacerLigne, DupliquerLigne,
        TransformerColonne, TransformerFichier
    };

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

    public class Profil
    {
        public string Nom;
        public int NbEntetes;
        public int[] ColsEltecs;
        public int[] ColsCustom;
        public int IdxSeparateur;

        public static int[] getIntArray(String str)
        {
            String[] tab = str.Split(new String[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries);
            List<int> tabInt = new List<int>();

            for (int i = 0; i < tab.Length; i++)
            {
                int x;
                if (int.TryParse(tab[i], out x))
                    if (!tabInt.Contains(x)) tabInt.Add(x);
            }

            return tabInt.ToArray();
        }

        public static String GetSeparateurFromIndex(int idx)
        {
            if (idx == 0) return ";";
            else if (idx == 1) return ",";
            else if (idx == 2) return " ";
            else if (idx == 3) return "\t";
            return ";";
        }

        public static String getStringFromIntArray(int[] tab)
        {
            return String.Join(",", tab);
        }

        public override string ToString()
        {
            return Nom;
        }
    }

    public class ActionFichier
    {
        public TypeActionFichier TypeActionFichier { get; set; }
        public int IdxSrc { get; set; }
        public int IdxDst { get; set; }
        public ParamRecherche ModifChaine { get; set; }
    }

    public class ProfilAction
    {
        public string Nom { get; set; }
        public List<ActionFichier> Actions { get; set; }
    }
}