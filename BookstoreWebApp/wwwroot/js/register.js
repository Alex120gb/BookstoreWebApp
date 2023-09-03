$(document).ready(function () {
    $('.alert-danger').hide();

    $('#register-form').submit(function (event) {
        $('#spinner').modal('show');
        var viewModel = {
            Username: $('#username-reg').val(),
            Email: $('#email-reg').val(),
            Password: $('#password-reg').val()
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
                    $('#spinner').modal('hide');
                    window.location.href = "/Account/Index";
                }
                else {
                    $('#spinner').modal('hide');
                    $('.alert-danger').text(data.message);
                    $('.alert-danger').show();
                }

            },
            error: function () {
                $('#spinner').modal('hide');
                $('.alert-danger').text('An error occurred while processing the data.');
                $('.alert-danger').show();
            }
        });
    });
});