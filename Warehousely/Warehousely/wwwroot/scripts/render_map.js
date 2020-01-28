function initMap() {
    var usaCoords = { lat: 37.0902, lng: -95.7129 };
    var bounds = new google.maps.LatLngBounds();
    var googleMap = new google.maps.Map(
        document.getElementById('map'), { zoom: 6, center: usaCoords, styles: hideStyle });

    var mapItems = modelData;

    for (var i in mapItems) {
        var markerPosition = { lat: mapItems[i].lat, lng: mapItems[i].lng };
        var marker = new google.maps.Marker({
            position: markerPosition,
            map: googleMap
        });

        var location = new google.maps.LatLng(markerPosition.lat, markerPosition.lng);
        bounds.extend(location);
    };

    googleMap.fitBounds(bounds);
    googleMap.panToBounds(bounds);

    var hideStyle =
        [
            {
                "featureType": "poi",
                "elementType": "labels.icon",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "transit",
                "elementType": "labels.icon",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            }
        ];



}