function prompt_arr() {
    let arr_size = NaN;
    while (isNaN(arr_size) || arr_size <= 0)
        arr_size = +prompt("Введіть розмір масиву (ціле число > 0)");

    let arr = [];

    for (let i = 0; i < arr_size; i++) {
        let input = +prompt('Введіть число під індексом ' + i); 
        if (isNaN(input))
            arr.push(0);
        else
            arr.push(input);
    }

    return arr;
}

function get_max_even(array) {
    let max_even = undefined; 

    for (let i = 0; i < array.length; i++){
        if (max_even === undefined && array[i] % 2 === 0) // using this condition we find
            max_even = array[i]                           // first even number in array

        if (array[i] > max_even && max_even != undefined)
            max_even = array[i];
    }
    return max_even;
}

function get_min_with_even_index(array) {
    let min = array[0]
    for (let i = 2; i < array.length; i+=2){
        if (array[i] < min)
            min = array[i];
    }
    return min;
}

function get_index_by_value(array, value) {
    for (let i = 0; i < array.length; i++){
        if (array[i] === value)
            return i;
    }
    return undefined;
}

function swap_min_max(array) {
    let min = get_min_with_even_index(array);
    let max = get_max_even(array);

    let tmp = min;
    let max_ind = array.indexOf(max);
    let min_ind = array.indexOf(min);
    array[min_ind] = max;
    array[max_ind] = tmp;
}

function insertion_sort(array) {
    let key, j;

    for (let i = 1; i < array.length; i++){
        key = array[i];
        j = i - 1;
        while (j >= 0 && array[j] > key){
            array[j+1] = array[j];
            j -= 1;
        }
        array[j+1] = key;
    }
}

let arr = prompt_arr();
alert(`Your array: ${arr}`);
swap_min_max(arr);
alert(`After swap: ${arr}`);
insertion_sort(arr);
alert(`After sort: ${arr}`);