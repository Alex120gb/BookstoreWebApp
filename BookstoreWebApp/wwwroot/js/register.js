$(document).ready(function () {
    $('#register-form').submit(function (event) {

        var viewModel = {
            Username: $('#username').val(),
            Email: $('#email').val(),
            Password: $('#password').val()
        };

        event.preventDefault();

        $.ajax({
            url: '/Account/Register',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(viewModel),
            dataType: 'json',
            success: function (data) {
                if (data.isSuccessful === true) {
                    window.location.href = "/Account/Index";
                }
                else {
                    $('.error-message').text(data.message);
                    $('.error-message').show();
                }

            },
            error: function () {
                $('.error-message').text('An error occurred while processing the data.');
                $('.error-message').show();
            }
        });
    });
});