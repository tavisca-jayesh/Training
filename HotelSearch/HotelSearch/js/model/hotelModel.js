window.hotel = window.hotel || {};
window.hotel.model = window.hotel.model || {};
window.hotel.model.hotelModel = window.hotel.model.hotelModel || {};

hotel.model.hotelModel = function (hotel) {
    if (hotel == null)
        throw new Error('Invalid Arguments');
    var hotelObj = hotel;
    var hotelData = {
        "Address": {
            "AddressLine1": '',
            "AddressLine2": '',
            "City": '',
            "Country": '',
            "Zip": ''
        },
        "geoCode": {
            "Latitude": 0.0,
            "Longitude": 0.0
        },
        "HotelId": 0,
        "Image": '',
        "Name": '',
        "Rating": 0
    };

    return
    (function () {

        hotelData.Address = hotelList.Address;
        hotelData.HotelId = hotelList.HotelId;
        hotelData.Image = hotelList.Image;
        hotelData.Name = hotelList.Name;
        hotelData.Rating = hotelList.Rating;
        geoCode.Latitude = hotelList.GeoCode.Latitude;
        geoCode.Longitude = hotelList.GeoCode.Longitude;
        return hotelData;
    }());
};