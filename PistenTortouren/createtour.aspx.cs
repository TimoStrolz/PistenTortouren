using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class createtour : System.Web.UI.Page
    {
        public string smeldung;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["User"].ToString() == "")
            {
                Response.Redirect("landingpage.aspx");
            }
            smeldung = createTour();
            if (smeldung == "")
            {
                Response.Redirect("detailpage.aspx");
            }
        }

            public string createTour()
        {
            if (Request.Form["title"] != null && Request.Form["difficulty"] != null && Request.Form["text"] != null && Request.Form["safetyi"] != null && Request.Form["seasonStart"] != null && Request.Form["seasonEnd"] != null && Request.Form["length"] != null && Request.Form["altitude"] != null && Request.Form["lowestPoint"] != null && Request.Form["highestPoint"] != null && Request.Form["startlat"] != null && Request.Form["startlong"] != null && Request.Form["finishlat"] != null && Request.Form["finishlong"] != null && Request.Form["gettingThere"] != null && Request.Form["signalled"] != null && Request.Form["changingRooms"] != null && Request.Form["wc"] != null && Request.Form["food"] != null && Request.Form["drink"] != null && Request.Form["accommodation"] != null && Request.Form["status"] != null && Request.Form["instructions"] != null)
            {
                bool success = float.TryParse(Request.Form["length"], out float flength);
                if (!success)
                {
                    return "Länge muss eine Zahl sein!";
                }
                success = int.TryParse(Request.Form["altitude"], out int ialtitude);
                if (!success)
                {
                    return "Höhenmeter muss eine Zahl sein!";
                }
                success = int.TryParse(Request.Form["lowestPoint"], out int ilowestPoint);
                if (!success)
                {
                    return "Niedrigster Punkt muss eine Ganzzahl sein!";
                }
                success = int.TryParse(Request.Form["highestPoint"], out int ihighestPoint);
                if (!success)
                {
                    return "Höchster Punkt muss eine Ganzzahl sein!";
                }
                success = int.TryParse(Request.Form["startlat"], out int dstartlat);
                if (!success)
                {
                    return "Start Latitude muss Zahl sein!!";
                }
                success = int.TryParse(Request.Form["startlong"], out int dstartlong);
                if (!success)
                {
                    return "Start Longitude muss Zahl sein!!";
                }
                success = int.TryParse(Request.Form["finishlat"], out int dfinishlat);
                if (!success)
                {
                    return "Ziel Latitude muss Zahl sein!!";
                }
                success = int.TryParse(Request.Form["finishlong"], out int dfinishlong);
                if (!success)
                {
                    return "Ziel Longitude muss Zahl sein!!";
                }


                Tour newTour = new Tour
                {
                    title = Request.Form["title"],
                    text = Request.Form["text"],
                    safetyInstruction = Request.Form["safetyi"],
                    difficulty = Request.Form["difficulty"],
                    seasonStart = Convert.ToDateTime(Request.Form["seasonStart"]),
                    seasonEnd = Convert.ToDateTime(Request.Form["seasonEnd"]),
                    tourLength = flength,
                    altitude = ialtitude,
                    lowestPoint= ilowestPoint,
                    highestPoint = ihighestPoint,
                    startingLatitude = dstartlat,
                    startingLongitude = dstartlong,
                    finishLatitude = dfinishlat,
                    finishLongitude = dfinishlat,
                    gettingThere = Request.Form["gettingThere"],
                    signalled = Convert.ToBoolean(Request.Form["signalled"]),
                    changingRooms = Convert.ToBoolean(Request.Form["changingRooms"]),
                    wc = Convert.ToBoolean(Request.Form["wc"]),
                    drinks = Convert.ToBoolean(Request.Form["drink"]),
                    food = Convert.ToBoolean(Request.Form["food"]),
                    accommodation = Convert.ToBoolean(Request.Form["accomodation"]),
                    status  = Convert.ToInt32(Request.Form["status"]),
                    instructions = Request.Form["instructions"],
                    numberOfFiles = 0,
                    birthday = DateTime.Now,
                    User_ID = GlobalRef.getIDFromEmail(Session["User"].ToString())
                
                };
                using (var context = new pistenTortourenDBContext())
                {
                    context.Tours.Add(newTour);
                        context.SaveChanges();
                        return "";
                }
            }
            return "nicht alle felder ausgefüllt";
        }
    }
}