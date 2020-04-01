<%@ Page Title="registration" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="PistenTortouren.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>registration</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script>  document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.autocomplete');
            var instances = M.Autocomplete.init(elems, options);
        });</script>
    <div class="row">
    <div class="col s12">
      <div class="row">
        <div class="input-field col s12">
          <i class="material-icons prefix">textsms</i>
          <input type="text" id="autocomplete-input" class="autocomplete">
          <label for="autocomplete-input">Autocomplete</label>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
