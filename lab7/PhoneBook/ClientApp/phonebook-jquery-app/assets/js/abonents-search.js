function abonentsSearch(selector){
    var component = $(selector);
    
    searchBar = createSearchBar(component);
    var button = $('#search-button');
    var resultTable = createTable(component);
    button.click(function(event){
        $('#result-content').empty();
        event.preventDefault();
        doSearch($('#search-input').val(),$('#sort-order').val());
    });
}

function createSearchBar(component){
    component.append(
        `<form class="d-flex mt-3" id="search-bar">
            <input class="form-control me-2" id="search-input" type="search" placeholder="Search" aria-label="Search">
            <select id="sort-order">
                <option value="false">ascending</option>
                <option value="true">descending</option>
            </select>
            <button class="btn btn-outline-success" id="search-button" type="submit">Search</button>
        </form>`
    );
    searchBar = $('#search-bar');
    return searchBar;
}

function createTable(component){
    component.append(
        `<table class="table mt-3" id='result-table'>
            <thead>
              <tr> <th>ПІБ</th> <th>Номер телефону</th> <th>Адреса</th> </tr>
            </thead>
            <tbody id='result-content'></tbody>
         </table>`
    );
}

function doSearch(searchRequest, desc){
    $.ajax({
        type: 'GET',
        url: `https://localhost:5001/api/abonents/searchByName/${searchRequest}/${desc}`,
        dataType: 'json',
        success: function(responce){
            responce.forEach(abonent => {
                $('#result-content').append(
                    `<tr>
                        <td>${abonent.fullName}</td>
                        <td>${abonent.phoneNumbers.map(function(num){return `+${num.number}`})}</td>
                        <td>обл. ${abonent.city.region.name}, м.${abonent.city.name}, ${abonent.adress}</td>
                    </tr>`
                );
            });;
        }
    });
}



