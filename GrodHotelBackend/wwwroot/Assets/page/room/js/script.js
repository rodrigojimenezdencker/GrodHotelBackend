setuppers['room'] = function () {
    console.log('Room');

    var widget = document.querySelector('[data-widget="room_form"]');
    if (widget != null) {
        widget.addEventListener("submit", function (event) {
            event.preventDefault();
            if (validateEntryDate(widget.querySelector('[data-hook="entry_date"]').value)
                || validateLeavingDate(widget.querySelector('[data-hook="leaving_date"]').value)
                || validateNumberAdults(parseInt(widget.querySelector('[data-hook="numberAdults"]').value))
                || validateNumberMinors(parseInt(widget.querySelector('[data-hook="numberMinors"]').value))) {
                return;
            }
            widget.submit();
        });
    }
}