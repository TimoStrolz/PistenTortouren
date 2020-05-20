using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class landingpage : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            //logout
            if (Request.QueryString["task"] != null && Request.QueryString["task"] == "logout")
            {
                logout();
            }

            //fillUpDatabase();
            int counter = 0;

            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
                foreach (Tour tour in context.Tours.SqlQuery("SELECT * FROM Tours").ToList<Tour>())
                {
                    string markerText = "<h5>@Title</h5><p>Beschreibung: @Text</p><p>Schwierigkeit: @Difficulty</p><p>Länge: @Length km</p><a href='detailpage.aspx?id=@Id'><button type='button'>Siehe Mehr</button></a>";
                    counter++;
                    this.JsInterfaceMapTypeManager.InnerHtml += generateDivMitIdUndValue(counter.ToString(), tour.finishLongitude.ToString());
                    counter++;
                    this.JsInterfaceMapTypeManager.InnerHtml += generateDivMitIdUndValue(counter.ToString(), tour.finishLatitude.ToString());
                    /*
                     Hier Code einfügen: Alle Daten für Popup mitnehmen in einem String -> ähnlich wie den Text bei Forumprojekt von dem Forumbeitrag beispiel.     
                     */
                    counter++;
                    markerText = markerText.Replace("@Id", tour.tourID.ToString());
                    markerText = markerText.Replace("@Title", tour.title);
                    markerText = markerText.Replace("@Text", tour.text);
                    markerText = markerText.Replace("@Difficulty", tour.difficulty);
                    markerText = markerText.Replace("@Length", tour.tourLength.ToString());
                    this.JsInterfaceMapTypeManager.InnerHtml += generateDivMitIdUndValue(counter.ToString(), markerText);
                }
            this.JsInterfaceMapTypeManager.InnerHtml += generateDivMitIdUndValue("counter", counter.ToString());

        }
        /// <summary>
        /// Gibt javascript Variabeln
        /// </summary>
        public static string generateDivMitIdUndValue(string id, string value)
        {
            return "<div id=\"" + id + "\" value=\"" + value + "\"></div>\n";
        }



        /// <summary>
        /// Funktion um Datensätze in Datenbank einzufügen
        /// </summary>
        public void fillUpDatabase()
        {
            User User1 = new User();
            {
                User1.userID = 1;
                User1.name = "Pizol";
                User1.website = "https://pizol.com/";
                User1.phone = "0813004820";
                User1.password = "OnlyTest";
                User1.email = "pizol@lol.ch";
                User1.lastPayment = DateTime.Now;
                User1.emailVerified = true;
                User1.billSent = DateTime.Now;
                User1.birthday = DateTime.Now;
                User1.language = "German";
                User1.country = "Switzerland";
                User1.city = "Bad Ragaz";
                User1.street = "Loisstrasse";
                User1.housenumber = 50;
                User1.zip = 7310;
                User1.subscriptionNumber = 1;
            };

            Tour Tour1 = new Tour();
            {
                Tour1.tourID = 1;
                Tour1.User_ID = 1;
                Tour1.title = "PistenTour 1";
                Tour1.text = "Es ist eine schöne Tour";
                Tour1.safetyInstruction = "Folge einfach den Richtlininien";
                Tour1.seasonStart = DateTime.Now;
                Tour1.seasonEnd = DateTime.Now;
                Tour1.tourLength = 30;
                Tour1.altitude = 2844;
                Tour1.lowestPoint = 2400;
                Tour1.highestPoint = 2800;
                Tour1.startingLatitude = 46.9581642;
                Tour1.startingLongitude = 9.359114;
                Tour1.finishLatitude = 46.9581642;
                Tour1.finishLongitude = 9.359114;
                Tour1.gettingThere = "You'll manage";
                Tour1.signalled = true;
                Tour1.changingRooms = false;
                Tour1.wc = true;
                Tour1.drinks = true;
                Tour1.food = true;
                Tour1.accommodation = false;
                Tour1.status = 1;
                Tour1.instructions = "Please don't die";
                Tour1.birthday = DateTime.Now;
                Tour1.numberOfFiles = 0;
                Tour1.difficulty = "easy";
            };

            Tour Tour2 = new Tour();
            {
                Tour2.tourID = 2;
                Tour2.User_ID = 1;
                Tour2.title = "PistenTour Zwei";
                Tour2.text = "Es ist eine nicht wirklich gute Tour";
                Tour2.safetyInstruction = "Darwin";
                Tour2.seasonStart = DateTime.Now;
                Tour2.seasonEnd = DateTime.Now;
                Tour2.tourLength = 70;
                Tour2.altitude = 2502;
                Tour2.lowestPoint = 2400;
                Tour2.highestPoint = 2800;
                Tour2.startingLatitude = 47.249444444444;
                Tour2.startingLongitude = 9.3433333333333;
                Tour2.finishLatitude = 47.249444444444;
                Tour2.finishLongitude = 9.3433333333333;
                Tour2.gettingThere = "Walk";
                Tour2.signalled = false;
                Tour2.changingRooms = true;
                Tour2.wc = true;
                Tour2.drinks = true;
                Tour2.food = true;
                Tour2.accommodation = true;
                Tour2.status = 1;
                Tour2.instructions = "Please die";
                Tour2.birthday = DateTime.Now;
                Tour2.numberOfFiles = 0;
                Tour2.difficulty = "medium";
            };

            Tour Tour3 = new Tour();
            {
                Tour3.tourID = 3;
                Tour3.User_ID = 1;
                Tour3.title = "PistenTour Drei";
                Tour3.text = "Die Tour deines Lebens";
                Tour3.safetyInstruction = "Für Kinder geeignet";
                Tour3.seasonStart = DateTime.Now;
                Tour3.seasonEnd = DateTime.Now;
                Tour3.tourLength = 100;
                Tour3.altitude = 1830;
                Tour3.lowestPoint = 2000;
                Tour3.highestPoint = 3000;
                Tour3.startingLatitude = 47.067222222222;
                Tour3.startingLongitude = 9.4338888888889;
                Tour3.finishLatitude = 47.067222222222;
                Tour3.finishLongitude = 9.4338888888889;
                Tour3.gettingThere = "Everything is signalled";
                Tour3.signalled = true;
                Tour3.changingRooms = false;
                Tour3.wc = false;
                Tour3.drinks = false;
                Tour3.food = true;
                Tour3.accommodation = true;
                Tour3.status = 1;
                Tour3.instructions = "Follow the path";
                Tour3.birthday = DateTime.Now;
                Tour3.numberOfFiles = 0;
                Tour3.difficulty = "hard";
            };

            Event Event1 = new Event();
            {
                Event1.eventID = 1;
                Event1.Tours_ID = 1;
                Event1.type = "Wettrennen";
                Event1.info = "be fast";
                Event1.start = DateTime.Now;
                Event1.finish = DateTime.Now;
                Event1.inscription = "Ja lol ey";
            };

            OpeningTime openingTime1 = new OpeningTime();
            {
                openingTime1.openingTimeID = 1;
                openingTime1.Tour_ID = 1;
                openingTime1.day = "Monday";
                openingTime1.start = DateTime.Now;
                openingTime1.end = DateTime.Now;
            };

            using (var context = new pistenTortourenDBContext())
            {
                context.Users.Add(User1);
                context.Tours.Add(Tour1);
                context.Tours.Add(Tour2);
                context.Tours.Add(Tour3);
                context.Events.Add(Event1);
                context.OpeningTimes.Add(openingTime1);
                context.SaveChanges();
            }

        }
        //logout
        public void logout()
        {
            Session.Clear();
            HttpCookie myCookie = new HttpCookie("User");
            myCookie.Value = "";
            Response.Cookies.Add(myCookie);
            Response.Redirect("landingpage.aspx");
        }

    }
}

