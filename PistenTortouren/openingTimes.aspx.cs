using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class openingTimes : System.Web.UI.Page
    {
        public string Item;
        public string btn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"].ToString() == "" ||Request.QueryString["ID"] == null)
            {
                Response.Redirect("landingpage.aspx");
            }
            if (Request.QueryString["Task"] == "Delete")
            {
                delete(Convert.ToInt32(Request.QueryString["ID"]));
            }
            if (Request.QueryString["Task"] == "Add")
            {
                add(Convert.ToInt32(Request.QueryString["ID"]));
            }

            btn = "<a class='btn' href='openingTimes.aspx?Task=Add&ID=" + Request.QueryString["ID"] + "'>+</a>";

            update();
            Item = loadData();
        }
        public string loadData()
        {
            string Items = "";
            string otTemplate = $@"<tr>
                   <form method='post' id='ot@ID' action='openingTimes.aspx?ID=@TourID'>
                       <input  name='hidden@ID' type='hidden' class='validate' value='@ID'>
                       <td><input  name='display@ID' type='number' class='validate' value='@ID' disabled></td>
                        <td><input  name='day@ID' type='text' class='validate' value='@day' required></td>
                       <td><input  name='start@ID' type='time' class='validate' value='@start' required></td>
                        <td><input name='end@ID' type='time' class='validate' value='@end' required></td>
                       <td><input  class='btn' type='submit' value='Speichern'></td>
                   </form>
                   <td><a class='btn btn-primary' href='openingTimes.aspx?Task=Delete&ID=@ID'>Löschen</a></td>
               </tr>";
            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
            {
                foreach (OpeningTime openingTime in context.OpeningTimes.SqlQuery("Select * FROM OpeningTimes").ToList<OpeningTime>())
                {
                    if (openingTime.Tour_ID.ToString() == Request.QueryString["ID"])
                    {
                        string userItem = otTemplate;
                        userItem = userItem.Replace("@ID", openingTime.openingTimeID.ToString());
                        userItem = userItem.Replace("@TourID", Request.QueryString["ID"]);
                        userItem = userItem.Replace("@day", openingTime.day);
                        userItem = userItem.Replace("@start", GlobalRef.htmltimeValue(openingTime.start));
                        userItem = userItem.Replace("@end", GlobalRef.htmltimeValue(openingTime.end));
                        Items = Items + userItem;
                    }
                    
                }
            }
            return Items;

        }
        public void delete(int id)
        {
            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
            {
                foreach (OpeningTime openingTime in context.OpeningTimes.SqlQuery("Select * FROM OpeningTimes").ToList<OpeningTime>())
                {
                    if (id == openingTime.openingTimeID)
                    {
                        context.Entry(openingTime).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                }
            }
        }

        public void update()

        {
            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
            {
                foreach (OpeningTime openingTime in context.OpeningTimes.SqlQuery("Select * FROM OpeningTimes").ToList<OpeningTime>())
                {
                    if (Convert.ToInt32(Request.Form["hidden" + openingTime.openingTimeID.ToString()]) == openingTime.openingTimeID)
                    {
                        openingTime.day = Request.Form["day" + openingTime.openingTimeID.ToString()];
                        openingTime.start = Convert.ToDateTime(Request.Form["start" + openingTime.openingTimeID.ToString()]);
                        openingTime.end = Convert.ToDateTime(Request.Form["end" + openingTime.openingTimeID.ToString()]);
                        context.SaveChanges();
                    }
                }
            }
        }

        public void add(int id)
        {
            OpeningTime ot = new OpeningTime
            {
                Tour_ID = id,
                day = "monday",
                start = new DateTime(2000, 1, 1),
                end = new DateTime(2000, 1, 1)
            };

            using (var context = new pistenTortourenDBContext())
            {
                context.OpeningTimes.Add(ot);
                context.SaveChanges();
            }
        }
    }
}