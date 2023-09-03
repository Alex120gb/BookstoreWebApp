$(document).ready(function () {
    $('.alert-danger').hide();
    var authToken = sessionStorage.getItem('token');

    if (authToken == null || authToken == "") {
        window.location.href = "/Account/Index";
    }
    $('#addBook').submit(function (event) {
        $('#spinner').modal('show');
        var model = {
            title: $('#addTitle').val(),
            author: $('#addAuthor').val(),
            publicationYear: $('#addPublicationYear').val(),
            isbn: $('#addIsbn').val()
        };

        event.preventDefault();

        $.ajax({
            url: '/Home/AddBook',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(model),
            dataType: 'json',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', authToken);
            },
            success: function (response) {
                if (response.isSuccessful === true) {
                    $('#spinner').modal('hide');
                    alert(response.message);
                    window.location.href = "/Home/Index";
                }
                else {
                    $('#spinner').modal('hide');
                    $('.alert-danger').text(response.message);
                    $('.alert-danger').show();
                    alert(response.message);
                }

            },
            error: function () {
                $('#spinner').modal('hide');
                $('.alert-danger').text(response.message);
                $('.alert-danger').show();
                alert("Something went wrong!");
            }
        });
    });
});
