$(document).ready(function () {
    $('.alert-danger').hide();

    sessionStorage.removeItem('token');
    $('#login-form').submit(function (event) {
        $('#spinner').modal('show');
        var viewModel = {
            Username: $('#username').val(),
            Password: $('#password').val()
        };

        event.preventDefault();

        $.ajax({
            url: '/Account/Login',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(viewModel),
            dataType: 'json',
            success: function (data) {
                if (data.isSuccessful === true) {
                    sessionStorage.setItem('token', data.value);
                    window.location.href = "/Home/Index";
                    $('#spinner').modal('hide');
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