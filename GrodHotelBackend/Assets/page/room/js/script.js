setuppers['room'] = function () {
    console.log('Room');
    var widget = document.querySelector('[data-widget="room_form"]');
    widget.addEventListener("submit", function(event) { event.preventDefault(); validateForm(widget); });
}