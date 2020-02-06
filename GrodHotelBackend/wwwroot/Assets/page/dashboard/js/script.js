$(document).ready(function () {
    $('[data-widget="new_client_form"]').submit(function (event) {
        event.preventDefault();
        validateUsername($('[data-hook="username"]').val());
        validateSurname($('[data-hook="surname"]').val());
        validateBirthdate($('[data-hook="birthdate"]').val());
        validateDNI($('[data-hook="dni"]').val());
        validateEmail($('[data-hook="email"]').val());
        validateComments($('[data-hook="comments"]').val());
    });

    function validateUsername(username) {
        if (username.length == 0) {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect name!',
                text: 'Name is empty!'
            });
            return;
        }
        if (username.length > 20) {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect name!',
                text: 'The name has to be 20 characters or less!'
            });
            return;
        }
    }

    function validateSurname(surname) {
        if (surname.length == 0) {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect surname!',
                text: 'Surame is empty!'
            });
            return;
        }
        if (surname.length > 40) {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect surname!',
                text: 'The surname has to be 40 characters or less!'
            });
            return;
        }
    }

    function validateBirthdate(birthdate) {
        if (birthdate == '') {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect birthdate!',
                text: 'Birthdate is empty!'
            });
            return;
        }

        let momentBirthdate = moment(birthdate, "YYYY-MM-DD");
        
        if (momentBirthdate.isAfter(moment().format("YYYY-MM-DD"))) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect birthdate!",
                text: 'The birthdate is after today!'
            });
            return;
        }

        if (!momentBirthdate.isBefore(moment().subtract(18, 'years').format("YYYY-MM-DD"))) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect birthdate!",
                text: 'The user has to be 18+ years old!'
            });
            return;
        }

        if (momentBirthdate.format() == 'Invalid date') {
            Swal.fire({
                icon: 'error',
                title: "Incorrect birthdate!",
                text: 'The birthdate is not valid!'
            });
            return;
        }
    }

    function validateDNI(dni) {
        let number;
        let char;
        let chars;
        let regex;
        regex = /^\d{8}[a-zA-Z]$/;
        
        if (dni == "") {
            Swal.fire({
                icon: 'error',
                title: "Incorrect DNI!",
                text: 'DNI is empty!'
            });
            return;
        }

        if (dni.length != 9) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect DNI!",
                text: 'The DNI has to be 9 characters long!'
            });
            return;
        }

        if (regex.test(dni) == false) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect DNI!",
                text: 'Invalid DNI!'
            });
            return;
        }

        number = dni.substr(0, dni.length - 1);
        char = dni.substr(dni.length - 1, 1);
        number = number % 23;
        chars = 'TRWAGMYFPDXBNJZSQVHLCKET';
        chars = chars.substring(number, number + 1);
        if (chars != char.toUpperCase()) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect DNI!",
                text: 'The letter is wrong!'
            });
            return;
        }
    }
});