<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="createtour.aspx.cs" Inherits="PistenTortouren.createtour" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script>  document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.autocomplete');
            var instances = M.Autocomplete.init(elems, options);
        });</script>
    <div id="meldung"><%//=smeldung %></div>
    <form class="col s12" method="post" enctype="multipart/form-data" id="formCreateTourn" action="createTour.aspx">
    <div class="row">

         <div class="input-field col s6">
        <input type="text" id="title" name="titel">
        <label for="title">Titel:</label>
        </div>

        <div class="input-field col s12">
          <textarea id="text"  name="text" class="materialize-textarea"></textarea>
          <label for="text">Text:</label>
        </div>

        <div class="input-field col s12">
          <textarea id="safetyi"  name="safetyi" class="materialize-textarea"></textarea>
          <label for="safetyi">Sicherheitsanweisungen:</label>
        </div>

        <div class="input-field col s6">
        <input type="date" id="seasonStart" name="seasonStart">
        <label for="seasonStart">Season start: </label>
        </div>
        
         <div class="input-field col s6">
        <input type="date" id="seasonEnd" name="seasonEnd">
        <label for="seassonEnd">Season start: </label>
        </div>

        <div class="input-field col s6">
        <input type="number" id="length" name="length">
        <label for="length">Länge: </label>
        </div>

        <div class="input-field col s6">
        <input type="number" id="altitude" name="altitude">
        <label for="altitude">Höhenmeter: </label>
        </div>

         <div class="input-field col s6">
        <input type="number" id="lowestPoint" name="lowestPoint">
        <label for="lowestPoint">Tiefster Punkt:</label>
        </div>

        
         <div class="input-field col s6">
        <input type="number" id="highestPoint" name="highestPoint">
        <label for="highestPoint">höchster Punkt: </label>
        </div>

        <div class="input-field col s3">
        <input type="number" id="startlat" name="startlat">
         <label for="startlat">Start Latitude: </label>
        </div>

         <div class="input-field col s3">
        <input type="number" id="startlong" name="startlong">
         <label for="startlong">Start Longitude: </label>
        </div>

        <div class="input-field col s3">
        <input type="number" id="finishlat" name="finishlat">
        <label for="finishlat">Ende Latitude: </label>
        </div>

        <div class="input-field col s3">
        <input type="number" id="finishlong" name="finishlong">
        <label for="finishlong">Ende Longitude: </label>
        </div>

        <div class="input-field col s12">
          <textarea id="gettingThere"  name="gettingThere" class="materialize-textarea"></textarea>
          <label for="gettingThere">Anreise: </label>
        </div>


         <div class="input-field col s6">
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
        </div>

        <div class="input-field col s6">
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
        </div>


        <div class="input-field col s6">
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
        </div>


        <div class="input-field col s6">
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
        </div>


        <div class="input-field col s6">
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
        </div>

        <div class="input-field col s6">
        <a>Unterkunft</a>
            <div id="accommodation">
                <p>
                    <label>
                    <input  class="with-gap" name="accommodation" value="ja" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="accommodation" value="nein" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>
        </div>

        <div class="input-field col s6">
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
        </div>

         <div class="input-field col s12">
          <textarea id="instructions"  name="instructions" class="materialize-textarea"></textarea>
          <label for="instructions">Anweisungen: </label>
        </div>


        <div class="input-field col s6">
        <div class="file-field input-field">
            <div class="btn">
            <span>Bilder</span>
            <input id="pictures" name="pictures" type="file" multiple>
            </div>
            <div class="file-path-wrapper">
            <input class="file-path validate" type="text" placeholder="Wählen Sie ein Bild, oder mehrere, von Ihrem Rechner aus.">
            </div>
        </div>
        </div>


        <div class="input-field col s6">
        <div class="file-field input-field">
            <div class="btn">
            <span>Videos</span>
            <input id="videos" name="videos" type="file" multiple>
            </div>
            <div class="file-path-wrapper">
            <input class="file-path validate" type="text" placeholder="Wählen Sie ein Video, oder mehrere, von Ihrem Rechner aus.">
            </div>
        </div>
        </div>
        
        <div class="input-field col s6">
        <div class="file-field input-field">
            <div class="btn">
            <span>Höhenprofil: </span>
            <input id="heightProfile" name="heightProfile" type="file">
            </div>
            <div class="file-path-wrapper">
            <input class="file-path validate" type="text" placeholder="Höhenprofil: ">
            </div>
        </div>
        </div>

        <div class="input-field col s6">
        <div class="file-field input-field">
            <div class="btn">
            <span>Tour Kurs: </span>
            <input id="tourCourse" name="tourCourse" type="file">
            </div>
            <div class="file-path-wrapper">
            <input class="file-path validate" type="text" placeholder="Tour Kurs: ">
            </div>
        </div>
        </div>

         <div class="input-field col s6">
        <button type="submit" class="btn" name="action" >erstellen</button>
        </div>
     </div>
   </form>
    
</asp:Content>