using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class Testtest123 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string test = "";
            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
            {
                foreach (User user in context.Users.SqlQuery("Select * FROM Users").ToList<User>())
                {
                    test += user.email;
                }
            }
            Response.Write(test);
        }
    }
}