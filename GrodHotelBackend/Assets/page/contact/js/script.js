setuppers['contact'] = function () {
    console.log("Contact");
    var widget = document.querySelector('[data-widget="contact_form"]');
    widget.addEventListener("submit", function(event) { event.preventDefault(); validateForm(widget); });
}