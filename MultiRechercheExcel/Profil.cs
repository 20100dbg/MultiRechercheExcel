using System;
using System.Collections.Generic;


namespace MultiRechercheExcel
{
    public class Profil
    {
        public String nom;
        public int nbEntetes;
        public int[] colsEltecs;
        public int separateur;
        public int[] colsCustom;


        public static int[] getIntArray(String str)
        {
            String[] tab = str.Split(new String[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries);
            int x, y;
            List<int> tabInt = new List<int>();

            for (int i = 0; i < tab.Length; i++)
            {

                if (int.TryParse(tab[i], out x))
                {
                    if (!tabInt.Contains(x)) tabInt.Add(x);
                }
                else
                {
                    y = 0;

                    int tmp = (int)tab[i][0] - 64;
                    if (tmp > 0 && tmp < 27) y = tmp;

                    if (!tabInt.Contains(y) && y > 0) tabInt.Add(y);
                }
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
            return nom;
        }

        public override bool Equals(object obj)
        {
            return (obj.ToString().ToUpper() == nom.ToUpper());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
