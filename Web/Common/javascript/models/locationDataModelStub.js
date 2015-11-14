define([], function () {
    var locationDatas =
        [
            {
                location:
                    {
                        id: 1,
                        name: "Home",
                        latitude: 100,
                        longitude: 100,
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
                        latitude: 120,
                        longitude: 120,
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