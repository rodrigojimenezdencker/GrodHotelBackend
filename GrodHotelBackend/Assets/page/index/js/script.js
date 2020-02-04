setuppers['index'] = function () {
    console.log('Index');
    var widget = document.querySelector('[data-widget="index_form"]');
    widget.addEventListener("submit", function(event) { event.preventDefault(); validateForm(widget); });
}