function initMap() {
    var usaCoords = { lat: 37.0902, lng: -95.7129 };

    var googleMap = new google.maps.Map(
        document.getElementById('map'), { zoom: 6, center: usaCoords });

    var mapItems = modelData;

    for (var i in mapItems) {
        var markerPosition = { lat: mapItems[i].lat, lng: mapItems[i].lng };
        var marker = new google.maps.Marker({
            position: markerPosition,
            map: googleMap
        });
    };

}