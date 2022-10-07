using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;

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

    public enum ModeResultat { UneOccurence, UneOccurenceParFichier, ToutesLesOccurences };

    public static class DB
    {
        public static List<Profil> profilsRecherche = new List<Profil>();
        public static List<ProfilAction> profilsAction = new List<ProfilAction>();

        public static List<Fichier> fichiersValeurs = new List<Fichier>();
        public static List<Fichier> fichiersBases = new List<Fichier>();
        public static List<MaBase> bases = new List<MaBase>();

        public static List<Valeur> valeurs = new List<Valeur>();
        public static List<string> entetesColonnes = new List<string>();

        public static ParamRecherche ParamRecherche { get; set; }
        public static TransformationChaine tcValeur { get; set; }
        public static TransformationChaine tcBase { get; set; }

        public static SQLiteConnection SQLiteCon { get; set; }
    }

    public static class SQLiteDB
    {
        public static Boolean Connect()
        {
            if (File.Exists(Settings.dbname))
            {
                DB.SQLiteCon = new SQLiteConnection("URI=file:" + Settings.dbname);
                DB.SQLiteCon.Open();
                return true;
            }
            else
                return false;
        }

        public static Boolean CreateDatabase()
        {
            if (!File.Exists(Settings.dbname))
            {
                SQLiteConnection.CreateFile(Settings.dbname);
                return true;
            }
            else
                return false;
        }

        public static void InsertDefaultData()
        {
            String sql = "CREATE TABLE bases (nom text, profil text, nbColonne integer);";
            SQLiteCommand cmd = new SQLiteCommand(sql, DB.SQLiteCon);
            cmd.ExecuteNonQuery();
        }
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
        public string Chemin { get; set; }
        public int IdxProfil { get; set; }

        public override string ToString()
        {
            return Path.GetFileName(Chemin);
        }
    }

    public class ParamRecherche
    {
        public static ModeRecherche ModeRecherche = ModeRecherche.Exact;
        public static bool RemonterToutesOccurences = true;
    }

    public class TransformationChaine : ICloneable
    {
        public ModeCasse ModeCasse = ModeCasse.Normal;
        
        public int debutChaine = 0;
        public int longueurChaine = 0;
        public int finChaine = 0;

        public string carPad = "";
        public int nbCarPad = 0;
        public bool leftPad = true;

        /*
        public string valeurDefaut = "";
        public bool valeurDefautDabord = true;
        */

        public TransformationChaine Clone()
        {
            return new TransformationChaine
            {
                ModeCasse = this.ModeCasse,
                debutChaine = this.debutChaine,
                longueurChaine = this.longueurChaine,
                finChaine = this.finChaine,
                carPad = this.carPad,
                nbCarPad = this.nbCarPad,
                leftPad = this.leftPad,
                /*
                valeurDefaut = this.valeurDefaut,
                valeurDefautDabord = this.valeurDefautDabord
                */
            };
        }
        
        object ICloneable.Clone()
        {
            return Clone();
        }

        public override string ToString()
        {
            return "casse " + this.ModeCasse.ToString() + Environment.NewLine +
                "substring(" + debutChaine + "," + longueurChaine + "," + finChaine + ")" + Environment.NewLine +
                "pad" + ((leftPad) ? "left" : "right") + "(" + carPad + "," + nbCarPad + ")";
        }
    }

    public class MaBase
    {
        public string Nom;
        public int NbColonnes;
        public Profil Profil;
        public int NbLignes;

        public static int GetIdxFromNom(string nom)
        {
            nom = nom.ToLower();
            int idx = -1;

            for (int i = 0; i < DB.bases.Count; i++)
            {
                if (DB.bases[i].Nom.ToLower() == nom) idx = i;
            }

            return idx;
        }

        public override string ToString()
        {
            return Nom + " (" + NbLignes + ")";
        }
    }

    public class Profil
    {
        public string Nom;
        public int NbEntetes;
        public int[] ColsEltecs;
        public int[] ColsAffichees;
        public int IdxSeparateur;
        public int IdxFeuille;
        public string NomFeuille;


        public static int[] GetIntArray(String str)
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

        public static int GetProfilIdxByName(string name)
        {
            for (int i = 0; i < DB.profilsRecherche.Count; i++)
            {
                if (name.ToUpper() == DB.profilsRecherche[i].Nom.ToUpper()) return i;
            }
            return -1;
        }

        public static string GetSeparateurFromIndex(int idx)
        {
            if (idx == 0) return ";";
            else if (idx == 1) return ",";
            else if (idx == 2) return " ";
            else if (idx == 3) return "\t";
            return ";";
        }

        public static string GetStringFromIntArray(int[] tab)
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
        public TransformationChaine TransChaine { get; set; }

        public override string ToString()
        {
            return TypeActionFichier.ToString();
        }
    }

    public class ProfilAction
    {
        public string Nom { get; set; }
        public List<ActionFichier> Actions { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }
}