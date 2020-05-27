using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class detailpage : System.Web.UI.Page
    {
        public string TourInfo = "<h1>@Titel</h1><h5>Beschreibung: @Text</h5><h5>Schwierigkeit: @difficulty</h5><h5>Sicherheitshinweise: @safetyInstruction</h5><h5>Saison Start: @seasonStart</h5><h5>Saison Ende: @seasonEnd</h5><h5>Länge: @tourLength km</h5><h5>Höhenmeter: @altitude m</h5><h5>Tiefster Punkt: @lowestPoint m</h5><h5>Höchster Punkt: @highestPoint m</h5><h5>Anfahrt: @gettingThere</h5><h5>Strecke signalisiert: @signalled</h5><h5>Umkleidekabinen: @changingRooms</h5><h5>WC: @WC</h5><h5>Getränke: @drinks</h5><h5>Essen: @food</h5><h5>Unterkunf: @accommodation</h5><h5>Anweisungen: @instruction</h5> @editTour";
        public string TourOeffnungszeiten = "<h5>Öffnungszeiten während der Saison: @alleÖffnungszeiten</h5> @editOpeningtimes";
        public string Öffnungszeiten = "";
        public int tourID;
        public int tourUserID;
        public int userID;
        protected void Page_Load(object sender, EventArgs e)
        {

            
            bool userIsOwner = false;

            if (Session["user"] != null)
            {
                userID = GlobalRef.getIDFromEmail(Session["user"].ToString());
            }

            // Falls keine ID mitgegeben wurde
            if (RequestString("Id") == string.Empty)
            {
                Response.Redirect("landingpage.aspx");
            }
            else
            {
                bool success = Int32.TryParse(RequestString("Id"), out tourID);
                if (success)
                {
                    tourID = Convert.ToInt32(RequestString("Id"));
                }
                else // falls die ID kein Integer ist
                {
                    Response.Redirect("landingpage.aspx");
                }
            }

            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
                foreach (Tour tour in context.Tours.SqlQuery("SELECT * FROM Tours WHERE tourID=" + tourID.ToString()).ToList<Tour>())
                {
                    
                    if (userID == tour.User_ID)
                    {
                        TourInfo = TourInfo.Replace("@editTour","<a href='editTour.aspx?id=@Id'><button type='button'>Edit Tour</button></a>");
                        userIsOwner = true;
                    }
                    tourUserID = tour.User_ID;
                    TourInfo = TourInfo.Replace("@Id", tour.tourID.ToString());
                    TourInfo = TourInfo.Replace("@editTour", "");
                    TourInfo = TourInfo.Replace("@Titel", tour.title);
                    TourInfo = TourInfo.Replace("@Text", tour.text);
                    TourInfo = TourInfo.Replace("@difficulty", tour.difficulty);
                    TourInfo = TourInfo.Replace("@safetyInstruction", tour.safetyInstruction);
                    TourInfo = TourInfo.Replace("@seasonStart", tour.seasonStart.ToString("dd MMMM"));
                    TourInfo = TourInfo.Replace("@seasonEnd", tour.seasonEnd.ToString("dd MMMM"));
                    TourInfo = TourInfo.Replace("@tourLength", tour.tourLength.ToString());
                    TourInfo = TourInfo.Replace("@altitude", tour.altitude.ToString());
                    TourInfo = TourInfo.Replace("@lowestPoint", tour.lowestPoint.ToString());
                    TourInfo = TourInfo.Replace("@highestPoint", tour.highestPoint.ToString());
                    TourInfo = TourInfo.Replace("@gettingThere", tour.gettingThere.ToString());
                    TourInfo = TourInfo.Replace("@signalled", changeBoolToText(tour.signalled));
                    TourInfo = TourInfo.Replace("@changingRooms", changeBoolToText(tour.changingRooms));
                    TourInfo = TourInfo.Replace("@drinks", changeBoolToText(tour.drinks));
                    TourInfo = TourInfo.Replace("@food", changeBoolToText(tour.food));
                    TourInfo = TourInfo.Replace("@WC", changeBoolToText(tour.wc));
                    TourInfo = TourInfo.Replace("@accommodation", changeBoolToText(tour.accommodation));
                    TourInfo = TourInfo.Replace("@instruction", tour.instructions);
                }
            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
                foreach (OpeningTime openingTime in context.OpeningTimes.SqlQuery("SELECT * FROM OpeningTimes WHERE Tour_ID=" + tourID.ToString()).ToList<OpeningTime>())
                {
                    string öffnungtemplate = "<h5>@tag: @öffnungAnfang - @öffnungEnde</h5> ";
                    öffnungtemplate = öffnungtemplate.Replace("@tag", openingTime.day);
                    öffnungtemplate = öffnungtemplate.Replace("@öffnungAnfang", openingTime.start.ToString("HH:mm"));
                    öffnungtemplate = öffnungtemplate.Replace("@öffnungEnde", openingTime.end.ToString("HH:mm"));


                    Öffnungszeiten = Öffnungszeiten + öffnungtemplate;
                }
            if (userID == tourUserID)
            {
                TourOeffnungszeiten = TourOeffnungszeiten.Replace("@editOpeningtimes", "<a href='openingtimes.aspx?id=@Id'><button type='button'>Edit Öffnungszeiten</button></a>");
                TourOeffnungszeiten = TourOeffnungszeiten.Replace("@Id", tourID.ToString());
            }
            TourOeffnungszeiten = TourOeffnungszeiten.Replace("@editOpeningtimes", "");
            TourOeffnungszeiten = TourOeffnungszeiten.Replace("@alleÖffnungszeiten", Öffnungszeiten);
        }


        /// <summary>
        /// Geht mit Post und Get Variabel um und wandelt dies in einen String
        /// </summary>
        public string RequestString(string name)
        {
            if (Request.Form[name] != null)
            {
                return Request.Form[name];
            }
            else if (Request.QueryString[name] != null)
            {
                return Request.QueryString[name];
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Ändert True zu "Ja" und False zu "Nein"
        /// </summary>
        public string changeBoolToText(bool wahroderfalsch)
        {
            if (wahroderfalsch)
            {
                return "Ja";
            }
            else
            {
                return "Nein";
            }
        }
    }
}

