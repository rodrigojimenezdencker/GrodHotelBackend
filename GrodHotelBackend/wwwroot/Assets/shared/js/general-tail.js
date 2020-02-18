var route = function () {
    var routing = document.querySelector('[data-page]').getAttribute('data-page');

    if (typeof routing == 'string') {
        setuppers[routing]();
    }

}

route();

window.onscroll = scrollFunction();

function scrollFunction() {
    if (document.body.scrollTop > 100 || document.documentElement.scrollTop > 100) {
        backToTopButton.style.display = "block";
    } else {
        backToTopButton.style.display = "none";
    }
}

function backToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
}

var backToTopButton = document.querySelector('[data-widget="scroll_to_top"]');

backToTopButton.addEventListener("click", backToTop);

function validateEntryDate(entryDate) {
    var momentEntryDate = moment(entryDate, "YYYY-MM-DD");
    var momentToday = moment();
    if (momentEntryDate.isBefore(momentToday) || momentEntryDate.diff(momentToday, 'months') >= 6 || momentEntryDate.format() == 'Invalid date') {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect entry date!'
        });
        return true;
    }
    return false
}

function validateLeavingDate(leavingDate) {
    var momentLeavingDate = moment(leavingDate, "YYYY-MM-DD");
    if (momentLeavingDate.isBefore(momentEntryDate)
        || momentLeavingDate.isSame(momentEntryDate)
        || momentLeavingDate.diff(momentEntryDate, 'days') == 1
        || momentLeavingDate.diff(momentToday, 'months') >= 6
        || momentLeavingDate.format() == 'Invalid date') {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect leaving date!'
        });
        return true;
    }
    return false;
}

function validateNumberAdults(numberAdults) {
    if (typeof numberAdults != 'number' || numberAdults < 0 || numberAdults > 10 || isNaN(numberAdults)) {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect number of adults!'
        });
        return true;
    }
    return false;
}

function validateNumberMinors(numberMinors) {
    if (typeof numberMinors != 'number' || numberMinors < 0 || numberMinors > 10) {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect number of minors!'
        });
        return true;
    }
    return false;
}
function validateName(name) {
    if (name.length == 0 || name.length > 30) {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect name!'
        });
        return true;
    }
    return false;
}

function validateSurname(surname) {
    if (surname.length == 0 || surname.length > 50) {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect surname!'
        });
        return true;
    }
    return false;
}

function validateComments(comments) {
    if (comments.length > 500) {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect comment!'
        });
        return true;
    }
    return false;
}

function validateMessage(message) {
    if (message.length == 0 || message.length > 2000) {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect message!'
        });
        return true;
    }
    return false;
}

function validateCity(city) {
    if (city.length == 0 || city.length > 20) {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect city!'
        });
        return true;
    }
    return false;
}

function validateDni(dni) {
    var number;
    var char;
    var chars;
    var regex;
    var resul;

    regex = /^\d{8}[a-zA-Z]$/;

    if (regex.test(dni) == true) {
        number = dni.substr(0, dni.length - 1);
        char = dni.substr(dni.length - 1, 1);
        number = number % 23;
        chars = 'TRWAGMYFPDXBNJZSQVHLCKET';
        chars = chars.substring(number, number + 1);
        if (chars == char.toUpperCase()) {
            resul = false;
        }
    } else {
        resul = true;
    }

    if (dni == "" || dni.length != 9 || resul) {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect DNI!'
        });
        return true;
    }
    return false;
}

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (email == "" || !re.test(String(email).toLowerCase())) {
        Swal.fire({
            icon: 'error',
            title: "Something is not right...",
            text: 'Incorrect Email!'
        });
        return true;
    }
    return false;
}

var widget = document.querySelector('[data-widget="newsletter-form"]');
widget.addEventListener("submit", function (event) {
    event.preventDefault();
    if (validateEmail(widget.querySelector('[data-hook="email"]').value)) {
        return;
    }
    widget.submit();
});

var cookies = document.querySelector('[data-widget="cookies_warning"]');
if (document.cookie == "") {
    var accept_cookie = cookies.querySelector('[data-hook="accept_cookie"]');
    var reject_cookie = cookies.querySelector('[data-hook="reject_cookie"]');
    accept_cookie.addEventListener("click", function () {
        document.cookie = 'USE_COOKIES=1;max-age=31536000';
        cookies.style.display = "none";
    });
    reject_cookie.addEventListener("click", function () {
        document.cookie = 'USE_COOKIES=0;max-age=31536000';
        cookies.style.display = "none";
    })
} else {
    cookies.style.display = "none";
}
}
window.addEventListener('DOMContentLoaded', window_onDomContentLoaded);