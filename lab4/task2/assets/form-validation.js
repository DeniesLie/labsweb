function try_validate(form)
{
    fields = form.elements;
    let isValidated = { status: true};

    for (const field of fields){
        if(!field.className.includes("required") && field.value === "")
            continue;
        else
            validate_field(field, isValidated);
    }
    return isValidated.status;
}

function validate_field(field, isValidated)
{
    field_class = field.className;

    if(field.type === "submit" || field.type === "reset")
        return;

    if(field_class.includes("required"))
        required_check(field, isValidated);

    if(field.id === "pswrd")
        validate_password(field, isValidated);

    if(field_class.includes("float-type"))
        validate_float(field, isValidated);

    if(field_class.includes("int-type"))
        validate_int(field, isValidated);

    if(field_class.includes("date-type"))
        validate_date(field, isValidated)
}

function validate_int(input, isValidated)
{
    if(!isInt(input.value)){
        isValidated.status = false;
        validation_warning(input, "Field must contain whole number!");
    }
}

function validate_float(input, isValidated)
{
    parse_float = parseFloat(input.value);
    if(isNaN(parse_float)){
        isValidated.status = false;
        validation_warning(input, "Field must contain a number!");
    }
}

function validate_date(input, isValidated)
{
    value =input.value;
    if(value.length !== 10 || (val[2] !== "." || val[5] !== ".") || !(isInt(value.slice(0,2)) && isInt(value.slice(3, 5)) && isInt(value.slice(5)))){
        isValidated.status = false;
        validation_warning(input, "Field must contain date in format 'DD.MM.YYYY'");
    }
}

function validate_password(pswrd, isValidated)
{
    confirm_pswrd = document.getElementById("confirm-pswrd");
    if(pswrd.value != confirm_pswrd.value){
        isValidated.status = false;
        validation_warning(confirm_pswrd, "Passwords are different!");
    }
}

function required_check(field, isValidated)
{
    if(field.value === ""){
        isValidated.status = false;
        validation_warning(field, "This field is required!");
    }
}

function validation_warning(field, message)
{
    waning_box = document.getElementById(`${field.id}-warning`);
    waning_box.innerHTML = message;
}

function isInt(str)
{
    parse_float = parseFloat(str);
    if(isNaN(parse_float) || !Number.isInteger(parse_float))
        return false;
    else
        return true;
}