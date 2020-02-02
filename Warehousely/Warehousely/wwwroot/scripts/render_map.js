function initMap() {
    var usaCoords = { lat: 37.0902, lng: -95.7129 };
    var bounds = new google.maps.LatLngBounds();
    var googleMap = new google.maps.Map(
        document.getElementById('map'), { zoom: 6, center: usaCoords });

    var mapItems = modelData;

    for (var i in mapItems) {
        console.log(mapItems[i].MapsContent);
        var markerPosition = { lat: mapItems[i].lat, lng: mapItems[i].lng };
        var infowindow = new google.maps.InfoWindow({
            content: mapItems[i].mapsContent
        });

        var marker = new google.maps.Marker({
            position: markerPosition,
            map: googleMap,
            infowindow: infowindow

        });

        google.maps.event.addListener(marker, 'click', (function (marker, infowindow) {
            return function () {
                infowindow.open(googleMap, marker);
            };
        })(marker, infowindow));

        bounds.extend(markerPosition);
        googleMap.fitBounds(bounds);
        googleMap.panToBounds(bounds);

        bounds.extend(markerPosition);
    };

}

  


