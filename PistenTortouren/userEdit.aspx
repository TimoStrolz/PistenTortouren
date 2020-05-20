<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="userEdit.aspx.cs" Inherits="PistenTortouren.userEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script>  document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.autocomplete');
            var instances = M.Autocomplete.init(elems, options);
        });</script>
    <div id="meldung"><%=smeldung %></div>
    <div id="anzeigen" ><%=loadForm() %></div>

</asp:Content>
