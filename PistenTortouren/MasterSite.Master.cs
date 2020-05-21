

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class MasterSite : System.Web.UI.MasterPage
    {
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null && Request.Cookies["User"].Value != "")
            {
                string email = "";
                using (var context = new pistenTortourenDBContext())
                {
                    foreach (User user in context.Users.SqlQuery("SELECT * FROM Users").ToList<User>())
                    {
                        if (user.email == StringCipher.Decrypt(Request.Cookies["User"].Value, "adminPW"))
                        {
                            email = user.email;
                        }
                    }
                }
                if (email != String.Empty)
                {
                    Session.Add("User", email);
                    llogout.Style.Add("display", "");
                    leditUser.Style.Add("display", "");
                    lcreatetour.Style.Add("display", "");
                }
                if (email == "admin@admin.com")
                {
                    ladminPage.Style.Add("display", "");
                }

            }
            else
            {
                llogin.Style.Add("display", "");
                lregistration.Style.Add("display", "");
            }
        }
    }
}

