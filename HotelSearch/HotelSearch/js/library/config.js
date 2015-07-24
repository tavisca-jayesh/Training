window.hotel = window.hotel || {};
window.hotel.model = window.hotel.model || {};
window.hotel.model.config = window.hotel.model.config || {};

hotel.model.hotelCollection = function () {

    url = 'http://capi.tavisca.com/api/tcs/Hotels';
    return {
        url: url
    };
}