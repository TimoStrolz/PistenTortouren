<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="PistenTortouren.adminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <h1>Admin Bereich</h1>
<table  class="table">
  <thead class="thead-light">
   <tr>
     <th>EMail</th>
     <th>Rechnung Versendet:</th>
     <th>Zuletzt bezahlt</th>
     <th> </th>
     <th> </th>
   </tr>
  </thead>
   <%=Item %>
</table>
</asp:Content>
