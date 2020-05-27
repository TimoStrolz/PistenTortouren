<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="openingTimes.aspx.cs" Inherits="PistenTortouren.openingTimes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Öffnungszeiten bearbeiten</h1>
<table  class="table">
  <thead class="thead-light">
   <tr>
     <th>ID</th>
       <th>Tag</th>
     <th>Von</th>
     <th>Bis</th>
     <th> </th>
     <th> </th>
   </tr>
  </thead>
   <%=Item %>
</table>
    <%=btn %>
</asp:Content>
