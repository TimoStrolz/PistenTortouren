<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="createtour.aspx.cs" Inherits="PistenTortouren.createtour" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
   <div>
    <form method="post" enctype="multipart/form-data">

        <label for="vname">Titel:
        <input type="text" id="title" name="titel">
        </label>

        <label for="zname">Text: 
        <input type ="text" id="text" name="text">
        </label>

        <label for="zname">Sicherheitsanweisungen: 
        <input type="text" id="safetyi" name="safetyi">
        </label>
        <br />
        <label>Wählen Sie ein Bild von Ihrem Rechner aus.
        <input name="datei" type="file" accept="text/*"> 
        </label>
        <br />
        <br />
        <label>Wählen Sie ein Video von Ihrem Rechner aus.
        <input name="datei" type="file" accept="text/*"> 
        </label>
        <br />
        <br />
        <label for="tourCourse">Tour Kurs: 
        <input type="text" id="tourCourse" name="tourCourse">
        </label>

        <label for="seasonStart">Season start: 
        <input type="date" id="seasonStart" name="seasonStart">
        </label>

        <label for="seassonEnd">Season start: 
        <input type="date" id="seasonEnd" name="seasonEnd">
        </label>

        <label for="openingTimes">Öffnungszet:
        <input type="time" id="openingTimes" name="openinngTimes">
        </label>

        <label for="length">Länge: 
        <input type="number" id="length" name="length">
        </label>

        <label for="altitude">Höhenlage: 
        <input type="number" id="altitude" name="altitude">
        </label>

        <label for="lowestPoint">Tiefster Punkt: 
        <input type="number" id="lowestPoint" name="lowestPoint">
        </label>

        <label for="highestPoint">höchster Punkt: 
        <input type="number" id="highestPoint" name="highestPoint">
        </label>

        <label for="heightProfile">Höhenprofil: 
        <input type="number" id="heightProfile" name="heightProfile">
        </label>

        <label for="start">Start: 
        <input type="text" id="start" name="start">
        </label>

        <label for="finish">Ende: 
        <input id="finish" name="finish">
        </label>

        <label for="gettingThere">Anreise: 
        <input id="gettingThere" name="gettingThere">
        </label>


        <a>Ist die Strecke signalisiert</a>
            <div id="signalled">
                <p>
                    <label>
                    <input  class="with-gap" name="signalled" value="ja" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="signalled" value="nein" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>

        <a>Hat es Umkleidekabinen</a>
            <div id="changingRooms">
                <p>
                    <label>
                    <input  class="with-gap" name="changingRooms" value="ja" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="changingRooms" value="nein" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>


        <a>Hat es Wc's</a>
            <div id="wc">
                <p>
                    <label>
                    <input  class="with-gap" name="wc" value="ja" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="wc" value="nein" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>


        <a>Trinkmöglichkeit?</a>
            <div id="drink">
                <p>
                    <label>
                    <input  class="with-gap" name="drink" value="ja" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="drink" value="nein" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>


        <a>Verpflegungsmöglichkeit?</a>
            <div id="food">
                <p>
                    <label>
                    <input  class="with-gap" name="food" value="ja" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="food" value="nein" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>

        <a>Unterkunft</a>
            <div id="accommandation">
                <p>
                    <label>
                    <input  class="with-gap" name="accommandation" value="ja" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="accommandation" value="nein" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>

        <a>Offen</a>
            <div id="open">
                <p>
                    <label>
                    <input  class="with-gap" name="open" value="ja" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="open" value="nein" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>


        <label for="zname">Anweisungen: 
        <input type="text" id="instructions" name="instructions">
        </label>

        <button type="submit" name="action" value="create">erstellen</button>
        <br />
        <br />

   </form>
  </div>
    
</asp:Content>
