﻿var map = L.map('map', { zoomControl: false }).setView([53.134699, 23.157905], 13);
L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
    attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://mapbox.com">Mapbox</a>',
    maxZoom: 18,
    id: 'adamgolubowski.og5h8gk5',
    accessToken: 'pk.eyJ1IjoiYWRhbWdvbHVib3dza2kiLCJhIjoiY2lpZ2ljNXNjMDAzYndvbTBvY3M2cmEzbiJ9.muPbMbiGcgo2W7H9I-TEpQ'
}).addTo(map);

//var locations = ["Białystok - Centrum", 53.1346, 23.1579]
//marker = new L.marker([locations[1], locations[2]])
//    .addTo(map)
//    .bindPopup(locations[0]);


function addMarker(name, lon, lat) {

    marker = new L.marker([lon, lat])
        .addTo(map)
        .bindPopup(name);
}

//addMarker("Białystok - Centrum", 53.1346, 23.1579);


//@for(int i=0;i<model.)
//{
//    addMarker('@item.Name',@item.LocLongitude,@item.LocLattitude);
//}

//@foreach (var item in Model)
//{
//    @: addMarker('@item.Name',@(item.LocLattitude.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture)),@(item.LocLongitude.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture)));
//}

