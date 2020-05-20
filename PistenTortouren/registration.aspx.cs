using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class registration : System.Web.UI.Page
    {
        public string smeldung;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("landingpage.aspx");
            }
            smeldung = registration_done();
            if (smeldung == "")
            {
                Session.Add("User", Request.Form["email"]);
                HttpCookie myCookie = new HttpCookie("User");
                myCookie.Value = StringCipher.Encrypt(Request.Form["email"], "adminPW");
                myCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(myCookie);
                Response.Redirect("landingpage.aspx");
            }
        }
        public string registration_done()
        {
            if (Request.Form["name"] != null && Request.Form["website"] != null && Request.Form["phone"] != null && Request.Form["email"] != null && Request.Form["language"] != null && Request.Form["country"] != null && Request.Form["city"] != null && Request.Form["zip"] != null && Request.Form["street"] != null && Request.Form["housenumber"] != null && Request.Form["subscriptionnumber"] != null)
            {
                if (!GlobalRef.phoneValid(Request.Form["phone"], Request.Form["country"]))
                {
                    return "Falsche Telefonnummer Achten sie auf das ausgewählte Land und geben sie die nummer mit der Korrekten vorwahl an.";
                }

                if (!GlobalRef.emailValid(Request.Form["email"]))
                {
                    return "email nicht korrektes format";
                }
                bool success = Int32.TryParse(Request.Form["zip"], out int izip);
                if (!success)
                {
                    return "plz muss zahl sein";
                }
                success = Int32.TryParse(Request.Form["housenumber"], out int ihousenumber);
                if (!success)
                {
                    return "hausnummer muss zahl sein";
                }

                string pw = GlobalRef.getHashSha256(Request.Form["password"]);
                int subnr = Convert.ToInt32(Request.Form["subscriptionnumber"]);


                User newUser = new User
                {
                    name = Request.Form["name"], 
                    website = Request.Form["website"],
                    phone = Request.Form["phone"],
                    password = pw,
                    email = Request.Form["email"],
                    lastPayment = new DateTime(2000, 1, 1),
                    emailVerified = false,
                    billSent = new DateTime(2000, 1, 1),
                    birthday = DateTime.Now,
                    language = Request.Form["language"],
                    country = Request.Form["country"],
                    city = Request.Form["city"],
                    street = Request.Form["street"],
                    zip = izip,
                    housenumber = ihousenumber,
                    subscriptionNumber = subnr
                };
                using (var context = new pistenTortourenDBContext())
                {
                    int counter = 0;
                    foreach (User user in context.Users.SqlQuery("SELECT * FROM Users").ToList<User>())
                    {
                        if (user.email == Request.Form["email"])
                        {
                            //email schon vorhanden
                            counter++;
                            return "Email schon vorhanden";
                        }
                    }
                    if (counter == 0)
                    {
                        context.Users.Add(newUser);
                        context.SaveChanges();
                        return "";
                    }
                }
            }
            return "nicht alle felder ausgefüllt";
        }
    }
}