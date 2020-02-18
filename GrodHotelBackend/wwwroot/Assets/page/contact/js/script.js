setuppers['contact'] = function () {
    console.log("Contact");
    var widget = document.querySelector('[data-widget="contact_form"]');
    widget.addEventListener("submit", function (event) {
        event.preventDefault();
        if (validateName(widget.querySelector('[data-hook="name"]').value)
            || validateSurname(widget.querySelector('[data-hook="surname"]').value)
            || validateEmail(widget.querySelector('[data-hook="email"]').value)
            || validateMessage(widget.querySelector('[data-hook="message"]').value)) {
            return;
        }
        widget.submit();
    });
}