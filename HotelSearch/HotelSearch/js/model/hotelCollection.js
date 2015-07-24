window.hotel = window.hotel || {};
window.hotel.model = window.hotel.model || {};
window.hotel.model.hotelCollection = window.hotel.model.hotelCollection || {};

hotel.model.hotelCollection = function () {
    var _hotel = [];

    function fetchAllHotels(cityName) {
        params = params || {};
        params.city = cityName;
        params.pageSize = params.pageSize || 10;
        params.pageNum = params.pageNum || 0;


        if (!params.city || $.trim(params.city) === '')
            throw Error('City Name is required');
        _hotels = [];
        var url = hotel.config.url + '?type=City&q=' + params.city + '&top=' + params.pageSize + '&skip=' + (params.pageNum * params.pageSize);
        $.getJSON(url, function (response) {
            if (!response || !response.Hotels)
                throw new Error('Could not fetch hotel information!!!');

            //pagination Object
            pagination = pagination || {};
            pagination.pageSize = pagination.pageSize || 10;
            pagination.pageNum = pagination.pageNum || 0;
            pagination.numberOfHotel = response.Hotels.length

            for (var index = 0; index < response.Hotels.length; index++) {
                _hotels.push(new hotel.model.hotelModel(response.Hotels[index]));
            }
            EventManager.fire('Hotels.fetched', this, _hotels,pagination);

        }).fail(function (error) {
            throw new Error('Could not handle the request!!!');
        });
    };
    return {
        fetch: fetchAllHotels,
        hotels: _hotels,
        paginationObj: pagination
    };
}