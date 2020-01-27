function ChangeColor(tableRow, highLight) {
    if (highLight) {
        tableRow.style.backgroundColor = '#E0FFFF';
    }
    else {
        tableRow.style.backgroundColor = 'white';
    }
}

function DoNav(pathname) {
    var origin = window.location.origin;
    var theUrl = origin + pathname;
    document.location.href = theUrl;
}