// JavaScript source code
var longitude = '<%= Longitude %>';
var latitude = '<%= Latitude %>';
alert(latitude);
alert(longitude);
var mymap = L.map('mapid').setView([46.8095954, 7.103216], 8);
var marker = L.marker([51.5, -0.09]).addTo(mymap);
var marker = L.marker([latitude, longitude]).addTo(mymap);


L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
    maxZoom: 18,
    id: 'mapbox/streets-v11',
    tileSize: 512,
    zoomOffset: -1,
    accessToken: 'pk.eyJ1IjoiYmFuZGl0b2pvIiwiYSI6ImNrOGhhcG03ejAzMXUzZm1rN2Qxa3YyYzUifQ.L0h1FE5Awq5QuwlEUS5dfA'
}).addTo(mymap);

function onMapClick(e) {
    alert("You clicked the map at " + e.latlng);
}