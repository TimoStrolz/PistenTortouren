using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public class GlobalRef
    {
        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
        public static bool emailValid(string eingabe)
        {
            //regular expression string
            string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
            //überprüfen
            Match result = Regex.Match(eingabe, pattern);
            //abfrage und rückgabe
            return result.Success;

        }
        public static bool phoneValid(string eingabe, string country)
        {

            //regular expression string
            string pattern = phonenpattern(country);
            //überprüfen
            Match result = Regex.Match(eingabe, pattern);
            //abfrage und rückgabe
            return result.Success;
        }

        //*******************************************************************************************************
        //***** GetLandInfo
        // https://en.wikipedia.org/wiki/List_of_country_calling_codes#Alphabetical_listing_by_country_or_region
        // https://regex101.com/
        //*******************************************************************************************************
        public static  string phonenpattern (string countryCode)
        {
            string pattern = "^\\+[3,4][0-9\\s]{7,17}$"; //Europa...
            switch (countryCode)
            {
                case "CH": pattern =  "^\\+41[0-9\\s]{7,17}$"; break;
                case "DE": pattern = "^\\+49[0-9\\s]{7,17}$";  break;
                case "AT": pattern = "^\\+43[0-9\\s]{7,17}$"; break;
                default:
                    break;
            }
            return pattern;
        }

        public static string htmlCorrectDateValue(DateTime date)
        {
            string lessTenDays = "";
            if (date.Day < 10)
            {
                lessTenDays = "0";
            }
            string lessTenMonths = "";
            if (date.Month < 10)
            {
                lessTenMonths = "0";
            }
            string s = date.Year.ToString() + "-" + lessTenMonths + date.Month.ToString() +  "-" + lessTenDays + date.Day.ToString();
            return s;
        }

        public static int getIDFromEmail(string email)
        {
            if (email != null)
            {
                using (pistenTortourenDBContext context = new pistenTortourenDBContext())
                {
                    foreach (User user in context.Users.SqlQuery("SELECT * FROM Users WHERE email='" + email + "'").ToList<User>())
                    {
                        return user.userID;
                    }
                }
            }
            return 0;
        }
    }
}