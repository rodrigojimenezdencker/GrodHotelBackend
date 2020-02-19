setuppers['index'] = function () {
    console.log('Index');
    var widget = document.querySelector('[data-widget="index_form"]');
    widget.addEventListener("submit", function (event) {
        event.preventDefault();
        if (validateEntryDate(widget.querySelector('[data-hook="entry_date"]').value)
            || validateLeavingDate(widget.querySelector('[data-hook="leaving_date"]').value)
            || validateNumberAdults(parseInt(widget.querySelector('[data-hook="numberAdults"]').value))
            || validateNumberMinors(parseInt(widget.querySelector('[data-hook="numberMinors"]').value))
            || validateCity(widget.querySelector('[data-hook="city"]').value)) {
            return;
        }
        widget.submit();
    });
}