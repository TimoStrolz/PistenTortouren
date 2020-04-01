<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="landingpage.aspx.cs" Inherits="PistenTortouren.landingpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.6.0/dist/leaflet.css"
  integrity="sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ=="
  crossorigin=""/>

    <script src="https://unpkg.com/leaflet@1.6.0/dist/leaflet.js"
  integrity="sha512-gZwIG9x3wUXg2hdXF6+rVkLF/0Vi9U8D2Ntg4Ga5I5BZpVkVxlJWbSQtXPSiUTtC0TjtGOmxa1AJPuV0CPthew=="
  crossorigin=""></script>

 <!--   <script src="script.js"></script> -->
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <style>
#mapid { height: 750px; }
</style>

    <div id="mapid"></div>

    <h1>test</h1>

    <script> 
        var mymap = L.map('mapid').setView([51.505, -0.09], 13);
        var marker = L.marker([51.5, -0.09]).addTo(mymap);

        L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox/streets-v11',
            tileSize: 512,
            zoomOffset: -1,
            accessToken: 'pk.eyJ1IjoiYmFuZGl0b2pvIiwiYSI6ImNrOGhhcG03ejAzMXUzZm1rN2Qxa3YyYzUifQ.L0h1FE5Awq5QuwlEUS5dfA'
        }).addTo(mymap);
    </script>

</asp:Content>
