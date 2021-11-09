$(function(){
    if(navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showWeatherData);
    }

    function showWeatherData(geolocation)
    {
        var lat = geolocation.coords.latitude;
        var long = geolocation.coords.longitude;
        
        var country = $("#weather-widget-country");
        var city= $("#weather-widget-city");
        var weatherType = $("#weathertype");
        var temp = $("#temperature");
        
        var apiKey = "fc7603a9a70fdc7da1969b96a402da92";

        $.getJSON("http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + long + "&appid=" + apiKey, 
            function(data){
                country.text(data["sys"]["country"]);
                city.text(data["name"]);
                weatherType.text(data["weather"][0]["main"]);
                temp.text((data["main"]["temp"] - 273.15).toFixed(2));
        });
    }
});