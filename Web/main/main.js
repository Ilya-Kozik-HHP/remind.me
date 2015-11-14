require(['googleAPI', 'locationDataModel'], function (googleAPI, locationDataModel) {
    (function () {
        var locationDatas = [];
        var mapCenter = { lat: 0, lng: 0 };
        var locationCount = 0;
        var markers = [];
        var map;
        var bounds = new google.maps.LatLngBounds();

        locationDataModel.getDataByLocation().forEach(function (item) {
            marker = new google.maps.Marker({
                position: { lat: item.location.latitude, lng: item.location.longitude },
                title: item.name
            });

            markers.push(marker);

            bounds.extend(marker.getPosition());

            mapCenter.lat += item.location.latitude;
            mapCenter.lng += item.location.longitude;
            ++locationCount;
        });
        debugger;
        mapCenter.lat /= locationCount;
        mapCenter.lng /= locationCount;

        map = new google.maps.Map(document.getElementById('map'), {
            zoom: 13,
            center: mapCenter
        });

        map.fitBounds(bounds);

        markers.forEach(function (marker) {
            marker.setMap(map);
        });
    })();
});