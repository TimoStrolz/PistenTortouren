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
        public float Longitude = 0;
        public float Latitude = 0;
        public List<float[]> map_data = new List<float[]>();
        public List<string> MarkerLatitude = new List<string>();
        public void Page_Load(object sender, EventArgs e)
        {


            using (pistenTortourenDBContext context = new pistenTortourenDBContext())
                foreach (Tour tour in context.Tours.SqlQuery("SELECT * FROM Tours").ToList<Tour>())
                {
                    
                    Longitude = tour.finishLongitude;
                    Latitude = tour.finishLatitude;
                    float[] dataMarker = new float[2] { Latitude, Longitude };
                    map_data.Add(dataMarker);
                    MarkerLatitude.Add(Latitude.ToString()); // TEST TEST
                    Response.Write(Latitude + " ");
                    Response.Write(Longitude);
                }
            foreach (var item in map_data)
            {
                foreach (var schlong in item)
                {
                    Response.Write(schlong);
                }
            }
            // TEST TEST
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("var testArray = new Array;");
            foreach (string str in MarkerLatitude)
            {
                Response.Write("lol " + str);
                sb.Append("testArray.push('" + str + "');");
            }
            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());

            //fillUpDatabase();


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
                User1.subscriptionnumber = 1;
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
                Tour1.startingLatitude = 748265;
                Tour1.startingLongitude = 202740;
                Tour1.finishLatitude = 748265;
                Tour1.finishLongitude = 202740;
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
                context.Events.Add(Event1);
                context.OpeningTimes.Add(openingTime1);
                context.SaveChanges();
            }

        }
    }
}