define([], function () {
    var datas = [
            {
                id: 1,
                name: "Pin Code USD",
                text: "3436"
            },
            {
                id: 2,
                name: "Pin Code BLR",
                text: "2397"
            },
            {
                id: 3,
                name: "Domofon",
                text: "k52k3408"
            }
    ];

    function getDatas() {
        return datas;
    }

    function udateData(data) {
        datas.push(data)
    }

    return {
        getDatas: getDatas,
        updateData: updateData
    }
});