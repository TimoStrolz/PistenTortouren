<%@ Page Title="registration" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="PistenTortouren.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>registration</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script>  document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.autocomplete');
            var instances = M.Autocomplete.init(elems, options);
        });</script>
    <div id="meldung"><%=smeldung %></div>
    <form class="col s12"  method="post" id="formRegistration" action="registration.aspx">
      <div class="row">
        <div class="input-field col s6">
          <i class="material-icons prefix">account_circle</i>
          <input id="name" name="name"type="text" class="validate" required>
          <label for="name">Name</label>
        </div>
    
        <div class="input-field col s6">
          <i class="material-icons prefix">dvr</i>
          <input id="website" name="website" type="text" class="validate" required>
          <label for="website">Webseite</label>
        </div>

        <div class="input-field col s6">
          <i class="material-icons prefix">phone</i>
          <input id="phone" name="phone" type="tel" class="validate" required>
          <label for="phone">Telefon</label>
        </div>

         <div class="input-field col s6">
          <i class="material-icons prefix">https</i>
          <input id="password" name="password" type="password" class="validate" required>
          <label for="password">Passwort</label>
        </div>

         <div class="input-field col s6">
          <i class="material-icons prefix">email</i>
          <input id="email" name="email" type="email" class="validate" required>
          <label for="email">Email</label>
        </div>

         <div class="input-field col s6">
          <a>Sprache Wählen</a>
            <div id="language">
                <p>
                    <label>
                    <input  class="with-gap" name="language" value="german" type="radio" required/>
                    <span>Deutsch</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="language" value="english" type="radio" required />
                    <span>English</span>
                    </label>
            </div>
        </div>
        </div>

          <div class="input-field col s6">
          <a>Land Wählen</a>
            <div id="country">
                <p>
                    <label>
                    <input  class="with-gap" name="country" value="CH" type="radio" required/>
                    <span>Schweiz</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="country" value="DE" type="radio" required />
                    <span>Deutschland</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input  class="with-gap" name="country" value="AU" type="radio" required/>
                    <span>Österreich</span>
                    </label>
                </p>
            </div>
        </div>

        <div class="input-field col s6">
          <i class="material-icons prefix">location_city</i>
          <input id="city" name="city" type="text" class="validate" required>
          <label for="city">Stadt</label>
        </div>

          <div class="input-field col s6">
          <i class="material-icons prefix">location_city</i>
          <input id="street" name="street" type="text" class="validate" required>
          <label for="street">Strasse</label>
        </div>

          <div class="input-field col s6">
          <i class="material-icons prefix">location_city</i>
          <input id="zip" name="zip" type="number" class="validate" required>
          <label for="zip">PLZ</label>
        </div>

          <div class="input-field col s6">
          <i class="material-icons prefix">home</i>
          <input id="housenumber" name="housenumber" type="number" class="validate" required>
          <label for="housenumber">Hausnummer</label>
        </div>
        <div class="input-field col s6">
            <a>Produkt Wählen</a>
            <div id="subscriptionnumber">
                <p>
                    <label>
                    <input  class="with-gap" name="subscriptionnumber" value="1" type="radio" required/>
                    <span>A</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input class="with-gap" name="subscriptionnumber" value="2" type="radio" required />
                    <span>B</span>
                    </label>
                </p>
                <p>
                    <label>
                    <input  class="with-gap" name="subscriptionnumber" value="3" type="radio" required/>
                    <span>C</span>
                    </label>
                </p>
            </div>
            
        <div class="input-field col s6">
            <input class="btn" type="submit" value="Registrieren" >
        </div>
      </div>
    </form>
</asp:Content>
