using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PistenTortouren
{
    public class GlobalRef
    {
        public static string sqlSearchFactory(string search, string fields)
        {
            List<string> listeSearch = GlobalRef.string2list(search);
            List<string> listeFields = GlobalRef.string2list(fields);



            string query = "WHERE (" + listeFields[0] + " LIKE '%" + listeSearch[0] + "%' ";
            for (int i = 1; i < listeFields.Count; i++)
            {
                query += "OR " + listeFields[i] + " Like '%" + listeSearch[0] + "%'";
            }
            query += ")";
            for (int i = 1; i < listeSearch.Count; i++)
            {
                query += "AND (" + listeFields[0] + " LIKE '%" + listeSearch[i] + "%' ";
                for (int a = 1; a < listeFields.Count; a++)
                {
                    query += "OR " + listeFields[a] + " Like '%" + listeSearch[i] + "%'";
                }
                query += ")";
            }
            query += ";";
            return query;
        }

        public static List<string> string2list(string st)
        {
            List<string> liste = new List<string>();
            string s = "";
            foreach (var item in st)
            {
                if (item.ToString() == " ")
                {
                    liste.Add(s);
                    s = "";
                }
                else
                {
                    s += item;
                }
            }
            liste.Add(s);
            return liste;
        }
    }
}