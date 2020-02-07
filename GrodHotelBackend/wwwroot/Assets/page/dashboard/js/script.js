$(document).ready(function () {
    $('[data-widget="new_client_form"], [data-widget="edit_client_form"]').submit(function (event) {
        event.preventDefault();
        if (validateUsername($('[data-hook="username"]').val())) {
            return;
        }
        if (validateSurname($('[data-hook="surname"]').val())) {
            return;
        }
        if (validateBirthdate($('[data-hook="birthdate"]').val())) {
            return;
        }
        if (validateDNI($('[data-hook="dni"]').val())) {
            return;
        }
        if (validateEmail($('[data-hook="email"]').val())) {
            return;
        }
        if (validateComments($('[data-hook="comments"]').val())) {
            return;
        }
        event.submit();
    });

    function validateUsername(username) {
        if (username == '') {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect name!',
                text: 'Name is empty!'
            });
            return true;
        }

        if (username.length > 20) {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect name!',
                text: 'The name has the capacity for 20 characters or less!'
            });
            return true;
        }
        return false;
    }

    function validateSurname(surname) {
        if (surname == '') {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect surname!',
                text: 'Surame is empty!'
            });
            return true;
        }
        if (surname.length > 40) {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect surname!',
                text: 'The surname has the capacity for 40 characters or less!'
            });
            return true;
        }
        return false;
    }

    function validateBirthdate(birthdate) {
        if (birthdate == '') {
            Swal.fire({
                icon: 'error',
                title: 'Incorrect birthdate!',
                text: 'Birthdate is empty!'
            });
            return true;
        }

        let momentBirthdate = moment(birthdate, "YYYY-MM-DD");
        
        if (momentBirthdate.isAfter(moment().format("YYYY-MM-DD"))) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect birthdate!",
                text: 'The birthdate is after today!'
            });
            return true;
        }

        if (!momentBirthdate.isBefore(moment().subtract(18, 'years').format("YYYY-MM-DD"))) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect birthdate!",
                text: 'The user has to be 18+ years old!'
            });
            return true;
        }

        if (momentBirthdate.format() == 'Invalid date') {
            Swal.fire({
                icon: 'error',
                title: "Incorrect birthdate!",
                text: 'The birthdate is not valid!'
            });
            return true;
        }
        return false;
    }

    function validateDNI(dni) {
        let number;
        let char;
        let chars = 'TRWAGMYFPDXBNJZSQVHLCKET';
        let regex = /^\d{8}[a-zA-Z]$/;
        
        if (dni == '') {
            Swal.fire({
                icon: 'error',
                title: "Incorrect DNI!",
                text: 'DNI is empty!'
            });
            return true;
        }

        if (dni.length != 9) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect DNI!",
                text: 'The DNI has to be 9 characters long!'
            });
            return true;
        }

        if (regex.test(dni) == false) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect DNI!",
                text: 'Invalid DNI!'
            });
            return true;
        }

        number = dni.substr(0, dni.length - 1);
        char = dni.substr(dni.length - 1, 1);
        number = number % 23;
        chars = chars.substring(number, number + 1);
        if (chars != char.toUpperCase()) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect DNI!",
                text: 'The letter is wrong!'
            });
            return true;
        }
        return false;
    }

    function validateEmail(email) {
        let re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (email == '') {
            Swal.fire({
                icon: 'error',
                title: "Incorrect Email!",
                text: 'Email is empty!'
            });
            return true;
        }
        if(!re.test(String(email).toLowerCase())) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect Email!",
                text: 'The Email is not valid!'
            });
            return true;
        }
        return false;
    }

    function validateComments(comments) {
        if (comments.length > 200) {
            Swal.fire({
                icon: 'error',
                title: "Incorrect Email!",
                text: 'The comment has the capacity for 200 characters or less!'
            });
            return true;
        }
        return false;
    }
});