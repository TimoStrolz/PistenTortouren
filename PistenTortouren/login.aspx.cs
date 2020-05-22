using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class login : System.Web.UI.Page
    {
        public string smeldung;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (login_())
            {
                Session.Add("User", Request.Form["email"]);
                HttpCookie myCookie = new HttpCookie("User");
                myCookie.Value = StringCipher.Encrypt(Request.Form["email"], "adminPW");
                myCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(myCookie);
                Response.Redirect("landingpage.aspx");
            }
            else
            {
                smeldung = "Falsches Passwort oder Email";
            }
        }

        public bool login_()
        {
            if (Request.Form["email"] == null && Request.Form["pw"] == null)
            {
                return false;
            }
            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
            {
                int counter = 0;
                foreach (User user in context.Users.SqlQuery("SELECT * FROM Users").ToList<User>())
                {
                    if (user.email == Request.Form["email"] && user.password == GlobalRef.getHashSha256(Request.Form["password"]))
                    {
                        counter++;

                    }
                }
                if (counter > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}