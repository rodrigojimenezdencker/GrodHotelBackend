setuppers['booking'] = function () {
    console.log("Booking");
    var widget = document.querySelector('[data-widget="booking_form"]');
    widget.addEventListener("submit", function (event) {
        event.preventDefault();
        if (validateEntryDate(widget.querySelector('[data-hook="entry_date"]').value)
            || validateLeavingDate(widget.querySelector('[data-hook="entry_date"]').value, widget.querySelector('[data-hook="leaving_date"]').value)
            || validateNumberAdults(parseInt(widget.querySelector('[data-hook="numberAdults"]').value))
            || validateNumberMinors(parseInt(widget.querySelector('[data-hook="numberMinors"]').value))
            || validateName(widget.querySelector('[data-hook="name"]').value)
            || validateSurname(widget.querySelector('[data-hook="surname"]').value)
            || validateDni(widget.querySelector('[data-hook="dni"]').value)
            || validateEmail(widget.querySelector('[data-hook="email"]').value)
            || validateComments(widget.querySelector('[data-hook="comments"]').value)) {
            return;
        }
        widget.submit();
    });
}