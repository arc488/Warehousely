function initMap() {
    var hidePoi = [
        {
            "featureType": "poi",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "transit",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        }
    ];

    var usaCoords = { lat: 37.0902, lng: -95.7129 };
    var bounds = new google.maps.LatLngBounds();
    var googleMap = new google.maps.Map(
        document.getElementById('map'), {
            zoom: 6,
            center: usaCoords,
            styles: hidePoi,
            streetViewControl: false,
            mapTypeControl: false
    });

    var mapItems = modelData;
    var infowindow = new google.maps.InfoWindow();

    for (var i in mapItems) {
        console.log(mapItems[i].MapsContent);
        var markerPosition = { lat: mapItems[i].lat, lng: mapItems[i].lng };

        var marker = new google.maps.Marker({
            position: markerPosition,
            map: googleMap,
            infoContent: mapItems[i].mapsContent

        });

        google.maps.event.addListener(marker, 'click', (function (marker, infowindow) {
            return function () {
                infowindow.setContent(this.infoContent);
                infowindow.open(googleMap, this);
            };
        })(marker, infowindow));

        google.maps.event.addListener(googleMap, 'click', (function (infowindow) {
            return function () {
                infowindow.close();
            };
        })(infowindow));

        bounds.extend(markerPosition);
        googleMap.fitBounds(bounds);
        googleMap.panToBounds(bounds);

        bounds.extend(markerPosition);
    };

}

  


