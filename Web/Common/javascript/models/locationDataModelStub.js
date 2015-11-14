define([], function () {
    var locationDatas =
        [
            {
                location:
                    {
                        id: 1,
                        name: "Home",
                        latitude: 53.8233382,
                        longitude: 27.7677942,
                        radius: 50
                    },
                dataIds:
                    [
                        1, 2, 3
                    ]
            },
            {
                location:
                    {
                        id: 1,
                        name: "Work",
                        latitude: 53.9262755,
                        longitude: 27.4386214,
                        radius: 50
                    },
                dataIds:
                    [
                        1, 2
                    ]
            },
        ];

    function getDataByLocation(latitude, longitude) {
        return locationDatas;
    }

    function updateLocations(location, dataIds) {
        locationDatas.push(
            {
                location: location,
                dataIds: dataIds
            }
        );
    }

    return {
        getDataByLocation: getDataByLocation,
        updateLocations: updateLocations
    }
});