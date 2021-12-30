function renderRegionSelect(selector){
    var select = $(selector);
    showList(select, 'https://localhost:5001/api/geo/regions');
}

function renderCitySelect(selector, region){
    if(region != undefined || region != ''){
        var select = $(selector);
        select.empty();
        showList(select, `https://localhost:5001/api/geo/cities/${region}`);
    }
}

function showList(select, apiUrl){
    $.ajax({
        url: apiUrl,
        type: 'GET',
        dataType: 'json',
        success: function(responce){
            responce.forEach(item => {
                select.append(`<option idAttr="${item.id === undefined? item.index: item.id}">
                                ${item.name}
                              </option>`);
            });
        }
    });
}
