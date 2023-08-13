var dataTable;
$(document).ready(function () {
    var authToken = sessionStorage.getItem('token');
    if (authToken == null || authToken == "") {
        window.location.href = "/Account/Index";
    }
    
    $('#spinner').modal('show');
    $.ajax({
        url: '/Home/GetBooks',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', authToken);
            },
        success: function (dataModel) {
            if (dataModel != null) {
                dataTable = $('#bookTable').DataTable({
                    data: dataModel, 
                    columns: [
                        { data: 'title' }, 
                        { data: 'author' },
                        { data: 'publicationYear' },
                        { data: 'isbn' },
                        {
                            data: null,
                            render: function (data, type, row) {
                                return '<button class="btn btn-primary edit-button">Edit</button>' +
                                    '<button class="btn btn-danger delete-button">Delete</button>';

                            }
                        }
                    ]
                });
                $('#spinner').modal('hide');
            }
        },
        error: function () {
            console.error('Error occurred during the AJAX request.');
            $('#spinner').modal('hide');
        }
    });
});

//Edit
$('#bookTable').on('click', '.edit-button', function () {
    var data = dataTable.row($(this).closest('tr')).data();

    $('#idEdit').val(data.id); 
    $('#titleEdit').val(data.title); 
    $('#authorEdit').val(data.author); 
    $('#publicationYearEdit').val(data.publicationYear); 
    $('#isbnEdit').val(data.isbn); 

    $('#editModal').show();
});

$('#saveEditButton').click(function () {
    $('#spinner').modal('show');
    var authToken = sessionStorage.getItem('token');

    var model = {
        id: $('#idEdit').val(),
        title: $('#titleEdit').val(),
        author: $('#authorEdit').val(),
        publicationYear: $('#publicationYearEdit').val(),
        isbn: $('#isbnEdit').val()
    };

    $.ajax({
        url: '/Home/UpdateBook', 
        type: 'POST',
        data: JSON.stringify(model),
        contentType: 'application/json',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', authToken);
        },
        success: function (response) {
            if (response.isSuccessful) {
                $('#editModal').hide();
                $('#spinner').modal('hide');
                location.reload();
                alert(response.message);
            }
            else {
                $('#editModal').hide();
                $('#spinner').modal('hide');
                alert(response.message);
            }
        },
        error: function () {
            $('#spinner').modal('hide');
            alert("System was unable to complete the request");
        }
    });
});

$('.btn-edit-modal-close').click(function () {
    $('#editModal').hide();
});

//Delete
$('#bookTable').on('click', '.delete-button', function () {
    var data = dataTable.row($(this).closest('tr')).data();

    $('#idDelete').val(data.id);
    $('#titleDelete').text(data.title);
    $('#authorDelete').text(data.author);
    $('#publicationYearDelete').text(data.publicationYear);
    $('#isbnDelete').text(data.isbn); 

    $('#deleteModal').show();
});

$('#confirmDelete').click(function () {
    $('#spinner').modal('show');
    var authToken = sessionStorage.getItem('token');

    var id = $('#idDelete').val();

    $.ajax({
        url: '/Home/DeleteBook',
        type: 'POST',
        data: JSON.stringify(id),
        contentType: 'application/json',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', authToken);
        },
        success: function (response) {
            if (response.isSuccessful) {
                $('#deleteModal').hide();
                $('#spinner').modal('hide');
                alert(response.message);
                location.reload();
            }
            else {
                $('#deleteModal').hide();
                $('#spinner').modal('hide');
                alert(response.message);
            }
        },
        error: function () {
            $('#spinner').modal('hide');
            alert("System was unable to complete the request");
        }
    });
});

$('.delete-modal-close').click(function () {
    $('#deleteModal').hide();
});