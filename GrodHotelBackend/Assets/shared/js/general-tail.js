var route = function () {
    var routing = document.querySelector('[data-page]').getAttribute('data-page');

    if (typeof routing == 'string') {
        setuppers[routing]();
    }

}

route();

window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 100 || document.documentElement.scrollTop > 100) {
        backToTopButton.style.display = "block";
    } else {
        backToTopButton.style.display = "none";
    }
}

function backToTop() { window.scrollTo({ top: 0, behavior: 'smooth' }); }

var backToTopButton = document.querySelector('[data-widget="scroll_to_top"]');

backToTopButton.addEventListener("click", backToTop);

function validateForm(widget) {
    //ENTRY DATE
    if (widget.querySelector('[data-hook="entry_date"]') != null) {
        var entryDate = widget.querySelector('[data-hook="entry_date"]').value;
        var momentEntryDate = moment(entryDate, "YYYY-MM-DD");
        var momentToday = moment();
        if (momentEntryDate.isBefore(momentToday) || momentEntryDate.diff(momentToday, 'months') >= 6 || momentEntryDate.format() == 'Invalid date') {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect entry date!'
            });
            return;
        }
    }
    //ENTRY DATE

    //LEAVING DATE
    if (widget.querySelector('[data-hook="leaving_date"]') != null) {
        var leavingDate = widget.querySelector('[data-hook="leaving_date"]').value;
        var momentLeavingDate = moment(leavingDate, "YYYY-MM-DD");
        if (momentLeavingDate.isBefore(momentEntryDate) || momentLeavingDate.isSame(momentEntryDate) || momentLeavingDate.diff(momentEntryDate, 'days') == 1 || momentLeavingDate.diff(momentToday, 'months') >= 6 || momentLeavingDate.format() == 'Invalid date') {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect leaving date!'
            });
            return;
        }
    }
    //LEAVING DATE

    //NUMBER OF ADULTS
    if (widget.querySelector('[data-hook="numberAdults"]') != null) {
        var numberAdults = parseInt(widget.querySelector('[data-hook="numberAdults"]').value);
        if (typeof numberAdults != 'number' || numberAdults < 0 || numberAdults > 10 || isNaN(numberAdults)) {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect number of adults!'
            });
            return;
        }
    }
    //NUMBER OF ADULTS

    //NUMBER OF MINORS
    if (widget.querySelector('[data-hook="numberMinors"]') != null) {
        var numberMinors = parseInt(widget.querySelector('[data-hook="numberMinors"]').value);
        if (typeof numberMinors != 'number' || numberMinors < 0 || numberMinors > 10) {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect number of minors!'
            });
            return;
        }
    }
    //NUMBER OF MINORS

    //NAME
    if (widget.querySelector('[data-hook="name"]') != null) {
        var name = widget.querySelector('[data-hook="name"]').value;
        if (name.length == 0 || name.length > 30) {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect name!'
            });
            return;
        }
    }
    //NAME

    //SURNAME
    if (widget.querySelector('[data-hook="surname"]') != null) {
        var surname = widget.querySelector('[data-hook="surname"]').value;
        if (surname.length == 0 || surname.length > 50) {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect surname!'
            });
            return;
        }
    }
    //SURNAME

    //COMMENTS
    if (widget.querySelector('[data-hook="comments"]') != null) {
        var comments = widget.querySelector('[data-hook="comments"]').value;
        if (comments.length > 500) {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect comment!'
            });
            return;
        }
    }
    //COMMENTS

    //MESSAGE
    if (widget.querySelector('[data-hook="message"]') != null) {
        var message = widget.querySelector('[data-hook="message"]').value;
        if (message.length == 0 || message.length > 2000) {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect message!'
            });
            return;
        }
    }
    //MESSAGE

    //CITY
    if (widget.querySelector('[data-hook="city"]') != null) {
        var city = widget.querySelector('[data-hook="city"]').value;
        if (city.length == 0 || city.length > 20) {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect city!'
            });
            return;
        }
    }
    //CITY

    //DNI
    if (widget.querySelector('[data-hook="dni"]') != null) {
        var dni = widget.querySelector('[data-hook="dni"]').value;
        if (dni == "" || dni.length != 9 || validadorDni(dni)) {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect DNI!'
            });
            return;
        }
    }
    //DNI

    //EMAIL
    if (widget.querySelector('[data-hook="email"]') != null) {
        var email = widget.querySelector('[data-hook="email"]').value;
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (email == "" || !re.test(String(email).toLowerCase())) {
            Swal.fire({
                icon: 'error',
                title: "Something is not right...",
                text: 'Incorrect Email!'
            });
            return;
        }
    }
    //EMAIL
    widget.submit();
}

function validadorDni(dni) {
    var number;
    var char;
    var chars;
    var regex;

    regex = /^\d{8}[a-zA-Z]$/;

    if (regex.test(dni) == true) {
        number = dni.substr(0, dni.length - 1);
        char = dni.substr(dni.length - 1, 1);
        number = number % 23;
        chars = 'TRWAGMYFPDXBNJZSQVHLCKET';
        chars = chars.substring(number, number + 1);
        if (chars == char.toUpperCase()) {
            return false;
        }
    } else {
        return true;
    }
}

var cookies = document.querySelector('[data-widget="cookies_warning"]');
if (document.cookie == "") {
    var accept_cookie = cookies.querySelector('[data-hook="accept_cookie"]');
    var reject_cookie = cookies.querySelector('[data-hook="reject_cookie"]');
    accept_cookie.addEventListener("click", function () {
        document.cookie = 'name=USE_COOKIES;value=1;max-age=300';
        cookies.style.display = "none";
    });
    reject_cookie.addEventListener("click", function () {
        document.cookie = 'name=USE_COOKIES;value=0;max-age=300';
        cookies.style.display = "none";
    })
} else {
    cookies.style.display = "none";
}
}
window.addEventListener('DOMContentLoaded', window_onDomContentLoaded);