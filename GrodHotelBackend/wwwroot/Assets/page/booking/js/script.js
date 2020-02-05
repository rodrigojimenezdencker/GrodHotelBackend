setuppers['booking'] = function () {
    console.log("Booking");
    var widget = document.querySelector('[data-widget="booking_form"]');
    widget.addEventListener("submit", function(event) { event.preventDefault(); validateForm(widget); });
}