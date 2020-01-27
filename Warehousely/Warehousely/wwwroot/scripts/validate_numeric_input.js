function validateNumericInput() {
    var charCode = (event.which) ? event.which : event.keyCode;
    if (charCode >= 48 && charCode <= 57) { return true; }
    else { return false; }
}