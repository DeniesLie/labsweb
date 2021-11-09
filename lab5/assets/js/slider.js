$(function(){
    $("#slider").slider({
        max: 100,
        value: 0
    });
    
    $("#show-slider-value").click(function(){
        var value = $("#slider").slider("option", "value");
        $("#slider-value").text(value);
    });
});