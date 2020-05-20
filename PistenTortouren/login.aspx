<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PistenTortouren.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script>  document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.autocomplete');
            var instances = M.Autocomplete.init(elems, options);
        });</script>
    <div id="meldung"><%=smeldung %></div>
    <form class="col s12"  method="post" id="formRegistration" action="login.aspx">
        <div class="row">
        <div class="input-field col s6">
          <i class="material-icons prefix">email</i>
          <input id="email" name="email" type="email" class="validate" required>
          <label for="email">Email</label>
        </div>

         <div class="input-field col s6">
          <i class="material-icons prefix">https</i>
          <input id="password" name="password" type="password" class="validate" required>
          <label for="password">Passwort</label>
        </div>


        <div class="input-field col s6">
            <input class="btn" type="submit" value="Login" >
        </div>
      </div>
    </form>
</asp:Content>
