using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PistenTortouren
{
    public partial class userEdit : System.Web.UI.Page
    {
        public string smeldung;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("landingpage.aspx");
            }
            loadForm();
            smeldung = editUser();
            if(smeldung == "")
            {
                Session.Add("User", Request.Form["email"]);
                HttpCookie myCookie = new HttpCookie("User");
                myCookie.Value = StringCipher.Encrypt(Request.Form["email"], "adminPW");
                myCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(myCookie);
                Response.Redirect("landingpage.aspx");
            }
        }

        public string loadForm()
        {
            
            string template = @"<form class='col s12'  method='post' id='formEdit' action='userEdit.aspx'>
      <div class='row'>
        <div class='input-field col s6'>
          <i class='material-icons prefix'>account_circle</i>
          <input id='name' name='name'type='text' class='validate' value='@name' required>
          <label for='name'>Name</label>
        </div>
    
        <div class='input-field col s6'>
          <i class='material-icons prefix'>dvr</i>
          <input id='website' name='website' type='text' class='validate' value='@website' required>
          <label for='website'>Webseite</label>
        </div>

        <div class='input-field col s6'>
          <i class='material-icons prefix'>phone</i>
          <input id='phone' name='phone' type='tel' class='validate' value='@phone' required>
          <label for='phone'>Telefon</label>
        </div>

         <div class='input-field col s6'>
          <i class='material-icons prefix'>https</i>
          <input id='password' name='password' type='password' class='validate'>
          <label for='password'>Passwort</label>
        </div>

         <div class='input-field col s6'>
          <i class='material-icons prefix'>email</i>
          <input id='email' name='email' type='email' class='validate' value='@email' required>
          <label for='email'>Email</label>
        </div>

         <div class='input-field col s6'>
          <a>Sprache Wählen</a>
            <div id='language'>
                <p>
                    <label>
                    <input  class='with-gap' name='language' @german value='german' type='radio' required/>
                    <span>Deutsch</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class='with-gap' name='language' @english value='english' type='radio' required />
                    <span>English</span>
                    </label>
            </div>
        </div>
        </div>

          <div class='input-field col s6'>
          <a>Land Wählen</a>
            <div id='country'>
                <p>
                    <label>
                    <input  class='with-gap' name='country' value='CH' type='radio' @CH required/>
                    <span>Schweiz</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class='with-gap' name='country' value='DE' type='radio' @DE required />
                    <span>Deutschland</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input  class='with-gap' name='country' value='AU' type='radio' @AU required/>
                    <span>Österreich</span>
                    </label>
                </p>
            </div>
        </div>

        <div class='input-field col s6'>
          <i class='material-icons prefix'>location_city</i>
          <input id='city' name='city' type='text' class='validate' value='@city' required>
          <label for='city'>Stadt</label>
        </div>

          <div class='input-field col s6'>
          <i class='material-icons prefix'>location_city</i>
          <input id='street' name='street' type='text' class='validate' value='@street' required>
          <label for='street'>Strasse</label>
        </div>

          <div class='input-field col s6'>
          <i class='material-icons prefix'>location_city</i>
          <input id='zip' name='zip' type='number' class='validate' value='@zip' required>
          <label for='zip'>PLZ</label>
        </div>

          <div class='input-field col s6'>
          <i class='material-icons prefix'>home</i>
          <input id='housenumber' name='housenumber' type='number' class='validate' value='@housenumber' required>
          <label for='housenumber'>Hausnummer</label>
        </div>
        <div class='input-field col s6'>
            <a>Produkt Wählen</a>
            <div id='subscriptionnumber'>
                <p>
                    <label>
                    <input  class='with-gap' name='subscriptionnumber' value='1' type='radio' @1 required/>
                    <span>A</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class='with-gap' name='subscriptionnumber' value='2' type='radio' @2 required />
                    <span>B</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input  class='with-gap' name='subscriptionnumber' value='3' type='radio' @3 required/>
                    <span>C</span>
                    </label>
                </p>
            </div>
            
        </div>
        <div class='input-field col s6'>
            <input class='btn' type='submit' value='Registrieren' >
        </div>
      </div>
    </form>
        ";
            using (var context = new pistenTortourenDBContext())
            {
                string email = Session["User"].ToString();
                foreach (User user in context.Users.SqlQuery("SELECT * FROM Users").ToList<User>())
                {
                    if (user.email == Session["User"].ToString())
                    {
                        template = template.Replace("@name", user.name);
                        template = template.Replace("@website", user.website);
                        template = template.Replace("@phone", user.phone);
                        template = template.Replace("@website", user.website);
                        template = template.Replace("@email", user.email);
                        template = template.Replace("@city", user.city);
                        template = template.Replace("@zip", user.zip.ToString());
                        template = template.Replace("@street", user.street);
                        template = template.Replace("@housenumber", user.housenumber.ToString());

                        //radios
                        //language
                        if (user.language == "english")
                        {
                            template = template.Replace("@english", "checked");
                            template = template.Replace("@german", "");
                        }
                        else
                        {
                            template = template.Replace("@german", "checked");
                            template = template.Replace("@english", "");
                        }
                        //country
                        switch (user.country)
                        {
                            case "CH":
                                template = template.Replace("@CH", "checked");
                                template = template.Replace("@DE", "");
                                template = template.Replace("@AU", "");
                                break;
                            case "DE":
                                template = template.Replace("@CH", "");
                                template = template.Replace("@DE", "checked");
                                template = template.Replace("@AU", "");
                                break;
                            case "AU":
                                template = template.Replace("@CH", "");
                                template = template.Replace("@DE", "");
                                template = template.Replace("@AU", "checked");
                                break;
                        }
                        //subnr
                        switch (user.subscriptionNumber)
                        {
                            case 1:
                                template = template.Replace("@1", "checked");
                                template = template.Replace("@2", "");
                                template = template.Replace("@3", "");
                                break;
                            case 2:
                                template = template.Replace("@1", "");
                                template = template.Replace("@2", "checked");
                                template = template.Replace("@3", "");
                                break;
                            case 3:
                                template = template.Replace("@1", "");
                                template = template.Replace("@2", "");
                                template = template.Replace("@3", "checked");
                                break;
                        }

                    }
                }
            }
            return template;
        }
        public string editUser()
        {
            if (Request.Form["name"] != null && Request.Form["website"] != null && Request.Form["phone"] != null && Request.Form["email"] != null && Request.Form["language"] != null && Request.Form["country"] != null && Request.Form["city"] != null && Request.Form["zip"] != null && Request.Form["street"] != null && Request.Form["housenumber"] != null && Request.Form["subscriptionnumber"] != null)
            {
                if (!GlobalRef.phoneValid(Request.Form["phone"], Request.Form["country"]))
                {
                    return "Falsche Telefonnummer Achten sie auf das ausgewählte Land und geben sie die nummer mit der Korrekten vorwahl an.";
                }

                if (!GlobalRef.emailValid(Request.Form["email"]))
                {
                    return "Falsche Email (Falsches Format)";
                }
                bool success = Int32.TryParse(Request.Form["zip"], out int izip);
                if (!success)
                {
                    return "PLZ muss eine Zahl sein";
                }
                success = Int32.TryParse(Request.Form["housenumber"], out int ihousenumber);
                if (!success)
                {
                    return "Hausnummer muss eine Zahl sein";
                }
                
                string pw = GlobalRef.getHashSha256(Request.Form["password"]);
                int subnr = Convert.ToInt32(Request.Form["subscriptionnumber"]);
                int counter = 0;
                using (var context = new pistenTortourenDBContext())
                {
                    
                    foreach (User user in context.Users.SqlQuery("SELECT * FROM Users").ToList<User>())
                    {
                        if (user.email == Request.Form["email"] && Request.Form["email"] != Session["User"].ToString())
                        {
                            //email schon vorhanden
                            counter++;
                        }
                    }
                }
                if (counter > 0)
                {
                    return "Neue Email wird schon verwendet";
                }
                using (var context = new pistenTortourenDBContext())
                {

                    foreach (User user in context.Users.SqlQuery("SELECT * FROM Users").ToList<User>())
                    {
                        if (user.email == Session["User"].ToString())
                        {
                            user.name = Request.Form["name"];
                            user.website = Request.Form["website"];
                            user.phone = Request.Form["phone"];
                            if (Request.Form["password"] != null || Request.Form["password"] != "")
                            {
                                user.password = pw;
                            }
                            user.email = Request.Form["email"];
                            user.lastPayment = new DateTime(2000, 1, 1);
                            user.emailVerified = false;
                            user.billSent = new DateTime(2000, 1, 1);
                            user.birthday = DateTime.Now;
                            user.language = Request.Form["language"];
                            user.country = Request.Form["country"];
                            user.city = Request.Form["city"];
                            user.street = Request.Form["street"];
                            user.zip = izip;
                            user.housenumber = ihousenumber;
                            user.subscriptionNumber = subnr;
                        }
                    }
                    context.SaveChanges();
                    return "";
                }
            }
            return "Nicht alle felder ausgefüllt";
        }
    }
}