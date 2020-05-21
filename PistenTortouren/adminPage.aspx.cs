using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class adminPage : System.Web.UI.Page
    {
        public string Item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"].ToString() != "admin@admin.com")
            {
                Response.Redirect("landingpage.aspx");
            }
            if (Request.QueryString["Task"] == "Delete")
            {
                delete(Convert.ToInt32(Request.QueryString["ID"]));
            }
            update();
            Item = loadData();
            
        }

        public string loadData()
        {
            string Items = "";
            string userTemplate = $@"<tr>
                   <form method='post' id='adminPage@ID' action='adminPage.aspx'>
                       <input  name='email@ID' type='hidden' class='validate' value='@EMail' >
                       <td><input  name='emaildisplay@ID' type='email' class='validate' value='@EMail' disabled></td>
                       <td><input  name='billsent@ID' type='date' class='validate' value='@BillSent' required></td>
                        <td><input name='lastpayment@ID' type='date' class='validate' value='@LastPayment' required></td>
                       <td><input  class='btn' type='submit' value='Speichern'></td>
                   <form>
                   <td><a class='btn btn-primary' href='adminPage.aspx?Task=Delete&ID=@ID'>Löschen</a></td>
               </tr>";

            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
            {
                foreach (User user in context.Users.SqlQuery("Select * FROM Users").ToList<User>())
                {
                    string userItem = userTemplate;
                    userItem = userItem.Replace("@EMail", user.email);
                    userItem = userItem.Replace("@BillSent", GlobalRef.htmlCorrectDateValue(user.billSent));
                    userItem = userItem.Replace("@LastPayment", GlobalRef.htmlCorrectDateValue(user.lastPayment));
                    userItem = userItem.Replace("@ID", user.userID.ToString());
                    Items = Items + userItem;
                }
            }
            return Items;

        }
        public void delete(int id)
        {
            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
            {
                foreach (User user in context.Users.SqlQuery("Select * FROM Users").ToList<User>())
                {
                    if (id == user.userID)
                    {
                        context.Entry(user).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                }
            }
        }

        public void update()
        {
            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
            {
                foreach (User user in context.Users.SqlQuery("Select * FROM Users").ToList<User>())
                {
                    if (Request.Form["email" + user.userID.ToString()] == user.email)
                    {
                        user.billSent = Convert.ToDateTime(Request.Form["billsent" + user.userID.ToString()]);
                        user.lastPayment = Convert.ToDateTime(Request.Form["lastpayment" + user.userID.ToString()]);
                        
                    }
                }
                context.SaveChanges();
            }
        }
    }
}