<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="createtour.aspx.cs" Inherits="PistenTortouren.createtour" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script>  document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.autocomplete');
            var instances = M.Autocomplete.init(elems, options);
        });</script>
    <div id="meldung"><%=smeldung %></div>
    <form class="col s12" method="post" enctype="multipart/form-data" id="formCreateTourn" action="createTour.aspx">
    <div class="row">

         <div class="input-field col s6">
        <input type="text" id="title" name="title" required>
        <label for="title">Titel:</label>
        </div>

        <div class="input-field col s12">
          <textarea id="text"  name="text" class="materialize-textarea" required></textarea>
          <label for="text">Text:</label>
        </div>

        <div class="input-field col s12">
          <textarea id="safetyi"  name="safetyi" class="materialize-textarea" required></textarea>
          <label for="safetyi">Sicherheitsanweisungen:</label>
        </div>

        <div class="input-field col s6">
        <input type="text" id="difficulty" name="difficulty" required>
        <label for="difficulty">Schwierigkeit:</label>
        </div>

        <div class="input-field col s6">
        <input type="date" id="seasonStart" name="seasonStart" required>
        <label for="seasonStart">Season start: </label>
        </div>
        
         <div class="input-field col s6">
        <input type="date" id="seasonEnd" name="seasonEnd" required>
        <label for="seassonEnd">Season start: </label>
        </div>

        <div class="input-field col s6">
        <input type="number" id="length" name="length" required>
        <label for="length">Länge: </label>
        </div>

        <div class="input-field col s6">
        <input type="number" id="altitude" name="altitude" required>
        <label for="altitude">Höhenmeter: </label>
        </div>

         <div class="input-field col s6">
        <input type="number" id="lowestPoint" name="lowestPoint" required>
        <label for="lowestPoint">Tiefster Punkt:</label>
        </div>

        
         <div class="input-field col s6">
        <input type="number" id="highestPoint" name="highestPoint" required>
        <label for="highestPoint">höchster Punkt: </label>
        </div>

        <div class="input-field col s3">
        <input type="number" id="startlat" name="startlat" required>
         <label for="startlat">Start Latitude: </label>
        </div>

         <div class="input-field col s3">
        <input type="number" id="startlong" name="startlong" required>
         <label for="startlong">Start Longitude: </label>
        </div>

        <div class="input-field col s3">
        <input type="number" id="finishlat" name="finishlat" required>
        <label for="finishlat">Ende Latitude: </label>
        </div>

        <div class="input-field col s3">
        <input type="number" id="finishlong" name="finishlong" required>
        <label for="finishlong">Ende Longitude: </label>
        </div>

        <div class="input-field col s12">
          <textarea id="gettingThere"  name="gettingThere" class="materialize-textarea" required></textarea>
          <label for="gettingThere">Anreise: </label>
        </div>


         <div class="input-field col s6">
        <a>Ist die Strecke signalisiert</a>
            <div id="signalled">
                <p>
                    <label>
                    <input  class="with-gap" name="signalled" value="true" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="signalled" value="false" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>
        </div>

        <div class="input-field col s6">
        <a>Hat es Umkleidekabinen</a>
            <div id="changingRooms">
                <p>
                    <label>
                    <input  class="with-gap" name="changingRooms" value="true" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="changingRooms" value="false" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>
        </div>


        <div class="input-field col s6">
        <a>Hat es Wc's</a>
            <div id="wc">
                <p>
                    <label>
                    <input  class="with-gap" name="wc" value="true" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="wc" value="false" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>
        </div>


        <div class="input-field col s6">
        <a>Trinkmöglichkeit?</a>
            <div id="drink">
                <p>
                    <label>
                    <input  class="with-gap" name="drink" value="true" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="drink" value="false" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>
        </div>


        <div class="input-field col s6">
        <a>Verpflegungsmöglichkeit?</a>
            <div id="food">
                <p>
                    <label>
                    <input  class="with-gap" name="food" value="true" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="food" value="false" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>
        </div>

        <div class="input-field col s6">
        <a>Unterkunft</a>
            <div id="accommodation">
                <p>
                    <label>
                    <input  class="with-gap" name="accommodation" value="true" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="accommodation" value="false" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>
        </div>

        <div class="input-field col s6">
        <a>Offen</a>
            <div id="status">
                <p>
                    <label>
                    <input  class="with-gap" name="status" value="1" type="radio" required/>
                    <span>Ja</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="status" value="0" type="radio" required />
                    <span>Nein</span>
                    </label>
            </div>
        </div>

         <div class="input-field col s12">
          <textarea id="instructions"  name="instructions" class="materialize-textarea" required></textarea>
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